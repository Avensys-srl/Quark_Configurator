Public Class CustomerData
    ' --- Proprietà Esistenti ---
    Public Property FSC_CAF_Speed1 As Integer
    Public Property FSC_CAF_Speed2 As Integer
    Public Property FSC_CAF_Speed3 As Integer
    Public Property F_Speed1 As Integer
    Public Property F_Speed2 As Integer
    Public Property F_Speed3 As Integer

    Public Property FK_Speed As Integer

    Public Property R_Speed1 As Integer
    Public Property R_Speed2 As Integer
    Public Property R_Speed3 As Integer

    Public Property RK_Speed As Integer

    Public Property CAP_Speed1 As Integer
    Public Property CAP_Speed2 As Integer
    Public Property CAP_Speed3 As Integer
    Public Property BoostTimer As Integer
    Public Property FilterTimer As Integer
    Public Property FireKitTimer As Integer
    Public Property CO2SetPoint As Integer
    Public Property RHSetPoint As Integer
    Public Property VOCSetPoint As Integer
    Public Property TempSetPoint As Integer
    Public Property SUM_WINSetPoint As Integer
    Public Property Configuration As String
    Public Property VersionHW As String
    Public Property VersionSW As String
    Public Property Accessories As String
    Public Property SerialNumber As String
    Public Property KHK_ENABLE As Boolean
    Public Property KHK_NC As Boolean
    Public Property KHK_NO As Boolean
    Public Property KHK_VALUE As Byte
    Public Property SMOKE_VALUE As Byte
    Public Property IMBALANCESetPoint1 As SByte
    Public Property IMBALANCE_ENABLE As Byte
    Public Property KHK_SET_POINT As Byte
    Public Property KHKIMBALANCESetPoint As SByte
    Public Property IMBALANCESetPoint2 As SByte
    Public Property IMBALANCESetPoint3 As SByte
    Public Property IAQ_Reference As Integer
    Public Property IAQ_Imbalance As SByte
    Public Property IAQ_F_Speed As Integer
    Public Property IAQ_R_Speed As Integer

    ' --- Costanti per identificare i set di velocità ---
    Public Const SpeedSetting1 As Integer = 1
    Public Const SpeedSetting2 As Integer = 2
    Public Const SpeedSetting3 As Integer = 3
    Public Const SpeedSettingKHK As Integer = 0 ' Usa 0 per identificare KHK
    Public Const SpeedSettingIAQ As Integer = 4

    ' --- Logica di Calcolo Inversa (Privata, per UpdateSpeedSettings) ---
    Private Shared Function CalculateInverseSpeedLogic(ByVal speedF_percent As Integer, ByVal speedR_percent As Integer) As (Reference As Double, Imbalance As Double)
        If speedF_percent < 25 OrElse speedF_percent > 100 OrElse
           speedR_percent < 25 OrElse speedR_percent > 100 Then
            Return (Reference:=0.0, Imbalance:=0.0)
        End If
        Dim refPercent As Double
        Dim imbalancePercent As Double
        If speedF_percent = speedR_percent Then
            refPercent = CDbl(speedF_percent)
            imbalancePercent = 0.0
        ElseIf speedF_percent < speedR_percent Then
            refPercent = CDbl(speedR_percent)
            imbalancePercent = 100.0 * (CDbl(speedF_percent) - CDbl(speedR_percent)) / CDbl(speedR_percent)
        Else ' speedF_percent > speedR_percent
            refPercent = CDbl(speedF_percent)
            imbalancePercent = 100.0 * (CDbl(speedF_percent) - CDbl(speedR_percent)) / CDbl(speedF_percent)
        End If
        Return (Reference:=refPercent, Imbalance:=imbalancePercent)
    End Function

    ' --- Metodo Pubblico per Aggiornare le Impostazioni (Input -> Proprietà) ---
    Public Function UpdateSpeedSettings(ByVal speedF_percent As Integer, ByVal speedR_percent As Integer, ByVal speedIndex As Integer) As Boolean
        Dim calcResult = CalculateInverseSpeedLogic(speedF_percent, speedR_percent)
        If calcResult.Reference = 0.0 AndAlso calcResult.Imbalance = 0.0 Then
            If speedF_percent <> 0 OrElse speedR_percent <> 0 Then
                Console.WriteLine($"Errore in UpdateSpeedSettings: Le percentuali input ({speedF_percent}%, {speedR_percent}%) sono fuori dal range valido 25-100.")
                Return False
            End If
            Console.WriteLine($"Errore in UpdateSpeedSettings: Le percentuali input ({speedF_percent}%, {speedR_percent}%) sono fuori dal range valido 25-100.")
            Return False
        End If
        Dim roundedRef As Integer = CInt(Math.Round(calcResult.Reference))
        Dim roundedImbalance As Integer = CInt(Math.Round(calcResult.Imbalance))
        Dim referenceSpeedInt As Integer
        Dim referenceSpeedByte As Byte
        referenceSpeedInt = Math.Max(25, Math.Min(100, roundedRef))
        referenceSpeedByte = CType(Math.Max(0, Math.Min(100, roundedRef)), Byte)
        Dim imbalanceSByte As SByte
        ' Optional tighter clamp: imbalanceSByte = CType(Math.Max(SByte.MinValue, Math.Min(SByte.MaxValue, roundedImbalance)), SByte)
        imbalanceSByte = CType(Math.Max(-70, Math.Min(70, roundedImbalance)), SByte)
        Select Case speedIndex
            Case SpeedSetting1
                Me.FSC_CAF_Speed1 = referenceSpeedInt
                Me.IMBALANCESetPoint1 = imbalanceSByte
            Case SpeedSetting2
                Me.FSC_CAF_Speed2 = referenceSpeedInt
                Me.IMBALANCESetPoint2 = imbalanceSByte
            Case SpeedSetting3
                Me.FSC_CAF_Speed3 = referenceSpeedInt
                Me.IMBALANCESetPoint3 = imbalanceSByte
            Case SpeedSettingKHK
                Me.KHK_SET_POINT = referenceSpeedByte
                Me.KHKIMBALANCESetPoint = imbalanceSByte
            Case SpeedSettingIAQ
                Me.IAQ_Reference = referenceSpeedInt
                Me.IAQ_Imbalance = imbalanceSByte
            Case Else
                Console.WriteLine($"Errore in UpdateSpeedSettings: speedIndex ({speedIndex}) non riconosciuto.")
                Return False
        End Select
        Return True
    End Function


    ' --- NUOVO Metodo Pubblico per Calcolare le Velocità (Proprietà -> Output) ---
    ''' <summary>
    ''' Calcola le velocità percentuali risultanti (Immissione F, Estrazione R) per un dato set di velocità (1, 2, 3, o KHK=0),
    ''' basandosi sui valori di Riferimento e Sbilanciamento memorizzati nella classe.
    ''' I risultati sono arrotondati all'intero più vicino e limitati al range 25-100.
    ''' </summary>
    ''' <param name="speedIndex">Il set di velocità da cui calcolare (usare costanti SpeedSetting...).</param>
    ''' <returns>Una tupla (SpeedF As Integer, SpeedR As Integer). Ritorna (0, 0) se speedIndex non è valido.</returns>
    Public Function GetCalculatedSpeeds(ByVal speedIndex As Integer) As (SpeedF As Integer, SpeedR As Integer)

        Dim referencePercent As Double
        Dim imbalancePercent As Double

        ' 1. Leggi i valori di Riferimento e Sbilanciamento dalle proprietà della classe
        Select Case speedIndex
            Case SpeedSetting1 ' 1
                referencePercent = CDbl(Me.FSC_CAF_Speed1) ' Usa valore da proprietà
                imbalancePercent = CDbl(Me.IMBALANCESetPoint1)
            Case SpeedSetting2 ' 2
                referencePercent = CDbl(Me.FSC_CAF_Speed2)
                imbalancePercent = CDbl(Me.IMBALANCESetPoint2)
            Case SpeedSetting3 ' 3
                referencePercent = CDbl(Me.FSC_CAF_Speed3)
                imbalancePercent = CDbl(Me.IMBALANCESetPoint3)
            Case SpeedSettingKHK ' 0
                referencePercent = CDbl(Me.KHK_SET_POINT)
                imbalancePercent = CDbl(Me.KHKIMBALANCESetPoint)
            Case SpeedSettingIAQ                      ' <-- nuovo ramo
                referencePercent = CDbl(Me.IAQ_Reference)
                imbalancePercent = CDbl(Me.IAQ_Imbalance)
            Case Else
                Console.WriteLine($"Errore in GetCalculatedSpeeds: speedIndex ({speedIndex}) non riconosciuto.")
                Return (SpeedF:=0, SpeedR:=0) ' Indica errore o stato non valido
        End Select

        ' Validazione dei valori letti (il riferimento dovrebbe essere almeno 25 per produrre risultati validi > 0)
        If referencePercent < 25 AndAlso speedIndex <> SpeedSettingKHK Then
            ' Se il riferimento memorizzato è sotto il minimo (es. 0), le velocità risultanti saranno sotto 25.
            ' Restituiamo (0,0) o il minimo (25,25)? Per ora, calcoliamo e poi limitiamo a 25.
            ' Potrebbe essere più corretto restituire (0,0) se ref=0.
            If referencePercent = 0 Then Return (SpeedF:=0, SpeedR:=0)
        End If
        If referencePercent = 0 AndAlso speedIndex = SpeedSettingKHK Then
            Return (SpeedF:=0, SpeedR:=0) ' Anche per KHK, se ref=0, le velocità sono 0
        End If


        ' 2. Applica la logica di calcolo diretta (usando Double per precisione)
        Dim calculatedSpeedF As Double
        Dim calculatedSpeedR As Double

        If imbalancePercent = 0.0 Then
            ' Caso 1: Bilanciato
            calculatedSpeedF = referencePercent
            calculatedSpeedR = referencePercent
        ElseIf imbalancePercent < 0.0 Then
            ' Caso 2: F < R (Sbilanciamento negativo)
            calculatedSpeedF = referencePercent * (1.0 + imbalancePercent / 100.0)
            calculatedSpeedR = referencePercent
        Else ' imbalancePercent > 0.0
            ' Caso 3: F > R (Sbilanciamento positivo)
            calculatedSpeedF = referencePercent
            calculatedSpeedR = referencePercent * (1.0 - imbalancePercent / 100.0) ' Nota il meno qui
        End If

        ' 3. Arrotonda i risultati Double all'intero più vicino
        Dim roundedSpeedF As Integer = CInt(Math.Round(calculatedSpeedF))
        Dim roundedSpeedR As Integer = CInt(Math.Round(calculatedSpeedR))

        ' 4. Limita (Clamping) i risultati interi al range valido 25-100
        '    (Se il calcolo risulta 0 o meno, rimane 0 dopo Math.Max con 25? No, diventa 25)
        '    Se il riferimento era 0, vogliamo 0, non 25. Gestito sopra.
        Dim finalSpeedF As Integer = Math.Max(25, Math.Min(100, roundedSpeedF))
        Dim finalSpeedR As Integer = Math.Max(25, Math.Min(100, roundedSpeedR))

        ' Gestione speciale: Se il riferimento era < 25 (ma non 0), il risultato clamped a 25 potrebbe essere fuorviante.
        ' La logica attuale limita comunque a 25 come minimo operativo. Va bene così? Sì, sembra l'interpretazione più sicura.

        ' 5. Ritorna la tupla con i valori finali interi
        Return (SpeedF:=finalSpeedF, SpeedR:=finalSpeedR)

    End Function


    ' --- Metodo Clear Esistente (invariato) ---
    Public Sub Clear()
        FSC_CAF_Speed1 = 25
        FSC_CAF_Speed2 = 25
        FSC_CAF_Speed3 = 25
        IAQ_Reference = 80
        IAQ_Imbalance = 0
        CAP_Speed1 = 30
        CAP_Speed2 = 30
        CAP_Speed3 = 30
        BoostTimer = 15
        FilterTimer = 30
        FireKitTimer = 10
        CO2SetPoint = 700
        RHSetPoint = 20
        VOCSetPoint = 2
        TempSetPoint = 12
        SUM_WINSetPoint = 12
        Configuration = String.Empty
        VersionHW = String.Empty
        VersionSW = String.Empty
        SerialNumber = String.Empty
        KHK_ENABLE = False
        KHK_NC = True
        KHK_NO = False
        KHK_VALUE = 2
        SMOKE_VALUE = 0
        IMBALANCESetPoint1 = 0
        IMBALANCESetPoint2 = 0
        IMBALANCESetPoint3 = 0
        IMBALANCE_ENABLE = False
        KHK_SET_POINT = 100
        KHKIMBALANCESetPoint = 0
        Dim calculatedSpeeds1 = Me.GetCalculatedSpeeds(1)
        F_Speed1 = calculatedSpeeds1.SpeedF
        R_Speed1 = calculatedSpeeds1.SpeedR
        Dim calculatedSpeeds2 = Me.GetCalculatedSpeeds(2)
        F_Speed2 = calculatedSpeeds2.SpeedF
        R_Speed2 = calculatedSpeeds2.SpeedR
        Dim calculatedSpeeds3 = Me.GetCalculatedSpeeds(3)
        F_Speed3 = calculatedSpeeds3.SpeedF
        R_Speed3 = calculatedSpeeds3.SpeedR
        Dim calculatedSpeeds0 = Me.GetCalculatedSpeeds(0)
        FK_Speed = calculatedSpeeds0.SpeedF
        RK_Speed = calculatedSpeeds0.SpeedR
        Dim calcIAQ = Me.GetCalculatedSpeeds(SpeedSettingIAQ)
        IAQ_F_Speed = calcIAQ.SpeedF
        IAQ_R_Speed = calcIAQ.SpeedR
    End Sub

    ' --- Altre proprietà e metodi ---

End Class
