<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Program_Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Program_Form))
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TP_Configurator = New System.Windows.Forms.TabPage()
        Me.Grp_Acc = New System.Windows.Forms.GroupBox()
        Me.Btn_ResAcc = New System.Windows.Forms.Button()
        Me.TB_acc = New System.Windows.Forms.TextBox()
        Me.Grp_Live = New System.Windows.Forms.GroupBox()
        Me.TB_alarm = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.CB_LiveData = New System.Windows.Forms.CheckBox()
        Me.lblTExhaust = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lblTSupply = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblRReturn = New System.Windows.Forms.Label()
        Me.lblTReturn = New System.Windows.Forms.Label()
        Me.lblRPMReturn = New System.Windows.Forms.Label()
        Me.lblRPMSupply = New System.Windows.Forms.Label()
        Me.lblRFresh = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblVReturn = New System.Windows.Forms.Label()
        Me.lblVSupply = New System.Windows.Forms.Label()
        Me.lblTFresh = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Grp_Smoke = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.CB_SmokeEnable = New System.Windows.Forms.CheckBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.RB_SmokeNO = New System.Windows.Forms.RadioButton()
        Me.RB_SmokeNC = New System.Windows.Forms.RadioButton()
        Me.Grp_DateTime = New System.Windows.Forms.GroupBox()
        Me.BtnUpdateDateTime = New System.Windows.Forms.Button()
        Me.lb_DateTimeTimer = New System.Windows.Forms.Label()
        Me.Grp_KHK = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CB_DisableTemperatureControl = New System.Windows.Forms.CheckBox()
        Me.lb_KHKenable = New System.Windows.Forms.Label()
        Me.lb_KHKContactBehavoir = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.num_FK_Speed = New System.Windows.Forms.NumericUpDown()
        Me.num_RK_Speed = New System.Windows.Forms.NumericUpDown()
        Me.lb_KHKSetpoint = New System.Windows.Forms.Label()
        Me.RB_NO = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CB_KHKenable = New System.Windows.Forms.CheckBox()
        Me.RB_NC = New System.Windows.Forms.RadioButton()
        Me.Grp_Preset = New System.Windows.Forms.GroupBox()
        Me.Lsb_FileConfig = New System.Windows.Forms.ListBox()
        Me.Btn_Rem = New System.Windows.Forms.Button()
        Me.Btn_Add = New System.Windows.Forms.Button()
        Me.Btn_Apply = New System.Windows.Forms.Button()
        Me.Btn_FirmwareUpdate = New System.Windows.Forms.Button()
        Me.lb_SaveProg = New System.Windows.Forms.Label()
        Me.PB_SaveData = New System.Windows.Forms.ProgressBar()
        Me.Grp_UnitConfig = New System.Windows.Forms.GroupBox()
        Me.PcBx_Quark = New System.Windows.Forms.PictureBox()
        Me.RB_right = New System.Windows.Forms.RadioButton()
        Me.lb_Configuration = New System.Windows.Forms.Label()
        Me.RB_left = New System.Windows.Forms.RadioButton()
        Me.Grp_UnitParam = New System.Windows.Forms.GroupBox()
        Me.num_Belimo = New System.Windows.Forms.NumericUpDown()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CB_BPDisable = New System.Windows.Forms.CheckBox()
        Me.num_SWSetpoint = New System.Windows.Forms.NumericUpDown()
        Me.num_TempSetpoint = New System.Windows.Forms.NumericUpDown()
        Me.num_VOCSetpoint = New System.Windows.Forms.NumericUpDown()
        Me.num_RHSetpoint = New System.Windows.Forms.NumericUpDown()
        Me.num_CO2Setpoint = New System.Windows.Forms.NumericUpDown()
        Me.num_FKITimer = New System.Windows.Forms.NumericUpDown()
        Me.num_FilterTimer = New System.Windows.Forms.NumericUpDown()
        Me.num_BoostTimer = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lb_SWSetpoint = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lb_TempSetpoint = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lb_VOCSetpoint = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lb_RHSetpoint = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lb_CO2Setpoint = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lb_FKITimer = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lb_FilterTimer = New System.Windows.Forms.Label()
        Me.lb_BoostTimer = New System.Windows.Forms.Label()
        Me.Grp_UnitData = New System.Windows.Forms.GroupBox()
        Me.lb_SW_vers = New System.Windows.Forms.Label()
        Me.lb_HW_vers = New System.Windows.Forms.Label()
        Me.lb_SerialNumber = New System.Windows.Forms.Label()
        Me.Grp_SpeedConf = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.NumericUpDown6 = New System.Windows.Forms.NumericUpDown()
        Me.num_Speed3CAP = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown()
        Me.num_Speed2CAP = New System.Windows.Forms.NumericUpDown()
        Me.lb_ImbalanceEnable = New System.Windows.Forms.Label()
        Me.CB_ImbEnable = New System.Windows.Forms.CheckBox()
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown()
        Me.num_Speed1CAP = New System.Windows.Forms.NumericUpDown()
        Me.num_R_IAQSpeed = New System.Windows.Forms.NumericUpDown()
        Me.num_R_Speed3 = New System.Windows.Forms.NumericUpDown()
        Me.num_F_IAQSpeed = New System.Windows.Forms.NumericUpDown()
        Me.num_F_Speed3 = New System.Windows.Forms.NumericUpDown()
        Me.num_R_Speed2 = New System.Windows.Forms.NumericUpDown()
        Me.num_F_Speed2 = New System.Windows.Forms.NumericUpDown()
        Me.num_R_Speed1 = New System.Windows.Forms.NumericUpDown()
        Me.num_F_Speed1 = New System.Windows.Forms.NumericUpDown()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.vlb_Speed3CAP = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lb_Speed3CAP = New System.Windows.Forms.Label()
        Me.vlb_Speed2CAP = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lb_Speed2CAP = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.vlb_Speed1CAP = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lb_Speed1CAP = New System.Windows.Forms.Label()
        Me.vlb_Speed3FSC = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lb_Speed3FSC = New System.Windows.Forms.Label()
        Me.vlb_Speed2FSC = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lb_Speed2FSC = New System.Windows.Forms.Label()
        Me.vlb_Speed1FSC = New System.Windows.Forms.Label()
        Me.lb_Speed1FSC = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.COM_List = New System.Windows.Forms.ListBox()
        Me.lb_status = New System.Windows.Forms.Label()
        Me.Btn_RefreshLIST = New System.Windows.Forms.Button()
        Me.Btn_Connect = New System.Windows.Forms.Button()
        Me.Btn_SaveData = New System.Windows.Forms.Button()
        Me.Btn_RefreshData = New System.Windows.Forms.Button()
        Me.Btn_Disconnect = New System.Windows.Forms.Button()
        Me.PcBx_Logo = New System.Windows.Forms.PictureBox()
        Me.Tab_Main = New System.Windows.Forms.TabControl()
        Me.TP_Shell = New System.Windows.Forms.TabPage()
        Me.CB_Timestamp = New System.Windows.Forms.CheckBox()
        Me.CB_SaveLog = New System.Windows.Forms.CheckBox()
        Me.Input_String = New System.Windows.Forms.RichTextBox()
        Me.tb_COMStrem = New System.Windows.Forms.RichTextBox()
        Me.Btn_SendData = New System.Windows.Forms.Button()
        Me.SerialDataTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lb_QKvers = New System.Windows.Forms.Label()
        Me.TimerDateTime = New System.Windows.Forms.Timer(Me.components)
        Me.TP_Configurator.SuspendLayout()
        Me.Grp_Acc.SuspendLayout()
        Me.Grp_Live.SuspendLayout()
        Me.Grp_Smoke.SuspendLayout()
        Me.Grp_DateTime.SuspendLayout()
        Me.Grp_KHK.SuspendLayout()
        CType(Me.num_FK_Speed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_RK_Speed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_Preset.SuspendLayout()
        Me.Grp_UnitConfig.SuspendLayout()
        CType(Me.PcBx_Quark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_UnitParam.SuspendLayout()
        CType(Me.num_Belimo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_SWSetpoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_TempSetpoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_VOCSetpoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_RHSetpoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_CO2Setpoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_FKITimer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_FilterTimer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_BoostTimer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_UnitData.SuspendLayout()
        Me.Grp_SpeedConf.SuspendLayout()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_Speed3CAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_Speed2CAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_Speed1CAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_R_IAQSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_R_Speed3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_F_IAQSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_F_Speed3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_R_Speed2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_F_Speed2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_R_Speed1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_F_Speed1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PcBx_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_Main.SuspendLayout()
        Me.TP_Shell.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        '
        'TP_Configurator
        '
        Me.TP_Configurator.Controls.Add(Me.Grp_Acc)
        Me.TP_Configurator.Controls.Add(Me.Grp_Live)
        Me.TP_Configurator.Controls.Add(Me.Grp_Smoke)
        Me.TP_Configurator.Controls.Add(Me.Grp_DateTime)
        Me.TP_Configurator.Controls.Add(Me.Grp_KHK)
        Me.TP_Configurator.Controls.Add(Me.Grp_Preset)
        Me.TP_Configurator.Controls.Add(Me.Btn_FirmwareUpdate)
        Me.TP_Configurator.Controls.Add(Me.lb_SaveProg)
        Me.TP_Configurator.Controls.Add(Me.PB_SaveData)
        Me.TP_Configurator.Controls.Add(Me.Grp_UnitConfig)
        Me.TP_Configurator.Controls.Add(Me.Grp_UnitParam)
        Me.TP_Configurator.Controls.Add(Me.Grp_UnitData)
        Me.TP_Configurator.Controls.Add(Me.Grp_SpeedConf)
        Me.TP_Configurator.Controls.Add(Me.Label2)
        Me.TP_Configurator.Controls.Add(Me.COM_List)
        Me.TP_Configurator.Controls.Add(Me.lb_status)
        Me.TP_Configurator.Controls.Add(Me.Btn_RefreshLIST)
        Me.TP_Configurator.Controls.Add(Me.Btn_Connect)
        Me.TP_Configurator.Controls.Add(Me.Btn_SaveData)
        Me.TP_Configurator.Controls.Add(Me.Btn_RefreshData)
        Me.TP_Configurator.Controls.Add(Me.Btn_Disconnect)
        Me.TP_Configurator.Controls.Add(Me.PcBx_Logo)
        Me.TP_Configurator.Location = New System.Drawing.Point(4, 22)
        Me.TP_Configurator.Name = "TP_Configurator"
        Me.TP_Configurator.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_Configurator.Size = New System.Drawing.Size(1073, 481)
        Me.TP_Configurator.TabIndex = 0
        Me.TP_Configurator.Text = "Configurator"
        Me.TP_Configurator.UseVisualStyleBackColor = True
        '
        'Grp_Acc
        '
        Me.Grp_Acc.Controls.Add(Me.Btn_ResAcc)
        Me.Grp_Acc.Controls.Add(Me.TB_acc)
        Me.Grp_Acc.Location = New System.Drawing.Point(655, 391)
        Me.Grp_Acc.Name = "Grp_Acc"
        Me.Grp_Acc.Size = New System.Drawing.Size(210, 84)
        Me.Grp_Acc.TabIndex = 21
        Me.Grp_Acc.TabStop = False
        Me.Grp_Acc.Text = "Accessories List"
        '
        'Btn_ResAcc
        '
        Me.Btn_ResAcc.Location = New System.Drawing.Point(159, 19)
        Me.Btn_ResAcc.Name = "Btn_ResAcc"
        Me.Btn_ResAcc.Size = New System.Drawing.Size(45, 59)
        Me.Btn_ResAcc.TabIndex = 1
        Me.Btn_ResAcc.Text = "Reset List"
        Me.Btn_ResAcc.UseVisualStyleBackColor = True
        '
        'TB_acc
        '
        Me.TB_acc.Location = New System.Drawing.Point(7, 19)
        Me.TB_acc.Multiline = True
        Me.TB_acc.Name = "TB_acc"
        Me.TB_acc.ReadOnly = True
        Me.TB_acc.Size = New System.Drawing.Size(146, 59)
        Me.TB_acc.TabIndex = 0
        '
        'Grp_Live
        '
        Me.Grp_Live.Controls.Add(Me.TB_alarm)
        Me.Grp_Live.Controls.Add(Me.Label35)
        Me.Grp_Live.Controls.Add(Me.Label33)
        Me.Grp_Live.Controls.Add(Me.CB_LiveData)
        Me.Grp_Live.Controls.Add(Me.lblTExhaust)
        Me.Grp_Live.Controls.Add(Me.Label32)
        Me.Grp_Live.Controls.Add(Me.lblTSupply)
        Me.Grp_Live.Controls.Add(Me.Label31)
        Me.Grp_Live.Controls.Add(Me.lblRReturn)
        Me.Grp_Live.Controls.Add(Me.lblTReturn)
        Me.Grp_Live.Controls.Add(Me.lblRPMReturn)
        Me.Grp_Live.Controls.Add(Me.lblRPMSupply)
        Me.Grp_Live.Controls.Add(Me.lblRFresh)
        Me.Grp_Live.Controls.Add(Me.Label30)
        Me.Grp_Live.Controls.Add(Me.lblVReturn)
        Me.Grp_Live.Controls.Add(Me.lblVSupply)
        Me.Grp_Live.Controls.Add(Me.lblTFresh)
        Me.Grp_Live.Controls.Add(Me.Label37)
        Me.Grp_Live.Controls.Add(Me.Label34)
        Me.Grp_Live.Controls.Add(Me.Label29)
        Me.Grp_Live.Location = New System.Drawing.Point(871, 185)
        Me.Grp_Live.Name = "Grp_Live"
        Me.Grp_Live.Size = New System.Drawing.Size(196, 290)
        Me.Grp_Live.TabIndex = 20
        Me.Grp_Live.TabStop = False
        Me.Grp_Live.Text = "LiveData"
        '
        'TB_alarm
        '
        Me.TB_alarm.Location = New System.Drawing.Point(10, 177)
        Me.TB_alarm.Multiline = True
        Me.TB_alarm.Name = "TB_alarm"
        Me.TB_alarm.ReadOnly = True
        Me.TB_alarm.Size = New System.Drawing.Size(180, 84)
        Me.TB_alarm.TabIndex = 19
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(7, 159)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(56, 13)
        Me.Label35.TabIndex = 18
        Me.Label35.Text = "Alarm box:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(33, 266)
        Me.Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(117, 13)
        Me.Label33.TabIndex = 17
        Me.Label33.Text = "Keep live data updated"
        '
        'CB_LiveData
        '
        Me.CB_LiveData.AutoSize = True
        Me.CB_LiveData.Enabled = False
        Me.CB_LiveData.Location = New System.Drawing.Point(14, 266)
        Me.CB_LiveData.Margin = New System.Windows.Forms.Padding(2)
        Me.CB_LiveData.Name = "CB_LiveData"
        Me.CB_LiveData.Size = New System.Drawing.Size(15, 14)
        Me.CB_LiveData.TabIndex = 16
        Me.CB_LiveData.UseVisualStyleBackColor = True
        '
        'lblTExhaust
        '
        Me.lblTExhaust.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTExhaust.AutoSize = True
        Me.lblTExhaust.Location = New System.Drawing.Point(72, 83)
        Me.lblTExhaust.Name = "lblTExhaust"
        Me.lblTExhaust.Size = New System.Drawing.Size(42, 13)
        Me.lblTExhaust.TabIndex = 0
        Me.lblTExhaust.Text = "00.0 °C"
        Me.lblTExhaust.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(7, 83)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(51, 13)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "Exhaust :"
        '
        'lblTSupply
        '
        Me.lblTSupply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTSupply.AutoSize = True
        Me.lblTSupply.Location = New System.Drawing.Point(72, 62)
        Me.lblTSupply.Name = "lblTSupply"
        Me.lblTSupply.Size = New System.Drawing.Size(42, 13)
        Me.lblTSupply.TabIndex = 0
        Me.lblTSupply.Text = "00.0 °C"
        Me.lblTSupply.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(7, 62)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(45, 13)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "Supply :"
        '
        'lblRReturn
        '
        Me.lblRReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRReturn.AutoSize = True
        Me.lblRReturn.Location = New System.Drawing.Point(120, 41)
        Me.lblRReturn.Name = "lblRReturn"
        Me.lblRReturn.Size = New System.Drawing.Size(30, 13)
        Me.lblRReturn.TabIndex = 0
        Me.lblRReturn.Text = "00 %"
        Me.lblRReturn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTReturn
        '
        Me.lblTReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTReturn.AutoSize = True
        Me.lblTReturn.Location = New System.Drawing.Point(72, 41)
        Me.lblTReturn.Name = "lblTReturn"
        Me.lblTReturn.Size = New System.Drawing.Size(42, 13)
        Me.lblTReturn.TabIndex = 0
        Me.lblTReturn.Text = "00.0 °C"
        Me.lblTReturn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblRPMReturn
        '
        Me.lblRPMReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRPMReturn.AutoSize = True
        Me.lblRPMReturn.Location = New System.Drawing.Point(120, 130)
        Me.lblRPMReturn.Name = "lblRPMReturn"
        Me.lblRPMReturn.Size = New System.Drawing.Size(51, 13)
        Me.lblRPMReturn.TabIndex = 0
        Me.lblRPMReturn.Text = "0000 rpm"
        Me.lblRPMReturn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblRPMSupply
        '
        Me.lblRPMSupply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRPMSupply.AutoSize = True
        Me.lblRPMSupply.Location = New System.Drawing.Point(120, 111)
        Me.lblRPMSupply.Name = "lblRPMSupply"
        Me.lblRPMSupply.Size = New System.Drawing.Size(51, 13)
        Me.lblRPMSupply.TabIndex = 0
        Me.lblRPMSupply.Text = "0000 rpm"
        Me.lblRPMSupply.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblRFresh
        '
        Me.lblRFresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRFresh.AutoSize = True
        Me.lblRFresh.Location = New System.Drawing.Point(120, 20)
        Me.lblRFresh.Name = "lblRFresh"
        Me.lblRFresh.Size = New System.Drawing.Size(30, 13)
        Me.lblRFresh.TabIndex = 0
        Me.lblRFresh.Text = "00 %"
        Me.lblRFresh.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(7, 41)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(45, 13)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Return :"
        '
        'lblVReturn
        '
        Me.lblVReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVReturn.AutoSize = True
        Me.lblVReturn.Location = New System.Drawing.Point(72, 130)
        Me.lblVReturn.Name = "lblVReturn"
        Me.lblVReturn.Size = New System.Drawing.Size(38, 13)
        Me.lblVReturn.TabIndex = 0
        Me.lblVReturn.Text = "00.0 V"
        Me.lblVReturn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVSupply
        '
        Me.lblVSupply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVSupply.AutoSize = True
        Me.lblVSupply.Location = New System.Drawing.Point(72, 111)
        Me.lblVSupply.Name = "lblVSupply"
        Me.lblVSupply.Size = New System.Drawing.Size(38, 13)
        Me.lblVSupply.TabIndex = 0
        Me.lblVSupply.Text = "00.0 V"
        Me.lblVSupply.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTFresh
        '
        Me.lblTFresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTFresh.AutoSize = True
        Me.lblTFresh.Location = New System.Drawing.Point(72, 20)
        Me.lblTFresh.Name = "lblTFresh"
        Me.lblTFresh.Size = New System.Drawing.Size(42, 13)
        Me.lblTFresh.TabIndex = 0
        Me.lblTFresh.Text = "00.0 °C"
        Me.lblTFresh.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(7, 130)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(66, 13)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "Return Fan :"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(7, 111)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(66, 13)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "Supply Fan :"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(7, 20)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(39, 13)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "Fresh :"
        '
        'Grp_Smoke
        '
        Me.Grp_Smoke.Controls.Add(Me.Label28)
        Me.Grp_Smoke.Controls.Add(Me.CB_SmokeEnable)
        Me.Grp_Smoke.Controls.Add(Me.Label27)
        Me.Grp_Smoke.Controls.Add(Me.RB_SmokeNO)
        Me.Grp_Smoke.Controls.Add(Me.RB_SmokeNC)
        Me.Grp_Smoke.Location = New System.Drawing.Point(477, 401)
        Me.Grp_Smoke.Name = "Grp_Smoke"
        Me.Grp_Smoke.Size = New System.Drawing.Size(172, 74)
        Me.Grp_Smoke.TabIndex = 19
        Me.Grp_Smoke.TabStop = False
        Me.Grp_Smoke.Text = "Smoke Detector (Input 2)"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(28, 21)
        Me.Label28.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(116, 13)
        Me.Label28.TabIndex = 17
        Me.Label28.Text = "Enable Smoke Contact"
        '
        'CB_SmokeEnable
        '
        Me.CB_SmokeEnable.AutoSize = True
        Me.CB_SmokeEnable.Location = New System.Drawing.Point(9, 21)
        Me.CB_SmokeEnable.Margin = New System.Windows.Forms.Padding(2)
        Me.CB_SmokeEnable.Name = "CB_SmokeEnable"
        Me.CB_SmokeEnable.Size = New System.Drawing.Size(15, 14)
        Me.CB_SmokeEnable.TabIndex = 16
        Me.CB_SmokeEnable.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(2, 48)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(89, 13)
        Me.Label27.TabIndex = 15
        Me.Label27.Text = "Contact Behavior"
        '
        'RB_SmokeNO
        '
        Me.RB_SmokeNO.AutoSize = True
        Me.RB_SmokeNO.Location = New System.Drawing.Point(133, 46)
        Me.RB_SmokeNO.Margin = New System.Windows.Forms.Padding(2)
        Me.RB_SmokeNO.Name = "RB_SmokeNO"
        Me.RB_SmokeNO.Size = New System.Drawing.Size(40, 17)
        Me.RB_SmokeNO.TabIndex = 14
        Me.RB_SmokeNO.TabStop = True
        Me.RB_SmokeNO.Text = "NC"
        Me.RB_SmokeNO.UseVisualStyleBackColor = True
        '
        'RB_SmokeNC
        '
        Me.RB_SmokeNC.AutoSize = True
        Me.RB_SmokeNC.Location = New System.Drawing.Point(94, 46)
        Me.RB_SmokeNC.Margin = New System.Windows.Forms.Padding(2)
        Me.RB_SmokeNC.Name = "RB_SmokeNC"
        Me.RB_SmokeNC.Size = New System.Drawing.Size(41, 17)
        Me.RB_SmokeNC.TabIndex = 13
        Me.RB_SmokeNC.TabStop = True
        Me.RB_SmokeNC.Text = "NO"
        Me.RB_SmokeNC.UseVisualStyleBackColor = True
        '
        'Grp_DateTime
        '
        Me.Grp_DateTime.Controls.Add(Me.BtnUpdateDateTime)
        Me.Grp_DateTime.Controls.Add(Me.lb_DateTimeTimer)
        Me.Grp_DateTime.Location = New System.Drawing.Point(362, 351)
        Me.Grp_DateTime.Name = "Grp_DateTime"
        Me.Grp_DateTime.Size = New System.Drawing.Size(224, 50)
        Me.Grp_DateTime.TabIndex = 18
        Me.Grp_DateTime.TabStop = False
        Me.Grp_DateTime.Text = "Date and Time"
        Me.Grp_DateTime.Visible = False
        '
        'BtnUpdateDateTime
        '
        Me.BtnUpdateDateTime.Location = New System.Drawing.Point(143, 10)
        Me.BtnUpdateDateTime.Name = "BtnUpdateDateTime"
        Me.BtnUpdateDateTime.Size = New System.Drawing.Size(75, 34)
        Me.BtnUpdateDateTime.TabIndex = 2
        Me.BtnUpdateDateTime.Text = "Update DateTime"
        Me.BtnUpdateDateTime.UseVisualStyleBackColor = True
        '
        'lb_DateTimeTimer
        '
        Me.lb_DateTimeTimer.AutoSize = True
        Me.lb_DateTimeTimer.Location = New System.Drawing.Point(6, 25)
        Me.lb_DateTimeTimer.Name = "lb_DateTimeTimer"
        Me.lb_DateTimeTimer.Size = New System.Drawing.Size(94, 13)
        Me.lb_DateTimeTimer.TabIndex = 17
        Me.lb_DateTimeTimer.Text = "Now on the Quark"
        '
        'Grp_KHK
        '
        Me.Grp_KHK.Controls.Add(Me.Label13)
        Me.Grp_KHK.Controls.Add(Me.Label10)
        Me.Grp_KHK.Controls.Add(Me.Label14)
        Me.Grp_KHK.Controls.Add(Me.CB_DisableTemperatureControl)
        Me.Grp_KHK.Controls.Add(Me.lb_KHKenable)
        Me.Grp_KHK.Controls.Add(Me.lb_KHKContactBehavoir)
        Me.Grp_KHK.Controls.Add(Me.Label23)
        Me.Grp_KHK.Controls.Add(Me.num_FK_Speed)
        Me.Grp_KHK.Controls.Add(Me.num_RK_Speed)
        Me.Grp_KHK.Controls.Add(Me.lb_KHKSetpoint)
        Me.Grp_KHK.Controls.Add(Me.RB_NO)
        Me.Grp_KHK.Controls.Add(Me.Label12)
        Me.Grp_KHK.Controls.Add(Me.CB_KHKenable)
        Me.Grp_KHK.Controls.Add(Me.RB_NC)
        Me.Grp_KHK.Location = New System.Drawing.Point(14, 401)
        Me.Grp_KHK.Name = "Grp_KHK"
        Me.Grp_KHK.Size = New System.Drawing.Size(457, 74)
        Me.Grp_KHK.TabIndex = 14
        Me.Grp_KHK.TabStop = False
        Me.Grp_KHK.Text = "KHK (Green Connector)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(206, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Return"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(307, 21)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(141, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Disable Temperature Control"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(129, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Supply"
        '
        'CB_DisableTemperatureControl
        '
        Me.CB_DisableTemperatureControl.AutoSize = True
        Me.CB_DisableTemperatureControl.Location = New System.Drawing.Point(288, 21)
        Me.CB_DisableTemperatureControl.Margin = New System.Windows.Forms.Padding(2)
        Me.CB_DisableTemperatureControl.Name = "CB_DisableTemperatureControl"
        Me.CB_DisableTemperatureControl.Size = New System.Drawing.Size(15, 14)
        Me.CB_DisableTemperatureControl.TabIndex = 13
        Me.CB_DisableTemperatureControl.UseVisualStyleBackColor = True
        '
        'lb_KHKenable
        '
        Me.lb_KHKenable.AutoSize = True
        Me.lb_KHKenable.Location = New System.Drawing.Point(36, 22)
        Me.lb_KHKenable.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_KHKenable.Name = "lb_KHKenable"
        Me.lb_KHKenable.Size = New System.Drawing.Size(65, 13)
        Me.lb_KHKenable.TabIndex = 5
        Me.lb_KHKenable.Text = "Enable KHK"
        '
        'lb_KHKContactBehavoir
        '
        Me.lb_KHKContactBehavoir.AutoSize = True
        Me.lb_KHKContactBehavoir.Location = New System.Drawing.Point(283, 48)
        Me.lb_KHKContactBehavoir.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_KHKContactBehavoir.Name = "lb_KHKContactBehavoir"
        Me.lb_KHKContactBehavoir.Size = New System.Drawing.Size(89, 13)
        Me.lb_KHKContactBehavoir.TabIndex = 12
        Me.lb_KHKContactBehavoir.Text = "Contact Behavior"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(258, 46)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(15, 13)
        Me.Label23.TabIndex = 9
        Me.Label23.Text = "%"
        '
        'num_FK_Speed
        '
        Me.num_FK_Speed.Enabled = False
        Me.num_FK_Speed.Location = New System.Drawing.Point(128, 44)
        Me.num_FK_Speed.Margin = New System.Windows.Forms.Padding(2)
        Me.num_FK_Speed.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.num_FK_Speed.Name = "num_FK_Speed"
        Me.num_FK_Speed.Size = New System.Drawing.Size(53, 20)
        Me.num_FK_Speed.TabIndex = 8
        Me.num_FK_Speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_FK_Speed.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'num_RK_Speed
        '
        Me.num_RK_Speed.Enabled = False
        Me.num_RK_Speed.Location = New System.Drawing.Point(206, 44)
        Me.num_RK_Speed.Margin = New System.Windows.Forms.Padding(2)
        Me.num_RK_Speed.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.num_RK_Speed.Name = "num_RK_Speed"
        Me.num_RK_Speed.Size = New System.Drawing.Size(51, 20)
        Me.num_RK_Speed.TabIndex = 8
        Me.num_RK_Speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_RK_Speed.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'lb_KHKSetpoint
        '
        Me.lb_KHKSetpoint.AutoSize = True
        Me.lb_KHKSetpoint.Location = New System.Drawing.Point(49, 48)
        Me.lb_KHKSetpoint.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_KHKSetpoint.Name = "lb_KHKSetpoint"
        Me.lb_KHKSetpoint.Size = New System.Drawing.Size(75, 13)
        Me.lb_KHKSetpoint.TabIndex = 12
        Me.lb_KHKSetpoint.Text = "KHK Set Point"
        '
        'RB_NO
        '
        Me.RB_NO.AutoSize = True
        Me.RB_NO.Location = New System.Drawing.Point(415, 46)
        Me.RB_NO.Margin = New System.Windows.Forms.Padding(2)
        Me.RB_NO.Name = "RB_NO"
        Me.RB_NO.Size = New System.Drawing.Size(41, 17)
        Me.RB_NO.TabIndex = 7
        Me.RB_NO.TabStop = True
        Me.RB_NO.Text = "NO"
        Me.RB_NO.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(181, 46)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "%"
        '
        'CB_KHKenable
        '
        Me.CB_KHKenable.AutoSize = True
        Me.CB_KHKenable.Location = New System.Drawing.Point(17, 22)
        Me.CB_KHKenable.Margin = New System.Windows.Forms.Padding(2)
        Me.CB_KHKenable.Name = "CB_KHKenable"
        Me.CB_KHKenable.Size = New System.Drawing.Size(15, 14)
        Me.CB_KHKenable.TabIndex = 4
        Me.CB_KHKenable.UseVisualStyleBackColor = True
        '
        'RB_NC
        '
        Me.RB_NC.AutoSize = True
        Me.RB_NC.Location = New System.Drawing.Point(374, 46)
        Me.RB_NC.Margin = New System.Windows.Forms.Padding(2)
        Me.RB_NC.Name = "RB_NC"
        Me.RB_NC.Size = New System.Drawing.Size(40, 17)
        Me.RB_NC.TabIndex = 6
        Me.RB_NC.TabStop = True
        Me.RB_NC.Text = "NC"
        Me.RB_NC.UseVisualStyleBackColor = True
        '
        'Grp_Preset
        '
        Me.Grp_Preset.Controls.Add(Me.Lsb_FileConfig)
        Me.Grp_Preset.Controls.Add(Me.Btn_Rem)
        Me.Grp_Preset.Controls.Add(Me.Btn_Add)
        Me.Grp_Preset.Controls.Add(Me.Btn_Apply)
        Me.Grp_Preset.Location = New System.Drawing.Point(871, 7)
        Me.Grp_Preset.Name = "Grp_Preset"
        Me.Grp_Preset.Size = New System.Drawing.Size(196, 176)
        Me.Grp_Preset.TabIndex = 16
        Me.Grp_Preset.TabStop = False
        Me.Grp_Preset.Text = "Preset Conf."
        '
        'Lsb_FileConfig
        '
        Me.Lsb_FileConfig.FormattingEnabled = True
        Me.Lsb_FileConfig.Location = New System.Drawing.Point(7, 20)
        Me.Lsb_FileConfig.Name = "Lsb_FileConfig"
        Me.Lsb_FileConfig.Size = New System.Drawing.Size(183, 108)
        Me.Lsb_FileConfig.TabIndex = 1
        '
        'Btn_Rem
        '
        Me.Btn_Rem.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Rem.Location = New System.Drawing.Point(148, 135)
        Me.Btn_Rem.Name = "Btn_Rem"
        Me.Btn_Rem.Size = New System.Drawing.Size(43, 36)
        Me.Btn_Rem.TabIndex = 0
        Me.Btn_Rem.Text = "-"
        Me.Btn_Rem.UseVisualStyleBackColor = True
        '
        'Btn_Add
        '
        Me.Btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add.Location = New System.Drawing.Point(99, 135)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(43, 36)
        Me.Btn_Add.TabIndex = 0
        Me.Btn_Add.Text = "+"
        Me.Btn_Add.UseVisualStyleBackColor = True
        '
        'Btn_Apply
        '
        Me.Btn_Apply.Location = New System.Drawing.Point(7, 135)
        Me.Btn_Apply.Name = "Btn_Apply"
        Me.Btn_Apply.Size = New System.Drawing.Size(86, 36)
        Me.Btn_Apply.TabIndex = 0
        Me.Btn_Apply.Text = "Apply"
        Me.Btn_Apply.UseVisualStyleBackColor = True
        '
        'Btn_FirmwareUpdate
        '
        Me.Btn_FirmwareUpdate.Location = New System.Drawing.Point(488, 21)
        Me.Btn_FirmwareUpdate.Margin = New System.Windows.Forms.Padding(2)
        Me.Btn_FirmwareUpdate.Name = "Btn_FirmwareUpdate"
        Me.Btn_FirmwareUpdate.Size = New System.Drawing.Size(80, 38)
        Me.Btn_FirmwareUpdate.TabIndex = 15
        Me.Btn_FirmwareUpdate.Text = "Firmware Update"
        Me.Btn_FirmwareUpdate.UseVisualStyleBackColor = True
        '
        'lb_SaveProg
        '
        Me.lb_SaveProg.AutoSize = True
        Me.lb_SaveProg.Location = New System.Drawing.Point(546, 64)
        Me.lb_SaveProg.Name = "lb_SaveProg"
        Me.lb_SaveProg.Size = New System.Drawing.Size(24, 13)
        Me.lb_SaveProg.TabIndex = 5
        Me.lb_SaveProg.Text = "0 %"
        '
        'PB_SaveData
        '
        Me.PB_SaveData.Location = New System.Drawing.Point(362, 61)
        Me.PB_SaveData.Name = "PB_SaveData"
        Me.PB_SaveData.Size = New System.Drawing.Size(178, 23)
        Me.PB_SaveData.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_SaveData.TabIndex = 14
        '
        'Grp_UnitConfig
        '
        Me.Grp_UnitConfig.Controls.Add(Me.PcBx_Quark)
        Me.Grp_UnitConfig.Controls.Add(Me.RB_right)
        Me.Grp_UnitConfig.Controls.Add(Me.lb_Configuration)
        Me.Grp_UnitConfig.Controls.Add(Me.RB_left)
        Me.Grp_UnitConfig.Location = New System.Drawing.Point(592, 7)
        Me.Grp_UnitConfig.Name = "Grp_UnitConfig"
        Me.Grp_UnitConfig.Size = New System.Drawing.Size(272, 378)
        Me.Grp_UnitConfig.TabIndex = 12
        Me.Grp_UnitConfig.TabStop = False
        Me.Grp_UnitConfig.Text = "Configuration"
        '
        'PcBx_Quark
        '
        Me.PcBx_Quark.Image = Global.Quark_Configurator.My.Resources.Resources.DRAW_QUARK
        Me.PcBx_Quark.Location = New System.Drawing.Point(6, 15)
        Me.PcBx_Quark.Name = "PcBx_Quark"
        Me.PcBx_Quark.Size = New System.Drawing.Size(260, 320)
        Me.PcBx_Quark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PcBx_Quark.TabIndex = 10
        Me.PcBx_Quark.TabStop = False
        '
        'RB_right
        '
        Me.RB_right.AutoSize = True
        Me.RB_right.Location = New System.Drawing.Point(187, 354)
        Me.RB_right.Name = "RB_right"
        Me.RB_right.Size = New System.Drawing.Size(59, 17)
        Me.RB_right.TabIndex = 11
        Me.RB_right.TabStop = True
        Me.RB_right.Text = "RIGHT"
        Me.RB_right.UseVisualStyleBackColor = True
        '
        'lb_Configuration
        '
        Me.lb_Configuration.AutoSize = True
        Me.lb_Configuration.Location = New System.Drawing.Point(85, 338)
        Me.lb_Configuration.Name = "lb_Configuration"
        Me.lb_Configuration.Size = New System.Drawing.Size(87, 13)
        Me.lb_Configuration.TabIndex = 3
        Me.lb_Configuration.Text = "Fresh position on"
        '
        'RB_left
        '
        Me.RB_left.AutoSize = True
        Me.RB_left.Location = New System.Drawing.Point(20, 354)
        Me.RB_left.Name = "RB_left"
        Me.RB_left.Size = New System.Drawing.Size(51, 17)
        Me.RB_left.TabIndex = 11
        Me.RB_left.TabStop = True
        Me.RB_left.Text = "LEFT"
        Me.RB_left.UseVisualStyleBackColor = True
        '
        'Grp_UnitParam
        '
        Me.Grp_UnitParam.Controls.Add(Me.num_Belimo)
        Me.Grp_UnitParam.Controls.Add(Me.Label36)
        Me.Grp_UnitParam.Controls.Add(Me.Label11)
        Me.Grp_UnitParam.Controls.Add(Me.CB_BPDisable)
        Me.Grp_UnitParam.Controls.Add(Me.num_SWSetpoint)
        Me.Grp_UnitParam.Controls.Add(Me.num_TempSetpoint)
        Me.Grp_UnitParam.Controls.Add(Me.num_VOCSetpoint)
        Me.Grp_UnitParam.Controls.Add(Me.num_RHSetpoint)
        Me.Grp_UnitParam.Controls.Add(Me.num_CO2Setpoint)
        Me.Grp_UnitParam.Controls.Add(Me.num_FKITimer)
        Me.Grp_UnitParam.Controls.Add(Me.num_FilterTimer)
        Me.Grp_UnitParam.Controls.Add(Me.num_BoostTimer)
        Me.Grp_UnitParam.Controls.Add(Me.Label9)
        Me.Grp_UnitParam.Controls.Add(Me.Label8)
        Me.Grp_UnitParam.Controls.Add(Me.lb_SWSetpoint)
        Me.Grp_UnitParam.Controls.Add(Me.Label7)
        Me.Grp_UnitParam.Controls.Add(Me.lb_TempSetpoint)
        Me.Grp_UnitParam.Controls.Add(Me.Label6)
        Me.Grp_UnitParam.Controls.Add(Me.lb_VOCSetpoint)
        Me.Grp_UnitParam.Controls.Add(Me.Label5)
        Me.Grp_UnitParam.Controls.Add(Me.lb_RHSetpoint)
        Me.Grp_UnitParam.Controls.Add(Me.Label4)
        Me.Grp_UnitParam.Controls.Add(Me.lb_CO2Setpoint)
        Me.Grp_UnitParam.Controls.Add(Me.Label3)
        Me.Grp_UnitParam.Controls.Add(Me.lb_FKITimer)
        Me.Grp_UnitParam.Controls.Add(Me.Label1)
        Me.Grp_UnitParam.Controls.Add(Me.lb_FilterTimer)
        Me.Grp_UnitParam.Controls.Add(Me.lb_BoostTimer)
        Me.Grp_UnitParam.Location = New System.Drawing.Point(361, 96)
        Me.Grp_UnitParam.Name = "Grp_UnitParam"
        Me.Grp_UnitParam.Size = New System.Drawing.Size(225, 249)
        Me.Grp_UnitParam.TabIndex = 9
        Me.Grp_UnitParam.TabStop = False
        Me.Grp_UnitParam.Text = "Parameter Setting"
        '
        'num_Belimo
        '
        Me.num_Belimo.Enabled = False
        Me.num_Belimo.Location = New System.Drawing.Point(114, 207)
        Me.num_Belimo.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.num_Belimo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.num_Belimo.Name = "num_Belimo"
        Me.num_Belimo.Size = New System.Drawing.Size(49, 20)
        Me.num_Belimo.TabIndex = 9
        Me.num_Belimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_Belimo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(6, 210)
        Me.Label36.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(106, 13)
        Me.Label36.TabIndex = 8
        Me.Label36.Text = "FKI Actuator Number"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 232)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Disable Bypass"
        '
        'CB_BPDisable
        '
        Me.CB_BPDisable.AutoSize = True
        Me.CB_BPDisable.Location = New System.Drawing.Point(114, 232)
        Me.CB_BPDisable.Margin = New System.Windows.Forms.Padding(2)
        Me.CB_BPDisable.Name = "CB_BPDisable"
        Me.CB_BPDisable.Size = New System.Drawing.Size(15, 14)
        Me.CB_BPDisable.TabIndex = 6
        Me.CB_BPDisable.UseVisualStyleBackColor = True
        '
        'num_SWSetpoint
        '
        Me.num_SWSetpoint.Enabled = False
        Me.num_SWSetpoint.Location = New System.Drawing.Point(114, 183)
        Me.num_SWSetpoint.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.num_SWSetpoint.Minimum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.num_SWSetpoint.Name = "num_SWSetpoint"
        Me.num_SWSetpoint.Size = New System.Drawing.Size(49, 20)
        Me.num_SWSetpoint.TabIndex = 3
        Me.num_SWSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_SWSetpoint.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'num_TempSetpoint
        '
        Me.num_TempSetpoint.Enabled = False
        Me.num_TempSetpoint.Location = New System.Drawing.Point(114, 159)
        Me.num_TempSetpoint.Maximum = New Decimal(New Integer() {32, 0, 0, 0})
        Me.num_TempSetpoint.Minimum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.num_TempSetpoint.Name = "num_TempSetpoint"
        Me.num_TempSetpoint.Size = New System.Drawing.Size(49, 20)
        Me.num_TempSetpoint.TabIndex = 3
        Me.num_TempSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_TempSetpoint.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'num_VOCSetpoint
        '
        Me.num_VOCSetpoint.Enabled = False
        Me.num_VOCSetpoint.Location = New System.Drawing.Point(114, 135)
        Me.num_VOCSetpoint.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.num_VOCSetpoint.Name = "num_VOCSetpoint"
        Me.num_VOCSetpoint.Size = New System.Drawing.Size(49, 20)
        Me.num_VOCSetpoint.TabIndex = 3
        Me.num_VOCSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_VOCSetpoint.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'num_RHSetpoint
        '
        Me.num_RHSetpoint.Enabled = False
        Me.num_RHSetpoint.Location = New System.Drawing.Point(114, 111)
        Me.num_RHSetpoint.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.num_RHSetpoint.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.num_RHSetpoint.Name = "num_RHSetpoint"
        Me.num_RHSetpoint.Size = New System.Drawing.Size(49, 20)
        Me.num_RHSetpoint.TabIndex = 3
        Me.num_RHSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_RHSetpoint.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'num_CO2Setpoint
        '
        Me.num_CO2Setpoint.Enabled = False
        Me.num_CO2Setpoint.Location = New System.Drawing.Point(114, 87)
        Me.num_CO2Setpoint.Maximum = New Decimal(New Integer() {1500, 0, 0, 0})
        Me.num_CO2Setpoint.Minimum = New Decimal(New Integer() {700, 0, 0, 0})
        Me.num_CO2Setpoint.Name = "num_CO2Setpoint"
        Me.num_CO2Setpoint.Size = New System.Drawing.Size(49, 20)
        Me.num_CO2Setpoint.TabIndex = 3
        Me.num_CO2Setpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_CO2Setpoint.Value = New Decimal(New Integer() {700, 0, 0, 0})
        '
        'num_FKITimer
        '
        Me.num_FKITimer.Enabled = False
        Me.num_FKITimer.Location = New System.Drawing.Point(114, 63)
        Me.num_FKITimer.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.num_FKITimer.Minimum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.num_FKITimer.Name = "num_FKITimer"
        Me.num_FKITimer.Size = New System.Drawing.Size(49, 20)
        Me.num_FKITimer.TabIndex = 3
        Me.num_FKITimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_FKITimer.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'num_FilterTimer
        '
        Me.num_FilterTimer.Enabled = False
        Me.num_FilterTimer.Location = New System.Drawing.Point(114, 39)
        Me.num_FilterTimer.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.num_FilterTimer.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.num_FilterTimer.Name = "num_FilterTimer"
        Me.num_FilterTimer.Size = New System.Drawing.Size(49, 20)
        Me.num_FilterTimer.TabIndex = 3
        Me.num_FilterTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_FilterTimer.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'num_BoostTimer
        '
        Me.num_BoostTimer.Enabled = False
        Me.num_BoostTimer.Location = New System.Drawing.Point(114, 15)
        Me.num_BoostTimer.Maximum = New Decimal(New Integer() {240, 0, 0, 0})
        Me.num_BoostTimer.Minimum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.num_BoostTimer.Name = "num_BoostTimer"
        Me.num_BoostTimer.Size = New System.Drawing.Size(49, 20)
        Me.num_BoostTimer.TabIndex = 3
        Me.num_BoostTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_BoostTimer.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(169, 187)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "°C"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(169, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "°C"
        '
        'lb_SWSetpoint
        '
        Me.lb_SWSetpoint.AutoSize = True
        Me.lb_SWSetpoint.Location = New System.Drawing.Point(6, 186)
        Me.lb_SWSetpoint.Name = "lb_SWSetpoint"
        Me.lb_SWSetpoint.Size = New System.Drawing.Size(104, 13)
        Me.lb_SWSetpoint.TabIndex = 2
        Me.lb_SWSetpoint.Text = "SUM/WIN Set Point"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(169, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "ppm"
        '
        'lb_TempSetpoint
        '
        Me.lb_TempSetpoint.AutoSize = True
        Me.lb_TempSetpoint.Location = New System.Drawing.Point(6, 162)
        Me.lb_TempSetpoint.Name = "lb_TempSetpoint"
        Me.lb_TempSetpoint.Size = New System.Drawing.Size(83, 13)
        Me.lb_TempSetpoint.TabIndex = 2
        Me.lb_TempSetpoint.Text = "Temp. Set Point"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(169, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "%"
        '
        'lb_VOCSetpoint
        '
        Me.lb_VOCSetpoint.AutoSize = True
        Me.lb_VOCSetpoint.Location = New System.Drawing.Point(6, 137)
        Me.lb_VOCSetpoint.Name = "lb_VOCSetpoint"
        Me.lb_VOCSetpoint.Size = New System.Drawing.Size(75, 13)
        Me.lb_VOCSetpoint.TabIndex = 2
        Me.lb_VOCSetpoint.Text = "VOC Set Point"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(171, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "ppm"
        '
        'lb_RHSetpoint
        '
        Me.lb_RHSetpoint.AutoSize = True
        Me.lb_RHSetpoint.Location = New System.Drawing.Point(6, 113)
        Me.lb_RHSetpoint.Name = "lb_RHSetpoint"
        Me.lb_RHSetpoint.Size = New System.Drawing.Size(69, 13)
        Me.lb_RHSetpoint.TabIndex = 2
        Me.lb_RHSetpoint.Text = "RH Set Point"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(169, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "days"
        '
        'lb_CO2Setpoint
        '
        Me.lb_CO2Setpoint.AutoSize = True
        Me.lb_CO2Setpoint.Location = New System.Drawing.Point(6, 89)
        Me.lb_CO2Setpoint.Name = "lb_CO2Setpoint"
        Me.lb_CO2Setpoint.Size = New System.Drawing.Size(74, 13)
        Me.lb_CO2Setpoint.TabIndex = 2
        Me.lb_CO2Setpoint.Text = "CO2 Set Point"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(169, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "days"
        '
        'lb_FKITimer
        '
        Me.lb_FKITimer.AutoSize = True
        Me.lb_FKITimer.Location = New System.Drawing.Point(6, 66)
        Me.lb_FKITimer.Name = "lb_FKITimer"
        Me.lb_FKITimer.Size = New System.Drawing.Size(68, 13)
        Me.lb_FKITimer.TabIndex = 2
        Me.lb_FKITimer.Text = "Fire Kit Timer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(169, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "min"
        '
        'lb_FilterTimer
        '
        Me.lb_FilterTimer.AutoSize = True
        Me.lb_FilterTimer.Location = New System.Drawing.Point(6, 42)
        Me.lb_FilterTimer.Name = "lb_FilterTimer"
        Me.lb_FilterTimer.Size = New System.Drawing.Size(58, 13)
        Me.lb_FilterTimer.TabIndex = 2
        Me.lb_FilterTimer.Text = "Filter Timer"
        '
        'lb_BoostTimer
        '
        Me.lb_BoostTimer.AutoSize = True
        Me.lb_BoostTimer.Location = New System.Drawing.Point(6, 16)
        Me.lb_BoostTimer.Name = "lb_BoostTimer"
        Me.lb_BoostTimer.Size = New System.Drawing.Size(63, 13)
        Me.lb_BoostTimer.TabIndex = 2
        Me.lb_BoostTimer.Text = "Boost Timer"
        '
        'Grp_UnitData
        '
        Me.Grp_UnitData.Controls.Add(Me.lb_SW_vers)
        Me.Grp_UnitData.Controls.Add(Me.lb_HW_vers)
        Me.Grp_UnitData.Controls.Add(Me.lb_SerialNumber)
        Me.Grp_UnitData.Location = New System.Drawing.Point(14, 96)
        Me.Grp_UnitData.Name = "Grp_UnitData"
        Me.Grp_UnitData.Size = New System.Drawing.Size(341, 68)
        Me.Grp_UnitData.TabIndex = 8
        Me.Grp_UnitData.TabStop = False
        Me.Grp_UnitData.Text = "Main Unit Data"
        '
        'lb_SW_vers
        '
        Me.lb_SW_vers.AutoSize = True
        Me.lb_SW_vers.Location = New System.Drawing.Point(189, 43)
        Me.lb_SW_vers.Name = "lb_SW_vers"
        Me.lb_SW_vers.Size = New System.Drawing.Size(90, 13)
        Me.lb_SW_vers.TabIndex = 0
        Me.lb_SW_vers.Text = "Software Version:"
        '
        'lb_HW_vers
        '
        Me.lb_HW_vers.AutoSize = True
        Me.lb_HW_vers.Location = New System.Drawing.Point(9, 43)
        Me.lb_HW_vers.Name = "lb_HW_vers"
        Me.lb_HW_vers.Size = New System.Drawing.Size(94, 13)
        Me.lb_HW_vers.TabIndex = 0
        Me.lb_HW_vers.Text = "Hardware Version:"
        '
        'lb_SerialNumber
        '
        Me.lb_SerialNumber.AutoSize = True
        Me.lb_SerialNumber.Location = New System.Drawing.Point(9, 20)
        Me.lb_SerialNumber.Name = "lb_SerialNumber"
        Me.lb_SerialNumber.Size = New System.Drawing.Size(76, 13)
        Me.lb_SerialNumber.TabIndex = 0
        Me.lb_SerialNumber.Text = "Serial Number:"
        '
        'Grp_SpeedConf
        '
        Me.Grp_SpeedConf.Controls.Add(Me.Label25)
        Me.Grp_SpeedConf.Controls.Add(Me.Label24)
        Me.Grp_SpeedConf.Controls.Add(Me.NumericUpDown6)
        Me.Grp_SpeedConf.Controls.Add(Me.num_Speed3CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.NumericUpDown5)
        Me.Grp_SpeedConf.Controls.Add(Me.num_Speed2CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_ImbalanceEnable)
        Me.Grp_SpeedConf.Controls.Add(Me.CB_ImbEnable)
        Me.Grp_SpeedConf.Controls.Add(Me.NumericUpDown4)
        Me.Grp_SpeedConf.Controls.Add(Me.num_Speed1CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.num_R_IAQSpeed)
        Me.Grp_SpeedConf.Controls.Add(Me.num_R_Speed3)
        Me.Grp_SpeedConf.Controls.Add(Me.num_F_IAQSpeed)
        Me.Grp_SpeedConf.Controls.Add(Me.num_F_Speed3)
        Me.Grp_SpeedConf.Controls.Add(Me.num_R_Speed2)
        Me.Grp_SpeedConf.Controls.Add(Me.num_F_Speed2)
        Me.Grp_SpeedConf.Controls.Add(Me.num_R_Speed1)
        Me.Grp_SpeedConf.Controls.Add(Me.num_F_Speed1)
        Me.Grp_SpeedConf.Controls.Add(Me.Label26)
        Me.Grp_SpeedConf.Controls.Add(Me.vlb_Speed3CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.Label22)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_Speed3CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.vlb_Speed2CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.Label21)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_Speed2CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.Label20)
        Me.Grp_SpeedConf.Controls.Add(Me.vlb_Speed1CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.Label17)
        Me.Grp_SpeedConf.Controls.Add(Me.Label19)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_Speed1CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.vlb_Speed3FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.Label15)
        Me.Grp_SpeedConf.Controls.Add(Me.Label18)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_Speed3FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.vlb_Speed2FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.Label16)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_Speed2FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.vlb_Speed1FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_Speed1FSC)
        Me.Grp_SpeedConf.Location = New System.Drawing.Point(14, 170)
        Me.Grp_SpeedConf.Name = "Grp_SpeedConf"
        Me.Grp_SpeedConf.Size = New System.Drawing.Size(342, 231)
        Me.Grp_SpeedConf.TabIndex = 7
        Me.Grp_SpeedConf.TabStop = False
        Me.Grp_SpeedConf.Text = "Speed Configuration"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(205, 18)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(39, 13)
        Me.Label25.TabIndex = 13
        Me.Label25.Text = "Return"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(128, 18)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(39, 13)
        Me.Label24.TabIndex = 13
        Me.Label24.Text = "Supply"
        '
        'NumericUpDown6
        '
        Me.NumericUpDown6.Enabled = False
        Me.NumericUpDown6.Location = New System.Drawing.Point(210, 200)
        Me.NumericUpDown6.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.NumericUpDown6.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.NumericUpDown6.Name = "NumericUpDown6"
        Me.NumericUpDown6.Size = New System.Drawing.Size(51, 20)
        Me.NumericUpDown6.TabIndex = 2
        Me.NumericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown6.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'num_Speed3CAP
        '
        Me.num_Speed3CAP.Enabled = False
        Me.num_Speed3CAP.Location = New System.Drawing.Point(132, 200)
        Me.num_Speed3CAP.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.num_Speed3CAP.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.num_Speed3CAP.Name = "num_Speed3CAP"
        Me.num_Speed3CAP.Size = New System.Drawing.Size(51, 20)
        Me.num_Speed3CAP.TabIndex = 2
        Me.num_Speed3CAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_Speed3CAP.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.Enabled = False
        Me.NumericUpDown5.Location = New System.Drawing.Point(210, 173)
        Me.NumericUpDown5.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.NumericUpDown5.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(51, 20)
        Me.NumericUpDown5.TabIndex = 2
        Me.NumericUpDown5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown5.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'num_Speed2CAP
        '
        Me.num_Speed2CAP.Enabled = False
        Me.num_Speed2CAP.Location = New System.Drawing.Point(132, 173)
        Me.num_Speed2CAP.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.num_Speed2CAP.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.num_Speed2CAP.Name = "num_Speed2CAP"
        Me.num_Speed2CAP.Size = New System.Drawing.Size(51, 20)
        Me.num_Speed2CAP.TabIndex = 2
        Me.num_Speed2CAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_Speed2CAP.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'lb_ImbalanceEnable
        '
        Me.lb_ImbalanceEnable.AutoSize = True
        Me.lb_ImbalanceEnable.Location = New System.Drawing.Point(280, 38)
        Me.lb_ImbalanceEnable.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_ImbalanceEnable.Name = "lb_ImbalanceEnable"
        Me.lb_ImbalanceEnable.Size = New System.Drawing.Size(56, 26)
        Me.lb_ImbalanceEnable.TabIndex = 11
        Me.lb_ImbalanceEnable.Text = "Enable" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Imbalance"
        Me.lb_ImbalanceEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CB_ImbEnable
        '
        Me.CB_ImbEnable.AutoSize = True
        Me.CB_ImbEnable.Location = New System.Drawing.Point(300, 71)
        Me.CB_ImbEnable.Margin = New System.Windows.Forms.Padding(2)
        Me.CB_ImbEnable.Name = "CB_ImbEnable"
        Me.CB_ImbEnable.Size = New System.Drawing.Size(15, 14)
        Me.CB_ImbEnable.TabIndex = 10
        Me.CB_ImbEnable.UseVisualStyleBackColor = True
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.Enabled = False
        Me.NumericUpDown4.Location = New System.Drawing.Point(209, 146)
        Me.NumericUpDown4.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.NumericUpDown4.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(51, 20)
        Me.NumericUpDown4.TabIndex = 2
        Me.NumericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown4.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'num_Speed1CAP
        '
        Me.num_Speed1CAP.Enabled = False
        Me.num_Speed1CAP.Location = New System.Drawing.Point(131, 146)
        Me.num_Speed1CAP.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.num_Speed1CAP.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.num_Speed1CAP.Name = "num_Speed1CAP"
        Me.num_Speed1CAP.Size = New System.Drawing.Size(51, 20)
        Me.num_Speed1CAP.TabIndex = 2
        Me.num_Speed1CAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_Speed1CAP.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'num_R_IAQSpeed
        '
        Me.num_R_IAQSpeed.Enabled = False
        Me.num_R_IAQSpeed.Location = New System.Drawing.Point(208, 119)
        Me.num_R_IAQSpeed.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.num_R_IAQSpeed.Name = "num_R_IAQSpeed"
        Me.num_R_IAQSpeed.Size = New System.Drawing.Size(51, 20)
        Me.num_R_IAQSpeed.TabIndex = 2
        Me.num_R_IAQSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_R_IAQSpeed.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'num_R_Speed3
        '
        Me.num_R_Speed3.Enabled = False
        Me.num_R_Speed3.Location = New System.Drawing.Point(208, 92)
        Me.num_R_Speed3.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.num_R_Speed3.Name = "num_R_Speed3"
        Me.num_R_Speed3.Size = New System.Drawing.Size(51, 20)
        Me.num_R_Speed3.TabIndex = 2
        Me.num_R_Speed3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_R_Speed3.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'num_F_IAQSpeed
        '
        Me.num_F_IAQSpeed.Enabled = False
        Me.num_F_IAQSpeed.Location = New System.Drawing.Point(131, 119)
        Me.num_F_IAQSpeed.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.num_F_IAQSpeed.Name = "num_F_IAQSpeed"
        Me.num_F_IAQSpeed.Size = New System.Drawing.Size(51, 20)
        Me.num_F_IAQSpeed.TabIndex = 2
        Me.num_F_IAQSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_F_IAQSpeed.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'num_F_Speed3
        '
        Me.num_F_Speed3.Enabled = False
        Me.num_F_Speed3.Location = New System.Drawing.Point(131, 92)
        Me.num_F_Speed3.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.num_F_Speed3.Name = "num_F_Speed3"
        Me.num_F_Speed3.Size = New System.Drawing.Size(51, 20)
        Me.num_F_Speed3.TabIndex = 2
        Me.num_F_Speed3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_F_Speed3.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'num_R_Speed2
        '
        Me.num_R_Speed2.Enabled = False
        Me.num_R_Speed2.Location = New System.Drawing.Point(208, 65)
        Me.num_R_Speed2.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.num_R_Speed2.Name = "num_R_Speed2"
        Me.num_R_Speed2.Size = New System.Drawing.Size(51, 20)
        Me.num_R_Speed2.TabIndex = 2
        Me.num_R_Speed2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_R_Speed2.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'num_F_Speed2
        '
        Me.num_F_Speed2.Enabled = False
        Me.num_F_Speed2.Location = New System.Drawing.Point(130, 65)
        Me.num_F_Speed2.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.num_F_Speed2.Name = "num_F_Speed2"
        Me.num_F_Speed2.Size = New System.Drawing.Size(51, 20)
        Me.num_F_Speed2.TabIndex = 2
        Me.num_F_Speed2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_F_Speed2.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'num_R_Speed1
        '
        Me.num_R_Speed1.Enabled = False
        Me.num_R_Speed1.Location = New System.Drawing.Point(208, 38)
        Me.num_R_Speed1.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.num_R_Speed1.Name = "num_R_Speed1"
        Me.num_R_Speed1.Size = New System.Drawing.Size(51, 20)
        Me.num_R_Speed1.TabIndex = 2
        Me.num_R_Speed1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_R_Speed1.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'num_F_Speed1
        '
        Me.num_F_Speed1.Enabled = False
        Me.num_F_Speed1.Location = New System.Drawing.Point(130, 38)
        Me.num_F_Speed1.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.num_F_Speed1.Name = "num_F_Speed1"
        Me.num_F_Speed1.Size = New System.Drawing.Size(51, 20)
        Me.num_F_Speed1.TabIndex = 2
        Me.num_F_Speed1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_F_Speed1.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(259, 201)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(20, 13)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "Pa"
        '
        'vlb_Speed3CAP
        '
        Me.vlb_Speed3CAP.AutoSize = True
        Me.vlb_Speed3CAP.Location = New System.Drawing.Point(181, 202)
        Me.vlb_Speed3CAP.Name = "vlb_Speed3CAP"
        Me.vlb_Speed3CAP.Size = New System.Drawing.Size(20, 13)
        Me.vlb_Speed3CAP.TabIndex = 1
        Me.vlb_Speed3CAP.Text = "Pa"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(260, 174)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(20, 13)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Pa"
        '
        'lb_Speed3CAP
        '
        Me.lb_Speed3CAP.AutoSize = True
        Me.lb_Speed3CAP.Location = New System.Drawing.Point(6, 202)
        Me.lb_Speed3CAP.Name = "lb_Speed3CAP"
        Me.lb_Speed3CAP.Size = New System.Drawing.Size(71, 13)
        Me.lb_Speed3CAP.TabIndex = 1
        Me.lb_Speed3CAP.Text = "Speed 3 CAP"
        '
        'vlb_Speed2CAP
        '
        Me.vlb_Speed2CAP.AutoSize = True
        Me.vlb_Speed2CAP.Location = New System.Drawing.Point(182, 175)
        Me.vlb_Speed2CAP.Name = "vlb_Speed2CAP"
        Me.vlb_Speed2CAP.Size = New System.Drawing.Size(20, 13)
        Me.vlb_Speed2CAP.TabIndex = 1
        Me.vlb_Speed2CAP.Text = "Pa"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(260, 147)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(20, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Pa"
        '
        'lb_Speed2CAP
        '
        Me.lb_Speed2CAP.AutoSize = True
        Me.lb_Speed2CAP.Location = New System.Drawing.Point(6, 175)
        Me.lb_Speed2CAP.Name = "lb_Speed2CAP"
        Me.lb_Speed2CAP.Size = New System.Drawing.Size(71, 13)
        Me.lb_Speed2CAP.TabIndex = 1
        Me.lb_Speed2CAP.Text = "Speed 2 CAP"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(260, 120)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(15, 13)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "%"
        '
        'vlb_Speed1CAP
        '
        Me.vlb_Speed1CAP.AutoSize = True
        Me.vlb_Speed1CAP.Location = New System.Drawing.Point(182, 148)
        Me.vlb_Speed1CAP.Name = "vlb_Speed1CAP"
        Me.vlb_Speed1CAP.Size = New System.Drawing.Size(20, 13)
        Me.vlb_Speed1CAP.TabIndex = 1
        Me.vlb_Speed1CAP.Text = "Pa"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(182, 121)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(15, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "%"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(260, 93)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(15, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "%"
        '
        'lb_Speed1CAP
        '
        Me.lb_Speed1CAP.AutoSize = True
        Me.lb_Speed1CAP.Location = New System.Drawing.Point(6, 148)
        Me.lb_Speed1CAP.Name = "lb_Speed1CAP"
        Me.lb_Speed1CAP.Size = New System.Drawing.Size(71, 13)
        Me.lb_Speed1CAP.TabIndex = 1
        Me.lb_Speed1CAP.Text = "Speed 1 CAP"
        '
        'vlb_Speed3FSC
        '
        Me.vlb_Speed3FSC.AutoSize = True
        Me.vlb_Speed3FSC.Location = New System.Drawing.Point(182, 94)
        Me.vlb_Speed3FSC.Name = "vlb_Speed3FSC"
        Me.vlb_Speed3FSC.Size = New System.Drawing.Size(15, 13)
        Me.vlb_Speed3FSC.TabIndex = 1
        Me.vlb_Speed3FSC.Text = "%"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 121)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Sensor max Speed"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(259, 66)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(15, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "%"
        '
        'lb_Speed3FSC
        '
        Me.lb_Speed3FSC.AutoSize = True
        Me.lb_Speed3FSC.Location = New System.Drawing.Point(6, 94)
        Me.lb_Speed3FSC.Name = "lb_Speed3FSC"
        Me.lb_Speed3FSC.Size = New System.Drawing.Size(95, 13)
        Me.lb_Speed3FSC.TabIndex = 1
        Me.lb_Speed3FSC.Text = "Speed 3 FSC/CAF"
        '
        'vlb_Speed2FSC
        '
        Me.vlb_Speed2FSC.AutoSize = True
        Me.vlb_Speed2FSC.Location = New System.Drawing.Point(181, 67)
        Me.vlb_Speed2FSC.Name = "vlb_Speed2FSC"
        Me.vlb_Speed2FSC.Size = New System.Drawing.Size(15, 13)
        Me.vlb_Speed2FSC.TabIndex = 1
        Me.vlb_Speed2FSC.Text = "%"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(260, 39)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "%"
        '
        'lb_Speed2FSC
        '
        Me.lb_Speed2FSC.AutoSize = True
        Me.lb_Speed2FSC.Location = New System.Drawing.Point(6, 67)
        Me.lb_Speed2FSC.Name = "lb_Speed2FSC"
        Me.lb_Speed2FSC.Size = New System.Drawing.Size(95, 13)
        Me.lb_Speed2FSC.TabIndex = 1
        Me.lb_Speed2FSC.Text = "Speed 2 FSC/CAF"
        '
        'vlb_Speed1FSC
        '
        Me.vlb_Speed1FSC.AutoSize = True
        Me.vlb_Speed1FSC.Location = New System.Drawing.Point(182, 40)
        Me.vlb_Speed1FSC.Name = "vlb_Speed1FSC"
        Me.vlb_Speed1FSC.Size = New System.Drawing.Size(15, 13)
        Me.vlb_Speed1FSC.TabIndex = 1
        Me.vlb_Speed1FSC.Text = "%"
        '
        'lb_Speed1FSC
        '
        Me.lb_Speed1FSC.AutoSize = True
        Me.lb_Speed1FSC.Location = New System.Drawing.Point(6, 40)
        Me.lb_Speed1FSC.Name = "lb_Speed1FSC"
        Me.lb_Speed1FSC.Size = New System.Drawing.Size(95, 13)
        Me.lb_Speed1FSC.TabIndex = 1
        Me.lb_Speed1FSC.Text = "Speed 1 FSC/CAF"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ComPort"
        '
        'COM_List
        '
        Me.COM_List.FormattingEnabled = True
        Me.COM_List.Location = New System.Drawing.Point(8, 21)
        Me.COM_List.Name = "COM_List"
        Me.COM_List.Size = New System.Drawing.Size(68, 56)
        Me.COM_List.TabIndex = 0
        '
        'lb_status
        '
        Me.lb_status.AutoSize = True
        Me.lb_status.Location = New System.Drawing.Point(89, 64)
        Me.lb_status.Name = "lb_status"
        Me.lb_status.Size = New System.Drawing.Size(144, 13)
        Me.lb_status.TabIndex = 5
        Me.lb_status.Text = "Press button Connect to start"
        '
        'Btn_RefreshLIST
        '
        Me.Btn_RefreshLIST.Location = New System.Drawing.Point(83, 21)
        Me.Btn_RefreshLIST.Name = "Btn_RefreshLIST"
        Me.Btn_RefreshLIST.Size = New System.Drawing.Size(80, 38)
        Me.Btn_RefreshLIST.TabIndex = 1
        Me.Btn_RefreshLIST.Text = "Refresh List"
        Me.Btn_RefreshLIST.UseVisualStyleBackColor = True
        '
        'Btn_Connect
        '
        Me.Btn_Connect.Location = New System.Drawing.Point(164, 21)
        Me.Btn_Connect.Name = "Btn_Connect"
        Me.Btn_Connect.Size = New System.Drawing.Size(80, 38)
        Me.Btn_Connect.TabIndex = 1
        Me.Btn_Connect.Text = "Connect"
        Me.Btn_Connect.UseVisualStyleBackColor = True
        '
        'Btn_SaveData
        '
        Me.Btn_SaveData.Location = New System.Drawing.Point(407, 21)
        Me.Btn_SaveData.Name = "Btn_SaveData"
        Me.Btn_SaveData.Size = New System.Drawing.Size(80, 38)
        Me.Btn_SaveData.TabIndex = 1
        Me.Btn_SaveData.Text = "Save Data"
        Me.Btn_SaveData.UseVisualStyleBackColor = True
        '
        'Btn_RefreshData
        '
        Me.Btn_RefreshData.Location = New System.Drawing.Point(326, 21)
        Me.Btn_RefreshData.Name = "Btn_RefreshData"
        Me.Btn_RefreshData.Size = New System.Drawing.Size(80, 38)
        Me.Btn_RefreshData.TabIndex = 1
        Me.Btn_RefreshData.Text = "Refresh Data"
        Me.Btn_RefreshData.UseVisualStyleBackColor = True
        '
        'Btn_Disconnect
        '
        Me.Btn_Disconnect.Location = New System.Drawing.Point(245, 21)
        Me.Btn_Disconnect.Name = "Btn_Disconnect"
        Me.Btn_Disconnect.Size = New System.Drawing.Size(80, 38)
        Me.Btn_Disconnect.TabIndex = 1
        Me.Btn_Disconnect.Text = "Disconnect"
        Me.Btn_Disconnect.UseVisualStyleBackColor = True
        '
        'PcBx_Logo
        '
        Me.PcBx_Logo.Image = Global.Quark_Configurator.My.Resources.Resources.SMART_ICON
        Me.PcBx_Logo.Location = New System.Drawing.Point(381, 96)
        Me.PcBx_Logo.Name = "PcBx_Logo"
        Me.PcBx_Logo.Size = New System.Drawing.Size(332, 320)
        Me.PcBx_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PcBx_Logo.TabIndex = 13
        Me.PcBx_Logo.TabStop = False
        '
        'Tab_Main
        '
        Me.Tab_Main.Controls.Add(Me.TP_Configurator)
        Me.Tab_Main.Controls.Add(Me.TP_Shell)
        Me.Tab_Main.Location = New System.Drawing.Point(12, 12)
        Me.Tab_Main.Name = "Tab_Main"
        Me.Tab_Main.SelectedIndex = 0
        Me.Tab_Main.Size = New System.Drawing.Size(1081, 507)
        Me.Tab_Main.TabIndex = 7
        '
        'TP_Shell
        '
        Me.TP_Shell.Controls.Add(Me.CB_Timestamp)
        Me.TP_Shell.Controls.Add(Me.CB_SaveLog)
        Me.TP_Shell.Controls.Add(Me.Input_String)
        Me.TP_Shell.Controls.Add(Me.tb_COMStrem)
        Me.TP_Shell.Controls.Add(Me.Btn_SendData)
        Me.TP_Shell.Location = New System.Drawing.Point(4, 22)
        Me.TP_Shell.Name = "TP_Shell"
        Me.TP_Shell.Size = New System.Drawing.Size(1073, 481)
        Me.TP_Shell.TabIndex = 1
        Me.TP_Shell.Text = "Shell"
        Me.TP_Shell.UseVisualStyleBackColor = True
        '
        'CB_Timestamp
        '
        Me.CB_Timestamp.AutoSize = True
        Me.CB_Timestamp.Location = New System.Drawing.Point(555, 361)
        Me.CB_Timestamp.Name = "CB_Timestamp"
        Me.CB_Timestamp.Size = New System.Drawing.Size(99, 17)
        Me.CB_Timestamp.TabIndex = 10
        Me.CB_Timestamp.Text = "Add Timestamp"
        Me.CB_Timestamp.UseVisualStyleBackColor = True
        '
        'CB_SaveLog
        '
        Me.CB_SaveLog.AutoSize = True
        Me.CB_SaveLog.Location = New System.Drawing.Point(468, 361)
        Me.CB_SaveLog.Name = "CB_SaveLog"
        Me.CB_SaveLog.Size = New System.Drawing.Size(69, 17)
        Me.CB_SaveLog.TabIndex = 10
        Me.CB_SaveLog.Text = "SaveLog"
        Me.CB_SaveLog.UseVisualStyleBackColor = True
        '
        'Input_String
        '
        Me.Input_String.Location = New System.Drawing.Point(3, 353)
        Me.Input_String.Name = "Input_String"
        Me.Input_String.Size = New System.Drawing.Size(322, 31)
        Me.Input_String.TabIndex = 9
        Me.Input_String.Text = ""
        '
        'tb_COMStrem
        '
        Me.tb_COMStrem.HideSelection = False
        Me.tb_COMStrem.Location = New System.Drawing.Point(3, 3)
        Me.tb_COMStrem.Name = "tb_COMStrem"
        Me.tb_COMStrem.Size = New System.Drawing.Size(864, 344)
        Me.tb_COMStrem.TabIndex = 8
        Me.tb_COMStrem.Text = ""
        '
        'Btn_SendData
        '
        Me.Btn_SendData.Location = New System.Drawing.Point(331, 353)
        Me.Btn_SendData.Name = "Btn_SendData"
        Me.Btn_SendData.Size = New System.Drawing.Size(114, 31)
        Me.Btn_SendData.TabIndex = 7
        Me.Btn_SendData.Text = "Send Command"
        Me.Btn_SendData.UseVisualStyleBackColor = True
        '
        'SerialDataTimer
        '
        '
        'lb_QKvers
        '
        Me.lb_QKvers.AutoSize = True
        Me.lb_QKvers.Location = New System.Drawing.Point(953, 9)
        Me.lb_QKvers.Name = "lb_QKvers"
        Me.lb_QKvers.Size = New System.Drawing.Size(96, 13)
        Me.lb_QKvers.TabIndex = 8
        Me.lb_QKvers.Text = "Software Version : "
        '
        'TimerDateTime
        '
        Me.TimerDateTime.Interval = 1000
        '
        'Program_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1098, 527)
        Me.Controls.Add(Me.lb_QKvers)
        Me.Controls.Add(Me.Tab_Main)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Program_Form"
        Me.Text = "Avensys Quark Configurator"
        Me.TP_Configurator.ResumeLayout(False)
        Me.TP_Configurator.PerformLayout()
        Me.Grp_Acc.ResumeLayout(False)
        Me.Grp_Acc.PerformLayout()
        Me.Grp_Live.ResumeLayout(False)
        Me.Grp_Live.PerformLayout()
        Me.Grp_Smoke.ResumeLayout(False)
        Me.Grp_Smoke.PerformLayout()
        Me.Grp_DateTime.ResumeLayout(False)
        Me.Grp_DateTime.PerformLayout()
        Me.Grp_KHK.ResumeLayout(False)
        Me.Grp_KHK.PerformLayout()
        CType(Me.num_FK_Speed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_RK_Speed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_Preset.ResumeLayout(False)
        Me.Grp_UnitConfig.ResumeLayout(False)
        Me.Grp_UnitConfig.PerformLayout()
        CType(Me.PcBx_Quark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_UnitParam.ResumeLayout(False)
        Me.Grp_UnitParam.PerformLayout()
        CType(Me.num_Belimo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_SWSetpoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_TempSetpoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_VOCSetpoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_RHSetpoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_CO2Setpoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_FKITimer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_FilterTimer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_BoostTimer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_UnitData.ResumeLayout(False)
        Me.Grp_UnitData.PerformLayout()
        Me.Grp_SpeedConf.ResumeLayout(False)
        Me.Grp_SpeedConf.PerformLayout()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_Speed3CAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_Speed2CAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_Speed1CAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_R_IAQSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_R_Speed3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_F_IAQSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_F_Speed3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_R_Speed2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_F_Speed2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_R_Speed1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_F_Speed1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PcBx_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_Main.ResumeLayout(False)
        Me.TP_Shell.ResumeLayout(False)
        Me.TP_Shell.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents TP_Configurator As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents COM_List As ListBox
    Friend WithEvents lb_status As Label
    Friend WithEvents Btn_RefreshLIST As Button
    Friend WithEvents Btn_Connect As Button
    Friend WithEvents Btn_Disconnect As Button
    Friend WithEvents Tab_Main As TabControl
    Friend WithEvents Grp_SpeedConf As GroupBox
    Friend WithEvents lb_Speed2CAP As Label
    Friend WithEvents lb_Speed1CAP As Label
    Friend WithEvents lb_Speed3FSC As Label
    Friend WithEvents lb_Speed2FSC As Label
    Friend WithEvents lb_Speed1FSC As Label
    Friend WithEvents lb_Speed3CAP As Label
    Friend WithEvents vlb_Speed3CAP As Label
    Friend WithEvents vlb_Speed2CAP As Label
    Friend WithEvents vlb_Speed1CAP As Label
    Friend WithEvents vlb_Speed3FSC As Label
    Friend WithEvents vlb_Speed2FSC As Label
    Friend WithEvents vlb_Speed1FSC As Label
    Friend WithEvents TP_Shell As TabPage
    Friend WithEvents Input_String As RichTextBox
    Friend WithEvents tb_COMStrem As RichTextBox
    Friend WithEvents Btn_SendData As Button
    Friend WithEvents Grp_UnitData As GroupBox
    Friend WithEvents lb_SW_vers As Label
    Friend WithEvents lb_HW_vers As Label
    Friend WithEvents lb_SerialNumber As Label
    Friend WithEvents SerialDataTimer As Timer
    Friend WithEvents Grp_UnitParam As GroupBox
    Friend WithEvents lb_BoostTimer As Label
    Friend WithEvents lb_CO2Setpoint As Label
    Friend WithEvents lb_FKITimer As Label
    Friend WithEvents lb_FilterTimer As Label
    Friend WithEvents lb_SWSetpoint As Label
    Friend WithEvents lb_TempSetpoint As Label
    Friend WithEvents lb_VOCSetpoint As Label
    Friend WithEvents lb_RHSetpoint As Label
    Friend WithEvents PcBx_Quark As PictureBox
    Friend WithEvents lb_Configuration As Label
    Friend WithEvents RB_right As RadioButton
    Friend WithEvents RB_left As RadioButton
    Friend WithEvents Btn_RefreshData As Button
    Friend WithEvents Btn_SaveData As Button
    Friend WithEvents Grp_UnitConfig As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents num_F_Speed1 As NumericUpDown
    Friend WithEvents num_Speed3CAP As NumericUpDown
    Friend WithEvents num_Speed2CAP As NumericUpDown
    Friend WithEvents num_Speed1CAP As NumericUpDown
    Friend WithEvents num_F_Speed3 As NumericUpDown
    Friend WithEvents num_F_Speed2 As NumericUpDown
    Friend WithEvents num_BoostTimer As NumericUpDown
    Friend WithEvents num_TempSetpoint As NumericUpDown
    Friend WithEvents num_VOCSetpoint As NumericUpDown
    Friend WithEvents num_RHSetpoint As NumericUpDown
    Friend WithEvents num_CO2Setpoint As NumericUpDown
    Friend WithEvents num_FKITimer As NumericUpDown
    Friend WithEvents num_FilterTimer As NumericUpDown
    Friend WithEvents num_SWSetpoint As NumericUpDown
    Friend WithEvents PcBx_Logo As PictureBox
    Friend WithEvents PB_SaveData As ProgressBar
    Friend WithEvents lb_SaveProg As Label
    Friend WithEvents lb_QKvers As Label
    Friend WithEvents CB_KHKenable As CheckBox
    Friend WithEvents lb_KHKenable As Label
    Friend WithEvents RB_NO As RadioButton
    Friend WithEvents RB_NC As RadioButton
    Friend WithEvents lb_ImbalanceEnable As Label
    Friend WithEvents CB_ImbEnable As CheckBox
    Friend WithEvents Btn_FirmwareUpdate As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents num_FK_Speed As NumericUpDown
    Friend WithEvents lb_KHKSetpoint As Label
    Friend WithEvents lb_KHKContactBehavoir As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents CB_BPDisable As CheckBox
    Friend WithEvents CB_SaveLog As CheckBox
    Friend WithEvents CB_Timestamp As CheckBox
    Friend WithEvents NumericUpDown6 As NumericUpDown
    Friend WithEvents NumericUpDown5 As NumericUpDown
    Friend WithEvents NumericUpDown4 As NumericUpDown
    Friend WithEvents num_R_Speed3 As NumericUpDown
    Friend WithEvents num_R_Speed2 As NumericUpDown
    Friend WithEvents num_R_Speed1 As NumericUpDown
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents num_RK_Speed As NumericUpDown
    Friend WithEvents Label23 As Label
    Friend WithEvents Grp_KHK As GroupBox
    Friend WithEvents Grp_Preset As GroupBox
    Friend WithEvents Btn_Apply As Button
    Friend WithEvents Btn_Rem As Button
    Friend WithEvents Btn_Add As Button
    Friend WithEvents Lsb_FileConfig As ListBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents CB_DisableTemperatureControl As CheckBox
    Friend WithEvents lb_DateTimeTimer As Label
    Friend WithEvents BtnUpdateDateTime As Button
    Friend WithEvents TimerDateTime As Timer
    Friend WithEvents Grp_DateTime As GroupBox
    Friend WithEvents num_R_IAQSpeed As NumericUpDown
    Friend WithEvents num_F_IAQSpeed As NumericUpDown
    Friend WithEvents Label26 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Grp_Smoke As GroupBox
    Friend WithEvents Label28 As Label
    Friend WithEvents CB_SmokeEnable As CheckBox
    Friend WithEvents Label27 As Label
    Friend WithEvents RB_SmokeNO As RadioButton
    Friend WithEvents RB_SmokeNC As RadioButton
    Friend WithEvents Grp_Live As GroupBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents lblTExhaust As Label
    Friend WithEvents lblTSupply As Label
    Friend WithEvents lblTReturn As Label
    Friend WithEvents lblTFresh As Label
    Friend WithEvents lblRReturn As Label
    Friend WithEvents lblRFresh As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents CB_LiveData As CheckBox
    Friend WithEvents lblRPMReturn As Label
    Friend WithEvents lblRPMSupply As Label
    Friend WithEvents lblVReturn As Label
    Friend WithEvents lblVSupply As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents TB_alarm As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Grp_Acc As GroupBox
    Friend WithEvents Btn_ResAcc As Button
    Friend WithEvents TB_acc As TextBox
    Friend WithEvents num_Belimo As NumericUpDown
    Friend WithEvents Label36 As Label
End Class
