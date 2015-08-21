<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DisableCheckPortA = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ApplyPortA = New System.Windows.Forms.Button()
        Me.ClearPortA = New System.Windows.Forms.Button()
        Me.MoveDownPortA = New System.Windows.Forms.Button()
        Me.MoveUpPortA = New System.Windows.Forms.Button()
        Me.RemoveSFPortA = New System.Windows.Forms.Button()
        Me.ImportSFPortA = New System.Windows.Forms.Button()
        Me.PortABox = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DisableCheckPortB = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ApplyPortB = New System.Windows.Forms.Button()
        Me.ClearPortB = New System.Windows.Forms.Button()
        Me.MoveDownPortB = New System.Windows.Forms.Button()
        Me.MoveUpPortB = New System.Windows.Forms.Button()
        Me.RemoveSFPortB = New System.Windows.Forms.Button()
        Me.ImportSFPortB = New System.Windows.Forms.Button()
        Me.PortBBox = New System.Windows.Forms.ListBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ManualBlackListLabel = New System.Windows.Forms.Label()
        Me.ManualBlackList = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BlackListAdvancedMode = New System.Windows.Forms.CheckBox()
        Me.RestoreDefaultBlackList = New System.Windows.Forms.Button()
        Me.RemoveBlackList = New System.Windows.Forms.Button()
        Me.AddBlackList = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ProgramsBlackList = New System.Windows.Forms.ListBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SoftwareRendering = New System.Windows.Forms.CheckBox()
        Me.FloatingDisabled = New System.Windows.Forms.CheckBox()
        Me.VolumeBar = New System.Windows.Forms.TrackBar()
        Me.CurrentVolumeHUE = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Versionlabel = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.LatestVersionDriver = New System.Windows.Forms.Label()
        Me.UpdateDownload = New System.Windows.Forms.Button()
        Me.ThisVersionDriver = New System.Windows.Forms.Label()
        Me.AdvancedReset = New System.Windows.Forms.Button()
        Me.AdvancedApply = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DSPipe = New System.Windows.Forms.RadioButton()
        Me.XAudioPipe = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TracksLimit = New System.Windows.Forms.NumericUpDown()
        Me.SincInter = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.sampframe = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.bufsize = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Frequency = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MaxCPU = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PolyphonyLimit = New System.Windows.Forms.NumericUpDown()
        Me.DisableFX = New System.Windows.Forms.CheckBox()
        Me.Preload = New System.Windows.Forms.CheckBox()
        Me.NoteOff = New System.Windows.Forms.CheckBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.FancyClock = New System.Windows.Forms.Label()
        Me.PortAOpenDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PortBOpenDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Information = New System.Windows.Forms.ToolTip(Me.components)
        Me.BlackListFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.FancyClockTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SystemTrayicon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowMainWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutDriverWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseApp = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutomaticStartup = New System.Windows.Forms.CheckBox()
        Me.Tabs.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.VolumeBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TracksLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bufsize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PolyphonyLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tabs
        '
        Me.Tabs.Controls.Add(Me.TabPage1)
        Me.Tabs.Controls.Add(Me.TabPage2)
        Me.Tabs.Controls.Add(Me.TabPage3)
        Me.Tabs.Controls.Add(Me.TabPage4)
        Me.Tabs.Controls.Add(Me.TabPage5)
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Location = New System.Drawing.Point(0, 0)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(599, 382)
        Me.Tabs.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DisableCheckPortA)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.ApplyPortA)
        Me.TabPage1.Controls.Add(Me.ClearPortA)
        Me.TabPage1.Controls.Add(Me.MoveDownPortA)
        Me.TabPage1.Controls.Add(Me.MoveUpPortA)
        Me.TabPage1.Controls.Add(Me.RemoveSFPortA)
        Me.TabPage1.Controls.Add(Me.ImportSFPortA)
        Me.TabPage1.Controls.Add(Me.PortABox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(591, 356)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Soundfont in Port A"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DisableCheckPortA
        '
        Me.DisableCheckPortA.AutoSize = True
        Me.DisableCheckPortA.Location = New System.Drawing.Point(7, 336)
        Me.DisableCheckPortA.Name = "DisableCheckPortA"
        Me.DisableCheckPortA.Size = New System.Drawing.Size(158, 17)
        Me.DisableCheckPortA.TabIndex = 10
        Me.DisableCheckPortA.Text = "Disable file extension check"
        Me.DisableCheckPortA.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(509, 148)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 128)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "On SFZ files:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "px,y=0,0|" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "x = Bank" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "y = Preset"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(340, 337)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "The last soundfont will override the previous ones."
        '
        'ApplyPortA
        '
        Me.ApplyPortA.Location = New System.Drawing.Point(509, 308)
        Me.ApplyPortA.Name = "ApplyPortA"
        Me.ApplyPortA.Size = New System.Drawing.Size(75, 23)
        Me.ApplyPortA.TabIndex = 7
        Me.ApplyPortA.Text = "Apply"
        Me.ApplyPortA.UseVisualStyleBackColor = True
        '
        'ClearPortA
        '
        Me.ClearPortA.Location = New System.Drawing.Point(509, 279)
        Me.ClearPortA.Name = "ClearPortA"
        Me.ClearPortA.Size = New System.Drawing.Size(75, 23)
        Me.ClearPortA.TabIndex = 6
        Me.ClearPortA.Text = "Clear list"
        Me.ClearPortA.UseVisualStyleBackColor = True
        '
        'MoveDownPortA
        '
        Me.MoveDownPortA.Location = New System.Drawing.Point(509, 122)
        Me.MoveDownPortA.Name = "MoveDownPortA"
        Me.MoveDownPortA.Size = New System.Drawing.Size(75, 23)
        Me.MoveDownPortA.TabIndex = 5
        Me.MoveDownPortA.Text = "Move down"
        Me.MoveDownPortA.UseVisualStyleBackColor = True
        '
        'MoveUpPortA
        '
        Me.MoveUpPortA.Location = New System.Drawing.Point(509, 93)
        Me.MoveUpPortA.Name = "MoveUpPortA"
        Me.MoveUpPortA.Size = New System.Drawing.Size(75, 23)
        Me.MoveUpPortA.TabIndex = 4
        Me.MoveUpPortA.Text = "Move up"
        Me.MoveUpPortA.UseVisualStyleBackColor = True
        '
        'RemoveSFPortA
        '
        Me.RemoveSFPortA.Location = New System.Drawing.Point(509, 35)
        Me.RemoveSFPortA.Name = "RemoveSFPortA"
        Me.RemoveSFPortA.Size = New System.Drawing.Size(75, 23)
        Me.RemoveSFPortA.TabIndex = 2
        Me.RemoveSFPortA.Text = "Remove"
        Me.RemoveSFPortA.UseVisualStyleBackColor = True
        '
        'ImportSFPortA
        '
        Me.ImportSFPortA.Location = New System.Drawing.Point(509, 6)
        Me.ImportSFPortA.Name = "ImportSFPortA"
        Me.ImportSFPortA.Size = New System.Drawing.Size(75, 23)
        Me.ImportSFPortA.TabIndex = 1
        Me.ImportSFPortA.Text = "Add"
        Me.ImportSFPortA.UseVisualStyleBackColor = True
        '
        'PortABox
        '
        Me.PortABox.FormattingEnabled = True
        Me.PortABox.HorizontalScrollbar = True
        Me.PortABox.Location = New System.Drawing.Point(1, 1)
        Me.PortABox.Name = "PortABox"
        Me.PortABox.Size = New System.Drawing.Size(502, 329)
        Me.PortABox.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DisableCheckPortB)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.ApplyPortB)
        Me.TabPage2.Controls.Add(Me.ClearPortB)
        Me.TabPage2.Controls.Add(Me.MoveDownPortB)
        Me.TabPage2.Controls.Add(Me.MoveUpPortB)
        Me.TabPage2.Controls.Add(Me.RemoveSFPortB)
        Me.TabPage2.Controls.Add(Me.ImportSFPortB)
        Me.TabPage2.Controls.Add(Me.PortBBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(591, 356)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Soundfont in Port B"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DisableCheckPortB
        '
        Me.DisableCheckPortB.AutoSize = True
        Me.DisableCheckPortB.Location = New System.Drawing.Point(7, 336)
        Me.DisableCheckPortB.Name = "DisableCheckPortB"
        Me.DisableCheckPortB.Size = New System.Drawing.Size(158, 17)
        Me.DisableCheckPortB.TabIndex = 19
        Me.DisableCheckPortB.Text = "Disable file extension check"
        Me.DisableCheckPortB.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(340, 337)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(243, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "The last soundfont will override the previous ones."
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(509, 148)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 128)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "On SFZ files:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "px,y=0,0|" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "x = Bank" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "y = Preset"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ApplyPortB
        '
        Me.ApplyPortB.Location = New System.Drawing.Point(509, 308)
        Me.ApplyPortB.Name = "ApplyPortB"
        Me.ApplyPortB.Size = New System.Drawing.Size(75, 23)
        Me.ApplyPortB.TabIndex = 15
        Me.ApplyPortB.Text = "Apply"
        Me.ApplyPortB.UseVisualStyleBackColor = True
        '
        'ClearPortB
        '
        Me.ClearPortB.Location = New System.Drawing.Point(509, 279)
        Me.ClearPortB.Name = "ClearPortB"
        Me.ClearPortB.Size = New System.Drawing.Size(75, 23)
        Me.ClearPortB.TabIndex = 14
        Me.ClearPortB.Text = "Clear list"
        Me.ClearPortB.UseVisualStyleBackColor = True
        '
        'MoveDownPortB
        '
        Me.MoveDownPortB.Location = New System.Drawing.Point(509, 122)
        Me.MoveDownPortB.Name = "MoveDownPortB"
        Me.MoveDownPortB.Size = New System.Drawing.Size(75, 23)
        Me.MoveDownPortB.TabIndex = 13
        Me.MoveDownPortB.Text = "Move down"
        Me.MoveDownPortB.UseVisualStyleBackColor = True
        '
        'MoveUpPortB
        '
        Me.MoveUpPortB.Location = New System.Drawing.Point(509, 93)
        Me.MoveUpPortB.Name = "MoveUpPortB"
        Me.MoveUpPortB.Size = New System.Drawing.Size(75, 23)
        Me.MoveUpPortB.TabIndex = 12
        Me.MoveUpPortB.Text = "Move up"
        Me.MoveUpPortB.UseVisualStyleBackColor = True
        '
        'RemoveSFPortB
        '
        Me.RemoveSFPortB.Location = New System.Drawing.Point(509, 35)
        Me.RemoveSFPortB.Name = "RemoveSFPortB"
        Me.RemoveSFPortB.Size = New System.Drawing.Size(75, 23)
        Me.RemoveSFPortB.TabIndex = 11
        Me.RemoveSFPortB.Text = "Remove"
        Me.RemoveSFPortB.UseVisualStyleBackColor = True
        '
        'ImportSFPortB
        '
        Me.ImportSFPortB.Location = New System.Drawing.Point(509, 6)
        Me.ImportSFPortB.Name = "ImportSFPortB"
        Me.ImportSFPortB.Size = New System.Drawing.Size(75, 23)
        Me.ImportSFPortB.TabIndex = 10
        Me.ImportSFPortB.Text = "Add"
        Me.ImportSFPortB.UseVisualStyleBackColor = True
        '
        'PortBBox
        '
        Me.PortBBox.FormattingEnabled = True
        Me.PortBBox.HorizontalScrollbar = True
        Me.PortBBox.Location = New System.Drawing.Point(1, 1)
        Me.PortBBox.Name = "PortBBox"
        Me.PortBBox.Size = New System.Drawing.Size(502, 329)
        Me.PortBBox.TabIndex = 9
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.ManualBlackListLabel)
        Me.TabPage3.Controls.Add(Me.ManualBlackList)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.BlackListAdvancedMode)
        Me.TabPage3.Controls.Add(Me.RestoreDefaultBlackList)
        Me.TabPage3.Controls.Add(Me.RemoveBlackList)
        Me.TabPage3.Controls.Add(Me.AddBlackList)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.ProgramsBlackList)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(591, 356)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "Driver blacklist"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(301, 336)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(286, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Tip: Names are case sensitive, and spaces are recognized."
        '
        'ManualBlackListLabel
        '
        Me.ManualBlackListLabel.Enabled = False
        Me.ManualBlackListLabel.Location = New System.Drawing.Point(271, 80)
        Me.ManualBlackListLabel.Name = "ManualBlackListLabel"
        Me.ManualBlackListLabel.Size = New System.Drawing.Size(215, 13)
        Me.ManualBlackListLabel.TabIndex = 18
        Me.ManualBlackListLabel.Text = "Name of the program (with .exe extension):"
        Me.ManualBlackListLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ManualBlackListLabel.Visible = False
        '
        'ManualBlackList
        '
        Me.ManualBlackList.Enabled = False
        Me.ManualBlackList.Location = New System.Drawing.Point(487, 77)
        Me.ManualBlackList.Name = "ManualBlackList"
        Me.ManualBlackList.Size = New System.Drawing.Size(100, 20)
        Me.ManualBlackList.TabIndex = 17
        Me.ManualBlackList.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(239, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Select a program by clicking ''Add executable(s)''."
        '
        'BlackListAdvancedMode
        '
        Me.BlackListAdvancedMode.AutoSize = True
        Me.BlackListAdvancedMode.Location = New System.Drawing.Point(6, 79)
        Me.BlackListAdvancedMode.Name = "BlackListAdvancedMode"
        Me.BlackListAdvancedMode.Size = New System.Drawing.Size(229, 17)
        Me.BlackListAdvancedMode.TabIndex = 15
        Me.BlackListAdvancedMode.Text = "I want to add the program's name by myself"
        Me.BlackListAdvancedMode.UseVisualStyleBackColor = True
        '
        'RestoreDefaultBlackList
        '
        Me.RestoreDefaultBlackList.Location = New System.Drawing.Point(466, 51)
        Me.RestoreDefaultBlackList.Name = "RestoreDefaultBlackList"
        Me.RestoreDefaultBlackList.Size = New System.Drawing.Size(122, 23)
        Me.RestoreDefaultBlackList.TabIndex = 14
        Me.RestoreDefaultBlackList.Text = "Restore default"
        Me.RestoreDefaultBlackList.UseVisualStyleBackColor = True
        '
        'RemoveBlackList
        '
        Me.RemoveBlackList.Location = New System.Drawing.Point(466, 27)
        Me.RemoveBlackList.Name = "RemoveBlackList"
        Me.RemoveBlackList.Size = New System.Drawing.Size(122, 23)
        Me.RemoveBlackList.TabIndex = 13
        Me.RemoveBlackList.Text = "Remove executable(s)"
        Me.RemoveBlackList.UseVisualStyleBackColor = True
        '
        'AddBlackList
        '
        Me.AddBlackList.Location = New System.Drawing.Point(466, 3)
        Me.AddBlackList.Name = "AddBlackList"
        Me.AddBlackList.Size = New System.Drawing.Size(122, 23)
        Me.AddBlackList.TabIndex = 12
        Me.AddBlackList.Text = "Add executable(s)"
        Me.AddBlackList.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(4, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(441, 52)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = resources.GetString("Label10.Text")
        '
        'ProgramsBlackList
        '
        Me.ProgramsBlackList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProgramsBlackList.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgramsBlackList.FormattingEnabled = True
        Me.ProgramsBlackList.HorizontalScrollbar = True
        Me.ProgramsBlackList.ItemHeight = 15
        Me.ProgramsBlackList.Location = New System.Drawing.Point(3, 100)
        Me.ProgramsBlackList.Margin = New System.Windows.Forms.Padding(0)
        Me.ProgramsBlackList.Name = "ProgramsBlackList"
        Me.ProgramsBlackList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ProgramsBlackList.Size = New System.Drawing.Size(585, 227)
        Me.ProgramsBlackList.TabIndex = 10
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.LinkLabel1)
        Me.TabPage4.Controls.Add(Me.GroupBox1)
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Controls.Add(Me.AdvancedReset)
        Me.TabPage4.Controls.Add(Me.AdvancedApply)
        Me.TabPage4.Controls.Add(Me.GroupBox2)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(591, 356)
        Me.TabPage4.TabIndex = 2
        Me.TabPage4.Text = "Settings/Update"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(13, 332)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(225, 13)
        Me.LinkLabel1.TabIndex = 7
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Why is software rendering enabled by default?"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SoftwareRendering)
        Me.GroupBox1.Controls.Add(Me.FloatingDisabled)
        Me.GroupBox1.Controls.Add(Me.VolumeBar)
        Me.GroupBox1.Controls.Add(Me.CurrentVolumeHUE)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(575, 74)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Quality/Volume"
        '
        'SoftwareRendering
        '
        Me.SoftwareRendering.AutoSize = True
        Me.SoftwareRendering.Location = New System.Drawing.Point(196, 18)
        Me.SoftwareRendering.Name = "SoftwareRendering"
        Me.SoftwareRendering.Size = New System.Drawing.Size(143, 17)
        Me.SoftwareRendering.TabIndex = 3
        Me.SoftwareRendering.Text = "Force software rendering"
        Me.Information.SetToolTip(Me.SoftwareRendering, "Force software rendering, instead of using the main hardware.")
        Me.SoftwareRendering.UseVisualStyleBackColor = True
        '
        'FloatingDisabled
        '
        Me.FloatingDisabled.AutoSize = True
        Me.FloatingDisabled.Location = New System.Drawing.Point(8, 18)
        Me.FloatingDisabled.Name = "FloatingDisabled"
        Me.FloatingDisabled.Size = New System.Drawing.Size(182, 17)
        Me.FloatingDisabled.TabIndex = 2
        Me.FloatingDisabled.Text = "Disable 32-bit floating point audio"
        Me.Information.SetToolTip(Me.FloatingDisabled, "Use 16-bit integer rendering instead of the 32-bit floating point one. (Useful fo" & _
        "r old PCs)")
        Me.FloatingDisabled.UseVisualStyleBackColor = True
        '
        'VolumeBar
        '
        Me.VolumeBar.AutoSize = False
        Me.VolumeBar.BackColor = System.Drawing.Color.White
        Me.VolumeBar.Location = New System.Drawing.Point(4, 37)
        Me.VolumeBar.Maximum = 10000
        Me.VolumeBar.Name = "VolumeBar"
        Me.VolumeBar.Size = New System.Drawing.Size(477, 33)
        Me.VolumeBar.TabIndex = 0
        Me.VolumeBar.TickFrequency = 100
        Me.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'CurrentVolumeHUE
        '
        Me.CurrentVolumeHUE.Font = New System.Drawing.Font("KEPPYDIGITAL", 44.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentVolumeHUE.Location = New System.Drawing.Point(336, 8)
        Me.CurrentVolumeHUE.Name = "CurrentVolumeHUE"
        Me.CurrentVolumeHUE.Size = New System.Drawing.Size(236, 60)
        Me.CurrentVolumeHUE.TabIndex = 1
        Me.CurrentVolumeHUE.Text = "100"
        Me.CurrentVolumeHUE.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CurrentVolumeHUE.UseCompatibleTextRendering = True
        Me.CurrentVolumeHUE.UseMnemonic = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.AutomaticStartup)
        Me.GroupBox3.Controls.Add(Me.Versionlabel)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.LatestVersionDriver)
        Me.GroupBox3.Controls.Add(Me.UpdateDownload)
        Me.GroupBox3.Controls.Add(Me.ThisVersionDriver)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 241)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(575, 80)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Other/Updates"
        '
        'Versionlabel
        '
        Me.Versionlabel.Location = New System.Drawing.Point(85, 56)
        Me.Versionlabel.Name = "Versionlabel"
        Me.Versionlabel.Size = New System.Drawing.Size(374, 15)
        Me.Versionlabel.TabIndex = 6
        Me.Versionlabel.Text = "Your current O.S. is: Not Linux For Sure"
        Me.Versionlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(4, 52)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Changelog"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'LatestVersionDriver
        '
        Me.LatestVersionDriver.AutoSize = True
        Me.LatestVersionDriver.Location = New System.Drawing.Point(5, 35)
        Me.LatestVersionDriver.Name = "LatestVersionDriver"
        Me.LatestVersionDriver.Size = New System.Drawing.Size(250, 13)
        Me.LatestVersionDriver.TabIndex = 2
        Me.LatestVersionDriver.Text = "The latest version of the driver is: ANOTHERTEST "
        '
        'UpdateDownload
        '
        Me.UpdateDownload.Location = New System.Drawing.Point(465, 52)
        Me.UpdateDownload.Name = "UpdateDownload"
        Me.UpdateDownload.Size = New System.Drawing.Size(106, 23)
        Me.UpdateDownload.TabIndex = 1
        Me.UpdateDownload.Text = "Check for updates"
        Me.UpdateDownload.UseVisualStyleBackColor = True
        '
        'ThisVersionDriver
        '
        Me.ThisVersionDriver.AutoSize = True
        Me.ThisVersionDriver.Location = New System.Drawing.Point(5, 16)
        Me.ThisVersionDriver.Name = "ThisVersionDriver"
        Me.ThisVersionDriver.Size = New System.Drawing.Size(208, 13)
        Me.ThisVersionDriver.TabIndex = 0
        Me.ThisVersionDriver.Text = "Your current version of the driver is:  TEST"
        '
        'AdvancedReset
        '
        Me.AdvancedReset.Location = New System.Drawing.Point(407, 327)
        Me.AdvancedReset.Name = "AdvancedReset"
        Me.AdvancedReset.Size = New System.Drawing.Size(87, 23)
        Me.AdvancedReset.TabIndex = 3
        Me.AdvancedReset.Text = "Reset settings"
        Me.AdvancedReset.UseVisualStyleBackColor = True
        '
        'AdvancedApply
        '
        Me.AdvancedApply.Location = New System.Drawing.Point(500, 327)
        Me.AdvancedApply.Name = "AdvancedApply"
        Me.AdvancedApply.Size = New System.Drawing.Size(85, 23)
        Me.AdvancedApply.TabIndex = 2
        Me.AdvancedApply.Text = "Apply settings"
        Me.AdvancedApply.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TracksLimit)
        Me.GroupBox2.Controls.Add(Me.SincInter)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.sampframe)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.bufsize)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Frequency)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.MaxCPU)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.PolyphonyLimit)
        Me.GroupBox2.Controls.Add(Me.DisableFX)
        Me.GroupBox2.Controls.Add(Me.Preload)
        Me.GroupBox2.Controls.Add(Me.NoteOff)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(575, 149)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Advanced settings"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.DSPipe)
        Me.Panel1.Controls.Add(Me.XAudioPipe)
        Me.Panel1.Location = New System.Drawing.Point(5, 86)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(303, 59)
        Me.Panel1.TabIndex = 16
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Location = New System.Drawing.Point(109, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(194, 59)
        Me.Panel2.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(7, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(179, 41)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "XAudio is actually much faster than DirectSound, in terms of" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "delay and soundfont" & _
    " preloading." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Use DirectSound if your PC isn't powerful enough for XAudio."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Change audio pipe:"
        '
        'DSPipe
        '
        Me.DSPipe.AutoSize = True
        Me.DSPipe.Location = New System.Drawing.Point(7, 36)
        Me.DSPipe.Name = "DSPipe"
        Me.DSPipe.Size = New System.Drawing.Size(84, 17)
        Me.DSPipe.TabIndex = 1
        Me.DSPipe.TabStop = True
        Me.DSPipe.Text = "DirectSound"
        Me.DSPipe.UseVisualStyleBackColor = True
        '
        'XAudioPipe
        '
        Me.XAudioPipe.AutoSize = True
        Me.XAudioPipe.Location = New System.Drawing.Point(7, 19)
        Me.XAudioPipe.Name = "XAudioPipe"
        Me.XAudioPipe.Size = New System.Drawing.Size(59, 17)
        Me.XAudioPipe.TabIndex = 0
        Me.XAudioPipe.TabStop = True
        Me.XAudioPipe.Text = "XAudio"
        Me.XAudioPipe.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(398, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Maximum MIDI tracks:"
        Me.Information.SetToolTip(Me.Label4, "Limit the tracks for BASSMIDI. (The other tracks will be muted)")
        '
        'TracksLimit
        '
        Me.TracksLimit.Location = New System.Drawing.Point(510, 124)
        Me.TracksLimit.Maximum = New Decimal(New Integer() {128, 0, 0, 0})
        Me.TracksLimit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TracksLimit.Name = "TracksLimit"
        Me.TracksLimit.Size = New System.Drawing.Size(59, 20)
        Me.TracksLimit.TabIndex = 14
        Me.Information.SetToolTip(Me.TracksLimit, "Limit the tracks for BASSMIDI. (The other tracks will be muted)")
        Me.TracksLimit.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'SincInter
        '
        Me.SincInter.AutoSize = True
        Me.SincInter.Location = New System.Drawing.Point(6, 34)
        Me.SincInter.Name = "SincInter"
        Me.SincInter.Size = New System.Drawing.Size(141, 17)
        Me.SincInter.TabIndex = 13
        Me.SincInter.Text = "Enable sinc interpolation"
        Me.Information.SetToolTip(Me.SincInter, "Enable the sinc interpolation. (Avoids audio corruptions, but can completely ruin" & _
        " the audio with Black MIDIs)")
        Me.SincInter.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(408, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Samples per frame:"
        Me.Information.SetToolTip(Me.Label8, "This is just a setting to make the driver run faster with old PCs.")
        '
        'sampframe
        '
        Me.sampframe.FormattingEnabled = True
        Me.sampframe.Items.AddRange(New Object() {"262140", "131070", "65535", "32768", "16384", "8192", "4096", "2048", "1024", "792"})
        Me.sampframe.Location = New System.Drawing.Point(505, 101)
        Me.sampframe.Name = "sampframe"
        Me.sampframe.Size = New System.Drawing.Size(64, 21)
        Me.sampframe.TabIndex = 11
        Me.sampframe.Text = "792"
        Me.Information.SetToolTip(Me.sampframe, "This is just a setting to make the driver run faster with old PCs. (792 is the de" & _
        "fault/minimum value)")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(440, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Buffer length:"
        Me.Information.SetToolTip(Me.Label7, "Change the size of the buffer, for XAudio. (DirectSound is deprecated)")
        '
        'bufsize
        '
        Me.bufsize.Location = New System.Drawing.Point(510, 33)
        Me.bufsize.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.bufsize.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.bufsize.Name = "bufsize"
        Me.bufsize.Size = New System.Drawing.Size(59, 20)
        Me.bufsize.TabIndex = 9
        Me.Information.SetToolTip(Me.bufsize, "Change the size of the buffer, for XAudio. (DirectSound is deprecated)")
        Me.bufsize.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(418, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Audio frequency:"
        Me.Information.SetToolTip(Me.Label6, "Change the audio frequency.")
        '
        'Frequency
        '
        Me.Frequency.FormattingEnabled = True
        Me.Frequency.Items.AddRange(New Object() {"192000", "142180", "96000", "74750", "66150", "50000", "48000", "44100", "22050", "11025", "8000"})
        Me.Frequency.Location = New System.Drawing.Point(505, 78)
        Me.Frequency.Name = "Frequency"
        Me.Frequency.Size = New System.Drawing.Size(64, 21)
        Me.Frequency.TabIndex = 7
        Me.Frequency.Text = "192000"
        Me.Information.SetToolTip(Me.Frequency, "Change the audio frequency. (WARNING: Setting an high value can potentially break" & _
        " the audio)")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(349, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(156, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Max rendering time percentage:"
        Me.Information.SetToolTip(Me.Label5, "Limit BASSMIDI's CPU usage.")
        '
        'MaxCPU
        '
        Me.MaxCPU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MaxCPU.FormattingEnabled = True
        Me.MaxCPU.Items.AddRange(New Object() {"Disabled", "100", "95", "90", "85", "80", "75", "70", "65", "60", "55", "50", "45", "40", "35", "30", "25", "20", "15", "10", "5"})
        Me.MaxCPU.Location = New System.Drawing.Point(505, 55)
        Me.MaxCPU.Name = "MaxCPU"
        Me.MaxCPU.Size = New System.Drawing.Size(64, 21)
        Me.MaxCPU.TabIndex = 5
        Me.Information.SetToolTip(Me.MaxCPU, "Limit BASSMIDI's CPU usage.")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(404, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Max voices (1-1000):"
        Me.Information.SetToolTip(Me.Label3, "Limit the polyphony for the driver.")
        '
        'PolyphonyLimit
        '
        Me.PolyphonyLimit.Location = New System.Drawing.Point(510, 11)
        Me.PolyphonyLimit.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.PolyphonyLimit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.PolyphonyLimit.Name = "PolyphonyLimit"
        Me.PolyphonyLimit.Size = New System.Drawing.Size(59, 20)
        Me.PolyphonyLimit.TabIndex = 3
        Me.Information.SetToolTip(Me.PolyphonyLimit, "Limit the polyphony for the driver.")
        Me.PolyphonyLimit.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'DisableFX
        '
        Me.DisableFX.AutoSize = True
        Me.DisableFX.Location = New System.Drawing.Point(6, 51)
        Me.DisableFX.Name = "DisableFX"
        Me.DisableFX.Size = New System.Drawing.Size(231, 17)
        Me.DisableFX.TabIndex = 2
        Me.DisableFX.Text = "Disable sound effects (Reverb, chorus etc.)"
        Me.Information.SetToolTip(Me.DisableFX, "Disable the sound effects, such as reverb and chorus. (Can reduce the CPU usage)")
        Me.DisableFX.UseVisualStyleBackColor = True
        '
        'Preload
        '
        Me.Preload.AutoSize = True
        Me.Preload.Enabled = False
        Me.Preload.Location = New System.Drawing.Point(6, 17)
        Me.Preload.Name = "Preload"
        Me.Preload.Size = New System.Drawing.Size(147, 17)
        Me.Preload.TabIndex = 1
        Me.Preload.Text = "Enable soundfont preload"
        Me.Information.SetToolTip(Me.Preload, "Enable/Disable soundfont preload. (Currently not working properly)")
        Me.Preload.UseVisualStyleBackColor = True
        '
        'NoteOff
        '
        Me.NoteOff.AutoSize = True
        Me.NoteOff.Location = New System.Drawing.Point(6, 68)
        Me.NoteOff.Name = "NoteOff"
        Me.NoteOff.Size = New System.Drawing.Size(329, 17)
        Me.NoteOff.TabIndex = 0
        Me.NoteOff.Text = "Release only the oldest instance of a note upon a note off event"
        Me.Information.SetToolTip(Me.NoteOff, "Release only the oldest instance. (Can actually increase the CPU usage. Use it wh" & _
        "en a MIDI doesn't play properly)")
        Me.NoteOff.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.FancyClock)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(591, 356)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Secret tab of doom"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'FancyClock
        '
        Me.FancyClock.Font = New System.Drawing.Font("KEPPYDIGITAL", 72.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FancyClock.Location = New System.Drawing.Point(0, 1)
        Me.FancyClock.Name = "FancyClock"
        Me.FancyClock.Size = New System.Drawing.Size(591, 355)
        Me.FancyClock.TabIndex = 8
        Me.FancyClock.Text = "DAH SECRET!"
        Me.FancyClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FancyClock.UseCompatibleTextRendering = True
        '
        'PortAOpenDialog1
        '
        Me.PortAOpenDialog1.FileName = "OpenFileDialog1"
        '
        'PortBOpenDialog1
        '
        Me.PortBOpenDialog1.FileName = "OpenFileDialog2"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(560, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(38, 21)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Info"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BlackListFileDialog
        '
        Me.BlackListFileDialog.FileName = "Add an executable..."
        Me.BlackListFileDialog.Multiselect = True
        '
        'FancyClockTimer
        '
        Me.FancyClockTimer.Interval = 1000
        '
        'SystemTrayicon
        '
        Me.SystemTrayicon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.SystemTrayicon.BalloonTipText = "Keppy's MIDI Driver (Configurator)"
        Me.SystemTrayicon.BalloonTipTitle = "Double click the icon, to show the configurator again"
        Me.SystemTrayicon.ContextMenuStrip = Me.ContextMenuStrip1
        Me.SystemTrayicon.Icon = CType(resources.GetObject("SystemTrayicon.Icon"), System.Drawing.Icon)
        Me.SystemTrayicon.Text = "Keppy's MIDI Driver (Configurator)"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowMainWindow, Me.AboutDriverWindow, Me.ToolStripSeparator1, Me.CloseApp})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(179, 76)
        '
        'ShowMainWindow
        '
        Me.ShowMainWindow.Name = "ShowMainWindow"
        Me.ShowMainWindow.Size = New System.Drawing.Size(178, 22)
        Me.ShowMainWindow.Text = "Show main window"
        '
        'AboutDriverWindow
        '
        Me.AboutDriverWindow.Name = "AboutDriverWindow"
        Me.AboutDriverWindow.Size = New System.Drawing.Size(178, 22)
        Me.AboutDriverWindow.Text = "About the driver..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(175, 6)
        '
        'CloseApp
        '
        Me.CloseApp.Name = "CloseApp"
        Me.CloseApp.Size = New System.Drawing.Size(178, 22)
        Me.CloseApp.Text = "Exit"
        '
        'AutomaticStartup
        '
        Me.AutomaticStartup.AutoSize = True
        Me.AutomaticStartup.Location = New System.Drawing.Point(459, 12)
        Me.AutomaticStartup.Name = "AutomaticStartup"
        Me.AutomaticStartup.Size = New System.Drawing.Size(117, 17)
        Me.AutomaticStartup.TabIndex = 7
        Me.AutomaticStartup.Text = "Start with Windows"
        Me.Information.SetToolTip(Me.AutomaticStartup, "The configurator will automatically start (minimized) along with Windows.")
        Me.AutomaticStartup.UseVisualStyleBackColor = True
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 382)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Tabs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Keppy's MIDI Driver (Configurator)"
        Me.Tabs.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.VolumeBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.TracksLimit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bufsize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PolyphonyLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PortABox As System.Windows.Forms.ListBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ApplyPortA As System.Windows.Forms.Button
    Friend WithEvents ClearPortA As System.Windows.Forms.Button
    Friend WithEvents MoveDownPortA As System.Windows.Forms.Button
    Friend WithEvents MoveUpPortA As System.Windows.Forms.Button
    Friend WithEvents RemoveSFPortA As System.Windows.Forms.Button
    Friend WithEvents ImportSFPortA As System.Windows.Forms.Button
    Friend WithEvents ApplyPortB As System.Windows.Forms.Button
    Friend WithEvents ClearPortB As System.Windows.Forms.Button
    Friend WithEvents MoveDownPortB As System.Windows.Forms.Button
    Friend WithEvents MoveUpPortB As System.Windows.Forms.Button
    Friend WithEvents RemoveSFPortB As System.Windows.Forms.Button
    Friend WithEvents ImportSFPortB As System.Windows.Forms.Button
    Friend WithEvents PortBBox As System.Windows.Forms.ListBox
    Friend WithEvents PortAOpenDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PortBOpenDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DisableFX As System.Windows.Forms.CheckBox
    Friend WithEvents Preload As System.Windows.Forms.CheckBox
    Friend WithEvents NoteOff As System.Windows.Forms.CheckBox
    Friend WithEvents AdvancedApply As System.Windows.Forms.Button
    Friend WithEvents AdvancedReset As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Frequency As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MaxCPU As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PolyphonyLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ThisVersionDriver As System.Windows.Forms.Label
    Friend WithEvents LatestVersionDriver As System.Windows.Forms.Label
    Friend WithEvents UpdateDownload As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents sampframe As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bufsize As System.Windows.Forms.NumericUpDown
    Friend WithEvents SincInter As System.Windows.Forms.CheckBox
    Friend WithEvents Versionlabel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TracksLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents Information As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DSPipe As System.Windows.Forms.RadioButton
    Friend WithEvents XAudioPipe As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CurrentVolumeHUE As System.Windows.Forms.Label
    Friend WithEvents VolumeBar As System.Windows.Forms.TrackBar
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents SoftwareRendering As System.Windows.Forms.CheckBox
    Friend WithEvents FloatingDisabled As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ProgramsBlackList As System.Windows.Forms.ListBox
    Friend WithEvents RemoveBlackList As System.Windows.Forms.Button
    Friend WithEvents AddBlackList As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BlackListFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RestoreDefaultBlackList As System.Windows.Forms.Button
    Friend WithEvents BlackListAdvancedMode As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ManualBlackListLabel As System.Windows.Forms.Label
    Friend WithEvents ManualBlackList As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DisableCheckPortA As System.Windows.Forms.CheckBox
    Friend WithEvents DisableCheckPortB As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FancyClockTimer As System.Windows.Forms.Timer
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents FancyClock As System.Windows.Forms.Label
    Friend WithEvents SystemTrayicon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowMainWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutDriverWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseApp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutomaticStartup As System.Windows.Forms.CheckBox

End Class
