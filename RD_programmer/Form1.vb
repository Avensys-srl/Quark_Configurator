Imports System.IO
Imports System.IO.Ports
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

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
    ReadOnly logBuffer As New StringBuilder()



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


        If customerData.KHK_VALUE > 1 And customerData.KHK_VALUE < 6 Then
            If customerData.KHK_VALUE = 2 Then
                CB_KHKenable.Checked = False
                RB_NC.Checked = True
                RB_NO.Checked = False
                RB_NC.Enabled = False
                RB_NO.Enabled = False
            End If
            If customerData.KHK_VALUE = 3 Then
                CB_KHKenable.Checked = True
                RB_NC.Checked = True
                RB_NO.Checked = False
                RB_NC.Enabled = True
                RB_NO.Enabled = True
            End If
            If customerData.KHK_VALUE = 4 Then
                CB_KHKenable.Checked = False
                RB_NC.Checked = False
                RB_NO.Checked = True
                RB_NC.Enabled = False
                RB_NO.Enabled = False
            End If
            If customerData.KHK_VALUE = 5 Then
                CB_KHKenable.Checked = True
                RB_NC.Checked = False
                RB_NO.Checked = True
                RB_NC.Enabled = True
                RB_NO.Enabled = True
            End If
        Else
            CB_KHKenable.Checked = False
            RB_NC.Checked = True
            RB_NO.Checked = False
            RB_NC.Enabled = False
            RB_NO.Enabled = False
        End If

        If customerData.IMBALANCESetPoint1 > -70 AndAlso customerData.IMBALANCESetPoint1 < 70 Then
            Invoke(Sub() num_Imbalance_Setpoint1.Value = customerData.IMBALANCESetPoint1)
        Else
            Invoke(Sub() num_Imbalance_Setpoint1.Value = 0)
            Invoke(Sub() customerData.IMBALANCESetPoint1 = 0)
        End If

        If customerData.IMBALANCESetPoint2 > -70 AndAlso customerData.IMBALANCESetPoint2 < 70 Then
            Invoke(Sub() num_Imbalance_Setpoint2.Value = customerData.IMBALANCESetPoint2)
        Else
            Invoke(Sub() num_Imbalance_Setpoint2.Value = 0)
            Invoke(Sub() customerData.IMBALANCESetPoint2 = 0)
        End If

        If customerData.IMBALANCESetPoint3 > -70 AndAlso customerData.IMBALANCESetPoint3 < 70 Then
            Invoke(Sub() num_Imbalance_Setpoint3.Value = customerData.IMBALANCESetPoint3)
        Else
            Invoke(Sub() num_Imbalance_Setpoint3.Value = 0)
            Invoke(Sub() customerData.IMBALANCESetPoint3 = 0)
        End If

        If customerData.IMBALANCE_ENABLE = 1 Then
            CB_ImbEnable.Checked = True
        Else
            CB_ImbEnable.Checked = False
        End If

        If customerData.KHKIMBALANCESetPoint > -70 AndAlso customerData.KHKIMBALANCESetPoint < 70 Then
            Invoke(Sub() num_KHKImbalance_Setpoint.Value = customerData.KHKIMBALANCESetPoint)
        Else
            Invoke(Sub() num_KHKImbalance_Setpoint.Value = 0)
            Invoke(Sub() customerData.KHKIMBALANCESetPoint = 0)
        End If


        'INIZIO Setting Velocità
        Dim velocitaCalcolate1 = customerData.GetCalculatedSpeeds(1)
        Dim velocitaCalcolate2 = customerData.GetCalculatedSpeeds(2)
        Dim velocitaCalcolate3 = customerData.GetCalculatedSpeeds(3)
        Dim velocitaCalcolateK = customerData.GetCalculatedSpeeds(0)


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
        ' FINE Setting Velocità



        If customerData.VersionHW IsNot Nothing AndAlso customerData.VersionHW.Length <> 0 Then
            Invoke(Sub() lb_HW_vers.Text = lb_HW_vers.Text + " " + customerData.VersionHW)
        Else
            Invoke(Sub() lb_HW_vers.Text = "Hardware Version:")
        End If

        If customerData.VersionSW IsNot Nothing AndAlso customerData.VersionSW.Length <> 0 Then
            Invoke(Sub() lb_SW_vers.Text = lb_SW_vers.Text + " " + customerData.VersionSW)
        Else
            Invoke(Sub() lb_SW_vers.Text = "Software Version:")
        End If

        If customerData.SerialNumber IsNot Nothing AndAlso customerData.SerialNumber.Length <> 0 Then
            Invoke(Sub() lb_SerialNumber.Text = lb_SerialNumber.Text + " " + customerData.SerialNumber)
            If customerData.SerialNumber.StartsWith("9999") Then
                Invoke(Sub() Grp_KHK.Visible = True)
            ElseIf customerData.SerialNumber.StartsWith("7603") AndAlso
                    Integer.Parse(customerData.SerialNumber.Substring(customerData.SerialNumber.Length - 3)) < 110 Then
                Invoke(Sub() Grp_KHK.Visible = True)
            ElseIf customerData.SerialNumber.StartsWith("8705") Then
                Invoke(Sub() Grp_KHK.Visible = True)
            ElseIf customerData.SerialNumber.StartsWith("8910") Then
                Invoke(Sub() Grp_KHK.Visible = True)
            Else
                Invoke(Sub() Grp_KHK.Visible = False)
            End If

        Else
            Invoke(Sub() lb_SerialNumber.Text = "Serial Number:")
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
        portWatcher = New ManagementEventWatcher(query)
        AddHandler portWatcher.EventArrived, AddressOf PortChanged
        portWatcher.Start()
    End Sub

    Private Sub PortChanged(sender As Object, e As EventArrivedEventArgs)
        Invoke(Sub() PopulateSerialPorts())
    End Sub

    Private Sub VisibleGroups(isVisible As Boolean)
        Grp_SpeedConf.Visible = isVisible
        Grp_UnitConfig.Visible = isVisible
        Grp_UnitData.Visible = isVisible
        Grp_UnitParam.Visible = isVisible
        Grp_KHK.Visible = isVisible
        Grp_Imbalance.Visible = isVisible
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

    Private Sub Program_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VisibleGroups(False)
        ToggleService(isService)
        PB_SaveData.Visible = False
        lb_SaveProg.Visible = False
        lb_QKvers.Text &= Assembly.GetExecutingAssembly().GetName().Version.ToString()
        StartPortWatcher()
        ToggleControls(isConnected)
        UpdateFormControls()
        PopulateSerialPorts()
    End Sub

    Private Sub Btn_RefreshLIST_Click(sender As Object, e As EventArgs) Handles Btn_RefreshLIST.Click
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
        num_SWSetpoint.Maximum = 99
        customerData.Clear()
        Invoke(Sub() tb_COMStrem.Text = String.Empty)
        UpdateFormControls()
    End Sub


    Private Async Sub SerialDataTimer_Tick(sender As Object, e As EventArgs) Handles SerialDataTimer.Tick

        Dim savestep As Integer

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
                    If tb_COMStrem.Text.Contains("Please set KHK configuration") Then
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
                savestep = (writeStep - 1) / 23 * 100
                PB_SaveData.Value = savestep
                lb_SaveProg.Text = savestep.ToString() + " %"
            End If

        Else

            If Not character2Sent Then
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
        num_F_Speed1.Enabled = True
        num_F_Speed2.Enabled = True
        num_F_Speed3.Enabled = True
        num_R_Speed1.Enabled = True
        num_R_Speed2.Enabled = True
        num_R_Speed3.Enabled = True
        num_BoostTimer.Enabled = True
        num_FilterTimer.Enabled = True
        num_RHSetpoint.Enabled = True
        num_TempSetpoint.Enabled = True
        num_FKITimer.Enabled = True
        If (customerData.SUM_WINSetPoint = 99) Then
            CB_BPDisable.Checked = True
        Else
            CB_BPDisable.Checked = False
            num_SWSetpoint.Enabled = True
        End If
    End Sub


    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim receivedData As String = SerialPort1.ReadExisting()

        ' Accumula i dati nel buffer
        SyncLock logBuffer
            logBuffer.Append(receivedData)

            ' Controlla se il buffer contiene una linea completa
            While logBuffer.ToString().Contains(vbLf)
                ' Trova la posizione della prima newline
                Dim lineEndIndex As Integer = logBuffer.ToString().IndexOf(vbLf)

                ' Estrai la linea completa
                Dim completeLine As String = logBuffer.ToString().Substring(0, lineEndIndex).Trim()

                ' Rimuovi la riga dal buffer
                logBuffer.Remove(0, lineEndIndex + 1)

                ' Scrivi la linea nel log e aggiorna l'interfaccia grafica
                Invoke(Sub()
                           tb_COMStrem.AppendText(completeLine & Environment.NewLine)
                           AppendLogData(completeLine) ' Scrive solo righe complete nel log
                       End Sub)
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
                ToggleControls(isConnected)
                StartInactivityTimer()
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
            ToggleControls(isConnected)
            Refresh_Data()
            StopInactivityTimer()
            VisibleGroups(False)
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

    Private Sub ParseCustomerData(data As String, customerData As CustomerData)

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
                End Select
            End If
        Next

        UpdateFormControls()

    End Sub

    Private Sub Btn_RefreshData_Click(sender As Object, e As EventArgs) Handles Btn_RefreshData.Click
        Refresh_Data()
    End Sub

    Private Sub RB_left_CheckedChanged(sender As Object, e As EventArgs) Handles RB_left.CheckedChanged
        If RB_left.Checked = True Then
            PcBx_Quark.Image = My.Resources._412_DRAW_QUARK_FL_D
        End If
    End Sub

    Private Sub RB_right_CheckedChanged(sender As Object, e As EventArgs) Handles RB_right.CheckedChanged
        If RB_right.Checked = True Then
            PcBx_Quark.Image = My.Resources._411_DRAW_QUARK_FL_C
        End If
    End Sub

    Private Sub F_Speed1_ValueChanged(sender As Object, e As EventArgs) Handles num_F_Speed1.ValueChanged

        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_Speed1.Value, num_R_Speed1.Value, 1)
            num_Imbalance_Setpoint1.Value = customerData.IMBALANCESetPoint1
        Else
            num_R_Speed1.Value = num_F_Speed1.Value
            customerData.UpdateSpeedSettings(num_F_Speed1.Value, num_R_Speed1.Value, 1)
            num_Imbalance_Setpoint1.Value = customerData.IMBALANCESetPoint1
        End If

    End Sub

    Private Sub F_Speed2_ValueChanged(sender As Object, e As EventArgs) Handles num_F_Speed2.ValueChanged

        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_Speed2.Value, num_R_Speed2.Value, 2)
            num_Imbalance_Setpoint2.Value = customerData.IMBALANCESetPoint2
        Else
            num_R_Speed2.Value = num_F_Speed2.Value
            customerData.UpdateSpeedSettings(num_F_Speed2.Value, num_R_Speed2.Value, 2)
            num_Imbalance_Setpoint2.Value = customerData.IMBALANCESetPoint2
        End If

    End Sub

    Private Sub F_Speed3_ValueChanged(sender As Object, e As EventArgs) Handles num_F_Speed3.ValueChanged

        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_Speed3.Value, num_R_Speed3.Value, 3)
            num_Imbalance_Setpoint3.Value = customerData.IMBALANCESetPoint3
        Else
            num_R_Speed3.Value = num_F_Speed3.Value
            customerData.UpdateSpeedSettings(num_F_Speed3.Value, num_R_Speed3.Value, 3)
            num_Imbalance_Setpoint3.Value = customerData.IMBALANCESetPoint3
        End If

    End Sub


    Private Sub R_Speed1_ValueChanged(sender As Object, e As EventArgs) Handles num_R_Speed1.ValueChanged

        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_Speed1.Value, num_R_Speed1.Value, 1)
            num_Imbalance_Setpoint1.Value = customerData.IMBALANCESetPoint1
        Else
            num_F_Speed1.Value = num_R_Speed1.Value
            customerData.UpdateSpeedSettings(num_F_Speed1.Value, num_R_Speed1.Value, 1)
            num_Imbalance_Setpoint1.Value = customerData.IMBALANCESetPoint1
        End If

    End Sub

    Private Sub R_Speed2_ValueChanged(sender As Object, e As EventArgs) Handles num_R_Speed2.ValueChanged

        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_Speed2.Value, num_R_Speed2.Value, 2)
            num_Imbalance_Setpoint2.Value = customerData.IMBALANCESetPoint2
        Else
            num_F_Speed2.Value = num_R_Speed2.Value
            customerData.UpdateSpeedSettings(num_F_Speed2.Value, num_R_Speed2.Value, 2)
            num_Imbalance_Setpoint2.Value = customerData.IMBALANCESetPoint2
        End If

    End Sub

    Private Sub R_Speed3_ValueChanged(sender As Object, e As EventArgs) Handles num_R_Speed3.ValueChanged

        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_F_Speed3.Value, num_R_Speed3.Value, 3)
            num_Imbalance_Setpoint3.Value = customerData.IMBALANCESetPoint3
        Else
            num_F_Speed3.Value = num_R_Speed3.Value
            customerData.UpdateSpeedSettings(num_F_Speed3.Value, num_R_Speed3.Value, 3)
            num_Imbalance_Setpoint3.Value = customerData.IMBALANCESetPoint3
        End If

    End Sub


    Private Sub Speed1CAP_ValueChanged(sender As Object, e As EventArgs) Handles num_Speed1CAP.ValueChanged, NumericUpDown4.ValueChanged

        If num_Speed1CAP.Value > num_Speed2CAP.Value Then
            num_Speed2CAP.Value = num_Speed1CAP.Value
        End If
    End Sub

    Private Sub Speed2CAP_ValueChanged(sender As Object, e As EventArgs) Handles num_Speed2CAP.ValueChanged, NumericUpDown5.ValueChanged

        If num_Speed2CAP.Value > num_Speed3CAP.Value Then
            num_Speed3CAP.Value = num_Speed2CAP.Value
        End If
        If num_Speed2CAP.Value < num_Speed1CAP.Value Then
            num_Speed1CAP.Value = num_Speed2CAP.Value
        End If
    End Sub

    Private Sub Speed3CAP_ValueChanged(sender As Object, e As EventArgs) Handles num_Speed3CAP.ValueChanged, NumericUpDown6.ValueChanged

        If num_Speed3CAP.Value < num_Speed2CAP.Value Then
            num_Speed2CAP.Value = num_Speed3CAP.Value
        End If
    End Sub

    Private Sub Btn_SaveData_Click(sender As Object, e As EventArgs) Handles Btn_SaveData.Click
        isWriting = True
        PB_SaveData.Visible = isWriting
        lb_SaveProg.Visible = isWriting
        lb_status.Text = "Saving data... please wait"
    End Sub

    Private Sub KHK_ENABLE_CheckedChanged(sender As Object, e As EventArgs) Handles CB_KHKenable.CheckedChanged
        num_FK_Speed.Enabled = CB_KHKenable.Checked
        num_RK_Speed.Enabled = CB_KHKenable.Checked

        If CB_KHKenable.Checked = True Then
            If RB_NC.Checked = True Then
                customerData.KHK_VALUE = 3
                RB_NC.Enabled = True
                RB_NO.Enabled = True
            Else
                customerData.KHK_VALUE = 5
                RB_NC.Enabled = True
                RB_NO.Enabled = True
            End If
        Else
            If RB_NC.Checked = True Then
                customerData.KHK_VALUE = 2
                RB_NC.Enabled = False
                RB_NO.Enabled = False
            Else
                customerData.KHK_VALUE = 4
                RB_NC.Enabled = False
                RB_NO.Enabled = False
            End If
        End If
    End Sub

    Private Sub NC_Button_CheckedChanged(sender As Object, e As EventArgs) Handles RB_NC.CheckedChanged
        If CB_KHKenable.Checked = True Then
            If RB_NC.Checked = True Then
                customerData.KHK_VALUE = 3
            End If
        End If
    End Sub

    Private Sub NO_Button_CheckedChanged(sender As Object, e As EventArgs) Handles RB_NO.CheckedChanged
        If CB_KHKenable.Checked = True Then
            If RB_NO.Checked = True Then
                customerData.KHK_VALUE = 5
            End If
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
            num_R_Speed1.Value = num_F_Speed1.Value
            num_R_Speed2.Value = num_F_Speed2.Value
            num_R_Speed3.Value = num_F_Speed3.Value
            num_RK_Speed.Value = num_FK_Speed.Value
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
        Else
            num_SWSetpoint.Maximum = 32
            num_SWSetpoint.Value = 16
            num_SWSetpoint.Enabled = True
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
            num_KHKImbalance_Setpoint.Value = customerData.KHKIMBALANCESetPoint
        Else
            num_RK_Speed.Value = num_FK_Speed.Value
            customerData.UpdateSpeedSettings(num_FK_Speed.Value, num_RK_Speed.Value, 0)
            num_KHKImbalance_Setpoint.Value = customerData.KHKIMBALANCESetPoint
        End If
    End Sub

    Private Sub RK_Speed_ValueChanged(sender As Object, e As EventArgs) Handles num_RK_Speed.ValueChanged
        If CB_ImbEnable.Checked Then
            customerData.UpdateSpeedSettings(num_FK_Speed.Value, num_RK_Speed.Value, 0)
            num_KHKImbalance_Setpoint.Value = customerData.KHKIMBALANCESetPoint
        Else
            num_FK_Speed.Value = num_RK_Speed.Value
            customerData.UpdateSpeedSettings(num_FK_Speed.Value, num_RK_Speed.Value, 0)
            num_KHKImbalance_Setpoint.Value = customerData.KHKIMBALANCESetPoint
        End If
    End Sub


End Class


