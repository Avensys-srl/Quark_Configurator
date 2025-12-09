Imports System.IO
Imports System.IO.Ports
Imports System.Diagnostics
Imports System.Reflection
Imports System.Text
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports System.Xml.Serialization
Imports System.Globalization
Imports System.Threading
Imports System.Media
Imports System.Xml.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Script.Serialization

Public Class Program_Form
    Dim isConnected As Boolean = False
    Dim isTimestampEnabled As Boolean = True
    Dim logFileIndex As Integer = 1
    Dim currentLogFilePath As String
    ReadOnly logFileSizeLimit As Long = 1024 * 1024 ' 1 MB
    Dim isLoggingEnabled As Boolean = False
    Private character2Sent As Boolean = False
    Private character6Sent As Boolean = False
    Private isWriting As Boolean = False
    Private writeStep As Integer = 1
    Private parameterRead As Boolean = False
    ReadOnly customerData As New CustomerData
    ReadOnly configDataBuilder As New StringBuilder()
    Private Const InactivityTimeoutMilliseconds As Integer = 1000 ' 1 secondo
    Private WithEvents PortWatcher As ManagementEventWatcher
    Private isService = False
    ReadOnly hiddenPages As New List(Of TabPage)()
    Private logBuffer As New Text.StringBuilder()
    Private currentDateTime As DateTime
    Private updatingDateTime As Boolean = False
    Private dateTimeStep As Integer = 0
    Private sentPcTimestamp As Boolean = False
    Private liveDataBuffer As New List(Of String)
    Private readingLiveData As Boolean = False
    Private Const LiveStartMarker As String = "------ START READ LIVE DATA ------"
    Private Const LiveEndMarker As String = "------ END READ LIVE DATA ------"
    Private lastLiveDataSnapshot As LiveData
    Private lastLiveDataTimestamp As DateTime = DateTime.MinValue
    Private unitTestCts As CancellationTokenSource
    Private unitTestRunning As Boolean = False
    Private unitTestLogPath As String
    Private Const TestFolderName As String = "test"
    Private Const TestFailedFolderName As String = "failed"
    Private originalSpeed1F As Integer = 0
    Private originalSpeed1R As Integer = 0
    Private originalSpeed2F As Integer = 0
    Private originalSpeed3F As Integer = 0
    Private originalRhSetPoint As Integer = 0
    Private originalImbalanceEnable As Integer = 0
    Private originalKhkConfig As Integer = 0
    Private originalSmokeValue As Byte = 0
    Private unitTestStartTime As DateTime = DateTime.MinValue
    Private khkVisibilityEntries As New List(Of KhkVisibilityEntry)()
    Private khkApiEndpoint As String = String.Empty
    Private Class TestLogListItem
        Public Property Display As String
        Public Property FullPath As String
        Public Overrides Function ToString() As String
            Return Display
        End Function
    End Class
    Private Class KhkVisibilityEntry
        Public Property Prefix As String
        Public Property MaxLast3 As Integer?
    End Class
    Private Class KhkApiPattern
        Public Property prefix As String
        Public Property maxLast3 As Integer?
    End Class
    Private Class KhkApiResponse
        Public Property serialPatterns As List(Of KhkApiPattern)
    End Class
    Private liveDataHistory As New Queue(Of LiveData)()

    ' === Palette (usa questi colori per coerenza) ===
    Private Shared ReadOnly ColBlue As Color = Color.FromArgb(37, 99, 235)     ' operativi
    Private Shared ReadOnly ColGreen As Color = Color.FromArgb(22, 163, 74)    ' ok/boost
    Private Shared ReadOnly ColAmber As Color = Color.FromArgb(245, 158, 11)   ' override
    Private Shared ReadOnly ColPurple As Color = Color.FromArgb(124, 58, 237)  ' update
    Private Shared ReadOnly ColText As Color = Color.White
    Private Shared ReadOnly ColBack As Color = Color.FromArgb(243, 244, 246)   ' grigino panel
    Private Shared ReadOnly ColRed As Color = Color.FromArgb(220, 38, 38) ' rosso acceso


    ' === Timer opzionale per "pulsare" i badge dinamici (es. Bypass in movimento) ===
    Private ReadOnly _pulseTimer As New System.Windows.Forms.Timer() With {.Interval = 350}
    Private _pulseToggle As Boolean = False

    ' Manteniamo un riferimento ai badge che vogliamo far lampeggiare
    Private _lblBypMov As Label = Nothing


    Private Function GetCurrentApplicationData() As CustomerData
        Dim dataToReturn As New CustomerData() ' Creiamo una nuova istanza per il salvataggio

        ' --- Popolamento dalle proprietà di Me.customerData che sono aggiornate dagli eventi UI ---
        ' Le velocità FSC_CAF e gli IMBALANCESetPoint sono aggiornati in Me.customerData
        ' tramite il metodo customerData.UpdateSpeedSettings() chiamato negli eventi ValueChanged dei NumericUpDown.
        dataToReturn.FSC_CAF_Speed1 = Me.customerData.FSC_CAF_Speed1
        dataToReturn.FSC_CAF_Speed2 = Me.customerData.FSC_CAF_Speed2
        dataToReturn.FSC_CAF_Speed3 = Me.customerData.FSC_CAF_Speed3
        dataToReturn.IMBALANCESetPoint1 = Me.customerData.IMBALANCESetPoint1
        dataToReturn.IMBALANCESetPoint2 = Me.customerData.IMBALANCESetPoint2
        dataToReturn.IMBALANCESetPoint3 = Me.customerData.IMBALANCESetPoint3

        ' Anche KHK_SET_POINT e KHKIMBALANCESetPoint sono gestiti da UpdateSpeedSettings (con speedIndex = 0)
        dataToReturn.KHK_SET_POINT = Me.customerData.KHK_SET_POINT
        dataToReturn.KHKIMBALANCESetPoint = Me.customerData.KHKIMBALANCESetPoint

        ' --- Popolamento dai NumericUpDown per CAP Speeds e Timers ---
        dataToReturn.CAP_Speed1 = CInt(num_Speed1CAP.Value)
        dataToReturn.CAP_Speed2 = CInt(num_Speed2CAP.Value)
        dataToReturn.CAP_Speed3 = CInt(num_Speed3CAP.Value)

        dataToReturn.BoostTimer = CInt(num_BoostTimer.Value)
        dataToReturn.FilterTimer = CInt(num_FilterTimer.Value)
        dataToReturn.FireKitTimer = CInt(num_FKITimer.Value) ' Assumendo che il controllo sia num_FKITimer

        ' --- Popolamento dai NumericUpDown per SetPoints ---
        dataToReturn.CO2SetPoint = CInt(num_CO2Setpoint.Value)
        dataToReturn.RHSetPoint = CInt(num_RHSetpoint.Value)
        dataToReturn.VOCSetPoint = CInt(num_VOCSetpoint.Value)
        dataToReturn.TempSetPoint = CInt(num_TempSetpoint.Value)

        If CB_BPDisable.Checked Then
            dataToReturn.SUM_WINSetPoint = 99 ' Valore speciale se il bypass è disabilitato
        Else
            dataToReturn.SUM_WINSetPoint = CInt(num_SWSetpoint.Value)
        End If

        dataToReturn.Belimo = CInt(num_Belimo.Value)

        ' --- Popolamento Configurazione KHK ---
        dataToReturn.KHK_ENABLE = CB_KHKenable.Checked
        dataToReturn.KHK_NC = RB_NC.Checked
        dataToReturn.KHK_NO = RB_NO.Checked
        ' KHK_VALUE è già aggiornato in Me.customerData dagli eventi dei controlli KHK
        dataToReturn.KHK_VALUE = Me.customerData.KHK_VALUE

        ' --- Popolamento Abilitazione Sbilanciamento ---
        If CB_ImbEnable.Checked Then
            dataToReturn.IMBALANCE_ENABLE = 1
        Else
            dataToReturn.IMBALANCE_ENABLE = 0
        End If

        dataToReturn.SMOKE_VALUE = Me.customerData.SMOKE_VALUE

        ' --- Popolamento della proprietà 'Configuration' (LEFT/RIGHT) ---
        If RB_left.Checked Then
            dataToReturn.Configuration = "LEFT" ' O un identificatore più strutturato se necessario
        ElseIf RB_right.Checked Then
            dataToReturn.Configuration = "RIGHT"
        Else
            dataToReturn.Configuration = String.Empty ' O un default se nessuno è selezionato
        End If

        dataToReturn.IAQ_Reference = Me.customerData.IAQ_Reference
        dataToReturn.IAQ_Imbalance = Me.customerData.IAQ_Imbalance



        ' --- Popolamento dei dati "read-only" (Versioni, Seriale) da Me.customerData ---
        ' Questi valori sono tipicamente letti dal dispositivo e non modificati dall'utente per il salvataggio.
        'dataToReturn.VersionHW = Me.customerData.VersionHW
        'dataToReturn.VersionSW = Me.customerData.VersionSW
        'dataToReturn.SerialNumber = Me.customerData.SerialNumber

        ' Le proprietà come F_Speed1, R_Speed1 ecc. nella classe CustomerData sono calcolate
        ' dal metodo GetCalculatedSpeeds. Non le impostiamo direttamente qui per il salvataggio,
        ' poiché sono dati derivati. Verranno serializzate con qualsiasi valore abbiano
        ' nell'oggetto dataToReturn (probabilmente i default se non diversamente impostato
        ' da un eventuale costruttore o metodo Clear chiamato su dataToReturn).
        ' Per la serializzazione, ci concentriamo sui dati primari/sorgente.

        Return dataToReturn
    End Function



    Private Function GenerateLogFileName() As String
        Do
            Dim logFileName As String = $"Log{logFileIndex:D4}.txt"
            Dim logFilePath As String = Path.Combine(Application.StartupPath, logFileName)
            If Not File.Exists(logFilePath) Then
                Return logFilePath
            End If
            logFileIndex += 1
        Loop
    End Function

    Private Sub StartNewLogFile()
        logFileIndex = 1
        currentLogFilePath = GenerateLogFileName()
        File.Create(currentLogFilePath).Dispose()
    End Sub

    Private Sub AppendLogData(data As String)
        If isLoggingEnabled Then
            ' Usa un StringBuilder per raccogliere la riga intera prima di scrivere
            Dim logEntry As New StringBuilder()

            ' Aggiunge timestamp se abilitato
            If isTimestampEnabled Then
                logEntry.Append($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} , ")
            End If

            ' Rimuove caratteri di newline indesiderati che spezzano le righe
            data = data.Replace(vbCr, "").Replace(vbLf, "")

            ' Aggiunge la riga formattata correttamente
            logEntry.Append(data)

            ' Scrive una sola riga nel file senza spezzarla
            File.AppendAllText(currentLogFilePath, logEntry.ToString() & Environment.NewLine)

            ' Controlla se il file ha superato il limite di dimensione
            Dim fileInfo As New FileInfo(currentLogFilePath)
            If fileInfo.Length > logFileSizeLimit Then
                logFileIndex += 1
                currentLogFilePath = GenerateLogFileName()
                File.Create(currentLogFilePath).Dispose()
            End If
        End If
    End Sub

    Private Sub UpdateFormControls()


        If customerData.CAP_Speed1 > 29 Then
            Invoke(Sub() num_Speed1CAP.Value = customerData.CAP_Speed1)
        Else
            Invoke(Sub() num_Speed1CAP.Value = 30)
            Invoke(Sub() customerData.CAP_Speed1 = 30)
        End If

        If customerData.CAP_Speed2 > 29 Then
            Invoke(Sub() num_Speed2CAP.Value = customerData.CAP_Speed2)
        Else
            Invoke(Sub() num_Speed2CAP.Value = 30)
            Invoke(Sub() customerData.CAP_Speed2 = 30)
        End If

        If customerData.CAP_Speed3 > 29 Then
            Invoke(Sub() num_Speed3CAP.Value = customerData.CAP_Speed3)
        Else
            Invoke(Sub() num_Speed3CAP.Value = 30)
            Invoke(Sub() customerData.CAP_Speed3 = 30)
        End If

        If customerData.BoostTimer > 14 Then
            Invoke(Sub() num_BoostTimer.Value = customerData.BoostTimer)
        Else
            Invoke(Sub() num_BoostTimer.Value = 15)
            Invoke(Sub() customerData.BoostTimer = 15)
        End If

        If customerData.FilterTimer > 29 Then
            Invoke(Sub() num_FilterTimer.Value = customerData.FilterTimer)
        Else
            Invoke(Sub() num_FilterTimer.Value = 30)
            Invoke(Sub() customerData.FilterTimer = 30)
        End If

        If customerData.FireKitTimer > 7 Then
            Invoke(Sub() num_FKITimer.Value = customerData.FireKitTimer)
        Else
            Invoke(Sub() num_FKITimer.Value = 10)
            Invoke(Sub() customerData.FireKitTimer = 10)
        End If

        If customerData.CO2SetPoint > 699 Then
            Invoke(Sub() num_CO2Setpoint.Value = customerData.CO2SetPoint)
        Else
            Invoke(Sub() num_CO2Setpoint.Value = 700)
            Invoke(Sub() customerData.CO2SetPoint = 700)
        End If

        If customerData.RHSetPoint > 19 Then
            Invoke(Sub() num_RHSetpoint.Value = customerData.RHSetPoint)
        Else
            Invoke(Sub() num_RHSetpoint.Value = 20)
            Invoke(Sub() customerData.RHSetPoint = 20)
        End If

        If customerData.VOCSetPoint > 1 Then
            Invoke(Sub() num_VOCSetpoint.Value = customerData.VOCSetPoint)
        Else
            Invoke(Sub() num_VOCSetpoint.Value = 2)
            Invoke(Sub() customerData.VOCSetPoint = 2)
        End If


        If customerData.TempSetPoint > 11 Then
            Invoke(Sub() num_TempSetpoint.Value = customerData.TempSetPoint)
        Else
            Invoke(Sub() num_TempSetpoint.Value = 12)
            Invoke(Sub() customerData.TempSetPoint = 12)
        End If


        If customerData.SUM_WINSetPoint > 11 Then
            Invoke(Sub() num_SWSetpoint.Value = customerData.SUM_WINSetPoint)
        Else
            Invoke(Sub() num_SWSetpoint.Value = 12)
            Invoke(Sub() customerData.SUM_WINSetPoint = 12)
        End If

        If customerData.Belimo > 0 And customerData.Belimo <= 2 Then
            Invoke(Sub() num_Belimo.Value = customerData.Belimo)
        Else
            Invoke(Sub() num_Belimo.Value = 1)
            Invoke(Sub() customerData.Belimo = 1)
        End If

        If customerData.Configuration IsNot Nothing AndAlso customerData.Configuration.Length <> 0 Then
            If customerData.Configuration.Contains("LEFT") Then
                RB_left.Checked = True
                RB_right.Checked = False
            Else
                RB_right.Checked = True
                RB_left.Checked = False
            End If
        Else
            PcBx_Quark.Image = My.Resources.DRAW_QUARK
            RB_right.Checked = False
            RB_left.Checked = False
        End If


        ' Estrai lo stato di KHK Enable (Bit 0)
        If (customerData.KHK_VALUE And &H1) = &H1 Then
            CB_KHKenable.Checked = True
        Else
            CB_KHKenable.Checked = False
        End If


        ' Estrai lo stato del Comportamento Contatto (Bit 1)
        If (customerData.KHK_VALUE And &H2) = &H2 Then
            RB_NC.Checked = True
            RB_NO.Checked = False ' Assicura che l'altro radio button sia deselezionato
        Else
            RB_NO.Checked = True
            RB_NC.Checked = False ' Assicura che l'altro radio button sia deselezionato
        End If

        ' Estrai lo stato per "Disable Temperature Control" (Bit 2)
        ' La logica del timer nel firmware si ATTIVA se il bit 2 di KHK_VALUE è 0.
        ' Quindi, se il bit 2 letto da KHK_VALUE è 1, significa che l'utente aveva scelto di DISABILITARE il controllo/timer.
        If (customerData.KHK_VALUE And &H4) = &H4 Then
            CB_DisableTemperatureControl.Checked = True ' Il bit 2 è 1 -> Disabilita controllo/timer è SPUNTATO
        Else
            CB_DisableTemperatureControl.Checked = False ' Il bit 2 è 0 -> Disabilita controllo/timer è NON SPUNTATO (quindi controllo/timer è abilitato)
        End If

        ' Abilita/Disabilita i controlli dipendenti in base allo stato di CB_KHKenable
        num_FK_Speed.Enabled = CB_KHKenable.Checked
        num_RK_Speed.Enabled = CB_KHKenable.Checked
        RB_NC.Enabled = CB_KHKenable.Checked
        RB_NO.Enabled = CB_KHKenable.Checked
        CB_DisableTemperatureControl.Enabled = CB_KHKenable.Checked

        If (customerData.SMOKE_VALUE = 0) Then
            Invoke(Sub() CB_SmokeEnable.Checked = False)
        ElseIf (customerData.SMOKE_VALUE = 1) Then
            Invoke(Sub() CB_SmokeEnable.Checked = True)
            Invoke(Sub() RB_SmokeNC.Checked = True)
            Invoke(Sub() RB_SmokeNO.Checked = False)
        Else
            customerData.SMOKE_VALUE = 2
            Invoke(Sub() CB_SmokeEnable.Checked = True)
            Invoke(Sub() RB_SmokeNC.Checked = False)
            Invoke(Sub() RB_SmokeNO.Checked = True)
        End If

        UpdateSmokeControls()

        If (customerData.IMBALANCESetPoint1 < -70 OrElse customerData.IMBALANCESetPoint1 > 70) Then
            Invoke(Sub() customerData.IMBALANCESetPoint1 = 0)
        End If

        If (customerData.IMBALANCESetPoint2 < -70 OrElse customerData.IMBALANCESetPoint2 > 70) Then
            Invoke(Sub() customerData.IMBALANCESetPoint2 = 0)
        End If

        If (customerData.IMBALANCESetPoint3 < -70 OrElse customerData.IMBALANCESetPoint3 > 70) Then
            Invoke(Sub() customerData.IMBALANCESetPoint3 = 0)
        End If

        CB_ImbEnable.Checked = (customerData.IMBALANCE_ENABLE = 1)

        If (customerData.KHKIMBALANCESetPoint < -70 OrElse customerData.KHKIMBALANCESetPoint > 70) Then
            Invoke(Sub() customerData.KHKIMBALANCESetPoint = 0)
        End If



        'INIZIO Setting Velocità
        Dim velocitaCalcolate1 = customerData.GetCalculatedSpeeds(1)
        Dim velocitaCalcolate2 = customerData.GetCalculatedSpeeds(2)
        Dim velocitaCalcolate3 = customerData.GetCalculatedSpeeds(3)
        Dim velocitaCalcolateK = customerData.GetCalculatedSpeeds(0)
        Dim velocitaCalcolateIAQ = customerData.GetCalculatedSpeeds(4)


        If customerData.FSC_CAF_Speed1 > 24 Then
            Invoke(Sub() num_F_Speed1.Value = velocitaCalcolate1.SpeedF)
            Invoke(Sub() num_R_Speed1.Value = velocitaCalcolate1.SpeedR)
        Else
            Invoke(Sub() num_F_Speed1.Value = 25)
            Invoke(Sub() num_R_Speed1.Value = 25)
            Invoke(Sub() customerData.FSC_CAF_Speed1 = 25)
        End If

        If customerData.FSC_CAF_Speed2 > 24 Then
            Invoke(Sub() num_F_Speed2.Value = velocitaCalcolate2.SpeedF)
            Invoke(Sub() num_R_Speed2.Value = velocitaCalcolate2.SpeedR)
        Else
            Invoke(Sub() num_F_Speed2.Value = 25)
            Invoke(Sub() num_R_Speed2.Value = 25)
            Invoke(Sub() customerData.FSC_CAF_Speed2 = 25)
        End If

        If customerData.FSC_CAF_Speed3 > 24 Then
            Invoke(Sub() num_F_Speed3.Value = velocitaCalcolate3.SpeedF)
            Invoke(Sub() num_R_Speed3.Value = velocitaCalcolate3.SpeedR)
        Else
            Invoke(Sub() num_F_Speed3.Value = 25)
            Invoke(Sub() num_R_Speed3.Value = 25)
            Invoke(Sub() customerData.FSC_CAF_Speed3 = 25)
        End If

        If customerData.KHK_SET_POINT > 25 And customerData.KHK_SET_POINT <= 100 Then
            Invoke(Sub() num_FK_Speed.Value = velocitaCalcolateK.SpeedF)
            Invoke(Sub() num_RK_Speed.Value = velocitaCalcolateK.SpeedR)
        Else
            Invoke(Sub() num_FK_Speed.Value = 100)
            Invoke(Sub() num_RK_Speed.Value = 100)
            Invoke(Sub() customerData.KHK_SET_POINT = 100)
        End If

        If customerData.IAQ_Reference > 25 And customerData.IAQ_Reference <= 100 Then
            Invoke(Sub() num_F_IAQSpeed.Value = velocitaCalcolateIAQ.SpeedF)
            Invoke(Sub() num_R_IAQSpeed.Value = velocitaCalcolateIAQ.SpeedR)
        Else
            Invoke(Sub() num_F_IAQSpeed.Value = 100)
            Invoke(Sub() num_R_IAQSpeed.Value = 100)
            Invoke(Sub() customerData.IAQ_Reference = 100)
        End If

        ' FINE Setting Velocità



        If customerData.VersionHW IsNot Nothing AndAlso customerData.VersionHW.Length <> 0 Then
            Invoke(Sub() lb_HW_vers.Text = "Hardware Version: " + customerData.VersionHW)
        Else
            Invoke(Sub() lb_HW_vers.Text = "Hardware Version:")
        End If

        If customerData.VersionSW IsNot Nothing AndAlso customerData.VersionSW.Length <> 0 Then
            Invoke(Sub() lb_SW_vers.Text = "Software Version: " + customerData.VersionSW)
        Else
            Invoke(Sub() lb_SW_vers.Text = "Software Version:")
        End If

        If customerData.Accessories IsNot Nothing AndAlso customerData.Accessories.Length <> 0 Then
            Invoke(Sub() TB_acc.Text = customerData.Accessories)
        Else
            Invoke(Sub() TB_acc.Text = "-----")
        End If

        If customerData IsNot Nothing AndAlso
       customerData.Accessories IsNot Nothing AndAlso
       customerData.Accessories.Contains("EHD") Then

            Me.Invoke(Sub()
                          lblTAfterHeater.Visible = True
                          lblTHeater.Visible = True
                      End Sub)
        End If

        If customerData.SerialNumber IsNot Nothing AndAlso customerData.SerialNumber.Length <> 0 Then
            Invoke(Sub() lb_SerialNumber.Text = "Serial Number: " + customerData.SerialNumber)
            Dim showKhk = ShouldShowKhkForSerial(customerData.SerialNumber)
            Invoke(Sub() Grp_KHK.Visible = showKhk)
        Else
            Invoke(Sub() lb_SerialNumber.Text = "Serial Number:")
        End If

        If customerData.no_FKI Then
            num_Belimo.Enabled = False
            num_FKITimer.Enabled = False
        Else
            num_Belimo.Enabled = True
            num_FKITimer.Enabled = True
        End If

    End Sub

    Private Function GetCDCUSBDevices() As List(Of ManagementObject)
        Dim usbDevices As New List(Of ManagementObject)()

        'List of USB device connect to PC
        Dim searcher As New ManagementObjectSearcher("Select * From Win32_PnPEntity WHERE ClassGuid = '{4d36e978-e325-11ce-bfc1-08002be10318}'")

        For Each device As ManagementObject In searcher.Get()
            usbDevices.Add(device)
        Next

        Return usbDevices
    End Function

    Private Sub PopulateSerialPorts()
        COM_List.Items.Clear()


        Dim usbCDCDevices As List(Of ManagementObject) = GetCDCUSBDevices()

        'We choose the USB device connect with COM available
        For Each portName As String In SerialPort.GetPortNames()
            For Each usbCDCDevice As ManagementObject In usbCDCDevices
                If usbCDCDevice("Name").ToString().Contains("USB") AndAlso usbCDCDevice("Name").ToString().Contains(portName) Then
                    COM_List.Items.Add(portName)
                    Exit For
                End If
            Next
        Next

        If COM_List.Items.Count > 0 Then
            COM_List.SelectedIndex = 0
        Else
            COM_List.Items.Add("No Device")
        End If
    End Sub



    Private Sub StartPortWatcher()
        Dim query As New WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 1 OR EventType = 2") ' EventType = 1 Device Added, EventType = 2 Device Removed
        PortWatcher = New ManagementEventWatcher(query)
        AddHandler PortWatcher.EventArrived, AddressOf PortChanged
        PortWatcher.Start()
    End Sub

    Private Sub PortChanged(sender As Object, e As EventArrivedEventArgs)
        Invoke(Sub() PopulateSerialPorts())
    End Sub

    Private Sub LoadXmlConfigFiles()
        ' Pulisci la ListBox prima di popolarla
        Lsb_FileConfig.Items.Clear()

        Dim configFolderPath As String
        Try
            ' 1. Ottieni il percorso della directory di avvio dell'applicazione
            Dim startupPath As String = Application.StartupPath
            ' Combina con il nome della sottocartella "config"
            configFolderPath = Path.Combine(startupPath, "config")

            ' 2. Controlla se la sottocartella "config" esiste. Se no, creala.
            If Not Directory.Exists(configFolderPath) Then
                Directory.CreateDirectory(configFolderPath)
                ' You might want to log or notify that the folder was created
            End If

            ' 3. Ottieni tutti i file .xml dalla cartella "config"
            Dim foundXmlFiles As String() = Directory.GetFiles(configFolderPath, "*.xml")

            ' 4. Popola la ListBox Lsb_FileConfig
            If foundXmlFiles.Length > 0 Then
                For Each fullFilePath As String In foundXmlFiles
                    ' Aggiungi solo il nome del file (non il percorso completo) alla ListBox
                    Lsb_FileConfig.Items.Add(Path.GetFileName(fullFilePath))
                Next
            Else
                ' 5. Se nessun file XML è stato trovato, mostra un messaggio nella ListBox
                Lsb_FileConfig.Items.Add("No XML files found.")
            End If

        Catch exIO As IOException
            MessageBox.Show($"I/O error while accessing the 'config' folder: {exIO.Message}", "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Lsb_FileConfig.Items.Add("Error accessing 'config' folder.")
        Catch exUnauthorized As UnauthorizedAccessException
            MessageBox.Show($"Access denied to the 'config' folder: {exUnauthorized.Message}", "Permissions Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Lsb_FileConfig.Items.Add("Access denied to 'config' folder.")
        Catch ex As Exception
            MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Lsb_FileConfig.Items.Add("Unexpected error.")
        End Try
    End Sub



    Private Sub VisibleGroups(isVisible As Boolean)
        Grp_SpeedConf.Visible = isVisible
        Grp_UnitConfig.Visible = isVisible
        Grp_UnitData.Visible = isVisible
        Grp_UnitParam.Visible = isVisible
        Grp_KHK.Visible = isVisible
        Grp_Preset.Visible = isVisible
        Grp_DateTime.Visible = False
        Grp_Smoke.Visible = isVisible
        Grp_Live.Visible = isVisible
        Grp_Acc.Visible = isVisible
        flpStatus.Visible = isVisible
        LoadXmlConfigFiles()
    End Sub

    Private Sub ToggleService(isService As Boolean)
        If (Not isService) Then
            hiddenPages.Add(TP_Shell)
            Tab_Main.TabPages.Remove(TP_Shell)
        Else
            Tab_Main.TabPages.Add(TP_Shell)
            hiddenPages.Remove(TP_Shell)
        End If
    End Sub


    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        For Each page In hiddenPages
            page.Dispose()
        Next
        MyBase.OnFormClosed(e)
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.Alt AndAlso e.KeyCode = Keys.S Then
            isService = Not isService
            ToggleService(isService)
        End If
    End Sub

    Private Sub LoadKhkVisibilityConfig()
        khkVisibilityEntries.Clear()
        khkApiEndpoint = String.Empty
        Dim xmlPatterns As New List(Of KhkVisibilityEntry)
        Dim configPath As String = Nothing
        Dim primary = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "khk_visibility.xml")
        Dim fallback = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "khk_visibility.xml"))
        If File.Exists(primary) Then
            configPath = primary
        ElseIf File.Exists(fallback) Then
            configPath = fallback
        End If

        Try
            If Not String.IsNullOrWhiteSpace(configPath) AndAlso File.Exists(configPath) Then
                Dim doc As System.Xml.Linq.XDocument = System.Xml.Linq.XDocument.Load(configPath)
                Dim api As String = doc.Root?.Element("ApiEndpoint")?.Value
                If Not String.IsNullOrWhiteSpace(api) Then khkApiEndpoint = api.Trim()

                Dim patterns As IEnumerable(Of System.Xml.Linq.XElement) = doc.Root?.Element("SerialPatterns")?.Elements("Pattern")
                If patterns IsNot Nothing Then
                    For Each p As System.Xml.Linq.XElement In patterns
                        Dim prefAttr = p.Attribute("prefix")
                        Dim pref = If(prefAttr IsNot Nothing, prefAttr.Value, String.Empty).Trim()
                        If String.IsNullOrWhiteSpace(pref) Then Continue For
                        Dim entry As New KhkVisibilityEntry With {.Prefix = pref}
                        Dim maxLast3Attr = p.Attribute("maxLast3")
                        If maxLast3Attr IsNot Nothing Then
                            Dim n As Integer
                            If Integer.TryParse(maxLast3Attr.Value, n) Then entry.MaxLast3 = n
                        End If
                        xmlPatterns.Add(entry)
                    Next
                End If
            End If
        Catch
            ' fallback gestito sotto
        End Try

        ' 1) Se esiste endpoint API e riusciamo a leggere, VINCE l'API (nessuna unione con XML)
        Dim apiApplied As Boolean = False
        If Not String.IsNullOrWhiteSpace(khkApiEndpoint) Then
            Dim apiList = LoadKhkVisibilityFromApi(khkApiEndpoint)
            If apiList IsNot Nothing AndAlso apiList.Count > 0 Then
                khkVisibilityEntries = apiList
                apiApplied = True
            End If
        End If

        ' 2) Se l'API non ha fornito dati validi, usa solo l'XML (se presente)
        If Not apiApplied AndAlso xmlPatterns.Count > 0 Then
            khkVisibilityEntries = xmlPatterns
        End If

        ' 3) Se non abbiamo né API né XML validi, usa i default
        If khkVisibilityEntries.Count = 0 Then
            ' Defaults (come logica precedente): 9999, 7603(last3<110), 8705, 8910
            khkVisibilityEntries.Add(New KhkVisibilityEntry With {.Prefix = "9999"})
            khkVisibilityEntries.Add(New KhkVisibilityEntry With {.Prefix = "7603", .MaxLast3 = 110})
            khkVisibilityEntries.Add(New KhkVisibilityEntry With {.Prefix = "8705"})
            khkVisibilityEntries.Add(New KhkVisibilityEntry With {.Prefix = "8910"})
        End If
    End Sub

    Private Function LoadKhkVisibilityFromApi(url As String) As List(Of KhkVisibilityEntry)
        Try
            Dim handler As New HttpClientHandler()
            handler.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            Using client As New HttpClient(handler)
                client.Timeout = TimeSpan.FromSeconds(8)
                Dim resp = client.GetAsync(url).Result
                If Not resp.IsSuccessStatusCode Then Return Nothing
                Dim json = resp.Content.ReadAsStringAsync().Result
                If String.IsNullOrWhiteSpace(json) Then Return Nothing
                Dim js As New JavaScriptSerializer()
                Dim payload = js.Deserialize(Of KhkApiResponse)(json)
                If payload Is Nothing OrElse payload.serialPatterns Is Nothing Then Return Nothing
                Dim list As New List(Of KhkVisibilityEntry)
                For Each p In payload.serialPatterns
                    If p Is Nothing OrElse String.IsNullOrWhiteSpace(p.prefix) Then Continue For
                    Dim entry As New KhkVisibilityEntry With {.Prefix = p.prefix.Trim()}
                    If p.maxLast3.HasValue Then entry.MaxLast3 = p.maxLast3.Value
                    list.Add(entry)
                Next
                Return list
            End Using
        Catch
            Return Nothing
        End Try
    End Function

    Private Function ShouldShowKhkForSerial(serial As String) As Boolean
        If String.IsNullOrWhiteSpace(serial) Then Return False
        For Each entry In khkVisibilityEntries
            If serial.StartsWith(entry.Prefix) Then
                If entry.MaxLast3.HasValue AndAlso serial.Length >= 3 Then
                    Dim last3Str = serial.Substring(Math.Max(0, serial.Length - 3))
                    Dim n As Integer
                    If Integer.TryParse(last3Str, n) Then
                        If n < entry.MaxLast3.Value Then Return True Else Continue For
                    End If
                Else
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub Program_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VisibleGroups(False)
        ToggleService(isService)
        PB_SaveData.Visible = False
        lb_SaveProg.Visible = False
        lb_QKvers.Text &= Assembly.GetExecutingAssembly().GetName().Version.ToString()
        LoadKhkVisibilityConfig()
        StartPortWatcher()
        ToggleControls(isConnected)
        UpdateFormControls()
        PopulateSerialPorts()
        If Tab_Main.TabPages.Contains(TP_TestUnit) Then
            Tab_Main.TabPages.Remove(TP_TestUnit)
            hiddenPages.Add(TP_TestUnit)
        End If
        LoadTestLogs()
    End Sub

    Private Sub Btn_RefreshLIST_Click(sender As Object, e As EventArgs) Handles Btn_RefreshLIST.Click
        If SerialPort1 IsNot Nothing AndAlso SerialPort1.IsOpen Then
            MessageBox.Show("Please disconnect before refreshing COM list to avoid serial conflicts.", "Refresh COM list", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        PopulateSerialPorts()
    End Sub

    Private Sub ToggleControls(isConnected As Boolean)
        Btn_Connect.Enabled = Not isConnected
        Btn_Disconnect.Enabled = isConnected
        Btn_SendData.Enabled = isConnected
        Btn_RefreshData.Enabled = isConnected
        Btn_SaveData.Enabled = isConnected
        PcBx_Logo.Visible = Not isConnected
        PB_SaveData.Visible = False
        lb_SaveProg.Visible = False
    End Sub
    Private Sub ResetInactivityTimer()
        SerialDataTimer.Stop()
        SerialDataTimer.Start()
    End Sub
    Private Sub StartInactivityTimer()
        SerialDataTimer.Enabled = True
        SerialDataTimer.Interval = InactivityTimeoutMilliseconds
        SerialDataTimer.Start()
    End Sub
    Private Sub StopInactivityTimer()
        SerialDataTimer.Stop()
        SerialDataTimer.Enabled = False
    End Sub

    Private Sub Refresh_Data()
        character2Sent = False
        character6Sent = False
        parameterRead = False
        num_F_Speed1.Enabled = False
        num_F_Speed2.Enabled = False
        num_F_Speed3.Enabled = False
        num_F_IAQSpeed.Enabled = False
        num_R_Speed1.Enabled = False
        num_R_Speed2.Enabled = False
        num_R_Speed3.Enabled = False
        num_R_IAQSpeed.Enabled = False
        num_Speed1CAP.Enabled = False
        num_Speed2CAP.Enabled = False
        num_Speed3CAP.Enabled = False
        num_BoostTimer.Enabled = False
        num_FilterTimer.Enabled = False
        num_FKITimer.Enabled = False
        num_CO2Setpoint.Enabled = False
        num_RHSetpoint.Enabled = False
        num_VOCSetpoint.Enabled = False
        num_TempSetpoint.Enabled = False
        num_SWSetpoint.Enabled = False
        num_Belimo.Enabled = False
        num_SWSetpoint.Maximum = 99
        updatingDateTime = False
        CB_SmokeEnable.Checked = False
        CB_LiveData.Enabled = False
        customerData.Clear()
        Invoke(Sub() tb_COMStrem.Text = String.Empty)
        UpdateFormControls()
    End Sub

    Private Async Sub SerialDataTimer_Tick(sender As Object, e As EventArgs) Handles SerialDataTimer.Tick
        ' 1) Acquisisco tutto ciò che arriva
        Dim chunk As String = SerialPort1.ReadExisting()
        If chunk.Length > 0 Then
            logBuffer.Append(chunk)
            Invoke(Sub() tb_COMStrem.AppendText(chunk))
        End If

        ' 2) Se siamo in update, gestisco i due passi
        If updatingDateTime Then
            Select Case dateTimeStep

                Case 1
                    ' attendo “Waiting for data from PC:”
                    If tb_COMStrem.Text.Contains("Waiting for data from PC:") Then
                        ' costruisco il timestamp
                        Dim pcNow As DateTime = DateTime.Now
                        Dim wd As Integer = ((CInt(pcNow.DayOfWeek) + 6) Mod 7) + 1
                        Dim msg As String = $"{pcNow.Year},{pcNow.Month},{pcNow.Day}," &
                                        $"{wd},{pcNow.Hour},{pcNow.Minute},{pcNow.Second}"
                        ' 2) invio timestamp con WriteLine
                        InviaStringa(msg)
                        'dateTimeStep = 2
                        ResetInactivityTimer()
                    End If

                Case 2
                    ' attendo la risposta “Data: … Ora: …”
                    If tb_COMStrem.Text.Contains("Data:") Then
                        ' prendo l’ultima riga completa
                        Dim allLines() As String = tb_COMStrem.Text _
                        .Split(New String() {vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)
                        ' Prendo l’ultima riga e la trimmo
                        Dim line As String = allLines(allLines.Length - 1).Trim()

                        ' parsifico
                        Dim parts() As String = Regex.Split(line, "Ora:")
                        If parts.Length = 2 Then
                            Dim datePart As String = parts(0).Replace("Data:", "").Trim()
                            Dim timePart As String = parts(1).Trim()
                            Dim dt As DateTime
                            If DateTime.TryParseExact($"{datePart} {timePart}",
                                                   "dd/MM/yy HH:mm:ss",
                                                   CultureInfo.InvariantCulture,
                                                   DateTimeStyles.None,
                                                   dt) Then
                                currentDateTime = dt
                                Invoke(Sub()
                                           lb_DateTimeTimer.Text = currentDateTime.ToString("dd/MM/yy HH:mm:ss")
                                           TimerDateTime.Start()  ' riavvio il timer +1s
                                       End Sub)
                            End If
                        End If

                        ' termino la sequenza update
                        updatingDateTime = False
                        BtnUpdateDateTime.Enabled = True
                    End If

            End Select

            ' finché non ho completato, esco subito
            Return
        End If


        Dim savestep As Integer

        CB_LiveData.Enabled = Not isWriting

        If isWriting Then
            Select Case writeStep
                Case 1
                    InviaStringa("7")
                    writeStep += 1
                    ResetInactivityTimer()
                Case 2
                    If tb_COMStrem.Text.Contains("Please set speed 1 > 25% (ex. 25...30...40):") Then
                        InviaStringa(customerData.FSC_CAF_Speed1.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 3
                    If tb_COMStrem.Text.Contains("Please set speed 2 > speed 1 :") Then
                        InviaStringa(customerData.FSC_CAF_Speed2.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 4
                    If tb_COMStrem.Text.Contains("Please set speed 3 > speed 2 :") Then
                        InviaStringa(customerData.FSC_CAF_Speed3.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 5
                    If tb_COMStrem.Text.Contains("Please set speed 1 > 30 Pa (ex. 30...35...50):") Then
                        InviaStringa(num_Speed1CAP.Value.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 6
                    If tb_COMStrem.Text.Contains("Please set speed 2 > speed 1 : ") Then
                        InviaStringa(num_Speed2CAP.Value.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 7
                    If tb_COMStrem.Text.Contains("Please set speed 3 > speed 2 : ") Then
                        InviaStringa(num_Speed3CAP.Value.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 8
                    If tb_COMStrem.Text.Contains("Please set Boost Timer (min:15, max:240) :") Then
                        InviaStringa(num_BoostTimer.Value.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 9
                    If tb_COMStrem.Text.Contains("Please set Filter Timer (min:30, max:180) :") Then
                        InviaStringa(num_FilterTimer.Value.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 10
                    If tb_COMStrem.Text.Contains("Please set Fire Kit timer (min:10, max:120) :") Then
                        InviaStringa(num_FKITimer.Value.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 11
                    If tb_COMStrem.Text.Contains("Please set CO2 Level (min:700, max:1500) :") Then
                        InviaStringa(num_CO2Setpoint.Value.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 12
                    If tb_COMStrem.Text.Contains("Please set RH Level (min:20, max:99) :") Then
                        InviaStringa(num_RHSetpoint.Value.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 13
                    If tb_COMStrem.Text.Contains("Please set VOC Level (min:2, max:100) :") Then
                        InviaStringa(num_VOCSetpoint.Value.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 14
                    If tb_COMStrem.Text.Contains("Please set Temperature (min:12, max:32) :") Then
                        InviaStringa(num_TempSetpoint.Value.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 15
                    If tb_COMStrem.Text.Contains("Please set SUM/WIN (min:12, max:32) :") Then
                        InviaStringa(num_SWSetpoint.Value.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 16
                    If tb_COMStrem.Text.Contains("Please set FRESH inlet configuration (l=left, r=right ) :") Then
                        If RB_right.Checked Then
                            InviaStringa("r")
                        Else
                            InviaStringa("l")
                        End If
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 17
                    If tb_COMStrem.Text.Contains("Please set KHK conf. (2=Ds NC, 3=En NC, 4=Ds No, 5=Ds NC ) : ") Then
                        InviaStringa(customerData.KHK_VALUE.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 18
                    If tb_COMStrem.Text.Contains("Please set IMBALANCE value  (min:-70, max:70) :") Then
                        InviaStringa(customerData.IMBALANCESetPoint1.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 19
                    If tb_COMStrem.Text.Contains("Please Enable IMBALANCE") Then
                        InviaStringa(customerData.IMBALANCE_ENABLE.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 20
                    If tb_COMStrem.Text.Contains("Please set KHK value  (min:20, max:100) :") Then
                        InviaStringa(customerData.KHK_SET_POINT.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 21
                    If tb_COMStrem.Text.Contains("Please set KHK IMBALANCE value  (min:-70, max:70) :") Then
                        InviaStringa(customerData.KHKIMBALANCESetPoint.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 22
                    If tb_COMStrem.Text.Contains("Please set IMBALANCE 2 value  (min:-70, max:70) :") Then
                        InviaStringa(customerData.IMBALANCESetPoint2.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 23
                    If tb_COMStrem.Text.Contains("Please set IMBALANCE 3 value  (min:-70, max:70) :") Then
                        InviaStringa(customerData.IMBALANCESetPoint3.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 24
                    If tb_COMStrem.Text.Contains("Please set IMBALANCE IAQ value  (min:-70, max:70) :") Then
                        InviaStringa(customerData.IAQ_Imbalance.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 25
                    If tb_COMStrem.Text.Contains("Please set IAQ value  (min:20, max:100) :") Then
                        InviaStringa(customerData.IAQ_Reference.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 26
                    If tb_COMStrem.Text.Contains("Please set Smoke conf. (1=En NC, 2=En NO, 0=Dis) :") Then
                        InviaStringa(customerData.SMOKE_VALUE.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case 27
                    If tb_COMStrem.Text.Contains("Please set Belimo number (1 or 2) :") Then
                        InviaStringa(num_Belimo.Value.ToString())
                        writeStep += 1
                        ResetInactivityTimer()
                    End If
                Case Else
                    Await Task.Delay(6000)
                    isWriting = False
                    PB_SaveData.Visible = isWriting
                    PB_SaveData.Value = 0
                    lb_SaveProg.Visible = isWriting
                    writeStep = 1
                    lb_status.Text = "Data successfully saved"
                    ResetInactivityTimer()
            End Select

            If (isWriting) Then
                savestep = (writeStep - 1) / 27 * 100
                PB_SaveData.Value = savestep
                lb_SaveProg.Text = savestep.ToString() + " %"
            End If

        Else

            If unitTestRunning Then
                ' Skip automatic reads while the unit test drives the serial workflow.
            ElseIf Not character2Sent Then
                InviaStringa("2")
                character2Sent = True
                ResetInactivityTimer()
                lb_status.Text = "Loading data from quark...please wait"
                VisibleGroups(True)
            ElseIf Not character6Sent Then
                InviaStringa("6")
                character6Sent = True
                ResetInactivityTimer()
            ElseIf character2Sent AndAlso character6Sent AndAlso Not parameterRead Then
                InviaStringa("")
                ExtractConfigData()
                ResetInactivityTimer()
                parameterRead = True
            End If
        End If
    End Sub


    Private Sub ExtractConfigData()
        Dim startPattern As String = "---[ 2  Read Config. Data Unit ]---"
        Dim endPattern As String = "--- END OF READING ---"
        Dim startIndex As Integer = tb_COMStrem.Text.IndexOf(startPattern)
        Dim endIndex As Integer = tb_COMStrem.Text.IndexOf(endPattern)
        If startIndex <> -1 AndAlso endIndex <> -1 AndAlso endIndex > startIndex Then
            Dim dataToParse As String = tb_COMStrem.Text.Substring(startIndex + startPattern.Length, endIndex - (startIndex + startPattern.Length))
            ParseCustomerData(dataToParse, customerData)
        End If
        lb_status.Text = "Data loaded successfully."
        If txtUnitTestSerial IsNot Nothing AndAlso String.IsNullOrWhiteSpace(txtUnitTestSerial.Text) Then
            txtUnitTestSerial.Text = customerData.SerialNumber
        End If
        num_F_Speed1.Enabled = True
        num_F_Speed2.Enabled = True
        num_F_Speed3.Enabled = True
        num_F_IAQSpeed.Enabled = True
        num_R_Speed1.Enabled = True
        num_R_Speed2.Enabled = True
        num_R_Speed3.Enabled = True
        num_R_IAQSpeed.Enabled = True
        num_BoostTimer.Enabled = True
        num_FilterTimer.Enabled = True
        num_RHSetpoint.Enabled = True
        num_TempSetpoint.Enabled = True
        CB_LiveData.Enabled = True
        If (customerData.SUM_WINSetPoint = 99) Then
            CB_BPDisable.Checked = True
        Else
            CB_BPDisable.Checked = False
            num_SWSetpoint.Enabled = True
        End If
        If (customerData.RHSetPoint = 99) Then
            CB_RHDisable.Checked = True
        Else
            CB_RHDisable.Checked = False
            num_SWSetpoint.Enabled = True
        End If
    End Sub


    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim receivedData As String = SerialPort1.ReadExisting()

        ' Accumula i dati nel buffer
        SyncLock logBuffer
            logBuffer.Append(receivedData)

            ' Controlla se il buffer contiene una linea completa
            While True
                Dim s As String = logBuffer.ToString()
                Dim lineEndIndex As Integer = s.IndexOf(vbLf)
                If lineEndIndex < 0 Then Exit While

                Dim completeLine As String = s.Substring(0, lineEndIndex).Trim()
                logBuffer.Remove(0, lineEndIndex + 1)

                ' Start/End LIVE DATA
                If completeLine = LiveStartMarker Then
                    readingLiveData = True
                    liveDataBuffer.Clear()
                    Continue While
                ElseIf completeLine = LiveEndMarker Then
                    readingLiveData = False
                    ' Parse e aggiorna UI
                    Dim live = ParseLiveDataBlock(liveDataBuffer)

                    ' 3) se live contiene dati validi, aggiorna la UI
                    If live IsNot Nothing AndAlso live.IsValid Then
                        lastLiveDataSnapshot = CloneLiveData(live)
                        lastLiveDataTimestamp = DateTime.Now
                        AddLiveDataHistory(lastLiveDataSnapshot)
                        If Me.IsHandleCreated AndAlso Not Me.IsDisposed Then
                            Me.Invoke(Sub()
                                          ' Esempio: aggiorna due label
                                          lblTFresh.Text = $"{live.TemperatureFresh:F1} °C"
                                          lblTReturn.Text = $"{live.TemperatureReturn:F1} °C"
                                          lblTSupply.Text = $"{live.TemperatureSupply:F1} °C"
                                          lblTExhaust.Text = $"{live.TemperatureExhaust:F1} °C"
                                          lblTHeater.Text = $"{live.TemperatureHeater:F1} °C"
                                          lblVSupply.Text = $"{live.FeedbackVMotorF:F1} V"
                                          lblRPMSupply.Text = $"{live.RPMMotorF:D4} rpm"
                                          lblVReturn.Text = $"{live.FeedbackVMotorR:F1} V"
                                          lblRPMReturn.Text = $"{live.RPMMotorR:D4} rpm"
                                          TB_alarm.Text = live.GetAlarmCodes()
                                          If customerData.Configuration IsNot Nothing AndAlso customerData.Configuration.Contains("LEFT") Then
                                              lblRFresh.Text = $"{live.HumidityLeft:F0} %"
                                              lblRReturn.Text = $"{live.HumidityRight:F0} %"
                                          ElseIf customerData.Configuration IsNot Nothing AndAlso customerData.Configuration.Contains("RIGHT") Then
                                              lblRFresh.Text = $"{live.HumidityRight:F0} %"
                                              lblRReturn.Text = $"{live.HumidityLeft:F0} %"
                                          End If
                                          UpdateStatusBar(live)
                                      End Sub)
                        End If
                    End If

                    liveDataBuffer.Clear()
                    Continue While
                ElseIf readingLiveData Then
                    liveDataBuffer.Add(completeLine)
                    Continue While
                End If



                ' Se è la riga di data/ora, la parsifico qui
                If completeLine.StartsWith("Data:") Then
                    ' Esempio: "Data: 09/06/25  Ora: 14:23:45"
                    Dim parts() As String = Regex.Split(completeLine, "Ora:")
                    If parts.Length = 2 Then
                        Dim datePart As String = parts(0).Replace("Data:", "").Trim()
                        Dim timePart As String = parts(1).Trim()
                        Dim dt As DateTime
                        If DateTime.TryParseExact($"{datePart} {timePart}",
                                              "dd/MM/yy HH:mm:ss",
                                              CultureInfo.InvariantCulture,
                                              DateTimeStyles.None,
                                              dt) Then
                            currentDateTime = dt
                            ' Aggiorno immediatamente la label sulla UI
                            Invoke(Sub()
                                       lb_DateTimeTimer.Text = currentDateTime.ToString("dd/MM/yy HH:mm:ss")

                                       ' Avvio il timer per +1s a ogni tick
                                       TimerDateTime.Start()
                                   End Sub)
                        End If
                        updatingDateTime = False
                        Invoke(Sub()
                                   BtnUpdateDateTime.Enabled = True
                               End Sub)
                    End If
                Else
                    ' Scrivi la linea nel log e aggiorna l'interfaccia grafica
                    Invoke(Sub()
                               tb_COMStrem.AppendText(completeLine & Environment.NewLine)
                               AppendLogData(completeLine) ' Scrive solo righe complete nel log
                           End Sub)
                End If

            End While

            If logBuffer.Length > 0 AndAlso Not logBuffer.ToString().Contains(vbLf) Then
                Invoke(Sub()
                           tb_COMStrem.AppendText(logBuffer.ToString())
                           AppendLogData(logBuffer.ToString())
                           logBuffer.Clear()
                       End Sub)
            End If

        End SyncLock


    End Sub


    Private Sub TimerDateTime_Tick(sender As Object, e As EventArgs) Handles TimerDateTime.Tick
        ' Simulo l'orologio che avanza di 1 secondo
        currentDateTime = currentDateTime.AddSeconds(1)
        lb_DateTimeTimer.Text = currentDateTime.ToString("dd/MM/yy HH:mm:ss")
    End Sub


    Private Sub Btn_Connect_Click(sender As Object, e As EventArgs) Handles Btn_Connect.Click
        Try
            If (Not COM_List.Text.Contains("COM")) Then
                MsgBox("Please check connection and power supply on Quark unit")
            Else
                Btn_FirmwareUpdate.Enabled = False
                SerialPort1.PortName = COM_List.Text
                SerialPort1.BaudRate = 9600
                SerialPort1.Encoding = Encoding.Default
                SerialPort1.DtrEnable = True
                SerialPort1.NewLine = vbLf

                SerialPort1.Open()

                isConnected = SerialPort1.IsOpen
                lb_status.Text = If(isConnected, "Serial " & COM_List.Text & " port is opened", "Failed to open serial port.")
                InitializeLiveDataLabels()
                ToggleControls(isConnected)
                StartInactivityTimer()
                If hiddenPages.Contains(TP_TestUnit) Then
                    Tab_Main.TabPages.Add(TP_TestUnit)
                    hiddenPages.Remove(TP_TestUnit)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Btn_Disconnect_Click(sender As Object, e As EventArgs) Handles Btn_Disconnect.Click
        Try
            Btn_FirmwareUpdate.Enabled = True
            SerialPort1.Close()
            isConnected = False
            lb_status.Text = "Serial " & SerialPort1.PortName & " port is closed"
            ClearStatusBar()
            ToggleControls(isConnected)
            Refresh_Data()
            StopInactivityTimer()
            VisibleGroups(False)
            InitializeLiveDataLabels()
            If Tab_Main.TabPages.Contains(TP_TestUnit) Then
                Tab_Main.TabPages.Remove(TP_TestUnit)
                hiddenPages.Add(TP_TestUnit)
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Btn_SendData_Click(sender As Object, e As EventArgs) Handles Btn_SendData.Click
        If SerialPort1.IsOpen Then
            InviaStringa(Input_String.Text)
            Input_String.Clear()
        End If
    End Sub

    Private Sub InviaStringa(ByVal testo As String)
        If SerialPort1.IsOpen Then
            SerialPort1.Write(testo & SerialPort1.NewLine)
        End If
    End Sub

    Private Sub ParseCustomerData(data As String, customerData As CustomerData, Optional updateUI As Boolean = True)

        Dim lines() As String = data.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)


        For Each line As String In lines

            Dim colonIndex As Integer = line.IndexOf(":")
            If colonIndex <> -1 AndAlso colonIndex < line.Length - 1 Then

                Dim name As String = line.Substring(0, colonIndex).Trim()
                Dim value As String = line.Substring(colonIndex + 1).Trim()


                'Dim numericValue As String = Regex.Replace(value, "[^\d]", "")
                Dim numericValue As String = Regex.Replace(value, "[^-?\d+]", "")
                'Dim numericValue As String = Regex.Replace(value, "^-?\d+", "")
                Dim numero As Int16


                Select Case name
                    Case "2.03-Version HW..."
                        customerData.VersionHW = value
                    Case "2.04-Version SW..."
                        customerData.VersionSW = value
                    Case "2.05-Serial Number"
                        customerData.SerialNumber = value
                    Case "2.14-PreConf.Acces"
                        customerData.Accessories = value
                    Case "FSC_CAF speed 1"
                        Integer.TryParse(numericValue, customerData.FSC_CAF_Speed1)
                    Case "FSC_CAF speed 2"
                        Integer.TryParse(numericValue, customerData.FSC_CAF_Speed2)
                    Case "FSC_CAF speed 3"
                        Integer.TryParse(numericValue, customerData.FSC_CAF_Speed3)
                    Case "CAP speed 1"
                        Integer.TryParse(numericValue, customerData.CAP_Speed1)
                    Case "CAP speed 2"
                        Integer.TryParse(numericValue, customerData.CAP_Speed2)
                    Case "CAP speed 3"
                        Integer.TryParse(numericValue, customerData.CAP_Speed3)
                    Case "Boost timer"
                        Integer.TryParse(numericValue, customerData.BoostTimer)
                    Case "Filter timer"
                        Integer.TryParse(numericValue, customerData.FilterTimer)
                    Case "Fire Kit timer"
                        Integer.TryParse(numericValue, customerData.FireKitTimer)
                    Case "CO2 Set Point"
                        Integer.TryParse(numericValue, customerData.CO2SetPoint)
                    Case "RH Set Point"
                        Integer.TryParse(numericValue, customerData.RHSetPoint)
                    Case "VOC Set Point"
                        Integer.TryParse(numericValue, customerData.VOCSetPoint)
                    Case "Temp. Set Point"
                        Integer.TryParse(numericValue, customerData.TempSetPoint)
                    Case "SUM/WIN Set Point"
                        Integer.TryParse(numericValue, customerData.SUM_WINSetPoint)
                    Case "IMBALANCE Set Point"
                        SByte.TryParse(numericValue, customerData.IMBALANCESetPoint1)
                    Case "KHK Set Point"
                        SByte.TryParse(numericValue, numero)
                        If (numero < customerData.FSC_CAF_Speed3) Then
                            customerData.KHK_SET_POINT = customerData.FSC_CAF_Speed3
                        Else
                            customerData.KHK_SET_POINT = numero
                        End If
                    Case "Configuration"
                        customerData.Configuration = value
                    Case "KHK Config"
                        SByte.TryParse(value, numero)
                        If numero < 2 AndAlso numero > 5 Then
                            numero = 2
                        End If
                        customerData.KHK_VALUE = numero
                    Case "IMBALANCE Enable"
                        customerData.IMBALANCE_ENABLE = value
                    Case "IMBALANCE KHK Set Point"
                        SByte.TryParse(numericValue, customerData.KHKIMBALANCESetPoint)
                    Case "IMBALANCE 2 Set Point"
                        SByte.TryParse(numericValue, customerData.IMBALANCESetPoint2)
                    Case "IMBALANCE 3 Set Point"
                        SByte.TryParse(numericValue, customerData.IMBALANCESetPoint3)
                    Case "IAQ Set Point"
                        Integer.TryParse(numericValue, customerData.IAQ_Reference)
                    Case "IMBALANCE IAQ"
                        SByte.TryParse(numericValue, customerData.IAQ_Imbalance)
                    Case "BELIMO"
                        SByte.TryParse(numericValue, customerData.Belimo)
                    Case "INPUT 2"
                        SByte.TryParse(value, numero)
                        If numero < 0 AndAlso numero > 2 Then
                            numero = 0
                        End If
                        customerData.SMOKE_VALUE = numero
                    Case "NO_FKI"
                        SByte.TryParse(numericValue, customerData.no_FKI)
                End Select
            End If
        Next

        If updateUI Then
            UpdateFormControls()
        End If

    End Sub

    Private Sub Btn_RefreshData_Click(sender As Object, e As EventArgs) Handles Btn_RefreshData.Click
        Refresh_Data()
    End Sub
    Private Sub RB_left_CheckedChanged(sender As Object, e As EventArgs) Handles RB_left.CheckedChanged
        If RB_left.Checked = True Then
            PcBx_Quark.Image = My.Resources._412_DRAW_QUARK_FL_D
            'MessageBox.Show("In case of F7 filter check that it is on the fresh position (LEFT)", "Update Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            customerData.Configuration = "LEFT"
        End If
    End Sub

    Private Sub RB_right_CheckedChanged(sender As Object, e As EventArgs) Handles RB_right.CheckedChanged
        If RB_right.Checked = True Then
            PcBx_Quark.Image = My.Resources._411_DRAW_QUARK_FL_C
            'MessageBox.Show("In case of F7 filter check that it is on the fresh position (RIGHT)", "Update Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            customerData.Configuration = "RIGHT"
        End If
    End Sub

    Private Sub F_Speed1_ValueChanged(sender As Object, e As EventArgs) Handles num_F_Speed1.ValueChanged

        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_Speed1.Value, num_R_Speed1.Value, 1)
        Else
            num_R_Speed1.Value = num_F_Speed1.Value
            customerData.UpdateSpeedSettings(num_F_Speed1.Value, num_R_Speed1.Value, 1)
        End If

    End Sub

    Private Sub F_Speed2_ValueChanged(sender As Object, e As EventArgs) Handles num_F_Speed2.ValueChanged

        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_Speed2.Value, num_R_Speed2.Value, 2)
        Else
            num_R_Speed2.Value = num_F_Speed2.Value
            customerData.UpdateSpeedSettings(num_F_Speed2.Value, num_R_Speed2.Value, 2)
        End If

    End Sub

    Private Sub F_Speed3_ValueChanged(sender As Object, e As EventArgs) Handles num_F_Speed3.ValueChanged

        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_Speed3.Value, num_R_Speed3.Value, 3)
        Else
            num_R_Speed3.Value = num_F_Speed3.Value
            customerData.UpdateSpeedSettings(num_F_Speed3.Value, num_R_Speed3.Value, 3)
        End If

    End Sub


    Private Sub R_Speed1_ValueChanged(sender As Object, e As EventArgs) Handles num_R_Speed1.ValueChanged

        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_Speed1.Value, num_R_Speed1.Value, 1)

        Else
            num_F_Speed1.Value = num_R_Speed1.Value
            customerData.UpdateSpeedSettings(num_F_Speed1.Value, num_R_Speed1.Value, 1)

        End If

    End Sub

    Private Sub R_Speed2_ValueChanged(sender As Object, e As EventArgs) Handles num_R_Speed2.ValueChanged

        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_Speed2.Value, num_R_Speed2.Value, 2)

        Else
            num_F_Speed2.Value = num_R_Speed2.Value
            customerData.UpdateSpeedSettings(num_F_Speed2.Value, num_R_Speed2.Value, 2)

        End If

    End Sub

    Private Sub R_Speed3_ValueChanged(sender As Object, e As EventArgs) Handles num_R_Speed3.ValueChanged

        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_Speed3.Value, num_R_Speed3.Value, 3)

        Else
            num_F_Speed3.Value = num_R_Speed3.Value
            customerData.UpdateSpeedSettings(num_F_Speed3.Value, num_R_Speed3.Value, 3)

        End If

    End Sub

    Private Sub num_F_IAQSpeed_ValueChanged(sender As Object, e As EventArgs) Handles num_F_IAQSpeed.ValueChanged
        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_IAQSpeed.Value, num_R_IAQSpeed.Value, 4)
        Else
            num_R_IAQSpeed.Value = num_F_IAQSpeed.Value
            customerData.UpdateSpeedSettings(num_F_IAQSpeed.Value, num_R_IAQSpeed.Value, 4)
        End If
    End Sub

    Private Sub num_R_IAQSpeed_ValueChanged(sender As Object, e As EventArgs) Handles num_R_IAQSpeed.ValueChanged
        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_IAQSpeed.Value, num_R_IAQSpeed.Value, 4)
        Else
            num_F_IAQSpeed.Value = num_R_IAQSpeed.Value
            customerData.UpdateSpeedSettings(num_F_IAQSpeed.Value, num_R_IAQSpeed.Value, 4)
        End If
    End Sub


    Private Sub Speed1CAP_ValueChanged(sender As Object, e As EventArgs) Handles num_Speed1CAP.ValueChanged

        If num_Speed1CAP.Value > num_Speed2CAP.Value Then
            num_Speed2CAP.Value = num_Speed1CAP.Value
        End If
    End Sub

    Private Sub Speed2CAP_ValueChanged(sender As Object, e As EventArgs) Handles num_Speed2CAP.ValueChanged

        If num_Speed2CAP.Value > num_Speed3CAP.Value Then
            num_Speed3CAP.Value = num_Speed2CAP.Value
        End If
        If num_Speed2CAP.Value < num_Speed1CAP.Value Then
            num_Speed1CAP.Value = num_Speed2CAP.Value
        End If
    End Sub

    Private Sub Speed3CAP_ValueChanged(sender As Object, e As EventArgs) Handles num_Speed3CAP.ValueChanged

        If num_Speed3CAP.Value < num_Speed2CAP.Value Then
            num_Speed2CAP.Value = num_Speed3CAP.Value
        End If
    End Sub

    Private Function ShowSaveDisclaimer() As Boolean
        Dim msg = "Please double-check the number of configured FKI actuators or verify the jumper position." & vbCrLf &
              "Refer to the manual for the correct jumper setting before proceeding." & vbCrLf & vbCrLf &
              "Continue with saving?"
        Return MessageBox.Show(msg, "Important Safety Check",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK
    End Function


    Private Sub Btn_SaveData_Click(sender As Object, e As EventArgs) Handles Btn_SaveData.Click
        If Not ShowSaveDisclaimer() Then Exit Sub
        isWriting = True
        PB_SaveData.Visible = isWriting
        lb_SaveProg.Visible = isWriting
        lb_status.Text = "Saving data... please wait"
    End Sub

    Private Sub UpdateKHKValue()
        Dim khkValueTemp As Byte = 0

        If CB_KHKenable.Checked Then
            khkValueTemp = khkValueTemp Or &H1 ' Bit 0: KHK Abilitato
        End If

        ' Bit 1: Comportamento Contatto (NC/NO)
        If RB_NC.Checked Then
            khkValueTemp = khkValueTemp Or &H2 ' Imposta bit 1 per NC
        End If

        ' Bit 2: Logica Timer/Uscita KHK (NUOVA LOGICA FIRMWARE)
        If CB_DisableTemperatureControl.Checked Then
            khkValueTemp = khkValueTemp Or &H4 ' Imposta bit 2 a 1 (disabilita logica timer nel firmware)
        Else
            ' Bit 2 rimane 0 (abilita logica timer nel firmware)
        End If

        customerData.KHK_VALUE = khkValueTemp
    End Sub

    Private Sub UpdateSmokeValue()
        Dim SmokeValueTemp As Byte = 0

        If Not CB_SmokeEnable.Checked Then
            SmokeValueTemp = 0
        Else
            If RB_SmokeNC.Checked Then
                SmokeValueTemp = 1
            Else
                SmokeValueTemp = 2
            End If
        End If

        customerData.SMOKE_VALUE = SmokeValueTemp
    End Sub

    Private Sub KHK_ENABLE_CheckedChanged(sender As Object, e As EventArgs) Handles CB_KHKenable.CheckedChanged
        num_FK_Speed.Enabled = CB_KHKenable.Checked
        num_RK_Speed.Enabled = CB_KHKenable.Checked
        RB_NC.Enabled = CB_KHKenable.Checked
        RB_NO.Enabled = CB_KHKenable.Checked
        CB_DisableTemperatureControl.Enabled = CB_KHKenable.Checked
        UpdateKHKValue()
    End Sub

    Private Sub NC_Button_CheckedChanged(sender As Object, e As EventArgs) Handles RB_NC.CheckedChanged
        If RB_NC.Checked Then UpdateKHKValue()
    End Sub

    Private Sub NO_Button_CheckedChanged(sender As Object, e As EventArgs) Handles RB_NO.CheckedChanged
        If RB_NO.Checked Then UpdateKHKValue()
    End Sub

    Private Sub CB_DisableTemperatureControl_CheckedChanged(sender As Object, e As EventArgs) Handles CB_DisableTemperatureControl.CheckedChanged
        UpdateKHKValue()

        ' Mostra il messaggio di avviso SOLO quando la checkbox viene SPUNTATA
        If CB_DisableTemperatureControl.Checked Then
            MessageBox.Show("By ticking you are accepting your responsibility of keeping the return branch temperature not higher than 40 °C",
                            "Responsibility Acceptance", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Imbalance_Enable_CheckedChanged(sender As Object, e As EventArgs) Handles CB_ImbEnable.CheckedChanged

        If CB_ImbEnable.Checked = True Then
            customerData.IMBALANCE_ENABLE = 1
        Else
            customerData.IMBALANCE_ENABLE = 0
            num_F_Speed1.Value = customerData.FSC_CAF_Speed1
            num_F_Speed2.Value = customerData.FSC_CAF_Speed2
            num_F_Speed3.Value = customerData.FSC_CAF_Speed3
            num_FK_Speed.Value = customerData.KHK_SET_POINT
            num_F_IAQSpeed.Value = customerData.IAQ_Reference
            num_R_Speed1.Value = num_F_Speed1.Value
            num_R_Speed2.Value = num_F_Speed2.Value
            num_R_Speed3.Value = num_F_Speed3.Value
            num_RK_Speed.Value = num_FK_Speed.Value
            num_R_IAQSpeed.Value = num_F_IAQSpeed.Value
        End If

    End Sub

    Private Sub Bootloader_Button_Click(sender As Object, e As EventArgs) Handles Btn_FirmwareUpdate.Click
        Dim FileName As String = IO.Path.Combine(Application.StartupPath, "Firmware_Update.exe")
        Dim BytesToWrite() As Byte = My.Resources.Firmware_Update
        Dim FileStream As New System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate)
        Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)
        BinaryWriter.Write(BytesToWrite)
        BinaryWriter.Close()
        FileStream.Close()
        Process.Start(FileName)
    End Sub

    Private Sub CB_BPDisable_CheckedChanged(sender As Object, e As EventArgs) Handles CB_BPDisable.CheckedChanged
        If (CB_BPDisable.Checked = True) Then
            num_SWSetpoint.Maximum = 99
            num_SWSetpoint.Value = 99
            num_SWSetpoint.Enabled = False
            lbl_DisBypass.ForeColor = Color.Red
        Else
            num_SWSetpoint.Maximum = 32
            num_SWSetpoint.Value = 16
            num_SWSetpoint.Enabled = True
            lbl_DisBypass.ForeColor = Color.Black
        End If
    End Sub

    Private Sub CB_SaveLog_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SaveLog.CheckedChanged
        isLoggingEnabled = CB_SaveLog.Checked
        If isLoggingEnabled Then
            StartNewLogFile()
        End If
    End Sub

    Private Sub CB_Timestamp_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Timestamp.CheckedChanged
        isTimestampEnabled = CB_Timestamp.Checked
    End Sub

    Private Sub FK_Speed_ValueChanged(sender As Object, e As EventArgs) Handles num_FK_Speed.ValueChanged
        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_FK_Speed.Value, num_RK_Speed.Value, 0)

        Else
            num_RK_Speed.Value = num_FK_Speed.Value
            customerData.UpdateSpeedSettings(num_FK_Speed.Value, num_RK_Speed.Value, 0)

        End If
    End Sub

    Private Sub RK_Speed_ValueChanged(sender As Object, e As EventArgs) Handles num_RK_Speed.ValueChanged
        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_FK_Speed.Value, num_RK_Speed.Value, 0)

        Else
            num_FK_Speed.Value = num_RK_Speed.Value
            customerData.UpdateSpeedSettings(num_FK_Speed.Value, num_RK_Speed.Value, 0)

        End If
    End Sub


    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        ' 1. Chiedi all'utente il nome base per il file di configurazione
        Dim baseName As String = Interaction.InputBox("Enter the base name for the configuration file (e.g., MyConfig):", "Save Configuration As")

        ' Controlla se l'utente ha annullato o inserito una stringa vuota
        If String.IsNullOrWhiteSpace(baseName) Then
            Return ' Esce se nessun nome è stato fornito o l'utente ha annullato
        End If

        ' Rimuovi ".xml" se l'utente lo ha accidentalmente digitato, per evitare file tipo "nome.xml.xml"
        If baseName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase) Then
            baseName = baseName.Substring(0, baseName.Length - 4)
        End If

        ' Controlla di nuovo se il nome base è diventato vuoto (es. se l'utente ha scritto solo ".xml")
        If String.IsNullOrWhiteSpace(baseName) Then
            MessageBox.Show("Filename cannot be empty or just '.xml'. Please provide a valid base name.", "Invalid Filename", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validazione basilare dei caratteri del nome file
        Dim invalidChars() As Char = Path.GetInvalidFileNameChars()
        If baseName.IndexOfAny(invalidChars) >= 0 Then
            MessageBox.Show($"The filename '{baseName}' contains invalid characters. Please use a valid name.", "Invalid Filename", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Costruisci il nome del file completo e i percorsi
        Dim fileNameWithExtension As String = baseName & ".xml"
        Dim configFolderPath As String = Path.Combine(Application.StartupPath, "config")
        Dim fullFilePath As String = Path.Combine(configFolderPath, fileNameWithExtension)

        ' Assicura che la cartella "config" esista
        If Not Directory.Exists(configFolderPath) Then
            Try
                Directory.CreateDirectory(configFolderPath)
            Catch ex As Exception
                MessageBox.Show($"Error creating 'config' directory: {ex.Message}", "Directory Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        End If

        ' Controlla se il file esiste già e chiedi conferma per sovrascrivere
        If File.Exists(fullFilePath) Then
            Dim overwriteResult As DialogResult = MessageBox.Show(
                $"The file '{fileNameWithExtension}' already exists in the 'config' folder. Do you want to overwrite it?",
                "File Exists",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            )
            If overwriteResult = DialogResult.No Then
                Return ' L'utente ha scelto di non sovrascrivere
            End If
        End If

        ' 2. Ottieni i dati correnti dell'applicazione da salvare.
        '    Questa funzione DEVE essere implementata correttamente come discusso in precedenza,
        '    per popolare un oggetto CustomerData con lo stato attuale della UI.
        Dim dataToSave As CustomerData = GetCurrentApplicationData()

        ' Controlla se GetCurrentApplicationData ha restituito qualcosa (dovrebbe sempre farlo se implementata bene)
        If dataToSave Is Nothing Then
            MessageBox.Show("Could not retrieve current data to save. Please ensure data is available and GetCurrentApplicationData() is working correctly.", "Data Retrieval Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' NOTA IMPORTANTE:
        ' La riga 'dataToSave.Configuration = baseName' è stata intenzionalmente omessa qui.
        ' La funzione GetCurrentApplicationData() è ora responsabile dell'impostazione corretta
        ' della proprietà 'Configuration' all'interno dell'oggetto 'dataToSave'
        ' (ad esempio, basandosi sullo stato di RB_left.Checked / RB_right.Checked),
        ' se questa proprietà deve riflettere lo stato della UI piuttosto che solo il nome del file.
        ' Il 'baseName' è usato solo per il nome del file su disco.

        ' 3. Serializza l'oggetto CustomerData in XML e salvalo nel file
        Try
            Dim serializer As New XmlSerializer(GetType(CustomerData)) ' Specifica il tipo da serializzare

            ' Using assicura che lo StreamWriter venga chiuso e rilasciato correttamente
            Using writer As New StreamWriter(fullFilePath)
                serializer.Serialize(writer, dataToSave)
            End Using

            MessageBox.Show($"Configuration '{fileNameWithExtension}' saved successfully in the 'config' folder.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' 4. Aggiorna la ListBox (Lsb_FileConfig) per mostrare il nuovo file salvato
            LoadXmlConfigFiles() ' Chiama la subroutine esistente per ricaricare i file nella ListBox

        Catch exSerialization As InvalidOperationException
            ' Errori specifici della serializzazione (es. la classe CustomerData non è serializzabile come previsto)
            MessageBox.Show($"Serialization error: {exSerialization.Message}{vbCrLf}{vbCrLf}Ensure the CustomerData class is public and suitable for XML serialization.", "Serialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch exIO As IOException
            ' Errori di Input/Output durante la scrittura del file
            MessageBox.Show($"File I/O error while saving '{fileNameWithExtension}': {exIO.Message}", "File Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Qualsiasi altra eccezione imprevista
            MessageBox.Show($"An unexpected error occurred while saving configuration: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Apply_Click(sender As Object, e As EventArgs) Handles Btn_Apply.Click
        ' 1. Controlla se un file è selezionato nella ListBox Lsb_FileConfig
        If Lsb_FileConfig.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a configuration file from the list to apply.", "No File Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedFileName As String = Lsb_FileConfig.SelectedItem.ToString()
        If selectedFileName = "No XML files found." OrElse selectedFileName = "Error accessing 'config' folder." OrElse selectedFileName = "Access denied to 'config' folder." OrElse selectedFileName = "Unexpected error." Then
            MessageBox.Show("Please select a valid configuration file.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Costruisci il percorso completo del file XML selezionato
        Dim configFolderPath As String = Path.Combine(Application.StartupPath, "config")
        Dim fullFilePath As String = Path.Combine(configFolderPath, selectedFileName)

        ' 3. Verifica che il file esista effettivamente
        If Not File.Exists(fullFilePath) Then
            MessageBox.Show($"The selected configuration file '{selectedFileName}' was not found in the 'config' folder.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Opzionale: ricarica la lista se il file è sparito
            ' LoadXmlConfigFiles()
            Return
        End If

        ' 4. Deserializza il file XML in un oggetto CustomerData
        Dim loadedConfigData As CustomerData = Nothing
        Try
            Dim serializer As New XmlSerializer(GetType(CustomerData))
            Using reader As New StreamReader(fullFilePath)
                loadedConfigData = CType(serializer.Deserialize(reader), CustomerData)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading or parsing the configuration file '{selectedFileName}':{vbCrLf}{ex.Message}", "Load Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If loadedConfigData Is Nothing Then
            MessageBox.Show($"Could not deserialize data from '{selectedFileName}'. The file might be corrupted or not a valid configuration file.", "Deserialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 5. Applica i valori dall'oggetto caricato (loadedConfigData) a Me.customerData
        '    Questo è l'oggetto "vivo" del tuo form.
        Try
            ' --- Applica le impostazioni di configurazione generali ---
            Me.customerData.FSC_CAF_Speed1 = loadedConfigData.FSC_CAF_Speed1
            Me.customerData.FSC_CAF_Speed2 = loadedConfigData.FSC_CAF_Speed2
            Me.customerData.FSC_CAF_Speed3 = loadedConfigData.FSC_CAF_Speed3

            Me.customerData.CAP_Speed1 = loadedConfigData.CAP_Speed1
            Me.customerData.CAP_Speed2 = loadedConfigData.CAP_Speed2
            Me.customerData.CAP_Speed3 = loadedConfigData.CAP_Speed3

            Me.customerData.BoostTimer = loadedConfigData.BoostTimer
            Me.customerData.FilterTimer = loadedConfigData.FilterTimer
            Me.customerData.FireKitTimer = loadedConfigData.FireKitTimer

            Me.customerData.CO2SetPoint = loadedConfigData.CO2SetPoint
            Me.customerData.RHSetPoint = loadedConfigData.RHSetPoint
            Me.customerData.VOCSetPoint = loadedConfigData.VOCSetPoint
            Me.customerData.TempSetPoint = loadedConfigData.TempSetPoint
            Me.customerData.SUM_WINSetPoint = loadedConfigData.SUM_WINSetPoint
            Me.customerData.Belimo = loadedConfigData.Belimo

            Me.customerData.Configuration = loadedConfigData.Configuration ' Per LEFT/RIGHT

            ' Impostazioni KHK
            Me.customerData.KHK_ENABLE = loadedConfigData.KHK_ENABLE
            Me.customerData.KHK_NC = loadedConfigData.KHK_NC
            Me.customerData.KHK_NO = loadedConfigData.KHK_NO
            Me.customerData.KHK_VALUE = loadedConfigData.KHK_VALUE
            Me.customerData.KHK_SET_POINT = loadedConfigData.KHK_SET_POINT
            Me.customerData.KHKIMBALANCESetPoint = loadedConfigData.KHKIMBALANCESetPoint


            ' Impostazioni Sbilanciamento
            Me.customerData.IMBALANCE_ENABLE = loadedConfigData.IMBALANCE_ENABLE
            Me.customerData.IMBALANCESetPoint1 = loadedConfigData.IMBALANCESetPoint1
            Me.customerData.IMBALANCESetPoint2 = loadedConfigData.IMBALANCESetPoint2
            Me.customerData.IMBALANCESetPoint3 = loadedConfigData.IMBALANCESetPoint3

            'Impostazioni IAQ
            Me.customerData.IAQ_Imbalance = loadedConfigData.IAQ_Imbalance
            Me.customerData.IAQ_Reference = loadedConfigData.IAQ_Reference

            Me.customerData.SMOKE_VALUE = loadedConfigData.SMOKE_VALUE

            ' --- Applica condizionatamente i dati specifici della macchina ---
            ' Questi verranno aggiornati solo se il file di configurazione caricato
            ' contiene effettivamente valori non vuoti per essi.
            ' Dato che abbiamo deciso di non salvarli, questa condizione solitamente
            ' non sovrascriverà i valori attuali della macchina con stringhe vuote.
            If Not String.IsNullOrEmpty(loadedConfigData.VersionHW) Then
                Me.customerData.VersionHW = loadedConfigData.VersionHW
            End If
            If Not String.IsNullOrEmpty(loadedConfigData.VersionSW) Then
                Me.customerData.VersionSW = loadedConfigData.VersionSW
            End If
            If Not String.IsNullOrEmpty(loadedConfigData.SerialNumber) Then
                Me.customerData.SerialNumber = loadedConfigData.SerialNumber
            End If

            ' 6. Aggiorna l'interfaccia utente per riflettere i nuovi dati in Me.customerData
            UpdateFormControls()

            MessageBox.Show($"Configuration '{selectedFileName}' applied successfully.", "Configuration Applied", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show($"An error occurred while applying the configuration: {ex.Message}", "Apply Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Rem_Click(sender As Object, e As EventArgs) Handles Btn_Rem.Click
        ' 1. Controlla se un elemento è selezionato nella ListBox
        If Lsb_FileConfig.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a configuration file from the list to remove.", "No File Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedFileName As String = Lsb_FileConfig.SelectedItem.ToString()

        ' 2. Controlla che l'elemento selezionato non sia un messaggio informativo
        Dim informationalMessages As New List(Of String) From {
        "No XML files found.",
        "Error accessing 'config' folder.",
        "Access denied to 'config' folder.",
        "Unexpected error."
    }

        If informationalMessages.Contains(selectedFileName) Then
            MessageBox.Show("The selected item is not a configuration file. Please select an actual file to remove.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 3. Costruisci il percorso completo del file
        Dim configFolderPath As String = Path.Combine(Application.StartupPath, "config")
        Dim fullFilePath As String = Path.Combine(configFolderPath, selectedFileName)

        ' 4. Chiedi conferma all'utente prima di cancellare
        Dim confirmationMessage As String = $"Are you sure you want to permanently delete the file '{selectedFileName}'?" & vbCrLf & "This action cannot be undone."
        Dim confirmationResult As DialogResult = MessageBox.Show(confirmationMessage, "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        ' 5. Se l'utente conferma, procedi con la cancellazione
        If confirmationResult = DialogResult.Yes Then
            Try
                ' Verifica ulteriormente se il file esiste prima di tentare la cancellazione
                If File.Exists(fullFilePath) Then
                    File.Delete(fullFilePath)
                    MessageBox.Show($"File '{selectedFileName}' has been deleted successfully.", "File Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show($"The file '{selectedFileName}' could not be found. It might have been already deleted.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch exIO As IOException
                ' Gestisce errori comuni di I/O, come file in uso o problemi di permessi
                MessageBox.Show($"An I/O error occurred while trying to delete '{selectedFileName}':{vbCrLf}{exIO.Message}{vbCrLf}The file might be in use by another process, or you might not have the necessary permissions.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch exUnauthorized As UnauthorizedAccessException
                ' Gestisce specificamente errori di permessi negati
                MessageBox.Show($"Access denied. You do not have permission to delete the file '{selectedFileName}'.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                ' Gestisce qualsiasi altra eccezione imprevista
                MessageBox.Show($"An unexpected error occurred while trying to delete '{selectedFileName}':{vbCrLf}{ex.Message}", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' 6. Aggiorna la ListBox in ogni caso (per riflettere la cancellazione o se il file non è stato trovato)
            LoadXmlConfigFiles()
        End If
    End Sub

    Private Sub BtnUpdateDateTime_Click(sender As Object, e As EventArgs) Handles BtnUpdateDateTime.Click
        If Not SerialPort1.IsOpen Then
            MessageBox.Show("Porta seriale non aperta.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' ── RESET COMPLETO PRIMA DI RIPARTIRE ──
        updatingDateTime = False
        dateTimeStep = 0
        sentPcTimestamp = False

        logBuffer.Clear()               ' buffer interno
        tb_COMStrem.Clear()             ' TextBox di log
        SerialPort1.DiscardInBuffer()   ' scarta byte pendenti
        SerialPort1.DiscardOutBuffer()  ' scarta dati in uscita

        ' ── GARANTISCO IL TIMER ATTIVO ──
        If Not SerialDataTimer.Enabled Then SerialDataTimer.Start()

        ' ── INIZIO SEQUENZA ──
        updatingDateTime = True
        dateTimeStep = 1
        ' Invio 'A' **con newline** per sbloccare subito il firmware
        InviaStringa("A")
        ResetInactivityTimer()

        BtnUpdateDateTime.Enabled = False

    End Sub

    Private Sub UpdateSmokeControls()
        RB_SmokeNC.Enabled = CB_SmokeEnable.Checked
        RB_SmokeNO.Enabled = CB_SmokeEnable.Checked
    End Sub

    Private Sub CB_SmokeEnable_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SmokeEnable.CheckedChanged
        UpdateSmokeControls()
        UpdateSmokeValue()
    End Sub

    Private Sub RB_SmokeNC_CheckedChanged(sender As Object, e As EventArgs) Handles RB_SmokeNC.CheckedChanged
        UpdateSmokeValue()
    End Sub

    Private Sub RB_SmokeNO_CheckedChanged(sender As Object, e As EventArgs) Handles RB_SmokeNO.CheckedChanged
        UpdateSmokeValue()
    End Sub
    Private Function ParseLiveDataBlock(lines As List(Of String)) As LiveData
        Dim data As New LiveData()
        Dim alarmPattern As New Regex("Alarm\[\s*(\d+)\s*\]\s*:\s*(\d+)")
        Dim validFields As Integer = 0

        For Each l In lines
            Dim parts = l.Split({":"c}, 2)
            If parts.Length <> 2 Then Continue For

            Dim key = parts(0).Trim()
            Dim val = parts(1).Trim()

            Select Case True
                Case key.StartsWith("Temperature Fresh")
                    Dim d As Double
                    If Double.TryParse(val, NumberStyles.Float, CultureInfo.InvariantCulture, d) Then
                        data.TemperatureFresh = d
                        validFields += 1
                    End If

                Case key.StartsWith("Temperature Return")
                    Dim d As Double
                    If Double.TryParse(val, NumberStyles.Float, CultureInfo.InvariantCulture, d) Then
                        data.TemperatureReturn = d
                        validFields += 1
                    End If

                Case key.StartsWith("Temperature Supply")
                    Dim d As Double
                    If Double.TryParse(val, NumberStyles.Float, CultureInfo.InvariantCulture, d) Then
                        data.TemperatureSupply = d
                        validFields += 1
                    End If

                Case key.StartsWith("Temperature Exhaust")
                    Dim d As Double
                    If Double.TryParse(val, NumberStyles.Float, CultureInfo.InvariantCulture, d) Then
                        data.TemperatureExhaust = d
                        validFields += 1
                    End If

                Case key.StartsWith("Humidity Left")
                    Dim i As Integer
                    If Integer.TryParse(val, i) Then
                        data.HumidityLeft = i
                        validFields += 1
                    End If

                Case key.StartsWith("Humidity Right")
                    Dim i As Integer
                    If Integer.TryParse(val, i) Then
                        data.HumidityRight = i
                        validFields += 1
                    End If

                Case key.StartsWith("T Heater")
                    Dim d As Double
                    If Double.TryParse(val, NumberStyles.Float, CultureInfo.InvariantCulture, d) Then
                        data.TemperatureHeater = d
                        validFields += 1
                    End If

                Case key.StartsWith("Feedback V Motor R")
                    Dim d As Double
                    If Double.TryParse(val, NumberStyles.Float, CultureInfo.InvariantCulture, d) Then
                        data.FeedbackVMotorR = d
                        validFields += 1
                    End If

                Case key.StartsWith("RPM Motor R")
                    Dim i As Integer
                    If Integer.TryParse(val, i) Then
                        data.RPMMotorR = i
                        validFields += 1
                    End If

                Case key.StartsWith("Feedback V Motor F")
                    Dim d As Double
                    If Double.TryParse(val, NumberStyles.Float, CultureInfo.InvariantCulture, d) Then
                        data.FeedbackVMotorF = d
                        validFields += 1
                    End If

                Case key.StartsWith("RPM Motor F")
                    Dim i As Integer
                    If Integer.TryParse(val, i) Then
                        data.RPMMotorF = i
                        validFields += 1
                    End If

                Case key.StartsWith("Belimo1 Contacts"), key.StartsWith("Belimo2 Contacts")
                    ' Salta riga header
                    Continue For

                Case key.StartsWith("IN5")
                    Dim bits = val.Split({"  "}, StringSplitOptions.RemoveEmptyEntries)
                    If bits.Length = 4 Then
                        data.Belimo1_Inputs(0) = bits(0).EndsWith("1")
                        data.Belimo1_Inputs(1) = bits(1).EndsWith("1")
                        data.Belimo1_Inputs(2) = bits(2).EndsWith("1")
                        data.Belimo1_Inputs(3) = bits(3).EndsWith("1")
                    End If

                Case key.StartsWith("IN1")
                    Dim bits = val.Split({"  "}, StringSplitOptions.RemoveEmptyEntries)
                    If bits.Length = 4 Then
                        data.Belimo2_Inputs(0) = bits(0).EndsWith("1")
                        data.Belimo2_Inputs(1) = bits(1).EndsWith("1")
                        data.Belimo2_Inputs(2) = bits(2).EndsWith("1")
                        data.Belimo2_Inputs(3) = bits(3).EndsWith("1")
                    End If

                Case key.StartsWith("Belimo Current")
                    Dim rawVal = val.Replace("mA", "").Trim()
                    Dim d As Double
                    If Double.TryParse(rawVal, NumberStyles.Float, CultureInfo.InvariantCulture, d) Then
                        data.BelimoCurrent = d
                    End If

                Case key.StartsWith("Status Unit")
                    Dim rawVal = val.Trim()
                    Dim su As UShort
                    If UShort.TryParse(rawVal, NumberStyles.Integer, Globalization.CultureInfo.InvariantCulture, su) Then
                        data.StatusUnit = su
                    End If

                Case Else
                    Dim m = alarmPattern.Match(l)
                    If m.Success Then
                        Dim idx = Integer.Parse(m.Groups(1).Value)
                        Dim v As Byte
                        If Byte.TryParse(m.Groups(2).Value, v) AndAlso idx >= 0 AndAlso idx < data.Alarms.Length Then
                            data.Alarms(idx) = v
                        End If
                    End If
            End Select
        Next

        ' Considera valido solo se almeno X campi fondamentali sono presenti
        If validFields < 11 Then
            Return Nothing
        End If

        Return data
    End Function


    Private Sub CB_LiveData_CheckedChanged(sender As Object, e As EventArgs) Handles CB_LiveData.CheckedChanged
        If CB_LiveData.Checked Then
            InviaStringa("b")
            Btn_RefreshData.Enabled = False
            Btn_Disconnect.Enabled = False
            Btn_SaveData.Enabled = False
            Btn_ResAcc.Enabled = False
            lb_status.Text = "Live-data polling enabled : disable to save, refresh or disconnect unit"
        Else
            InviaStringa("b")
            Btn_RefreshData.Enabled = True
            Btn_Disconnect.Enabled = True
            Btn_SaveData.Enabled = True
            Btn_ResAcc.Enabled = True
            lb_status.Text = "Live-data stopped successfully."
        End If
    End Sub

    Private Sub Btn_ResAcc_Click(sender As Object, e As EventArgs) Handles Btn_ResAcc.Click
        If SerialPort1.IsOpen Then
            InviaStringa("c")
            StartMenuRecoveryAfterAccessories()
        End If
    End Sub

    Private Sub Program_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Se live‐data è ancora attivo, disattivalo prima di chiudere
        If CB_LiveData.Checked Then
            CB_LiveData.Checked = False
        End If
    End Sub

    Private Sub InitializeLiveDataLabels()
        lblTFresh.Text = "00.0 °C"
        lblTReturn.Text = "00.0 °C"
        lblTSupply.Text = "00.0 °C"
        lblTExhaust.Text = "00.0 °C"
        lblTHeater.Text = "00.0 °C"
        lblTHeater.Visible = False
        lblTAfterHeater.Visible = False

        lblVSupply.Text = "00.0 V"
        lblRPMSupply.Text = "0000 rpm"
        lblVReturn.Text = "00.0 V"
        lblRPMReturn.Text = "0000 rpm"

        lblRFresh.Text = "00 %"
        lblRReturn.Text = "00 %"

        TB_alarm.Text = ""
    End Sub

    Private Sub RHDisable_CheckedChanged(sender As Object, e As EventArgs) Handles CB_RHDisable.CheckedChanged
        If (CB_RHDisable.Checked = True) Then
            num_RHSetpoint.Value = 99
            num_RHSetpoint.Enabled = False
            lbl_DisRH.ForeColor = Color.Red
        Else
            num_RHSetpoint.Value = 80
            num_RHSetpoint.Enabled = True
            lbl_DisRH.ForeColor = Color.Black
        End If
    End Sub


    Private Sub EnsureStatusPanelStyle()
        flpStatus.BackColor = ColBack
        flpStatus.Padding = New Padding(6, 6, 6, 6)
        flpStatus.WrapContents = False
        flpStatus.AutoSize = True
        flpStatus.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpStatus.Dock = DockStyle.Bottom
    End Sub

    Private Shared Function RoundedRect(r As Rectangle, radius As Integer) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath()
        Dim d = radius * 2
        path.AddArc(r.X, r.Y, d, d, 180, 90)
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90)
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90)
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Function MakeBadge(text As String, bg As Color, Optional tooltip As String = "") As Label
        Dim lb As New Label With {
        .AutoSize = True,
        .Padding = New Padding(10, 3, 10, 3),
        .Margin = New Padding(4, 2, 4, 2),
        .Font = New Font(Me.Font, FontStyle.Bold),
        .Text = text,
        .Cursor = Cursors.Hand,
        .BackColor = Color.Transparent ' Importante: lasciamo trasparente
    }
        If tooltip <> "" Then
            Dim tt As New ToolTip()
            tt.SetToolTip(lb, tooltip)
        End If

        AddHandler lb.Paint,
        Sub(s, e)
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim r As New Rectangle(0, 0, lb.Width - 1, lb.Height - 1)
            Dim radius As Integer = 10

            Using path As Drawing2D.GraphicsPath = RoundedRect(r, radius)
                ' sfondo
                Using b As New SolidBrush(bg)
                    e.Graphics.FillPath(b, path)
                End Using
                ' bordo nero sottile
                Using p As New Pen(Color.Black, 1)
                    e.Graphics.DrawPath(p, path)
                End Using
            End Using

            ' testo centrato
            TextRenderer.DrawText(e.Graphics, lb.Text, lb.Font, r, ColText,
                                  TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End Sub

        Return lb
    End Function

    ' ---- Helper ESTERNO (non locale) per aggiungere badge se condizione vera ----
    Private Sub AddBadgeIf(flp As FlowLayoutPanel,
                           cond As Boolean,
                           txt As String,
                           col As Color,
                           tip As String,
                           Optional clickHandler As EventHandler = Nothing,
                           Optional ByRef keepRef As Label = Nothing)

        If Not cond Then Return
        Dim b = MakeBadge(txt, col, tip)
        If clickHandler IsNot Nothing Then AddHandler b.Click, clickHandler
        flp.Controls.Add(b)
        If keepRef IsNot Nothing Then keepRef = b
    End Sub

    Private Sub PulseTick(sender As Object, e As EventArgs)
        If _lblBypMov Is Nothing Then Return
        _pulseToggle = Not _pulseToggle
        _lblBypMov.Visible = _pulseToggle
    End Sub

    ' ==================== CHIAMA QUESTA PER AGGIORNARE ====================
    Public Sub UpdateStatusBar(ld As LiveData)
        EnsureStatusPanelStyle()
        flpStatus.SuspendLayout()
        flpStatus.Controls.Clear()
        _lblBypMov = Nothing

        ' ---- Mappa stati → badge ----
        If ld.UnitRun Then
            AddBadgeIf(flpStatus, True, "RUN", ColBlue, "Unit is running")
        Else
            AddBadgeIf(flpStatus, True, "STAND-BY", ColRed, "Unit is in Stand-By")
        End If

        If ld.BypassRun Then
            AddBadgeIf(flpStatus, True, "BYP MOV", ColBlue, "Bypass running", Nothing, _lblBypMov)
        End If

        Dim bypTxt As String = If(ld.BypassClosed, "BYP CLOSE", "BYP OPEN")
        Dim bypTip As String = If(ld.BypassClosed, "Closed Bypass", "Opened Bypass")
        AddBadgeIf(flpStatus, True, bypTxt, ColBlue, bypTip)


        AddBadgeIf(flpStatus, ld.BoostOperating, "BOOST", ColGreen, "BOOST")
        AddBadgeIf(flpStatus, ld.BoostKHK, "KHK", ColGreen, "OVR: Kitchen Hood")
        AddBadgeIf(flpStatus, ld.CmdFanInput, "CMD 0–10V", ColBlue, "External 0–10 V activated")
        AddBadgeIf(flpStatus, ld.DefrostOperating, "DEFROST", ColBlue, "Defrost activated")
        AddBadgeIf(flpStatus, ld.PostVentOperating, "POST-VENT", ColBlue, "Post-ventilation activated")
        AddBadgeIf(flpStatus, ld.ImbalanceOperating, "IMB", ColAmber, "Imbalance")


        ' Override raggruppati
        Dim ovr As New List(Of String)
        If ld.MaxRH Then ovr.Add("RH")
        If ld.MaxCO2 Then ovr.Add("CO₂")
        If ld.MaxVOC Then ovr.Add("VOC")
        If ovr.Count > 0 Then
            AddBadgeIf(flpStatus, True, "OVR: " & String.Join(",", ovr), ColAmber, "Override per: " & String.Join(", ", ovr))
        End If

        AddBadgeIf(flpStatus, ld.InTesting, "TEST", ColBlue, "Test running")
        AddBadgeIf(flpStatus, ld.DppCheck, "DPP", ColBlue, "DPP checking activated")
        AddBadgeIf(flpStatus, ld.QrkUpdate, "UPDATE", ColPurple, "Firmware update available")
        AddBadgeIf(flpStatus, ld.BoostInput2, "BOOST SMOKE", ColBlue, "Smoke detector activated")

        flpStatus.ResumeLayout()

        ' Gestione lampeggio BYP MOV
        If _lblBypMov IsNot Nothing Then
            If Not _pulseTimer.Enabled Then
                AddHandler _pulseTimer.Tick, AddressOf PulseTick
                _pulseTimer.Start()
            End If
        Else
            If _pulseTimer.Enabled Then
                _pulseTimer.Stop()
                RemoveHandler _pulseTimer.Tick, AddressOf PulseTick
            End If
        End If
    End Sub

    Public Sub ClearStatusBar()
        flpStatus.SuspendLayout()
        flpStatus.Controls.Clear()
        flpStatus.ResumeLayout()

        ' Ferma eventuali lampeggi
        _lblBypMov = Nothing
        If _pulseTimer.Enabled Then
            _pulseTimer.Stop()
            RemoveHandler _pulseTimer.Tick, AddressOf PulseTick
        End If
    End Sub

    Private Function CloneLiveData(source As LiveData) As LiveData
        If source Is Nothing Then Return Nothing
        Dim copy As New LiveData() With {
            .TemperatureFresh = source.TemperatureFresh,
            .TemperatureReturn = source.TemperatureReturn,
            .TemperatureSupply = source.TemperatureSupply,
            .TemperatureExhaust = source.TemperatureExhaust,
            .HumidityLeft = source.HumidityLeft,
            .HumidityRight = source.HumidityRight,
            .TemperatureHeater = source.TemperatureHeater,
            .FeedbackVMotorR = source.FeedbackVMotorR,
            .RPMMotorR = source.RPMMotorR,
            .FeedbackVMotorF = source.FeedbackVMotorF,
            .RPMMotorF = source.RPMMotorF,
            .BelimoCurrent = source.BelimoCurrent,
            .StatusUnit = source.StatusUnit
        }
        If source.Alarms IsNot Nothing Then
            Array.Copy(source.Alarms, copy.Alarms, Math.Min(source.Alarms.Length, copy.Alarms.Length))
        End If
        If source.Belimo1_Inputs IsNot Nothing Then
            Array.Copy(source.Belimo1_Inputs, copy.Belimo1_Inputs, Math.Min(source.Belimo1_Inputs.Length, copy.Belimo1_Inputs.Length))
        End If
        If source.Belimo2_Inputs IsNot Nothing Then
            Array.Copy(source.Belimo2_Inputs, copy.Belimo2_Inputs, Math.Min(source.Belimo2_Inputs.Length, copy.Belimo2_Inputs.Length))
        End If
        Return copy
    End Function

    Private Function GetConsoleLength() As Integer
        Dim length As Integer = 0
        If Me.InvokeRequired Then
            Me.Invoke(Sub() length = tb_COMStrem.TextLength)
        Else
            length = tb_COMStrem.TextLength
        End If
        Return length
    End Function

    Private Function GetConsoleSlice(startIndex As Integer) As String
        Dim result As String = String.Empty
        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          Dim txt = tb_COMStrem.Text
                          If startIndex < 0 Then startIndex = 0
                          If startIndex > txt.Length Then startIndex = txt.Length
                          result = txt.Substring(startIndex)
                      End Sub)
        Else
            Dim txt = tb_COMStrem.Text
            If startIndex < 0 Then startIndex = 0
            If startIndex > txt.Length Then startIndex = txt.Length
            result = txt.Substring(startIndex)
        End If
        Return result
    End Function

    Private Function ContainsTokenAfter(startIndex As Integer, token As String) As Boolean
        If String.IsNullOrWhiteSpace(token) Then Return False
        Dim found As Boolean = False
        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          Dim txt = tb_COMStrem.Text
                          Dim idx = txt.IndexOf(token, Math.Max(0, startIndex), StringComparison.OrdinalIgnoreCase)
                          found = idx >= 0
                      End Sub)
        Else
            Dim txt = tb_COMStrem.Text
            Dim idx = txt.IndexOf(token, Math.Max(0, startIndex), StringComparison.OrdinalIgnoreCase)
            found = idx >= 0
        End If
        Return found
    End Function

    Private Async Function WaitForConditionAsync(predicate As Func(Of Boolean), timeout As TimeSpan, ct As CancellationToken) As Task(Of Boolean)
        Dim sw = Stopwatch.StartNew()
        While sw.Elapsed < timeout AndAlso Not ct.IsCancellationRequested
            Dim conditionMet As Boolean = False
            Try
                If Me.InvokeRequired Then
                    Me.Invoke(Sub() conditionMet = predicate())
                Else
                    conditionMet = predicate()
                End If
            Catch
                conditionMet = False
            End Try
            If conditionMet Then Return True
            Try
                Await Task.Delay(150, ct)
            Catch ex As TaskCanceledException
                Exit While
            End Try
        End While
        Return False
    End Function

    Private Async Function SendCommandAndCaptureAsync(command As String, expectedToken As String, timeoutSeconds As Integer, ct As CancellationToken) As Task(Of (Success As Boolean, Output As String))
        Dim start = GetConsoleLength()
        InviaStringa(command)
        Dim ok As Boolean
        If String.IsNullOrWhiteSpace(expectedToken) Then
            ok = True
            Try
                Await Task.Delay(TimeSpan.FromSeconds(timeoutSeconds), ct)
            Catch ex As TaskCanceledException
                ok = False
            End Try
        Else
            ok = Await WaitForConditionAsync(Function() ContainsTokenAfter(start, expectedToken), TimeSpan.FromSeconds(timeoutSeconds), ct)
        End If
        Dim output = GetConsoleSlice(start)
        Return (ok, output)
    End Function

    Private Async Function ReadLiveDataOnceAsync(ct As CancellationToken) As Task(Of LiveData)
        Return Await ReadLiveDataWithDelayAsync(0, 60, ct)
    End Function

    Private Async Function ReadLiveDataWithDelayAsync(minDelaySeconds As Integer, maxWaitSeconds As Integer, ct As CancellationToken) As Task(Of LiveData)
        Dim startStamp = lastLiveDataTimestamp
        InviaStringa("b") ' toggle on
        Try
            Dim waited As Integer = 0
            While waited < minDelaySeconds AndAlso Not ct.IsCancellationRequested
                Await Task.Delay(1000, ct)
                waited += 1
            End While

            If ct.IsCancellationRequested Then Return Nothing

            Dim remaining = Math.Max(0, maxWaitSeconds - minDelaySeconds)
            Dim ok = Await WaitForConditionAsync(Function() lastLiveDataTimestamp > startStamp, TimeSpan.FromSeconds(remaining), ct)
            If ok Then
                Return CloneLiveData(lastLiveDataSnapshot)
            End If
            Return Nothing
        Finally
            InviaStringa("b") ' toggle off
            readingLiveData = False
        End Try
    End Function

    Private Function FormatLiveDataMarkdown(live As LiveData) As String
        If live Is Nothing Then Return "- Live data non disponibili."
        Dim sb As New StringBuilder()
        sb.AppendLine($"- Temp Fresh/Return: {live.TemperatureFresh:F1} / {live.TemperatureReturn:F1} C")
        sb.AppendLine($"- Temp Supply/Exhaust: {live.TemperatureSupply:F1} / {live.TemperatureExhaust:F1} C")
        Dim heaterText As String = $"{live.TemperatureHeater:F1} C"
        If Not HasEhdAccessory() AndAlso Math.Abs(live.TemperatureHeater) < 0.0001 Then
            heaterText = "N/A"
        End If
        sb.AppendLine($"- Heater: {heaterText}")
        sb.AppendLine($"- Humidity L/R: {live.HumidityLeft} / {live.HumidityRight} %")
        sb.AppendLine($"- Feedback V F/R: {live.FeedbackVMotorF:F1} / {live.FeedbackVMotorR:F1} V")
        sb.AppendLine($"- RPM F/R: {live.RPMMotorF} / {live.RPMMotorR}")
        sb.AppendLine($"- StatusUnit: {live.StatusUnit} (0x{live.StatusUnit:X4}): {FormatStatusUnitFlags(live)}")
        sb.AppendLine($"- Belimo current: {live.BelimoCurrent:F1} mA")
        sb.AppendLine($"- Belimo1: {FormatBelimoState(live.Belimo1_Inputs)} (inputs: {FormatBelimoInputs(live.Belimo1_Inputs)})")
        sb.AppendLine($"- Belimo2: {FormatBelimoState(live.Belimo2_Inputs)} (inputs: {FormatBelimoInputs(live.Belimo2_Inputs)})")
        Dim alarms = live.GetAlarmCodes()
        If String.IsNullOrWhiteSpace(alarms) Then
            sb.AppendLine("- Alarms: NONE")
        Else
            sb.AppendLine($"- Alarms: {alarms}")
        End If
        Return sb.ToString()
    End Function

    Private Function ValidateTemperaturePairs(live As LiveData, ByRef reason As String) As Boolean
        If live Is Nothing Then
            reason = "Temperature validation failed: live data missing."
            Return False
        End If
        Dim samples As New List(Of LiveData)()
        samples.Add(live)
        If liveDataHistory.Count > 0 Then
            samples.AddRange(liveDataHistory)
        End If
        Dim takeN = Math.Min(10, samples.Count)
        Dim lastSamples = samples.Skip(Math.Max(0, samples.Count - takeN)).ToList()
        Dim avgFresh = lastSamples.Average(Function(x) x.TemperatureFresh)
        Dim avgReturn = lastSamples.Average(Function(x) x.TemperatureReturn)
        Dim avgSupply = lastSamples.Average(Function(x) x.TemperatureSupply)
        Dim avgExhaust = lastSamples.Average(Function(x) x.TemperatureExhaust)
        Dim diffFR = Math.Abs(avgFresh - avgReturn)
        Dim diffSE = Math.Abs(avgSupply - avgExhaust)
        Dim avgFR = (avgFresh + avgReturn) / 2.0
        Dim avgSE = (avgSupply + avgExhaust) / 2.0
        Dim diffAvg = Math.Abs(avgFR - avgSE)

        Dim okPairs = diffFR <= 3.0 AndAlso diffSE <= 3.0 AndAlso diffAvg <= 5.0
        If Not okPairs Then
            reason = $"Temperature validation failed: |F-R|={diffFR:F1}C, |S-E|={diffSE:F1}C, |avg pairs|={diffAvg:F1}C (limits 3.0/3.0/5.0)."
        End If
        Return okPairs
    End Function

    Private Function ValidateHumidity(live As LiveData, ByRef reason As String) As Boolean
        If live Is Nothing Then
            reason = "Humidity validation failed: live data missing."
            Return False
        End If
        Dim diff = Math.Abs(live.HumidityLeft - live.HumidityRight)
        Dim ok = diff <= 8
        If Not ok Then
            reason = $"Humidity validation failed: |L-R|={diff}% (limit 8%)."
        End If
        Return ok
    End Function

    Private Function ValidateBelimoCurrent(live As LiveData, noFki As Integer, ByRef reason As String) As Boolean
        If noFki <> 0 Then
            Return True ' skip check when NO_FKI is not 0
        End If
        If live Is Nothing Then
            reason = "Belimo current validation failed: live data missing."
            Return False
        End If
        Dim ok = live.BelimoCurrent > 200.0
        If Not ok Then
            reason = $"Belimo current validation failed: {live.BelimoCurrent:F1} mA (must be > 200 mA)."
        End If
        Return ok
    End Function
    Private Function FormatStatusUnitFlags(live As LiveData) As String
        Dim flags As New List(Of String)
        If live.UnitRun Then flags.Add("RUN")
        If live.DefrostOperating Then flags.Add("DEFROST")
        If live.PostVentOperating Then flags.Add("POSTVENT")
        If live.ImbalanceOperating Then flags.Add("IMBALANCE")
        If live.BoostOperating Then flags.Add("BOOST")
        If live.BoostKHK Then flags.Add("BOOST_KHK")
        If live.BypassRun Then flags.Add("BYP_RUN")
        If live.BypassClosed Then flags.Add("BYP_CLOSED")
        If live.CmdFanInput Then flags.Add("CMD_FAN_INPUT")
        If live.MaxRH Then flags.Add("MAX_RH")
        If live.MaxCO2 Then flags.Add("MAX_CO2")
        If live.MaxVOC Then flags.Add("MAX_VOC")
        If live.InTesting Then flags.Add("IN_TEST")
        If live.DppCheck Then flags.Add("DPP_CHECK")
        If live.QrkUpdate Then flags.Add("QRK_UPDATE")
        If live.BoostInput2 Then flags.Add("BOOST_INPUT2")
        Return If(flags.Count = 0, "none", String.Join(", ", flags))
    End Function

    Private Function FormatBelimoInputs(inputs As Boolean()) As String
        If inputs Is Nothing OrElse inputs.Length = 0 Then Return "n/a"
        Dim bits As New List(Of String)
        For i As Integer = 0 To inputs.Length - 1
            bits.Add(If(inputs(i), "1", "0"))
        Next
        Return String.Join(",", bits)
    End Function

    Private Function HasEhdAccessory() As Boolean
        If customerData Is Nothing OrElse String.IsNullOrWhiteSpace(customerData.Accessories) Then Return False
        Return customerData.Accessories.IndexOf("EHD", StringComparison.OrdinalIgnoreCase) >= 0
    End Function

    Private Function FormatBelimoState(inputs As Boolean()) As String
        If inputs Is Nothing OrElse inputs.Length < 4 Then Return "unknown"

        Dim i0 = inputs(0)
        Dim i1 = inputs(1)
        Dim i2 = inputs(2)
        Dim i3 = inputs(3)

        If (i0 AndAlso i1 AndAlso i2 AndAlso i3) Then
            Return "Disconnect"
        ElseIf (Not i0 AndAlso Not i1 AndAlso i2 AndAlso i3) Then
            Return "Close"
        ElseIf (Not i0 AndAlso i1 AndAlso i2 AndAlso Not i3) Then
            Return "Moving"
        ElseIf (i0 AndAlso i1 AndAlso Not i2 AndAlso Not i3) Then
            Return "Open"
        Else
            Return "No_FKI"
        End If
    End Function

    Private Sub AddLiveDataHistory(live As LiveData)
        If live Is Nothing Then Return
        liveDataHistory.Enqueue(CloneLiveData(live))
        While liveDataHistory.Count > 10
            liveDataHistory.Dequeue()
        End While
    End Sub

    Private Sub SignalTestCompletion(result As String)
        Try
            Select Case result
                Case "PASSED"
                    Console.Beep(1200, 200)
                    Thread.Sleep(100)
                    Console.Beep(1500, 300)
                    MessageBox.Show("Test PASSED. Confirm to stop alert.", "Test result", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case "FAILED"
                    For i As Integer = 1 To 3
                        Console.Beep(400, 300)
                        Thread.Sleep(120)
                    Next
                    MessageBox.Show("Test FAILED. Confirm to stop alert.", "Test result", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Case "CANCELLED"
                    Console.Beep(900, 150)
            End Select
        Catch
        End Try
    End Sub

    Private Function PrepareLogFile(serialNumber As String) As String
        Try
            Dim safeSerial = Regex.Replace(serialNumber.Trim(), "[^\da-zA-Z]+", "")
            If safeSerial.Length = 0 Then
                MessageBox.Show("Inserire un numero seriale valido (18 cifre).", "Serial mancante", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return String.Empty
            End If

            Dim testFolder = Path.Combine(Application.StartupPath, TestFolderName)
            Dim failedFolder = Path.Combine(testFolder, TestFailedFolderName)
            Directory.CreateDirectory(testFolder)
            Directory.CreateDirectory(failedFolder)

            Dim logPath = Path.Combine(testFolder, $"test_{safeSerial}.md")
            If File.Exists(logPath) Then
                Dim res = MessageBox.Show($"Il file {Path.GetFileName(logPath)} esiste gia'. Vuoi crearne uno nuovo con indice progressivo?", "File esistente", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If res = DialogResult.No Then Return String.Empty

                Dim idx As Integer = 1
                Do
                    Dim candidate = Path.Combine(testFolder, $"test_{safeSerial}_{idx:000}.md")
                    If Not File.Exists(candidate) Then
                        logPath = candidate
                        Exit Do
                    End If
                    idx += 1
                Loop
            End If

            Return logPath
        Catch ex As Exception
            MessageBox.Show($"Impossibile preparare il file di log: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty
        End Try
    End Function

    Private Function MoveLogToFailed(logPath As String) As String
        Try
            Dim failedFolder = Path.Combine(Application.StartupPath, TestFolderName, TestFailedFolderName)
            Directory.CreateDirectory(failedFolder)
            Dim baseName = Path.GetFileNameWithoutExtension(logPath)
            Dim ext = Path.GetExtension(logPath)
            Dim dest = Path.Combine(failedFolder, $"{baseName}_failed{ext}")
            Dim idx As Integer = 1
            While File.Exists(dest)
                dest = Path.Combine(failedFolder, $"{baseName}_failed_{idx:000}{ext}")
                idx += 1
            End While
            File.Move(logPath, dest)
            Return dest
        Catch ex As Exception
            MessageBox.Show($"Impossibile spostare il log fallito: {ex.Message}", "Errore spostamento log", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return logPath
        End Try
    End Function

    Private Function GetTestSerialNumber() As String
        Dim serial As String = String.Empty
        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          If txtUnitTestSerial IsNot Nothing Then
                              serial = txtUnitTestSerial.Text
                          End If
                      End Sub)
        Else
            If txtUnitTestSerial IsNot Nothing Then
                serial = txtUnitTestSerial.Text
            End If
        End If
        If String.IsNullOrWhiteSpace(serial) AndAlso Not String.IsNullOrWhiteSpace(customerData.SerialNumber) Then
            serial = customerData.SerialNumber
        End If
        Return serial
    End Function

    Private Function GetCurrentSpeed1() As Integer
        Dim val As Integer = customerData.FSC_CAF_Speed1
        If Me.InvokeRequired Then
            Me.Invoke(Sub() val = CInt(num_F_Speed1.Value))
        Else
            val = CInt(num_F_Speed1.Value)
        End If
        Return val
    End Function

    Private Sub ClearUnitTestPreview()
        If txtUnitTestLogPreview Is Nothing Then Return
        If Me.InvokeRequired Then
            Me.Invoke(Sub() ClearUnitTestPreview())
            Return
        End If
        unitTestStartTime = DateTime.Now
        txtUnitTestLogPreview.Clear()
    End Sub

    Private Sub AppendUnitTestPreview(line As String)
        If txtUnitTestLogPreview Is Nothing Then Return
        If Me.InvokeRequired Then
            Me.Invoke(Sub() AppendUnitTestPreview(line))
            Return
        End If
        Dim prefix As String = String.Empty
        If unitTestStartTime <> DateTime.MinValue Then
            Dim elapsed = DateTime.Now - unitTestStartTime
            prefix = $"[{elapsed:mm\:ss}] "
        End If
        txtUnitTestLogPreview.AppendText(prefix & line & Environment.NewLine)
    End Sub

    Private Sub LoadTestLogs()
        If lstTestLogs Is Nothing Then Return
        If Me.InvokeRequired Then
            Me.Invoke(Sub() LoadTestLogs())
            Return
        End If
        lstTestLogs.Items.Clear()
        Try
            Dim testDir = Path.Combine(Application.StartupPath, TestFolderName)
            If Not Directory.Exists(testDir) Then Return

            Dim files As New List(Of String)()
            files.AddRange(Directory.GetFiles(testDir, "*.md"))
            Dim failedDir = Path.Combine(testDir, TestFailedFolderName)
            If Directory.Exists(failedDir) Then
                files.AddRange(Directory.GetFiles(failedDir, "*.md"))
            End If

            For Each f In files.OrderByDescending(Function(x) File.GetCreationTime(x))
                Dim display = Path.GetFileName(f)
                If f.StartsWith(Path.Combine(testDir, TestFailedFolderName), StringComparison.OrdinalIgnoreCase) Then
                    display = Path.Combine(TestFailedFolderName, Path.GetFileName(f))
                End If
                lstTestLogs.Items.Add(New TestLogListItem With {.Display = display, .FullPath = f})
            Next
        Catch
            ' ignore errors on listing
        End Try
    End Sub

    Private Sub ExportSelectedLogToPdf()
        Dim item = TryCast(lstTestLogs.SelectedItem, TestLogListItem)
        If item Is Nothing Then
            MessageBox.Show("Select a log file first.", "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim mdPath = item.FullPath
        If Not File.Exists(mdPath) Then
            MessageBox.Show("File not found.", "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim pdfPath = Path.ChangeExtension(mdPath, ".pdf")
        If File.Exists(pdfPath) Then
            Dim overwrite = MessageBox.Show($"PDF already exists:{Environment.NewLine}{pdfPath}{Environment.NewLine}Overwrite?", "Export to PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If overwrite <> DialogResult.Yes Then Return
        End If

        Dim serialLabel As String = "Serial: n/a"
        Try
            Dim nameNoExt = Path.GetFileNameWithoutExtension(mdPath)
            If nameNoExt.StartsWith("test_", StringComparison.OrdinalIgnoreCase) Then
                serialLabel = "Serial: " & nameNoExt.Substring(5)
            Else
                serialLabel = "Serial: " & nameNoExt
            End If
        Catch
        End Try

        Dim tempHtml As String = ConvertMarkdownToHtml(mdPath)
        If String.IsNullOrWhiteSpace(tempHtml) OrElse Not File.Exists(tempHtml) Then
            MessageBox.Show("Failed to generate HTML for PDF export.", "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim wkArgs = $"--dpi 300 --image-dpi 300 --image-quality 90 --print-media-type --disable-smart-shrinking --enable-local-file-access --footer-left ""{serialLabel}"" --footer-right ""[page]/[topage]"" ""{tempHtml}"" ""{pdfPath}"""
            Dim psi As New ProcessStartInfo With {
                .FileName = "wkhtmltopdf",
                .Arguments = wkArgs,
                .UseShellExecute = False,
                .RedirectStandardOutput = True,
                .RedirectStandardError = True,
                .CreateNoWindow = True
            }
            Using proc = Process.Start(psi)
                proc.WaitForExit(30000)
                If proc.ExitCode <> 0 Then
                    Dim err = proc.StandardError.ReadToEnd()
                    MessageBox.Show($"PDF export failed (wkhtmltopdf, code {proc.ExitCode}).{Environment.NewLine}{err}", "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End Using
            MessageBox.Show($"PDF created:{Environment.NewLine}{pdfPath}", "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"PDF export failed: {ex.Message}", "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If File.Exists(tempHtml) Then File.Delete(tempHtml)
            Catch
            End Try
        End Try
    End Sub

    Private Function ConvertMarkdownToHtml(mdPath As String) As String
        Dim tempHtml = Path.Combine(Path.GetTempPath(), $"testlog_{Guid.NewGuid():N}.html")
        Dim bodyHtml As String = Nothing

        ' Primo tentativo: pandoc -> HTML (senza CSS) e poi wrappo con il mio template
        Try
            Dim psi As New ProcessStartInfo With {
                .FileName = "pandoc",
                .Arguments = $" ""{mdPath}"" -t html",
                .UseShellExecute = False,
                .RedirectStandardOutput = True,
                .RedirectStandardError = True,
                .CreateNoWindow = True
            }
            Using proc = Process.Start(psi)
                bodyHtml = proc.StandardOutput.ReadToEnd()
                proc.WaitForExit(15000)
                If proc.ExitCode <> 0 Then
                    Dim err = proc.StandardError.ReadToEnd()
                    Console.WriteLine($"pandoc to html failed: {err}")
                    bodyHtml = Nothing
                End If
            End Using
        Catch ex As Exception
            Console.WriteLine($"ConvertMarkdownToHtml pandoc error: {ex.Message}")
        End Try

        ' Fallback: HTML minimale
        If String.IsNullOrWhiteSpace(bodyHtml) Then
            Try
                Dim md = File.ReadAllText(mdPath)
                Dim escaped = System.Net.WebUtility.HtmlEncode(md).Replace(Environment.NewLine, "<br/>")
                bodyHtml = $"<pre>{escaped}</pre>"
            Catch ex As Exception
                Console.WriteLine($"ConvertMarkdownToHtml fallback error: {ex.Message}")
                Return String.Empty
            End Try
        End If

        Try
            Dim css = "
                body { font-family: 'Segoe UI', Arial, sans-serif; margin: 32px; color: #111827; background: #ffffff; font-size: 13px; }
                h1, h2, h3 { color: #111827; margin-top: 22px; margin-bottom: 10px; }
                h1 { font-size: 22px; border-bottom: 1px solid #e5e7eb; padding-bottom: 6px; }
                h2 { font-size: 18px; }
                h3 { font-size: 16px; }
                p { line-height: 1.5; margin: 6px 0; }
                pre, code { font-family: 'Cascadia Mono', 'Fira Code', Consolas, monospace; font-size: 12px; }
                pre { background: #f3f4f6; padding: 12px; border-radius: 10px; border: 1px solid #e5e7eb; overflow-x: auto; }
                blockquote { border-left: 4px solid #3b82f6; padding-left: 12px; color: #374151; background: #f8fafc; }
                ul, ol { margin-left: 18px; }
                .container { max-width: 900px; margin: 0 auto; }
                .card { background: #fff; padding: 14px; border-radius: 12px; border: 1px solid #e5e7eb; box-shadow: 0 1px 2px rgba(0,0,0,0.05); margin-bottom: 12px; }
            "
            Dim template = $"<html><head><meta charset='utf-8'><style>{css}</style></head><body><div class='container'><div class='card'>{bodyHtml}</div></div></body></html>"
            File.WriteAllText(tempHtml, template, Encoding.UTF8)
            Return tempHtml
        Catch ex As Exception
            Console.WriteLine($"ConvertMarkdownToHtml write error: {ex.Message}")
            Return String.Empty
        End Try
    End Function

    Private Function ParseTestVariations() As List(Of Integer)
        Dim variations As New List(Of Integer)()
        Dim raw As String = String.Empty
        If Me.InvokeRequired Then
            Me.Invoke(Sub() raw = txtUnitTestVariations.Text)
        Else
            raw = txtUnitTestVariations.Text
        End If

        Dim lines = raw.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
        If lines.Length = 0 Then
            variations.Add(Math.Max(25, Math.Min(100, customerData.FSC_CAF_Speed1)))
            Return variations
        End If

        For Each line In lines
            Dim parts = line.Split(New Char() {","c, ";"c, ":"c}, StringSplitOptions.RemoveEmptyEntries)
            If parts.Length = 0 Then Continue For

            Dim v1 As Integer = customerData.FSC_CAF_Speed1
            Integer.TryParse(parts(0).Trim(), v1)
            v1 = Math.Max(25, Math.Min(100, v1))
            variations.Add(v1)
        Next

        Return variations
    End Function

    Private Sub ApplyVariationToModel(speed1 As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() ApplyVariationToModel(speed1))
            Return
        End If

        num_F_Speed1.Value = speed1
        num_R_Speed1.Value = speed1
        customerData.UpdateSpeedSettings(num_F_Speed1.Value, num_R_Speed1.Value, 1)
    End Sub

    Private Async Function SaveConfigurationAsync(ct As CancellationToken) As Task(Of Boolean)
        ' Ensure Speed2/Speed3 remain at original baseline values during variations
        If originalSpeed2F > 0 Then customerData.FSC_CAF_Speed2 = originalSpeed2F
        If originalSpeed3F > 0 Then customerData.FSC_CAF_Speed3 = originalSpeed3F
        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          writeStep = 1
                          isWriting = True
                          PB_SaveData.Visible = True
                          lb_SaveProg.Visible = True
                          lb_status.Text = "Saving data... (test unita)"
                          ResetInactivityTimer()
                      End Sub)
        Else
            writeStep = 1
            isWriting = True
            PB_SaveData.Visible = True
            lb_SaveProg.Visible = True
            lb_status.Text = "Saving data... (test unita)"
            ResetInactivityTimer()
        End If

        Return Await WaitForConditionAsync(Function() Not isWriting, TimeSpan.FromSeconds(45), ct)
    End Function

    Private Sub UpdateUnitTestUi(statusText As String, running As Boolean, logPath As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() UpdateUnitTestUi(statusText, running, logPath))
            Return
        End If

        unitTestRunning = running
        Btn_StartUnitTest.Enabled = Not running
        Btn_StopUnitTest.Enabled = running
        lblUnitTestStatus.Text = statusText
        If Not String.IsNullOrWhiteSpace(logPath) Then
            lblUnitTestLogPath.Text = $"Log: {logPath}"
        Else
            lblUnitTestLogPath.Text = "Log: n/d"
        End If
    End Sub

    Private Async Function RestoreOriginalSpeedAsync(ct As CancellationToken) As Task
        If originalSpeed1F <= 0 OrElse originalSpeed1R <= 0 Then Return
        ' Ripristina anche i setpoint/flag modificati durante il test
        customerData.RHSetPoint = originalRhSetPoint
        customerData.IMBALANCE_ENABLE = originalImbalanceEnable
        customerData.KHK_VALUE = originalKhkConfig
        customerData.SMOKE_VALUE = originalSmokeValue
        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          num_RHSetpoint.Value = originalRhSetPoint
                          CB_ImbEnable.Checked = (originalImbalanceEnable = 1)
                          ' Ripristino KHK
                          CB_KHKenable.Checked = (originalKhkConfig And &H1) = &H1
                          If (originalKhkConfig And &H2) = &H2 Then
                              RB_NC.Checked = True
                              RB_NO.Checked = False
                          Else
                              RB_NO.Checked = True
                              RB_NC.Checked = False
                          End If
                          ' Ripristino Smoke
                          CB_SmokeEnable.Checked = (originalSmokeValue <> 0)
                          If originalSmokeValue = 1 Then
                              RB_SmokeNC.Checked = True
                              RB_SmokeNO.Checked = False
                          ElseIf originalSmokeValue = 2 Then
                              RB_SmokeNC.Checked = False
                              RB_SmokeNO.Checked = True
                          Else
                              RB_SmokeNC.Checked = True
                              RB_SmokeNO.Checked = False
                          End If
                      End Sub)
        Else
            num_RHSetpoint.Value = originalRhSetPoint
            CB_ImbEnable.Checked = (originalImbalanceEnable = 1)
            CB_KHKenable.Checked = (originalKhkConfig And &H1) = &H1
            If (originalKhkConfig And &H2) = &H2 Then
                RB_NC.Checked = True
                RB_NO.Checked = False
            Else
                RB_NO.Checked = True
                RB_NC.Checked = False
            End If
            CB_SmokeEnable.Checked = (originalSmokeValue <> 0)
            If originalSmokeValue = 1 Then
                RB_SmokeNC.Checked = True
                RB_SmokeNO.Checked = False
            ElseIf originalSmokeValue = 2 Then
                RB_SmokeNC.Checked = False
                RB_SmokeNO.Checked = True
            Else
                RB_SmokeNC.Checked = True
                RB_SmokeNO.Checked = False
            End If
        End If
        ApplyVariationToModel(originalSpeed1F)
        Await SaveConfigurationAsync(ct)
    End Function

    Private Sub AppendFinalFooter(log As StringBuilder, result As String, startTime As DateTime)
        Dim endTime = DateTime.Now
        Dim duration = endTime - startTime
        log.AppendLine()
        log.AppendLine("## Test summary")
        log.AppendLine($"End: {endTime:yyyy-MM-dd HH:mm:ss}")
        log.AppendLine($"Duration: {duration:hh\:mm\:ss}")
        log.AppendLine($"Result: {result}")
    End Sub

    Private Async Function RunUnitTestAsync(ct As CancellationToken) As Task
        Dim caughtEx As Exception = Nothing
        Try
            UpdateUnitTestUi("Test unita in esecuzione...", True, Nothing)

            If Not SerialPort1.IsOpen Then
                UpdateUnitTestUi("Porta seriale non aperta.", False, Nothing)
                SignalTestCompletion("FAILED")
                Return
            End If

            If Me.InvokeRequired Then
                Me.Invoke(Sub() CB_LiveData.Checked = False)
            Else
                CB_LiveData.Checked = False
            End If

            Dim serial = GetTestSerialNumber()
            If String.IsNullOrWhiteSpace(serial) Then
                UpdateUnitTestUi("Seriale mancante", False, Nothing)
                SignalTestCompletion("FAILED")
                Return
            End If

            originalSpeed1F = GetCurrentSpeed1()
            originalSpeed1R = originalSpeed1F
            originalSpeed2F = customerData.FSC_CAF_Speed2
            originalSpeed3F = customerData.FSC_CAF_Speed3

            Dim logPath = PrepareLogFile(serial)
            If String.IsNullOrWhiteSpace(logPath) Then
                UpdateUnitTestUi("Preparazione log annullata", False, Nothing)
                SignalTestCompletion("FAILED")
                Return
            End If

            unitTestLogPath = logPath
            Dim log As New StringBuilder()
            Dim logStart = DateTime.Now
            log.AppendLine($"# Unit test {serial}")
            log.AppendLine($"Start: {logStart:yyyy-MM-dd HH:mm:ss}")
            log.AppendLine()
            AppendUnitTestPreview("Unit test started...")
            AppendUnitTestPreview($"Serial: {serial}")

            Dim step1 = Await SendCommandAndCaptureAsync("2", "--- END OF READING ---", 8, ct)
            log.AppendLine("## Step 1 - Read unit data (2)")
            log.AppendLine("```")
            log.AppendLine(step1.Output.Trim())
            log.AppendLine("```")
            AppendUnitTestPreview("Step 1 completed (2)")

            Dim step2 = Await SendCommandAndCaptureAsync("6", "--- END OF READING ---", 8, ct)
            If Me.InvokeRequired Then
                Me.Invoke(Sub() ExtractConfigData())
            Else
                ExtractConfigData()
            End If
            ' Memorizza i valori originali che forzeremo durante il test
            originalRhSetPoint = customerData.RHSetPoint
            originalImbalanceEnable = customerData.IMBALANCE_ENABLE
            originalKhkConfig = customerData.KHK_VALUE
            originalSmokeValue = CByte(customerData.SMOKE_VALUE)
            log.AppendLine("## Step 2 - Read configuration (6)")
            log.AppendLine("```")
            log.AppendLine(step2.Output.Trim())
            log.AppendLine("```")
            AppendUnitTestPreview("Step 2 completed (6)")

            Dim liveBaseline = Await ReadLiveDataOnceAsync(ct)
            log.AppendLine("## Step 3 - Initial live data (b)")
            log.AppendLine(FormatLiveDataMarkdown(liveBaseline))
            AppendUnitTestPreview("Initial temperature check in progress...")
            Dim tempBaselineReason As String = String.Empty
            If Not ValidateTemperaturePairs(liveBaseline, tempBaselineReason) Then
                AppendUnitTestPreview($"Initial temperature check failed, retrying in 15s: {tempBaselineReason}")
                Dim retryLive = Await ReadLiveDataWithDelayAsync(15, 15, ct)
                If retryLive IsNot Nothing Then
                    log.AppendLine("## Temperature retry (initial, +15s)")
                    log.AppendLine(FormatLiveDataMarkdown(retryLive))
                    liveBaseline = retryLive
                    tempBaselineReason = String.Empty
                    If Not ValidateTemperaturePairs(liveBaseline, tempBaselineReason) Then
                        log.AppendLine($"- {tempBaselineReason}")
                        AppendUnitTestPreview($"Initial temperature check failed after retry: {tempBaselineReason}")
                        AppendFinalFooter(log, "FAILED", logStart)
                        File.WriteAllText(logPath, log.ToString())
                        Dim failPath = MoveLogToFailed(logPath)
                        LoadTestLogs()
                        UpdateUnitTestUi("Test fallito: live data mancanti", False, failPath)
                        SignalTestCompletion("FAILED")
                        Return
                    End If
                Else
                    log.AppendLine($"- {tempBaselineReason}")
                    AppendUnitTestPreview($"Initial temperature check failed (no retry data): {tempBaselineReason}")
                    AppendFinalFooter(log, "FAILED", logStart)
                    File.WriteAllText(logPath, log.ToString())
                    Dim failPath = MoveLogToFailed(logPath)
                    LoadTestLogs()
                    UpdateUnitTestUi("Test fallito: live data mancanti", False, failPath)
                    SignalTestCompletion("FAILED")
                    Return
                End If
            Else
                log.AppendLine("- Temperature check: OK")
                AppendUnitTestPreview("Initial temperature check: OK")
            End If
            Dim humReason As String = String.Empty
            If Not ValidateHumidity(liveBaseline, humReason) Then
                AppendUnitTestPreview($"Initial humidity check failed, retrying in 15s: {humReason}")
                Dim retryHum = Await ReadLiveDataWithDelayAsync(15, 15, ct)
                If retryHum IsNot Nothing Then
                    log.AppendLine("## Humidity retry (initial, +15s)")
                    log.AppendLine(FormatLiveDataMarkdown(retryHum))
                    If Not ValidateHumidity(retryHum, humReason) Then
                        log.AppendLine($"- {humReason}")
                        AppendUnitTestPreview($"Initial humidity check failed after retry: {humReason}")
                        AppendFinalFooter(log, "FAILED", logStart)
                        File.WriteAllText(logPath, log.ToString())
                        Dim failPath = MoveLogToFailed(logPath)
                        LoadTestLogs()
                        UpdateUnitTestUi("Test fallito: humidity out of range", False, failPath)
                        SignalTestCompletion("FAILED")
                        Return
                    End If
                Else
                    log.AppendLine($"- {humReason}")
                    AppendUnitTestPreview($"Initial humidity check failed (no retry data): {humReason}")
                    AppendFinalFooter(log, "FAILED", logStart)
                    File.WriteAllText(logPath, log.ToString())
                    Dim failPath = MoveLogToFailed(logPath)
                    LoadTestLogs()
                    UpdateUnitTestUi("Test fallito: humidity out of range", False, failPath)
                    SignalTestCompletion("FAILED")
                    Return
                End If
            Else
                log.AppendLine("- Humidity check: OK")
                AppendUnitTestPreview("Initial humidity check: OK")
            End If
            Dim belimoReason As String = String.Empty
            If Not ValidateBelimoCurrent(liveBaseline, customerData.no_FKI, belimoReason) Then
                log.AppendLine($"- {belimoReason}")
                AppendUnitTestPreview($"Initial Belimo check failed: {belimoReason}")
                AppendFinalFooter(log, "FAILED", logStart)
                File.WriteAllText(logPath, log.ToString())
                Dim failPath = MoveLogToFailed(logPath)
                LoadTestLogs()
                UpdateUnitTestUi("Test fallito: Belimo current out of range", False, failPath)
                SignalTestCompletion("FAILED")
                Return
            Else
                log.AppendLine("- Belimo current check: OK")
                AppendUnitTestPreview("Initial Belimo current check: OK")
            End If
            If liveBaseline Is Nothing Then
                log.AppendLine("- Live data not received within 60s: test failed.")
                AppendUnitTestPreview("Initial live data not received within 60s. Test failed.")
                AppendFinalFooter(log, "FAILED", logStart)
                File.WriteAllText(logPath, log.ToString())
                Dim failPath = MoveLogToFailed(logPath)
                LoadTestLogs()
                UpdateUnitTestUi("Test fallito: live data mancanti", False, failPath)
                SignalTestCompletion("FAILED")
                Return
            End If
            AppendUnitTestPreview("Initial live data received.")

            If ct.IsCancellationRequested Then
                AppendFinalFooter(log, "CANCELLED", logStart)
                File.WriteAllText(logPath, log.ToString())
                UpdateUnitTestUi("Test annullato dall'utente", False, logPath)
                SignalTestCompletion("CANCELLED")
                Return
            End If

            Dim variations = ParseTestVariations()
            Dim previousLive = liveBaseline
            Dim allPassed As Boolean = True
            Dim variationIndex As Integer = 1
            Dim wasCancelled As Boolean = False
            Dim previousTargetSpeed As Integer = originalSpeed1F
            Dim forcedParamsApplied As Boolean = False

            For Each variationSpeed1 In variations
                If ct.IsCancellationRequested Then
                    wasCancelled = True
                    Exit For
                End If

                log.AppendLine()
                log.AppendLine($"## Variation {variationIndex}")
                log.AppendLine($"- Target Speed1: {variationSpeed1}")

                If Not forcedParamsApplied Then
                    ' Forza i parametri richiesti solo all'inizio del test (anche sui controlli UI)
                    customerData.RHSetPoint = 99
                    customerData.IMBALANCE_ENABLE = 0
                    customerData.KHK_VALUE = 0 ' coerente con KHK disabilitato
                    customerData.SMOKE_VALUE = 0
                    If Me.InvokeRequired Then
                        Me.Invoke(Sub()
                                      num_RHSetpoint.Value = 99
                                      CB_ImbEnable.Checked = False
                                      CB_KHKenable.Checked = False ' durante il test deve restare disabilitato
                                      RB_NC.Checked = True ' selezione neutra
                                      RB_NO.Checked = False
                                      CB_SmokeEnable.Checked = False
                                      RB_SmokeNC.Checked = True
                                      RB_SmokeNO.Checked = False
                                  End Sub)
                    Else
                        num_RHSetpoint.Value = 99
                        CB_ImbEnable.Checked = False
                        CB_KHKenable.Checked = False
                        RB_NC.Checked = True
                        RB_NO.Checked = False
                        CB_SmokeEnable.Checked = False
                        RB_SmokeNC.Checked = True
                        RB_SmokeNO.Checked = False
                    End If
                    forcedParamsApplied = True
                End If

                ApplyVariationToModel(variationSpeed1)
                Dim saveOk = Await SaveConfigurationAsync(ct)
                log.AppendLine($"- Saving configuration: {(If(saveOk, "OK", "FAILED"))}")
                If Not saveOk Then
                    allPassed = False
                    log.AppendLine("- Reason: timeout during save.")
                    Exit For
                End If

                Dim verify = Await SendCommandAndCaptureAsync("6", "--- END OF READING ---", 8, ct)
                If Me.InvokeRequired Then
                    Me.Invoke(Sub() ExtractConfigData())
                Else
                    ExtractConfigData()
                End If
                If Not verify.Success Then
                    allPassed = False
                    log.AppendLine("- Reading configuration after variation failed.")
                    Exit For
                End If
                log.AppendLine("```")
                log.AppendLine(verify.Output.Trim())
                log.AppendLine("```")
                AppendUnitTestPreview($"Variation {variationIndex}: configuration re-read.")

                Dim parsedVerify As New CustomerData()
                ParseCustomerData(verify.Output, parsedVerify, False)

                If parsedVerify.FSC_CAF_Speed1 <> variationSpeed1 Then
                    allPassed = False
                    log.AppendLine($"- Speed1 read ({parsedVerify.FSC_CAF_Speed1}) different from target {variationSpeed1}.")
                    AppendUnitTestPreview($"Variation {variationIndex}: Speed1 read {parsedVerify.FSC_CAF_Speed1} differs from target {variationSpeed1}.")
                    Exit For
                End If
                AppendUnitTestPreview($"Variation {variationIndex}: Speed1 confirmed at {parsedVerify.FSC_CAF_Speed1}.")

                AppendUnitTestPreview($"Variation {variationIndex}: enabling live data, wait 30s (timeout 60s).")
                Dim liveAfter = Await ReadLiveDataWithDelayAsync(30, 60, ct)
                If liveAfter Is Nothing Then
                    allPassed = False
                    log.AppendLine("- Live data not received within 60s after variation.")
                    AppendUnitTestPreview($"Variation {variationIndex}: live data not received within 60s.")
                    Exit For
                End If
                log.AppendLine(FormatLiveDataMarkdown(liveAfter))

                AppendUnitTestPreview($"Variation {variationIndex}: temperature check in progress...")
                Dim tempReason As String = String.Empty
                If Not ValidateTemperaturePairs(liveAfter, tempReason) Then
                    AppendUnitTestPreview($"Variation {variationIndex}: temp check failed, retrying in 15s: {tempReason}")
                    Dim retryLive = Await ReadLiveDataWithDelayAsync(15, 15, ct)
                    If retryLive IsNot Nothing Then
                        log.AppendLine($"## Temperature retry (variation {variationIndex}, +15s)")
                        log.AppendLine(FormatLiveDataMarkdown(retryLive))
                        liveAfter = retryLive
                        tempReason = String.Empty
                        If Not ValidateTemperaturePairs(liveAfter, tempReason) Then
                            allPassed = False
                            log.AppendLine($"- {tempReason}")
                            AppendUnitTestPreview($"Variation {variationIndex}: {tempReason}")
                            Exit For
                        End If
                    Else
                        allPassed = False
                        log.AppendLine($"- {tempReason}")
                        AppendUnitTestPreview($"Variation {variationIndex}: {tempReason}")
                        Exit For
                    End If
                Else
                    log.AppendLine("- Temperature check: OK")
                    AppendUnitTestPreview($"Variation {variationIndex}: Temperature check OK")
                End If

                Dim humReason2 As String = String.Empty
                AppendUnitTestPreview($"Variation {variationIndex}: humidity check in progress...")
                If Not ValidateHumidity(liveAfter, humReason2) Then
                    AppendUnitTestPreview($"Variation {variationIndex}: humidity check failed, retrying in 15s: {humReason2}")
                    Dim retryHum = Await ReadLiveDataWithDelayAsync(15, 15, ct)
                    If retryHum IsNot Nothing Then
                        log.AppendLine($"## Humidity retry (variation {variationIndex}, +15s)")
                        log.AppendLine(FormatLiveDataMarkdown(retryHum))
                        humReason2 = String.Empty
                        If Not ValidateHumidity(retryHum, humReason2) Then
                            allPassed = False
                            log.AppendLine($"- {humReason2}")
                            AppendUnitTestPreview($"Variation {variationIndex}: {humReason2}")
                            Exit For
                        End If
                    Else
                        allPassed = False
                        log.AppendLine($"- {humReason2}")
                        AppendUnitTestPreview($"Variation {variationIndex}: {humReason2}")
                        Exit For
                    End If
                Else
                    log.AppendLine("- Humidity check: OK")
                    AppendUnitTestPreview($"Variation {variationIndex}: Humidity check OK")
                End If

                Dim belimoReason2 As String = String.Empty
                AppendUnitTestPreview($"Variation {variationIndex}: Belimo current check in progress...")
                If Not ValidateBelimoCurrent(liveAfter, customerData.no_FKI, belimoReason2) Then
                    allPassed = False
                    log.AppendLine($"- {belimoReason2}")
                    AppendUnitTestPreview($"Variation {variationIndex}: {belimoReason2}")
                    Exit For
                Else
                    log.AppendLine("- Belimo current check: OK")
                    AppendUnitTestPreview($"Variation {variationIndex}: Belimo current check OK")
                End If

                Dim rpmOk As Boolean = False
                If liveAfter IsNot Nothing AndAlso previousLive IsNot Nothing Then
                    Dim deltaF As Integer = liveAfter.RPMMotorF - previousLive.RPMMotorF
                    Dim deltaR As Integer = liveAfter.RPMMotorR - previousLive.RPMMotorR
                    If variationSpeed1 > previousTargetSpeed Then
                        rpmOk = (deltaF >= 300) AndAlso (deltaR >= 300)
                    ElseIf variationSpeed1 < previousTargetSpeed Then
                        rpmOk = (deltaF <= -300) AndAlso (deltaR <= -300)
                    Else
                        rpmOk = True ' nessun cambio richiesto se target identico
                    End If
                ElseIf liveAfter IsNot Nothing Then
                    rpmOk = liveAfter.RPMMotorF > 0 AndAlso liveAfter.RPMMotorR > 0
                End If

                log.AppendLine($"- RPM check: {(If(rpmOk, "OK", "FAILED"))} (F {If(liveAfter IsNot Nothing, liveAfter.RPMMotorF, 0)} / R {If(liveAfter IsNot Nothing, liveAfter.RPMMotorR, 0)}) vs previous target (F {previousLive?.RPMMotorF}, R {previousLive?.RPMMotorR})")
                AppendUnitTestPreview($"Variation {variationIndex}: RPM check {(If(rpmOk, "OK", "FAILED"))}")

                previousLive = liveAfter
                previousTargetSpeed = variationSpeed1
                If Not rpmOk Then
                    allPassed = False
                    log.AppendLine("- Reason: expected RPM change not detected.")
                    Exit For
                End If

                variationIndex += 1
            Next

            If wasCancelled Then
                log.AppendLine()
                log.AppendLine("## Restore original configuration")
                log.AppendLine($"- Original Speed1: {originalSpeed1F}")
                log.AppendLine($"- Original RH setpoint: {originalRhSetPoint}")
                log.AppendLine($"- Original IMBALANCE Enable: {originalImbalanceEnable}")
                log.AppendLine($"- Original KHK Config: {originalKhkConfig}")
                log.AppendLine($"- Original Smoke contact: {originalSmokeValue}")
                Await RestoreOriginalSpeedAsync(ct)
                AppendFinalFooter(log, "CANCELLED", logStart)
                File.WriteAllText(logPath, log.ToString())
                UpdateUnitTestUi("Test annullato dall'utente", False, logPath)
                SignalTestCompletion("CANCELLED")
                Return
            End If

            log.AppendLine()
            log.AppendLine("## Restore original configuration")
            log.AppendLine($"- Original Speed1: {originalSpeed1F}")
            Dim origS2 As String = If(originalSpeed2F > 0, originalSpeed2F.ToString(), "n/a")
            Dim origS3 As String = If(originalSpeed3F > 0, originalSpeed3F.ToString(), "n/a")
            log.AppendLine($"- Restored fan speeds: S1={originalSpeed1F}, S2={origS2}, S3={origS3}")
            log.AppendLine($"- Restored RH setpoint: {originalRhSetPoint}")
            log.AppendLine($"- Restored IMBALANCE Enable: {originalImbalanceEnable}")
            log.AppendLine($"- Restored KHK Config: {originalKhkConfig}")
            log.AppendLine($"- Restored Smoke contact: {originalSmokeValue}")
            Await RestoreOriginalSpeedAsync(ct)
            AppendUnitTestPreview("Original Speed1 restored.")

            AppendFinalFooter(log, If(allPassed, "PASSED", "FAILED"), logStart)
            File.WriteAllText(logPath, log.ToString())
            LoadTestLogs()
            Dim finalLogPath = logPath
            If Not allPassed Then
                finalLogPath = MoveLogToFailed(logPath)
                UpdateUnitTestUi("Test fallito: log spostato in failed", False, finalLogPath)
            Else
                UpdateUnitTestUi("Test concluso con successo", False, finalLogPath)
            End If
            SignalTestCompletion(If(allPassed, "PASSED", "FAILED"))
        Catch ex As Exception
            caughtEx = ex
        End Try

        If caughtEx IsNot Nothing Then
            Await HandleUnitTestExceptionAsync(caughtEx, ct)
            SignalTestCompletion("FAILED")
        End If
    End Function

    Private Async Function HandleUnitTestExceptionAsync(ex As Exception, ct As CancellationToken) As Task
        Dim failPath = unitTestLogPath
        If Not String.IsNullOrWhiteSpace(failPath) AndAlso File.Exists(failPath) Then
            failPath = MoveLogToFailed(failPath)
        End If
        If unitTestRunning Then
            Await RestoreOriginalSpeedAsync(ct)
        End If
        UpdateUnitTestUi($"Errore test: {ex.Message}", False, failPath)
    End Function

    Private Async Sub Btn_StartUnitTest_Click(sender As Object, e As EventArgs) Handles Btn_StartUnitTest.Click
        If unitTestRunning Then
            MessageBox.Show("Un test e' gia' in esecuzione.", "Test unita", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        ClearUnitTestPreview() ' pulizia immediata e reset timer mm:ss
        unitTestCts = New CancellationTokenSource()
        Await RunUnitTestAsync(unitTestCts.Token)
    End Sub

    Private Sub Btn_StopUnitTest_Click(sender As Object, e As EventArgs) Handles Btn_StopUnitTest.Click
        If unitTestRunning Then
            unitTestCts?.Cancel()
            UpdateUnitTestUi("Test annullato dall'utente", False, unitTestLogPath)
            SignalTestCompletion("CANCELLED")
        End If
    End Sub

    Private Sub Btn_RefreshTestLogs_Click(sender As Object, e As EventArgs) Handles Btn_RefreshTestLogs.Click
        LoadTestLogs()
    End Sub

    Private Sub Btn_ExportPdf_Click(sender As Object, e As EventArgs) Handles Btn_ExportPdf.Click
        ExportSelectedLogToPdf()
    End Sub

    Private Async Sub StartMenuRecoveryAfterAccessories()
        Dim startLen = GetConsoleLength()
        Try
            Await Task.Delay(4000)
            If Not SerialPort1.IsOpen Then Return
            Dim newText = GetConsoleSlice(startLen)
            If newText.Contains("Select the number") Then Return
            If tb_COMStrem.Text.Contains("Writing standard HW accessories to EEPROM") Then
                Await ReconnectCurrentPortAsync()
            End If
        Catch
            ' ignore recovery errors
        End Try
    End Sub

    Private Async Function ReconnectCurrentPortAsync() As Task
        If Me.InvokeRequired Then
            Dim tcs As New TaskCompletionSource(Of Boolean)()
            Me.Invoke(Async Sub()
                          Await ReconnectCurrentPortAsync()
                          tcs.SetResult(True)
                      End Sub)
            Await tcs.Task
            Return
        End If

        Try
            If SerialPort1 IsNot Nothing AndAlso SerialPort1.IsOpen Then
                Btn_Disconnect_Click(Btn_Disconnect, EventArgs.Empty)
            End If
            Await Task.Delay(400)
            Btn_Connect_Click(Btn_Connect, EventArgs.Empty)
        Catch ex As Exception
            lb_status.Text = $"Reconnect failed: {ex.Message}"
        End Try
    End Function

    Private Sub lstTestLogs_DoubleClick(sender As Object, e As EventArgs) Handles lstTestLogs.DoubleClick
        Dim item = TryCast(lstTestLogs.SelectedItem, TestLogListItem)
        If item Is Nothing Then Return
        Try
            If File.Exists(item.FullPath) Then
                Dim psi As New ProcessStartInfo With {
                    .FileName = item.FullPath,
                    .UseShellExecute = True
                }
                Process.Start(psi)
            End If
        Catch ex As Exception
            MessageBox.Show($"Cannot open file: {ex.Message}", "Open file error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class



