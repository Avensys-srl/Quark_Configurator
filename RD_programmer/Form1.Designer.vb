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
        Me.Grp_Imbalance = New System.Windows.Forms.GroupBox()
        Me.lb_ImbalanceEnable = New System.Windows.Forms.Label()
        Me.CB_ImbEnable = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lb_ImbalanceLevel = New System.Windows.Forms.Label()
        Me.num_Imbalance_Setpoint = New System.Windows.Forms.NumericUpDown()
        Me.Btn_FirmwareUpdate = New System.Windows.Forms.Button()
        Me.Grp_KHK = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lb_KHKContactBehavoir = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.num_KHKImbalance_Setpoint = New System.Windows.Forms.NumericUpDown()
        Me.lb_KHKSetpoint = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.num_KHK_Setpoint = New System.Windows.Forms.NumericUpDown()
        Me.RB_NO = New System.Windows.Forms.RadioButton()
        Me.RB_NC = New System.Windows.Forms.RadioButton()
        Me.lb_KHKenable = New System.Windows.Forms.Label()
        Me.CB_KHKenable = New System.Windows.Forms.CheckBox()
        Me.lb_SaveProg = New System.Windows.Forms.Label()
        Me.PB_SaveData = New System.Windows.Forms.ProgressBar()
        Me.Grp_UnitConfig = New System.Windows.Forms.GroupBox()
        Me.PcBx_Quark = New System.Windows.Forms.PictureBox()
        Me.RB_right = New System.Windows.Forms.RadioButton()
        Me.lb_Configuration = New System.Windows.Forms.Label()
        Me.RB_left = New System.Windows.Forms.RadioButton()
        Me.Grp_UnitParam = New System.Windows.Forms.GroupBox()
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
        Me.num_Speed3CAP = New System.Windows.Forms.NumericUpDown()
        Me.num_Speed2CAP = New System.Windows.Forms.NumericUpDown()
        Me.num_Speed1CAP = New System.Windows.Forms.NumericUpDown()
        Me.num_Speed3FSC = New System.Windows.Forms.NumericUpDown()
        Me.num_Speed2FSC = New System.Windows.Forms.NumericUpDown()
        Me.num_Speed1FSC = New System.Windows.Forms.NumericUpDown()
        Me.vlb_Speed3CAP = New System.Windows.Forms.Label()
        Me.lb_Speed3CAP = New System.Windows.Forms.Label()
        Me.vlb_Speed2CAP = New System.Windows.Forms.Label()
        Me.lb_Speed2CAP = New System.Windows.Forms.Label()
        Me.vlb_Speed1CAP = New System.Windows.Forms.Label()
        Me.lb_Speed1CAP = New System.Windows.Forms.Label()
        Me.vlb_Speed3FSC = New System.Windows.Forms.Label()
        Me.lb_Speed3FSC = New System.Windows.Forms.Label()
        Me.vlb_Speed2FSC = New System.Windows.Forms.Label()
        Me.lb_Speed2FSC = New System.Windows.Forms.Label()
        Me.vlb_Speed1FSC = New System.Windows.Forms.Label()
        Me.lb_Speed1FSC = New System.Windows.Forms.Label()
        Me.PB_Speed3CAP = New System.Windows.Forms.ProgressBar()
        Me.PB_Speed2CAP = New System.Windows.Forms.ProgressBar()
        Me.PB_Speed1CAP = New System.Windows.Forms.ProgressBar()
        Me.PB_Speed3FSC = New System.Windows.Forms.ProgressBar()
        Me.PB_Speed2FSC = New System.Windows.Forms.ProgressBar()
        Me.PB_Speed1FSC = New System.Windows.Forms.ProgressBar()
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
        Me.TP_Configurator.SuspendLayout()
        Me.Grp_Imbalance.SuspendLayout()
        CType(Me.num_Imbalance_Setpoint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_KHK.SuspendLayout()
        CType(Me.num_KHKImbalance_Setpoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KHK_Setpoint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_UnitConfig.SuspendLayout()
        CType(Me.PcBx_Quark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_UnitParam.SuspendLayout()
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
        CType(Me.num_Speed3CAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_Speed2CAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_Speed1CAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_Speed3FSC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_Speed2FSC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_Speed1FSC, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TP_Configurator.Controls.Add(Me.Grp_Imbalance)
        Me.TP_Configurator.Controls.Add(Me.Btn_FirmwareUpdate)
        Me.TP_Configurator.Controls.Add(Me.Grp_KHK)
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
        Me.TP_Configurator.Size = New System.Drawing.Size(870, 481)
        Me.TP_Configurator.TabIndex = 0
        Me.TP_Configurator.Text = "Configurator"
        Me.TP_Configurator.UseVisualStyleBackColor = True
        '
        'Grp_Imbalance
        '
        Me.Grp_Imbalance.Controls.Add(Me.lb_ImbalanceEnable)
        Me.Grp_Imbalance.Controls.Add(Me.CB_ImbEnable)
        Me.Grp_Imbalance.Controls.Add(Me.Label10)
        Me.Grp_Imbalance.Controls.Add(Me.lb_ImbalanceLevel)
        Me.Grp_Imbalance.Controls.Add(Me.num_Imbalance_Setpoint)
        Me.Grp_Imbalance.Location = New System.Drawing.Point(14, 385)
        Me.Grp_Imbalance.Margin = New System.Windows.Forms.Padding(2)
        Me.Grp_Imbalance.Name = "Grp_Imbalance"
        Me.Grp_Imbalance.Padding = New System.Windows.Forms.Padding(2)
        Me.Grp_Imbalance.Size = New System.Drawing.Size(341, 91)
        Me.Grp_Imbalance.TabIndex = 7
        Me.Grp_Imbalance.TabStop = False
        Me.Grp_Imbalance.Text = "Imbalance"
        '
        'lb_ImbalanceEnable
        '
        Me.lb_ImbalanceEnable.AutoSize = True
        Me.lb_ImbalanceEnable.Location = New System.Drawing.Point(4, 22)
        Me.lb_ImbalanceEnable.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_ImbalanceEnable.Name = "lb_ImbalanceEnable"
        Me.lb_ImbalanceEnable.Size = New System.Drawing.Size(92, 13)
        Me.lb_ImbalanceEnable.TabIndex = 11
        Me.lb_ImbalanceEnable.Text = "Enable Imbalance"
        '
        'CB_ImbEnable
        '
        Me.CB_ImbEnable.AutoSize = True
        Me.CB_ImbEnable.Location = New System.Drawing.Point(110, 22)
        Me.CB_ImbEnable.Margin = New System.Windows.Forms.Padding(2)
        Me.CB_ImbEnable.Name = "CB_ImbEnable"
        Me.CB_ImbEnable.Size = New System.Drawing.Size(15, 14)
        Me.CB_ImbEnable.TabIndex = 10
        Me.CB_ImbEnable.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(302, 22)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "%"
        '
        'lb_ImbalanceLevel
        '
        Me.lb_ImbalanceLevel.AutoSize = True
        Me.lb_ImbalanceLevel.Location = New System.Drawing.Point(148, 22)
        Me.lb_ImbalanceLevel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_ImbalanceLevel.Name = "lb_ImbalanceLevel"
        Me.lb_ImbalanceLevel.Size = New System.Drawing.Size(85, 13)
        Me.lb_ImbalanceLevel.TabIndex = 8
        Me.lb_ImbalanceLevel.Text = "Imbalance Level"
        '
        'num_Imbalance_Setpoint
        '
        Me.num_Imbalance_Setpoint.Enabled = False
        Me.num_Imbalance_Setpoint.Location = New System.Drawing.Point(240, 20)
        Me.num_Imbalance_Setpoint.Margin = New System.Windows.Forms.Padding(2)
        Me.num_Imbalance_Setpoint.Maximum = New Decimal(New Integer() {70, 0, 0, 0})
        Me.num_Imbalance_Setpoint.Minimum = New Decimal(New Integer() {70, 0, 0, -2147483648})
        Me.num_Imbalance_Setpoint.Name = "num_Imbalance_Setpoint"
        Me.num_Imbalance_Setpoint.Size = New System.Drawing.Size(55, 20)
        Me.num_Imbalance_Setpoint.TabIndex = 7
        Me.num_Imbalance_Setpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'Grp_KHK
        '
        Me.Grp_KHK.Controls.Add(Me.Label13)
        Me.Grp_KHK.Controls.Add(Me.lb_KHKContactBehavoir)
        Me.Grp_KHK.Controls.Add(Me.Label14)
        Me.Grp_KHK.Controls.Add(Me.num_KHKImbalance_Setpoint)
        Me.Grp_KHK.Controls.Add(Me.lb_KHKSetpoint)
        Me.Grp_KHK.Controls.Add(Me.Label12)
        Me.Grp_KHK.Controls.Add(Me.num_KHK_Setpoint)
        Me.Grp_KHK.Controls.Add(Me.RB_NO)
        Me.Grp_KHK.Controls.Add(Me.RB_NC)
        Me.Grp_KHK.Controls.Add(Me.lb_KHKenable)
        Me.Grp_KHK.Controls.Add(Me.CB_KHKenable)
        Me.Grp_KHK.Location = New System.Drawing.Point(361, 344)
        Me.Grp_KHK.Margin = New System.Windows.Forms.Padding(2)
        Me.Grp_KHK.Name = "Grp_KHK"
        Me.Grp_KHK.Padding = New System.Windows.Forms.Padding(2)
        Me.Grp_KHK.Size = New System.Drawing.Size(225, 132)
        Me.Grp_KHK.TabIndex = 6
        Me.Grp_KHK.TabStop = False
        Me.Grp_KHK.Text = "KHK"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(170, 76)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "%"
        '
        'lb_KHKContactBehavoir
        '
        Me.lb_KHKContactBehavoir.AutoSize = True
        Me.lb_KHKContactBehavoir.Location = New System.Drawing.Point(4, 110)
        Me.lb_KHKContactBehavoir.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_KHKContactBehavoir.Name = "lb_KHKContactBehavoir"
        Me.lb_KHKContactBehavoir.Size = New System.Drawing.Size(89, 13)
        Me.lb_KHKContactBehavoir.TabIndex = 12
        Me.lb_KHKContactBehavoir.Text = "Contact Behavior"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 76)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Imbalance Level"
        '
        'num_KHKImbalance_Setpoint
        '
        Me.num_KHKImbalance_Setpoint.Enabled = False
        Me.num_KHKImbalance_Setpoint.Location = New System.Drawing.Point(114, 74)
        Me.num_KHKImbalance_Setpoint.Margin = New System.Windows.Forms.Padding(2)
        Me.num_KHKImbalance_Setpoint.Maximum = New Decimal(New Integer() {70, 0, 0, 0})
        Me.num_KHKImbalance_Setpoint.Minimum = New Decimal(New Integer() {70, 0, 0, -2147483648})
        Me.num_KHKImbalance_Setpoint.Name = "num_KHKImbalance_Setpoint"
        Me.num_KHKImbalance_Setpoint.Size = New System.Drawing.Size(49, 20)
        Me.num_KHKImbalance_Setpoint.TabIndex = 12
        Me.num_KHKImbalance_Setpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lb_KHKSetpoint
        '
        Me.lb_KHKSetpoint.AutoSize = True
        Me.lb_KHKSetpoint.Location = New System.Drawing.Point(4, 44)
        Me.lb_KHKSetpoint.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_KHKSetpoint.Name = "lb_KHKSetpoint"
        Me.lb_KHKSetpoint.Size = New System.Drawing.Size(75, 13)
        Me.lb_KHKSetpoint.TabIndex = 12
        Me.lb_KHKSetpoint.Text = "KHK Set Point"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(170, 44)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "%"
        '
        'num_KHK_Setpoint
        '
        Me.num_KHK_Setpoint.Enabled = False
        Me.num_KHK_Setpoint.Location = New System.Drawing.Point(114, 42)
        Me.num_KHK_Setpoint.Margin = New System.Windows.Forms.Padding(2)
        Me.num_KHK_Setpoint.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.num_KHK_Setpoint.Name = "num_KHK_Setpoint"
        Me.num_KHK_Setpoint.Size = New System.Drawing.Size(50, 20)
        Me.num_KHK_Setpoint.TabIndex = 8
        Me.num_KHK_Setpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_KHK_Setpoint.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'RB_NO
        '
        Me.RB_NO.AutoSize = True
        Me.RB_NO.Location = New System.Drawing.Point(155, 106)
        Me.RB_NO.Margin = New System.Windows.Forms.Padding(2)
        Me.RB_NO.Name = "RB_NO"
        Me.RB_NO.Size = New System.Drawing.Size(41, 17)
        Me.RB_NO.TabIndex = 7
        Me.RB_NO.TabStop = True
        Me.RB_NO.Text = "NO"
        Me.RB_NO.UseVisualStyleBackColor = True
        '
        'RB_NC
        '
        Me.RB_NC.AutoSize = True
        Me.RB_NC.Location = New System.Drawing.Point(114, 106)
        Me.RB_NC.Margin = New System.Windows.Forms.Padding(2)
        Me.RB_NC.Name = "RB_NC"
        Me.RB_NC.Size = New System.Drawing.Size(40, 17)
        Me.RB_NC.TabIndex = 6
        Me.RB_NC.TabStop = True
        Me.RB_NC.Text = "NC"
        Me.RB_NC.UseVisualStyleBackColor = True
        '
        'lb_KHKenable
        '
        Me.lb_KHKenable.AutoSize = True
        Me.lb_KHKenable.Location = New System.Drawing.Point(4, 16)
        Me.lb_KHKenable.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_KHKenable.Name = "lb_KHKenable"
        Me.lb_KHKenable.Size = New System.Drawing.Size(65, 13)
        Me.lb_KHKenable.TabIndex = 5
        Me.lb_KHKenable.Text = "Enable KHK"
        '
        'CB_KHKenable
        '
        Me.CB_KHKenable.AutoSize = True
        Me.CB_KHKenable.Location = New System.Drawing.Point(114, 15)
        Me.CB_KHKenable.Margin = New System.Windows.Forms.Padding(2)
        Me.CB_KHKenable.Name = "CB_KHKenable"
        Me.CB_KHKenable.Size = New System.Drawing.Size(15, 14)
        Me.CB_KHKenable.TabIndex = 4
        Me.CB_KHKenable.UseVisualStyleBackColor = True
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
        Me.Grp_UnitConfig.Size = New System.Drawing.Size(272, 468)
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
        Me.Grp_UnitParam.Size = New System.Drawing.Size(225, 246)
        Me.Grp_UnitParam.TabIndex = 9
        Me.Grp_UnitParam.TabStop = False
        Me.Grp_UnitParam.Text = "Parameter Setting"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 219)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Disable Bypass"
        '
        'CB_BPDisable
        '
        Me.CB_BPDisable.AutoSize = True
        Me.CB_BPDisable.Location = New System.Drawing.Point(114, 218)
        Me.CB_BPDisable.Margin = New System.Windows.Forms.Padding(2)
        Me.CB_BPDisable.Name = "CB_BPDisable"
        Me.CB_BPDisable.Size = New System.Drawing.Size(15, 14)
        Me.CB_BPDisable.TabIndex = 6
        Me.CB_BPDisable.UseVisualStyleBackColor = True
        '
        'num_SWSetpoint
        '
        Me.num_SWSetpoint.Enabled = False
        Me.num_SWSetpoint.Location = New System.Drawing.Point(114, 188)
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
        Me.num_TempSetpoint.Location = New System.Drawing.Point(114, 163)
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
        Me.num_VOCSetpoint.Location = New System.Drawing.Point(114, 139)
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
        Me.num_RHSetpoint.Location = New System.Drawing.Point(114, 115)
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
        Me.num_CO2Setpoint.Location = New System.Drawing.Point(114, 90)
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
        Me.num_FKITimer.Location = New System.Drawing.Point(114, 67)
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
        Me.num_FilterTimer.Location = New System.Drawing.Point(114, 43)
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
        Me.num_BoostTimer.Location = New System.Drawing.Point(114, 19)
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
        Me.Label9.Location = New System.Drawing.Point(169, 190)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "°C"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(169, 166)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "°C"
        '
        'lb_SWSetpoint
        '
        Me.lb_SWSetpoint.AutoSize = True
        Me.lb_SWSetpoint.Location = New System.Drawing.Point(6, 190)
        Me.lb_SWSetpoint.Name = "lb_SWSetpoint"
        Me.lb_SWSetpoint.Size = New System.Drawing.Size(104, 13)
        Me.lb_SWSetpoint.TabIndex = 2
        Me.lb_SWSetpoint.Text = "SUM/WIN Set Point"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(169, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "ppm"
        '
        'lb_TempSetpoint
        '
        Me.lb_TempSetpoint.AutoSize = True
        Me.lb_TempSetpoint.Location = New System.Drawing.Point(6, 166)
        Me.lb_TempSetpoint.Name = "lb_TempSetpoint"
        Me.lb_TempSetpoint.Size = New System.Drawing.Size(83, 13)
        Me.lb_TempSetpoint.TabIndex = 2
        Me.lb_TempSetpoint.Text = "Temp. Set Point"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(169, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "%"
        '
        'lb_VOCSetpoint
        '
        Me.lb_VOCSetpoint.AutoSize = True
        Me.lb_VOCSetpoint.Location = New System.Drawing.Point(6, 141)
        Me.lb_VOCSetpoint.Name = "lb_VOCSetpoint"
        Me.lb_VOCSetpoint.Size = New System.Drawing.Size(75, 13)
        Me.lb_VOCSetpoint.TabIndex = 2
        Me.lb_VOCSetpoint.Text = "VOC Set Point"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(171, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "ppm"
        '
        'lb_RHSetpoint
        '
        Me.lb_RHSetpoint.AutoSize = True
        Me.lb_RHSetpoint.Location = New System.Drawing.Point(6, 117)
        Me.lb_RHSetpoint.Name = "lb_RHSetpoint"
        Me.lb_RHSetpoint.Size = New System.Drawing.Size(69, 13)
        Me.lb_RHSetpoint.TabIndex = 2
        Me.lb_RHSetpoint.Text = "RH Set Point"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(169, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "days"
        '
        'lb_CO2Setpoint
        '
        Me.lb_CO2Setpoint.AutoSize = True
        Me.lb_CO2Setpoint.Location = New System.Drawing.Point(6, 93)
        Me.lb_CO2Setpoint.Name = "lb_CO2Setpoint"
        Me.lb_CO2Setpoint.Size = New System.Drawing.Size(74, 13)
        Me.lb_CO2Setpoint.TabIndex = 2
        Me.lb_CO2Setpoint.Text = "CO2 Set Point"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(169, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "days"
        '
        'lb_FKITimer
        '
        Me.lb_FKITimer.AutoSize = True
        Me.lb_FKITimer.Location = New System.Drawing.Point(6, 70)
        Me.lb_FKITimer.Name = "lb_FKITimer"
        Me.lb_FKITimer.Size = New System.Drawing.Size(68, 13)
        Me.lb_FKITimer.TabIndex = 2
        Me.lb_FKITimer.Text = "Fire Kit Timer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(169, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "min"
        '
        'lb_FilterTimer
        '
        Me.lb_FilterTimer.AutoSize = True
        Me.lb_FilterTimer.Location = New System.Drawing.Point(6, 46)
        Me.lb_FilterTimer.Name = "lb_FilterTimer"
        Me.lb_FilterTimer.Size = New System.Drawing.Size(58, 13)
        Me.lb_FilterTimer.TabIndex = 2
        Me.lb_FilterTimer.Text = "Filter Timer"
        '
        'lb_BoostTimer
        '
        Me.lb_BoostTimer.AutoSize = True
        Me.lb_BoostTimer.Location = New System.Drawing.Point(6, 20)
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
        Me.Grp_SpeedConf.Controls.Add(Me.num_Speed3CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.num_Speed2CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.num_Speed1CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.num_Speed3FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.num_Speed2FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.num_Speed1FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.vlb_Speed3CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_Speed3CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.vlb_Speed2CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_Speed2CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.vlb_Speed1CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_Speed1CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.vlb_Speed3FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_Speed3FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.vlb_Speed2FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_Speed2FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.vlb_Speed1FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.lb_Speed1FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.PB_Speed3CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.PB_Speed2CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.PB_Speed1CAP)
        Me.Grp_SpeedConf.Controls.Add(Me.PB_Speed3FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.PB_Speed2FSC)
        Me.Grp_SpeedConf.Controls.Add(Me.PB_Speed1FSC)
        Me.Grp_SpeedConf.Location = New System.Drawing.Point(14, 170)
        Me.Grp_SpeedConf.Name = "Grp_SpeedConf"
        Me.Grp_SpeedConf.Size = New System.Drawing.Size(342, 214)
        Me.Grp_SpeedConf.TabIndex = 7
        Me.Grp_SpeedConf.TabStop = False
        Me.Grp_SpeedConf.Text = "Speed Configuration"
        '
        'num_Speed3CAP
        '
        Me.num_Speed3CAP.Enabled = False
        Me.num_Speed3CAP.Location = New System.Drawing.Point(240, 174)
        Me.num_Speed3CAP.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.num_Speed3CAP.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.num_Speed3CAP.Name = "num_Speed3CAP"
        Me.num_Speed3CAP.Size = New System.Drawing.Size(56, 20)
        Me.num_Speed3CAP.TabIndex = 2
        Me.num_Speed3CAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_Speed3CAP.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'num_Speed2CAP
        '
        Me.num_Speed2CAP.Enabled = False
        Me.num_Speed2CAP.Location = New System.Drawing.Point(240, 145)
        Me.num_Speed2CAP.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.num_Speed2CAP.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.num_Speed2CAP.Name = "num_Speed2CAP"
        Me.num_Speed2CAP.Size = New System.Drawing.Size(56, 20)
        Me.num_Speed2CAP.TabIndex = 2
        Me.num_Speed2CAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_Speed2CAP.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'num_Speed1CAP
        '
        Me.num_Speed1CAP.Enabled = False
        Me.num_Speed1CAP.Location = New System.Drawing.Point(239, 116)
        Me.num_Speed1CAP.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.num_Speed1CAP.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.num_Speed1CAP.Name = "num_Speed1CAP"
        Me.num_Speed1CAP.Size = New System.Drawing.Size(56, 20)
        Me.num_Speed1CAP.TabIndex = 2
        Me.num_Speed1CAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_Speed1CAP.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'num_Speed3FSC
        '
        Me.num_Speed3FSC.Enabled = False
        Me.num_Speed3FSC.Location = New System.Drawing.Point(240, 87)
        Me.num_Speed3FSC.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.num_Speed3FSC.Name = "num_Speed3FSC"
        Me.num_Speed3FSC.Size = New System.Drawing.Size(56, 20)
        Me.num_Speed3FSC.TabIndex = 2
        Me.num_Speed3FSC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_Speed3FSC.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'num_Speed2FSC
        '
        Me.num_Speed2FSC.Enabled = False
        Me.num_Speed2FSC.Location = New System.Drawing.Point(239, 58)
        Me.num_Speed2FSC.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.num_Speed2FSC.Name = "num_Speed2FSC"
        Me.num_Speed2FSC.Size = New System.Drawing.Size(56, 20)
        Me.num_Speed2FSC.TabIndex = 2
        Me.num_Speed2FSC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_Speed2FSC.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'num_Speed1FSC
        '
        Me.num_Speed1FSC.Enabled = False
        Me.num_Speed1FSC.Location = New System.Drawing.Point(239, 29)
        Me.num_Speed1FSC.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.num_Speed1FSC.Name = "num_Speed1FSC"
        Me.num_Speed1FSC.Size = New System.Drawing.Size(56, 20)
        Me.num_Speed1FSC.TabIndex = 2
        Me.num_Speed1FSC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.num_Speed1FSC.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'vlb_Speed3CAP
        '
        Me.vlb_Speed3CAP.AutoSize = True
        Me.vlb_Speed3CAP.Location = New System.Drawing.Point(301, 176)
        Me.vlb_Speed3CAP.Name = "vlb_Speed3CAP"
        Me.vlb_Speed3CAP.Size = New System.Drawing.Size(20, 13)
        Me.vlb_Speed3CAP.TabIndex = 1
        Me.vlb_Speed3CAP.Text = "Pa"
        '
        'lb_Speed3CAP
        '
        Me.lb_Speed3CAP.AutoSize = True
        Me.lb_Speed3CAP.Location = New System.Drawing.Point(5, 176)
        Me.lb_Speed3CAP.Name = "lb_Speed3CAP"
        Me.lb_Speed3CAP.Size = New System.Drawing.Size(71, 13)
        Me.lb_Speed3CAP.TabIndex = 1
        Me.lb_Speed3CAP.Text = "Speed 3 CAP"
        '
        'vlb_Speed2CAP
        '
        Me.vlb_Speed2CAP.AutoSize = True
        Me.vlb_Speed2CAP.Location = New System.Drawing.Point(301, 147)
        Me.vlb_Speed2CAP.Name = "vlb_Speed2CAP"
        Me.vlb_Speed2CAP.Size = New System.Drawing.Size(20, 13)
        Me.vlb_Speed2CAP.TabIndex = 1
        Me.vlb_Speed2CAP.Text = "Pa"
        '
        'lb_Speed2CAP
        '
        Me.lb_Speed2CAP.AutoSize = True
        Me.lb_Speed2CAP.Location = New System.Drawing.Point(5, 147)
        Me.lb_Speed2CAP.Name = "lb_Speed2CAP"
        Me.lb_Speed2CAP.Size = New System.Drawing.Size(71, 13)
        Me.lb_Speed2CAP.TabIndex = 1
        Me.lb_Speed2CAP.Text = "Speed 2 CAP"
        '
        'vlb_Speed1CAP
        '
        Me.vlb_Speed1CAP.AutoSize = True
        Me.vlb_Speed1CAP.Location = New System.Drawing.Point(301, 118)
        Me.vlb_Speed1CAP.Name = "vlb_Speed1CAP"
        Me.vlb_Speed1CAP.Size = New System.Drawing.Size(20, 13)
        Me.vlb_Speed1CAP.TabIndex = 1
        Me.vlb_Speed1CAP.Text = "Pa"
        '
        'lb_Speed1CAP
        '
        Me.lb_Speed1CAP.AutoSize = True
        Me.lb_Speed1CAP.Location = New System.Drawing.Point(5, 118)
        Me.lb_Speed1CAP.Name = "lb_Speed1CAP"
        Me.lb_Speed1CAP.Size = New System.Drawing.Size(71, 13)
        Me.lb_Speed1CAP.TabIndex = 1
        Me.lb_Speed1CAP.Text = "Speed 1 CAP"
        '
        'vlb_Speed3FSC
        '
        Me.vlb_Speed3FSC.AutoSize = True
        Me.vlb_Speed3FSC.Location = New System.Drawing.Point(302, 89)
        Me.vlb_Speed3FSC.Name = "vlb_Speed3FSC"
        Me.vlb_Speed3FSC.Size = New System.Drawing.Size(15, 13)
        Me.vlb_Speed3FSC.TabIndex = 1
        Me.vlb_Speed3FSC.Text = "%"
        '
        'lb_Speed3FSC
        '
        Me.lb_Speed3FSC.AutoSize = True
        Me.lb_Speed3FSC.Location = New System.Drawing.Point(6, 89)
        Me.lb_Speed3FSC.Name = "lb_Speed3FSC"
        Me.lb_Speed3FSC.Size = New System.Drawing.Size(95, 13)
        Me.lb_Speed3FSC.TabIndex = 1
        Me.lb_Speed3FSC.Text = "Speed 3 FSC/CAF"
        '
        'vlb_Speed2FSC
        '
        Me.vlb_Speed2FSC.AutoSize = True
        Me.vlb_Speed2FSC.Location = New System.Drawing.Point(302, 60)
        Me.vlb_Speed2FSC.Name = "vlb_Speed2FSC"
        Me.vlb_Speed2FSC.Size = New System.Drawing.Size(15, 13)
        Me.vlb_Speed2FSC.TabIndex = 1
        Me.vlb_Speed2FSC.Text = "%"
        '
        'lb_Speed2FSC
        '
        Me.lb_Speed2FSC.AutoSize = True
        Me.lb_Speed2FSC.Location = New System.Drawing.Point(6, 60)
        Me.lb_Speed2FSC.Name = "lb_Speed2FSC"
        Me.lb_Speed2FSC.Size = New System.Drawing.Size(95, 13)
        Me.lb_Speed2FSC.TabIndex = 1
        Me.lb_Speed2FSC.Text = "Speed 2 FSC/CAF"
        '
        'vlb_Speed1FSC
        '
        Me.vlb_Speed1FSC.AutoSize = True
        Me.vlb_Speed1FSC.Location = New System.Drawing.Point(302, 31)
        Me.vlb_Speed1FSC.Name = "vlb_Speed1FSC"
        Me.vlb_Speed1FSC.Size = New System.Drawing.Size(15, 13)
        Me.vlb_Speed1FSC.TabIndex = 1
        Me.vlb_Speed1FSC.Text = "%"
        '
        'lb_Speed1FSC
        '
        Me.lb_Speed1FSC.AutoSize = True
        Me.lb_Speed1FSC.Location = New System.Drawing.Point(6, 31)
        Me.lb_Speed1FSC.Name = "lb_Speed1FSC"
        Me.lb_Speed1FSC.Size = New System.Drawing.Size(95, 13)
        Me.lb_Speed1FSC.TabIndex = 1
        Me.lb_Speed1FSC.Text = "Speed 1 FSC/CAF"
        '
        'PB_Speed3CAP
        '
        Me.PB_Speed3CAP.Location = New System.Drawing.Point(110, 175)
        Me.PB_Speed3CAP.Maximum = 400
        Me.PB_Speed3CAP.Name = "PB_Speed3CAP"
        Me.PB_Speed3CAP.Size = New System.Drawing.Size(123, 19)
        Me.PB_Speed3CAP.Step = 1
        Me.PB_Speed3CAP.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_Speed3CAP.TabIndex = 0
        '
        'PB_Speed2CAP
        '
        Me.PB_Speed2CAP.Location = New System.Drawing.Point(110, 145)
        Me.PB_Speed2CAP.Maximum = 400
        Me.PB_Speed2CAP.Name = "PB_Speed2CAP"
        Me.PB_Speed2CAP.Size = New System.Drawing.Size(123, 20)
        Me.PB_Speed2CAP.Step = 1
        Me.PB_Speed2CAP.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_Speed2CAP.TabIndex = 0
        '
        'PB_Speed1CAP
        '
        Me.PB_Speed1CAP.Location = New System.Drawing.Point(110, 116)
        Me.PB_Speed1CAP.Maximum = 400
        Me.PB_Speed1CAP.Name = "PB_Speed1CAP"
        Me.PB_Speed1CAP.Size = New System.Drawing.Size(123, 20)
        Me.PB_Speed1CAP.Step = 1
        Me.PB_Speed1CAP.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_Speed1CAP.TabIndex = 0
        '
        'PB_Speed3FSC
        '
        Me.PB_Speed3FSC.Location = New System.Drawing.Point(110, 87)
        Me.PB_Speed3FSC.Name = "PB_Speed3FSC"
        Me.PB_Speed3FSC.Size = New System.Drawing.Size(123, 20)
        Me.PB_Speed3FSC.Step = 1
        Me.PB_Speed3FSC.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_Speed3FSC.TabIndex = 0
        '
        'PB_Speed2FSC
        '
        Me.PB_Speed2FSC.Location = New System.Drawing.Point(110, 58)
        Me.PB_Speed2FSC.Name = "PB_Speed2FSC"
        Me.PB_Speed2FSC.Size = New System.Drawing.Size(123, 20)
        Me.PB_Speed2FSC.Step = 1
        Me.PB_Speed2FSC.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_Speed2FSC.TabIndex = 0
        '
        'PB_Speed1FSC
        '
        Me.PB_Speed1FSC.Location = New System.Drawing.Point(110, 29)
        Me.PB_Speed1FSC.Name = "PB_Speed1FSC"
        Me.PB_Speed1FSC.Size = New System.Drawing.Size(123, 20)
        Me.PB_Speed1FSC.Step = 1
        Me.PB_Speed1FSC.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_Speed1FSC.TabIndex = 0
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
        Me.PcBx_Logo.Location = New System.Drawing.Point(254, 64)
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
        Me.Tab_Main.Size = New System.Drawing.Size(878, 507)
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
        Me.TP_Shell.Size = New System.Drawing.Size(870, 481)
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
        Me.lb_QKvers.Location = New System.Drawing.Point(749, 8)
        Me.lb_QKvers.Name = "lb_QKvers"
        Me.lb_QKvers.Size = New System.Drawing.Size(96, 13)
        Me.lb_QKvers.TabIndex = 8
        Me.lb_QKvers.Text = "Software Version : "
        '
        'Program_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 527)
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
        Me.Grp_Imbalance.ResumeLayout(False)
        Me.Grp_Imbalance.PerformLayout()
        CType(Me.num_Imbalance_Setpoint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_KHK.ResumeLayout(False)
        Me.Grp_KHK.PerformLayout()
        CType(Me.num_KHKImbalance_Setpoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KHK_Setpoint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_UnitConfig.ResumeLayout(False)
        Me.Grp_UnitConfig.PerformLayout()
        CType(Me.PcBx_Quark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_UnitParam.ResumeLayout(False)
        Me.Grp_UnitParam.PerformLayout()
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
        CType(Me.num_Speed3CAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_Speed2CAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_Speed1CAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_Speed3FSC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_Speed2FSC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_Speed1FSC, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PB_Speed3CAP As ProgressBar
    Friend WithEvents PB_Speed2CAP As ProgressBar
    Friend WithEvents PB_Speed1CAP As ProgressBar
    Friend WithEvents PB_Speed3FSC As ProgressBar
    Friend WithEvents PB_Speed2FSC As ProgressBar
    Friend WithEvents PB_Speed1FSC As ProgressBar
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
    Friend WithEvents num_Speed1FSC As NumericUpDown
    Friend WithEvents num_Speed3CAP As NumericUpDown
    Friend WithEvents num_Speed2CAP As NumericUpDown
    Friend WithEvents num_Speed1CAP As NumericUpDown
    Friend WithEvents num_Speed3FSC As NumericUpDown
    Friend WithEvents num_Speed2FSC As NumericUpDown
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
    Friend WithEvents Grp_KHK As GroupBox
    Friend WithEvents RB_NO As RadioButton
    Friend WithEvents RB_NC As RadioButton
    Friend WithEvents lb_ImbalanceLevel As Label
    Friend WithEvents num_Imbalance_Setpoint As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents Grp_Imbalance As GroupBox
    Friend WithEvents lb_ImbalanceEnable As Label
    Friend WithEvents CB_ImbEnable As CheckBox
    Friend WithEvents Btn_FirmwareUpdate As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents num_KHK_Setpoint As NumericUpDown
    Friend WithEvents lb_KHKSetpoint As Label
    Friend WithEvents lb_KHKContactBehavoir As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents CB_BPDisable As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents num_KHKImbalance_Setpoint As NumericUpDown
    Friend WithEvents CB_SaveLog As CheckBox
    Friend WithEvents CB_Timestamp As CheckBox
End Class
