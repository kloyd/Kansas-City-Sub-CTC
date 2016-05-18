<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainPanel))
        Me.menuMain = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemParametersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunWithCMRISimulatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunWithCMRIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopRunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResumeRunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepairSignalsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SignalTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.LampTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.timerMainLoop = New System.Windows.Forms.Timer(Me.components)
        Me.CommPort = New System.IO.Ports.SerialPort(Me.components)
        Me.txtLogMsg = New System.Windows.Forms.TextBox()
        Me.lineBlock8A = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock7A = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock8R = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock7E = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock7R = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock8B = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock2A = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock4A = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock4R = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock3R = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock1A = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock3A = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock3B = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock7D = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock6A = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock9A = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock9B = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock9F = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock9E = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock9D = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock9C = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock7C = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock8C = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock5A = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.YardInterchange = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock4D = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock8D = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock8E = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.IndependenceB = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.IndependenceA = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock7F = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock7H = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock7G = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock5B = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock6B = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.RockCreekA = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.RockCreekB = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock7B = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock4B = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock4C = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.picTurnout3 = New System.Windows.Forms.PictureBox()
        Me.images = New System.Windows.Forms.ImageList(Me.components)
        Me.picTurnout23Down = New System.Windows.Forms.PictureBox()
        Me.picTurnout23Up = New System.Windows.Forms.PictureBox()
        Me.picTurnout7 = New System.Windows.Forms.PictureBox()
        Me.picTurnout9Down = New System.Windows.Forms.PictureBox()
        Me.picTurnout9Up = New System.Windows.Forms.PictureBox()
        Me.picTurnout11 = New System.Windows.Forms.PictureBox()
        Me.picTurnout15 = New System.Windows.Forms.PictureBox()
        Me.picLock25Up = New System.Windows.Forms.PictureBox()
        Me.picLock25Down = New System.Windows.Forms.PictureBox()
        Me.picLock17 = New System.Windows.Forms.PictureBox()
        Me.picLock19 = New System.Windows.Forms.PictureBox()
        Me.lblSouthwestJct = New System.Windows.Forms.Label()
        Me.lblRockCreek = New System.Windows.Forms.Label()
        Me.lblSheffield = New System.Windows.Forms.Label()
        Me.lblFreightLineJct = New System.Windows.Forms.Label()
        Me.picTraffic5BEast = New System.Windows.Forms.PictureBox()
        Me.picTraffic5BWest = New System.Windows.Forms.PictureBox()
        Me.picTraffic6BWest = New System.Windows.Forms.PictureBox()
        Me.picTraffic6BEast = New System.Windows.Forms.PictureBox()
        Me.picTraffic1West = New System.Windows.Forms.PictureBox()
        Me.picTraffic1East = New System.Windows.Forms.PictureBox()
        Me.picTraffic2West = New System.Windows.Forms.PictureBox()
        Me.picTraffic2East = New System.Windows.Forms.PictureBox()
        Me.picTraffic5AWest = New System.Windows.Forms.PictureBox()
        Me.picTraffic5AEast = New System.Windows.Forms.PictureBox()
        Me.picTraffic6AWest = New System.Windows.Forms.PictureBox()
        Me.picTraffic6AEast = New System.Windows.Forms.PictureBox()
        Me.picSig26LA = New System.Windows.Forms.PictureBox()
        Me.picSig24L = New System.Windows.Forms.PictureBox()
        Me.picSig8LA = New System.Windows.Forms.PictureBox()
        Me.picSig10L = New System.Windows.Forms.PictureBox()
        Me.picSig4L = New System.Windows.Forms.PictureBox()
        Me.picSig8LB = New System.Windows.Forms.PictureBox()
        Me.picSig26R = New System.Windows.Forms.PictureBox()
        Me.picSig24R = New System.Windows.Forms.PictureBox()
        Me.picSig10R = New System.Windows.Forms.PictureBox()
        Me.picSig12R = New System.Windows.Forms.PictureBox()
        Me.picSig8RA = New System.Windows.Forms.PictureBox()
        Me.picSig4RB = New System.Windows.Forms.PictureBox()
        Me.picSig4RA = New System.Windows.Forms.PictureBox()
        Me.picSig8RB = New System.Windows.Forms.PictureBox()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.lineCoburgYardLead = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineCentropolis = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineOttumwa = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineCoburgEast = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBroadway = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineCoburgWest = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineBlock10 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineIndicate = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineControl = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lblControl = New System.Windows.Forms.Label()
        Me.lblIndication = New System.Windows.Forms.Label()
        Me.txtTrainMovements = New System.Windows.Forms.TextBox()
        Me.lblSignalMaintLog = New System.Windows.Forms.Label()
        Me.lblTrainMovementLog = New System.Windows.Forms.Label()
        Me.lblClock = New System.Windows.Forms.Label()
        Me.lblBlock11 = New System.Windows.Forms.Label()
        Me.lblBlock15 = New System.Windows.Forms.Label()
        Me.lblBlock10 = New System.Windows.Forms.Label()
        Me.lblBlock5A = New System.Windows.Forms.Label()
        Me.lblBlock5 = New System.Windows.Forms.Label()
        Me.lblBlock12 = New System.Windows.Forms.Label()
        Me.lblBlock7 = New System.Windows.Forms.Label()
        Me.lblBlock14 = New System.Windows.Forms.Label()
        Me.lblBlock13 = New System.Windows.Forms.Label()
        Me.lblCoburgYard = New System.Windows.Forms.Label()
        Me.lblBlock8 = New System.Windows.Forms.Label()
        Me.lblBlock6A = New System.Windows.Forms.Label()
        Me.lblBlock6 = New System.Windows.Forms.Label()
        Me.lblBlock1 = New System.Windows.Forms.Label()
        Me.lblBlock2 = New System.Windows.Forms.Label()
        Me.lblBlock3 = New System.Windows.Forms.Label()
        Me.lblBlock4 = New System.Windows.Forms.Label()
        Me.lblBlock9 = New System.Windows.Forms.Label()
        Me.picSig26LB = New System.Windows.Forms.PictureBox()
        Me.picTraffic8West = New System.Windows.Forms.PictureBox()
        Me.picTraffic7EastA = New System.Windows.Forms.PictureBox()
        Me.picTraffic7EastB = New System.Windows.Forms.PictureBox()
        Me.picTraffic3East = New System.Windows.Forms.PictureBox()
        Me.picTraffic8East = New System.Windows.Forms.PictureBox()
        Me.picTraffic4East = New System.Windows.Forms.PictureBox()
        Me.picTraffic9EastA = New System.Windows.Forms.PictureBox()
        Me.picTraffic9EastB = New System.Windows.Forms.PictureBox()
        Me.picTraffic7WestA = New System.Windows.Forms.PictureBox()
        Me.picTraffic4West = New System.Windows.Forms.PictureBox()
        Me.picTraffic3West = New System.Windows.Forms.PictureBox()
        Me.picTraffic7WestB = New System.Windows.Forms.PictureBox()
        Me.picTraffic9West = New System.Windows.Forms.PictureBox()
        Me.menuMain.SuspendLayout()
        CType(Me.picTurnout3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTurnout23Down, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTurnout23Up, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTurnout7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTurnout9Down, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTurnout9Up, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTurnout11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTurnout15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLock25Up, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLock25Down, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLock17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLock19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic5BEast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic5BWest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic6BWest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic6BEast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic1West, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic1East, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic2West, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic2East, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic5AWest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic5AEast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic6AWest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic6AEast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig26LA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig24L, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig8LA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig10L, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig4L, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig8LB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig26R, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig24R, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig10R, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig12R, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig8RA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig4RB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig4RA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig8RB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSig26LB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic8West, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic7EastA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic7EastB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic3East, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic8East, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic4East, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic9EastA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic9EastB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic7WestA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic4West, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic3West, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic7WestB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTraffic9West, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuMain
        '
        Me.menuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripMenuItem2, Me.HelpToolStripMenuItem})
        Me.menuMain.Location = New System.Drawing.Point(0, 0)
        Me.menuMain.Name = "menuMain"
        Me.menuMain.Size = New System.Drawing.Size(1008, 24)
        Me.menuMain.TabIndex = 0
        Me.menuMain.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystemParametersToolStripMenuItem, Me.RunWithCMRISimulatorToolStripMenuItem, Me.RunWithCMRIToolStripMenuItem, Me.StopRunToolStripMenuItem, Me.ResumeRunToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SystemParametersToolStripMenuItem
        '
        Me.SystemParametersToolStripMenuItem.Name = "SystemParametersToolStripMenuItem"
        Me.SystemParametersToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.SystemParametersToolStripMenuItem.Text = "System P&arameters..."
        '
        'RunWithCMRISimulatorToolStripMenuItem
        '
        Me.RunWithCMRISimulatorToolStripMenuItem.Name = "RunWithCMRISimulatorToolStripMenuItem"
        Me.RunWithCMRISimulatorToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.RunWithCMRISimulatorToolStripMenuItem.Text = "Run with CMRI Simulator..."
        '
        'RunWithCMRIToolStripMenuItem
        '
        Me.RunWithCMRIToolStripMenuItem.Name = "RunWithCMRIToolStripMenuItem"
        Me.RunWithCMRIToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.RunWithCMRIToolStripMenuItem.Text = "Run with CMRI..."
        '
        'StopRunToolStripMenuItem
        '
        Me.StopRunToolStripMenuItem.Enabled = False
        Me.StopRunToolStripMenuItem.Name = "StopRunToolStripMenuItem"
        Me.StopRunToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.StopRunToolStripMenuItem.Text = "Pause"
        '
        'ResumeRunToolStripMenuItem
        '
        Me.ResumeRunToolStripMenuItem.Name = "ResumeRunToolStripMenuItem"
        Me.ResumeRunToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ResumeRunToolStripMenuItem.Text = "Resume"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(213, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RepairSignalsToolStripMenuItem, Me.ToolStripMenuItem3, Me.SignalTestToolStripMenuItem, Me.ToolStripMenuItem4, Me.LampTestToolStripMenuItem})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(88, 20)
        Me.ToolStripMenuItem2.Text = "Maintenance"
        '
        'RepairSignalsToolStripMenuItem
        '
        Me.RepairSignalsToolStripMenuItem.Name = "RepairSignalsToolStripMenuItem"
        Me.RepairSignalsToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.RepairSignalsToolStripMenuItem.Text = "Repair Signals"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(144, 6)
        '
        'SignalTestToolStripMenuItem
        '
        Me.SignalTestToolStripMenuItem.Name = "SignalTestToolStripMenuItem"
        Me.SignalTestToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.SignalTestToolStripMenuItem.Text = "Signal Test"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(144, 6)
        '
        'LampTestToolStripMenuItem
        '
        Me.LampTestToolStripMenuItem.Name = "LampTestToolStripMenuItem"
        Me.LampTestToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.LampTestToolStripMenuItem.Text = "Lamp Test"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'timerMainLoop
        '
        '
        'txtLogMsg
        '
        Me.txtLogMsg.Location = New System.Drawing.Point(504, 468)
        Me.txtLogMsg.Multiline = True
        Me.txtLogMsg.Name = "txtLogMsg"
        Me.txtLogMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLogMsg.Size = New System.Drawing.Size(504, 193)
        Me.txtLogMsg.TabIndex = 1
        '
        'lineBlock8A
        '
        Me.lineBlock8A.BorderColor = System.Drawing.Color.White
        Me.lineBlock8A.BorderWidth = 7
        Me.lineBlock8A.Name = "lineBlock8A"
        Me.lineBlock8A.X1 = 225
        Me.lineBlock8A.X2 = 364
        Me.lineBlock8A.Y1 = 240
        Me.lineBlock8A.Y2 = 240
        '
        'lineBlock7A
        '
        Me.lineBlock7A.BorderColor = System.Drawing.Color.White
        Me.lineBlock7A.BorderWidth = 7
        Me.lineBlock7A.Name = "lineBlock7A"
        Me.lineBlock7A.X1 = 225
        Me.lineBlock7A.X2 = 370
        Me.lineBlock7A.Y1 = 180
        Me.lineBlock7A.Y2 = 180
        '
        'lineBlock8R
        '
        Me.lineBlock8R.BorderColor = System.Drawing.Color.White
        Me.lineBlock8R.BorderWidth = 7
        Me.lineBlock8R.Name = "lineBlock8R"
        Me.lineBlock8R.X1 = 376
        Me.lineBlock8R.X2 = 396
        Me.lineBlock8R.Y1 = 231
        Me.lineBlock8R.Y2 = 211
        '
        'lineBlock7E
        '
        Me.lineBlock7E.BorderColor = System.Drawing.Color.White
        Me.lineBlock7E.BorderWidth = 7
        Me.lineBlock7E.Name = "lineBlock7E"
        Me.lineBlock7E.X1 = 342
        Me.lineBlock7E.X2 = 380
        Me.lineBlock7E.Y1 = 129
        Me.lineBlock7E.Y2 = 167
        '
        'lineBlock7R
        '
        Me.lineBlock7R.BorderColor = System.Drawing.Color.White
        Me.lineBlock7R.BorderWidth = 7
        Me.lineBlock7R.Name = "lineBlock7R"
        Me.lineBlock7R.X1 = 399
        Me.lineBlock7R.X2 = 419
        Me.lineBlock7R.Y1 = 208
        Me.lineBlock7R.Y2 = 188
        '
        'lineBlock8B
        '
        Me.lineBlock8B.BorderColor = System.Drawing.Color.White
        Me.lineBlock8B.BorderWidth = 7
        Me.lineBlock8B.Name = "lineBlock8B"
        Me.lineBlock8B.X1 = 382
        Me.lineBlock8B.X2 = 547
        Me.lineBlock8B.Y1 = 240
        Me.lineBlock8B.Y2 = 240
        '
        'lineBlock2A
        '
        Me.lineBlock2A.BorderColor = System.Drawing.Color.White
        Me.lineBlock2A.BorderWidth = 7
        Me.lineBlock2A.Name = "lineBlock2A"
        Me.lineBlock2A.X1 = 615
        Me.lineBlock2A.X2 = 730
        Me.lineBlock2A.Y1 = 240
        Me.lineBlock2A.Y2 = 240
        '
        'lineBlock4A
        '
        Me.lineBlock4A.BorderColor = System.Drawing.Color.White
        Me.lineBlock4A.BorderWidth = 7
        Me.lineBlock4A.Name = "lineBlock4A"
        Me.lineBlock4A.X1 = 735
        Me.lineBlock4A.X2 = 779
        Me.lineBlock4A.Y1 = 240
        Me.lineBlock4A.Y2 = 240
        '
        'lineBlock4R
        '
        Me.lineBlock4R.BorderColor = System.Drawing.Color.White
        Me.lineBlock4R.BorderWidth = 7
        Me.lineBlock4R.Name = "lineBlock4R"
        Me.lineBlock4R.X1 = 817
        Me.lineBlock4R.X2 = 837
        Me.lineBlock4R.Y1 = 212
        Me.lineBlock4R.Y2 = 232
        '
        'lineBlock3R
        '
        Me.lineBlock3R.BorderColor = System.Drawing.Color.White
        Me.lineBlock3R.BorderWidth = 7
        Me.lineBlock3R.Name = "lineBlock3R"
        Me.lineBlock3R.X1 = 795
        Me.lineBlock3R.X2 = 815
        Me.lineBlock3R.Y1 = 189
        Me.lineBlock3R.Y2 = 209
        '
        'lineBlock1A
        '
        Me.lineBlock1A.BorderColor = System.Drawing.Color.White
        Me.lineBlock1A.BorderWidth = 7
        Me.lineBlock1A.Name = "lineBlock1A"
        Me.lineBlock1A.X1 = 615
        Me.lineBlock1A.X2 = 730
        Me.lineBlock1A.Y1 = 180
        Me.lineBlock1A.Y2 = 180
        '
        'lineBlock3A
        '
        Me.lineBlock3A.BorderColor = System.Drawing.Color.White
        Me.lineBlock3A.BorderWidth = 7
        Me.lineBlock3A.Name = "lineBlock3A"
        Me.lineBlock3A.X1 = 735
        Me.lineBlock3A.X2 = 776
        Me.lineBlock3A.Y1 = 180
        Me.lineBlock3A.Y2 = 180
        '
        'lineBlock3B
        '
        Me.lineBlock3B.BorderColor = System.Drawing.Color.White
        Me.lineBlock3B.BorderWidth = 7
        Me.lineBlock3B.Name = "lineBlock3B"
        Me.lineBlock3B.X1 = 803
        Me.lineBlock3B.X2 = 895
        Me.lineBlock3B.Y1 = 180
        Me.lineBlock3B.Y2 = 180
        '
        'lineBlock7D
        '
        Me.lineBlock7D.BorderColor = System.Drawing.Color.White
        Me.lineBlock7D.BorderWidth = 7
        Me.lineBlock7D.Name = "lineBlock7D"
        Me.lineBlock7D.X1 = 304
        Me.lineBlock7D.X2 = 344
        Me.lineBlock7D.Y1 = 130
        Me.lineBlock7D.Y2 = 130
        '
        'lineBlock6A
        '
        Me.lineBlock6A.BorderColor = System.Drawing.Color.White
        Me.lineBlock6A.BorderWidth = 7
        Me.lineBlock6A.Name = "lineBlock6A"
        Me.lineBlock6A.X1 = 120
        Me.lineBlock6A.X2 = 220
        Me.lineBlock6A.Y1 = 240
        Me.lineBlock6A.Y2 = 240
        '
        'lineBlock9A
        '
        Me.lineBlock9A.BorderColor = System.Drawing.Color.White
        Me.lineBlock9A.BorderWidth = 7
        Me.lineBlock9A.Name = "lineBlock9A"
        Me.lineBlock9A.X1 = 74
        Me.lineBlock9A.X2 = 154
        Me.lineBlock9A.Y1 = 80
        Me.lineBlock9A.Y2 = 80
        '
        'lineBlock9B
        '
        Me.lineBlock9B.BorderColor = System.Drawing.Color.White
        Me.lineBlock9B.BorderWidth = 7
        Me.lineBlock9B.Name = "lineBlock9B"
        Me.lineBlock9B.X1 = 76
        Me.lineBlock9B.X2 = 127
        Me.lineBlock9B.Y1 = 130
        Me.lineBlock9B.Y2 = 130
        '
        'lineBlock9F
        '
        Me.lineBlock9F.BorderColor = System.Drawing.Color.White
        Me.lineBlock9F.BorderWidth = 7
        Me.lineBlock9F.Name = "lineBlock9F"
        Me.lineBlock9F.SelectionColor = System.Drawing.Color.White
        Me.lineBlock9F.X1 = 259
        Me.lineBlock9F.X2 = 299
        Me.lineBlock9F.Y1 = 130
        Me.lineBlock9F.Y2 = 130
        '
        'lineBlock9E
        '
        Me.lineBlock9E.BorderColor = System.Drawing.Color.White
        Me.lineBlock9E.BorderWidth = 7
        Me.lineBlock9E.Name = "lineBlock9E"
        Me.lineBlock9E.X1 = 210
        Me.lineBlock9E.X2 = 261
        Me.lineBlock9E.Y1 = 79
        Me.lineBlock9E.Y2 = 130
        '
        'lineBlock9D
        '
        Me.lineBlock9D.BorderColor = System.Drawing.Color.White
        Me.lineBlock9D.BorderWidth = 7
        Me.lineBlock9D.Name = "lineBlock9D"
        Me.lineBlock9D.X1 = 187
        Me.lineBlock9D.X2 = 212
        Me.lineBlock9D.Y1 = 80
        Me.lineBlock9D.Y2 = 80
        '
        'lineBlock9C
        '
        Me.lineBlock9C.BorderColor = System.Drawing.Color.White
        Me.lineBlock9C.BorderWidth = 7
        Me.lineBlock9C.Name = "lineBlock9C"
        Me.lineBlock9C.X1 = 125
        Me.lineBlock9C.X2 = 166
        Me.lineBlock9C.Y1 = 131
        Me.lineBlock9C.Y2 = 90
        '
        'lineBlock7C
        '
        Me.lineBlock7C.BorderColor = System.Drawing.Color.White
        Me.lineBlock7C.BorderWidth = 7
        Me.lineBlock7C.Name = "lineBlock7C"
        Me.lineBlock7C.X1 = 506
        Me.lineBlock7C.X2 = 610
        Me.lineBlock7C.Y1 = 180
        Me.lineBlock7C.Y2 = 180
        '
        'lineBlock8C
        '
        Me.lineBlock8C.BorderColor = System.Drawing.Color.White
        Me.lineBlock8C.BorderWidth = 7
        Me.lineBlock8C.Name = "lineBlock8C"
        Me.lineBlock8C.X1 = 567
        Me.lineBlock8C.X2 = 610
        Me.lineBlock8C.Y1 = 240
        Me.lineBlock8C.Y2 = 240
        '
        'lineBlock5A
        '
        Me.lineBlock5A.BorderColor = System.Drawing.Color.White
        Me.lineBlock5A.BorderWidth = 7
        Me.lineBlock5A.Name = "lineBlock5A"
        Me.lineBlock5A.X1 = 120
        Me.lineBlock5A.X2 = 220
        Me.lineBlock5A.Y1 = 180
        Me.lineBlock5A.Y2 = 180
        '
        'YardInterchange
        '
        Me.YardInterchange.BorderColor = System.Drawing.Color.White
        Me.YardInterchange.BorderWidth = 7
        Me.YardInterchange.Name = "YardInterchange"
        Me.YardInterchange.X1 = 820
        Me.YardInterchange.X2 = 838
        Me.YardInterchange.Y1 = 273
        Me.YardInterchange.Y2 = 291
        '
        'lineBlock4D
        '
        Me.lineBlock4D.BorderColor = System.Drawing.Color.White
        Me.lineBlock4D.BorderWidth = 7
        Me.lineBlock4D.Name = "lineBlock4D"
        Me.lineBlock4D.X1 = 796
        Me.lineBlock4D.X2 = 816
        Me.lineBlock4D.Y1 = 250
        Me.lineBlock4D.Y2 = 270
        '
        'lineBlock8D
        '
        Me.lineBlock8D.BorderColor = System.Drawing.Color.White
        Me.lineBlock8D.BorderWidth = 7
        Me.lineBlock8D.Name = "lineBlock8D"
        Me.lineBlock8D.X1 = 364
        Me.lineBlock8D.X2 = 405
        Me.lineBlock8D.Y1 = 291
        Me.lineBlock8D.Y2 = 250
        '
        'lineBlock8E
        '
        Me.lineBlock8E.BorderColor = System.Drawing.Color.White
        Me.lineBlock8E.BorderWidth = 7
        Me.lineBlock8E.Name = "lineBlock8E"
        Me.lineBlock8E.X1 = 316
        Me.lineBlock8E.X2 = 367
        Me.lineBlock8E.Y1 = 290
        Me.lineBlock8E.Y2 = 290
        '
        'IndependenceB
        '
        Me.IndependenceB.BorderColor = System.Drawing.Color.White
        Me.IndependenceB.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.IndependenceB.BorderWidth = 7
        Me.IndependenceB.Name = "IndependenceB"
        Me.IndependenceB.X1 = 460
        Me.IndependenceB.X2 = 511
        Me.IndependenceB.Y1 = 292
        Me.IndependenceB.Y2 = 292
        '
        'IndependenceA
        '
        Me.IndependenceA.BorderColor = System.Drawing.Color.White
        Me.IndependenceA.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.IndependenceA.BorderWidth = 7
        Me.IndependenceA.Name = "IndependenceA"
        Me.IndependenceA.X1 = 507
        Me.IndependenceA.X2 = 548
        Me.IndependenceA.Y1 = 293
        Me.IndependenceA.Y2 = 252
        '
        'lineBlock7F
        '
        Me.lineBlock7F.BorderColor = System.Drawing.Color.White
        Me.lineBlock7F.BorderWidth = 7
        Me.lineBlock7F.Name = "lineBlock7F"
        Me.lineBlock7F.X1 = 527
        Me.lineBlock7F.X2 = 568
        Me.lineBlock7F.Y1 = 171
        Me.lineBlock7F.Y2 = 130
        '
        'lineBlock7H
        '
        Me.lineBlock7H.BorderColor = System.Drawing.Color.White
        Me.lineBlock7H.BorderWidth = 7
        Me.lineBlock7H.Name = "lineBlock7H"
        Me.lineBlock7H.X1 = 566
        Me.lineBlock7H.X2 = 606
        Me.lineBlock7H.Y1 = 131
        Me.lineBlock7H.Y2 = 131
        '
        'lineBlock7G
        '
        Me.lineBlock7G.BorderColor = System.Drawing.Color.White
        Me.lineBlock7G.BorderWidth = 7
        Me.lineBlock7G.Name = "lineBlock7G"
        Me.lineBlock7G.X1 = 619
        Me.lineBlock7G.X2 = 722
        Me.lineBlock7G.Y1 = 131
        Me.lineBlock7G.Y2 = 131
        '
        'lineBlock5B
        '
        Me.lineBlock5B.BorderColor = System.Drawing.Color.White
        Me.lineBlock5B.BorderWidth = 7
        Me.lineBlock5B.Name = "lineBlock5B"
        Me.lineBlock5B.X1 = 900
        Me.lineBlock5B.X2 = 1000
        Me.lineBlock5B.Y1 = 180
        Me.lineBlock5B.Y2 = 180
        '
        'lineBlock6B
        '
        Me.lineBlock6B.BorderColor = System.Drawing.Color.White
        Me.lineBlock6B.BorderWidth = 7
        Me.lineBlock6B.Name = "lineBlock6B"
        Me.lineBlock6B.X1 = 900
        Me.lineBlock6B.X2 = 1000
        Me.lineBlock6B.Y1 = 240
        Me.lineBlock6B.Y2 = 240
        '
        'RockCreekA
        '
        Me.RockCreekA.BorderColor = System.Drawing.Color.White
        Me.RockCreekA.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.RockCreekA.BorderWidth = 7
        Me.RockCreekA.Name = "RockCreekA"
        Me.RockCreekA.X1 = 621
        Me.RockCreekA.X2 = 662
        Me.RockCreekA.Y1 = 119
        Me.RockCreekA.Y2 = 78
        '
        'RockCreekB
        '
        Me.RockCreekB.BorderColor = System.Drawing.Color.White
        Me.RockCreekB.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.RockCreekB.BorderWidth = 7
        Me.RockCreekB.Name = "RockCreekB"
        Me.RockCreekB.X1 = 660
        Me.RockCreekB.X2 = 711
        Me.RockCreekB.Y1 = 78
        Me.RockCreekB.Y2 = 78
        '
        'lineBlock7B
        '
        Me.lineBlock7B.BorderColor = System.Drawing.Color.White
        Me.lineBlock7B.BorderWidth = 7
        Me.lineBlock7B.Name = "lineBlock7B"
        Me.lineBlock7B.X1 = 435
        Me.lineBlock7B.X2 = 508
        Me.lineBlock7B.Y1 = 180
        Me.lineBlock7B.Y2 = 180
        '
        'lineBlock4B
        '
        Me.lineBlock4B.BorderColor = System.Drawing.Color.White
        Me.lineBlock4B.BorderWidth = 7
        Me.lineBlock4B.Name = "lineBlock4B"
        Me.lineBlock4B.X1 = 798
        Me.lineBlock4B.X2 = 825
        Me.lineBlock4B.Y1 = 240
        Me.lineBlock4B.Y2 = 240
        '
        'lineBlock4C
        '
        Me.lineBlock4C.BorderColor = System.Drawing.Color.White
        Me.lineBlock4C.BorderWidth = 7
        Me.lineBlock4C.Name = "lineBlock4C"
        Me.lineBlock4C.X1 = 850
        Me.lineBlock4C.X2 = 895
        Me.lineBlock4C.Y1 = 240
        Me.lineBlock4C.Y2 = 240
        '
        'picTurnout3
        '
        Me.picTurnout3.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownNormal
        Me.picTurnout3.Location = New System.Drawing.Point(153, 77)
        Me.picTurnout3.Name = "picTurnout3"
        Me.picTurnout3.Size = New System.Drawing.Size(35, 20)
        Me.picTurnout3.TabIndex = 3
        Me.picTurnout3.TabStop = False
        '
        'images
        '
        Me.images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.images.ImageSize = New System.Drawing.Size(16, 16)
        Me.images.TransparentColor = System.Drawing.Color.Transparent
        '
        'picTurnout23Down
        '
        Me.picTurnout23Down.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightDownNormal
        Me.picTurnout23Down.Location = New System.Drawing.Point(775, 177)
        Me.picTurnout23Down.Name = "picTurnout23Down"
        Me.picTurnout23Down.Size = New System.Drawing.Size(35, 20)
        Me.picTurnout23Down.TabIndex = 4
        Me.picTurnout23Down.TabStop = False
        '
        'picTurnout23Up
        '
        Me.picTurnout23Up.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpNormal
        Me.picTurnout23Up.Location = New System.Drawing.Point(821, 224)
        Me.picTurnout23Up.Name = "picTurnout23Up"
        Me.picTurnout23Up.Size = New System.Drawing.Size(35, 23)
        Me.picTurnout23Up.TabIndex = 5
        Me.picTurnout23Up.TabStop = False
        '
        'picTurnout7
        '
        Me.picTurnout7.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpNormal
        Me.picTurnout7.Location = New System.Drawing.Point(369, 164)
        Me.picTurnout7.Name = "picTurnout7"
        Me.picTurnout7.Size = New System.Drawing.Size(35, 30)
        Me.picTurnout7.TabIndex = 6
        Me.picTurnout7.TabStop = False
        '
        'picTurnout9Down
        '
        Me.picTurnout9Down.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownNormal
        Me.picTurnout9Down.Location = New System.Drawing.Point(404, 177)
        Me.picTurnout9Down.Name = "picTurnout9Down"
        Me.picTurnout9Down.Size = New System.Drawing.Size(35, 20)
        Me.picTurnout9Down.TabIndex = 7
        Me.picTurnout9Down.TabStop = False
        '
        'picTurnout9Up
        '
        Me.picTurnout9Up.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftUpNormal
        Me.picTurnout9Up.Location = New System.Drawing.Point(357, 224)
        Me.picTurnout9Up.Name = "picTurnout9Up"
        Me.picTurnout9Up.Size = New System.Drawing.Size(35, 30)
        Me.picTurnout9Up.TabIndex = 8
        Me.picTurnout9Up.TabStop = False
        '
        'picTurnout11
        '
        Me.picTurnout11.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownNormal
        Me.picTurnout11.Location = New System.Drawing.Point(392, 237)
        Me.picTurnout11.Name = "picTurnout11"
        Me.picTurnout11.Size = New System.Drawing.Size(35, 20)
        Me.picTurnout11.TabIndex = 9
        Me.picTurnout11.TabStop = False
        '
        'picTurnout15
        '
        Me.picTurnout15.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftUpNormal
        Me.picTurnout15.Location = New System.Drawing.Point(508, 164)
        Me.picTurnout15.Name = "picTurnout15"
        Me.picTurnout15.Size = New System.Drawing.Size(35, 30)
        Me.picTurnout15.TabIndex = 10
        Me.picTurnout15.TabStop = False
        '
        'picLock25Up
        '
        Me.picLock25Up.Image = Global.KCSubCTCV3.My.Resources.Resources.LockRightUpLocked
        Me.picLock25Up.Location = New System.Drawing.Point(821, 282)
        Me.picLock25Up.Name = "picLock25Up"
        Me.picLock25Up.Size = New System.Drawing.Size(35, 23)
        Me.picLock25Up.TabIndex = 11
        Me.picLock25Up.TabStop = False
        '
        'picLock25Down
        '
        Me.picLock25Down.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightDownNormal
        Me.picLock25Down.Location = New System.Drawing.Point(775, 237)
        Me.picLock25Down.Name = "picLock25Down"
        Me.picLock25Down.Size = New System.Drawing.Size(35, 20)
        Me.picLock25Down.TabIndex = 12
        Me.picLock25Down.TabStop = False
        '
        'picLock17
        '
        Me.picLock17.Image = Global.KCSubCTCV3.My.Resources.Resources.LockLeftUpLocked
        Me.picLock17.Location = New System.Drawing.Point(597, 115)
        Me.picLock17.Name = "picLock17"
        Me.picLock17.Size = New System.Drawing.Size(35, 24)
        Me.picLock17.TabIndex = 13
        Me.picLock17.TabStop = False
        '
        'picLock19
        '
        Me.picLock19.Image = Global.KCSubCTCV3.My.Resources.Resources.LockLeftDownLocked
        Me.picLock19.Location = New System.Drawing.Point(537, 237)
        Me.picLock19.Name = "picLock19"
        Me.picLock19.Size = New System.Drawing.Size(35, 24)
        Me.picLock19.TabIndex = 14
        Me.picLock19.TabStop = False
        '
        'lblSouthwestJct
        '
        Me.lblSouthwestJct.AutoSize = True
        Me.lblSouthwestJct.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSouthwestJct.ForeColor = System.Drawing.Color.White
        Me.lblSouthwestJct.Location = New System.Drawing.Point(210, 41)
        Me.lblSouthwestJct.Name = "lblSouthwestJct"
        Me.lblSouthwestJct.Size = New System.Drawing.Size(138, 18)
        Me.lblSouthwestJct.TabIndex = 15
        Me.lblSouthwestJct.Text = "Southwest Jct"
        '
        'lblRockCreek
        '
        Me.lblRockCreek.AutoSize = True
        Me.lblRockCreek.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRockCreek.ForeColor = System.Drawing.Color.White
        Me.lblRockCreek.Location = New System.Drawing.Point(543, 39)
        Me.lblRockCreek.Name = "lblRockCreek"
        Me.lblRockCreek.Size = New System.Drawing.Size(148, 18)
        Me.lblRockCreek.TabIndex = 16
        Me.lblRockCreek.Text = "Rock Creek Jct"
        '
        'lblSheffield
        '
        Me.lblSheffield.AutoSize = True
        Me.lblSheffield.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSheffield.ForeColor = System.Drawing.Color.White
        Me.lblSheffield.Location = New System.Drawing.Point(197, 370)
        Me.lblSheffield.Name = "lblSheffield"
        Me.lblSheffield.Size = New System.Drawing.Size(138, 18)
        Me.lblSheffield.TabIndex = 17
        Me.lblSheffield.Text = "Sheffield Jct"
        '
        'lblFreightLineJct
        '
        Me.lblFreightLineJct.AutoSize = True
        Me.lblFreightLineJct.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFreightLineJct.ForeColor = System.Drawing.Color.White
        Me.lblFreightLineJct.Location = New System.Drawing.Point(739, 370)
        Me.lblFreightLineJct.Name = "lblFreightLineJct"
        Me.lblFreightLineJct.Size = New System.Drawing.Size(168, 18)
        Me.lblFreightLineJct.TabIndex = 18
        Me.lblFreightLineJct.Text = "Freight Line Jct"
        '
        'picTraffic5BEast
        '
        Me.picTraffic5BEast.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic5BEast.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic5BEast.Location = New System.Drawing.Point(896, 170)
        Me.picTraffic5BEast.Name = "picTraffic5BEast"
        Me.picTraffic5BEast.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic5BEast.TabIndex = 19
        Me.picTraffic5BEast.TabStop = False
        '
        'picTraffic5BWest
        '
        Me.picTraffic5BWest.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic5BWest.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneWest
        Me.picTraffic5BWest.Location = New System.Drawing.Point(990, 170)
        Me.picTraffic5BWest.Name = "picTraffic5BWest"
        Me.picTraffic5BWest.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic5BWest.TabIndex = 21
        Me.picTraffic5BWest.TabStop = False
        '
        'picTraffic6BWest
        '
        Me.picTraffic6BWest.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic6BWest.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneWest
        Me.picTraffic6BWest.Location = New System.Drawing.Point(991, 230)
        Me.picTraffic6BWest.Name = "picTraffic6BWest"
        Me.picTraffic6BWest.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic6BWest.TabIndex = 23
        Me.picTraffic6BWest.TabStop = False
        '
        'picTraffic6BEast
        '
        Me.picTraffic6BEast.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic6BEast.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic6BEast.Location = New System.Drawing.Point(896, 230)
        Me.picTraffic6BEast.Name = "picTraffic6BEast"
        Me.picTraffic6BEast.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic6BEast.TabIndex = 22
        Me.picTraffic6BEast.TabStop = False
        '
        'picTraffic1West
        '
        Me.picTraffic1West.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic1West.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneWest
        Me.picTraffic1West.Location = New System.Drawing.Point(723, 170)
        Me.picTraffic1West.Name = "picTraffic1West"
        Me.picTraffic1West.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic1West.TabIndex = 25
        Me.picTraffic1West.TabStop = False
        '
        'picTraffic1East
        '
        Me.picTraffic1East.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic1East.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic1East.Location = New System.Drawing.Point(611, 170)
        Me.picTraffic1East.Name = "picTraffic1East"
        Me.picTraffic1East.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic1East.TabIndex = 24
        Me.picTraffic1East.TabStop = False
        '
        'picTraffic2West
        '
        Me.picTraffic2West.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic2West.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneWest
        Me.picTraffic2West.Location = New System.Drawing.Point(722, 230)
        Me.picTraffic2West.Name = "picTraffic2West"
        Me.picTraffic2West.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic2West.TabIndex = 27
        Me.picTraffic2West.TabStop = False
        '
        'picTraffic2East
        '
        Me.picTraffic2East.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic2East.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic2East.Location = New System.Drawing.Point(611, 230)
        Me.picTraffic2East.Name = "picTraffic2East"
        Me.picTraffic2East.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic2East.TabIndex = 26
        Me.picTraffic2East.TabStop = False
        '
        'picTraffic5AWest
        '
        Me.picTraffic5AWest.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic5AWest.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneWest
        Me.picTraffic5AWest.Location = New System.Drawing.Point(213, 170)
        Me.picTraffic5AWest.Name = "picTraffic5AWest"
        Me.picTraffic5AWest.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic5AWest.TabIndex = 29
        Me.picTraffic5AWest.TabStop = False
        '
        'picTraffic5AEast
        '
        Me.picTraffic5AEast.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic5AEast.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic5AEast.Location = New System.Drawing.Point(118, 170)
        Me.picTraffic5AEast.Name = "picTraffic5AEast"
        Me.picTraffic5AEast.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic5AEast.TabIndex = 28
        Me.picTraffic5AEast.TabStop = False
        '
        'picTraffic6AWest
        '
        Me.picTraffic6AWest.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic6AWest.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneWest
        Me.picTraffic6AWest.Location = New System.Drawing.Point(213, 230)
        Me.picTraffic6AWest.Name = "picTraffic6AWest"
        Me.picTraffic6AWest.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic6AWest.TabIndex = 31
        Me.picTraffic6AWest.TabStop = False
        '
        'picTraffic6AEast
        '
        Me.picTraffic6AEast.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic6AEast.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic6AEast.Location = New System.Drawing.Point(118, 230)
        Me.picTraffic6AEast.Name = "picTraffic6AEast"
        Me.picTraffic6AEast.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic6AEast.TabIndex = 30
        Me.picTraffic6AEast.TabStop = False
        '
        'picSig26LA
        '
        Me.picSig26LA.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteLeft
        Me.picSig26LA.Location = New System.Drawing.Point(862, 215)
        Me.picSig26LA.Name = "picSig26LA"
        Me.picSig26LA.Size = New System.Drawing.Size(38, 20)
        Me.picSig26LA.TabIndex = 32
        Me.picSig26LA.TabStop = False
        '
        'picSig24L
        '
        Me.picSig24L.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteLeft
        Me.picSig24L.Location = New System.Drawing.Point(862, 155)
        Me.picSig24L.Name = "picSig24L"
        Me.picSig24L.Size = New System.Drawing.Size(38, 20)
        Me.picSig24L.TabIndex = 33
        Me.picSig24L.TabStop = False
        '
        'picSig8LA
        '
        Me.picSig8LA.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteLeft
        Me.picSig8LA.Location = New System.Drawing.Point(575, 153)
        Me.picSig8LA.Name = "picSig8LA"
        Me.picSig8LA.Size = New System.Drawing.Size(38, 20)
        Me.picSig8LA.TabIndex = 34
        Me.picSig8LA.TabStop = False
        '
        'picSig10L
        '
        Me.picSig10L.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteLeft
        Me.picSig10L.Location = New System.Drawing.Point(577, 213)
        Me.picSig10L.Name = "picSig10L"
        Me.picSig10L.Size = New System.Drawing.Size(38, 20)
        Me.picSig10L.TabIndex = 35
        Me.picSig10L.TabStop = False
        '
        'picSig4L
        '
        Me.picSig4L.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteLeft
        Me.picSig4L.Location = New System.Drawing.Point(267, 102)
        Me.picSig4L.Name = "picSig4L"
        Me.picSig4L.Size = New System.Drawing.Size(38, 20)
        Me.picSig4L.TabIndex = 36
        Me.picSig4L.TabStop = False
        '
        'picSig8LB
        '
        Me.picSig8LB.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteLeft
        Me.picSig8LB.Location = New System.Drawing.Point(693, 104)
        Me.picSig8LB.Name = "picSig8LB"
        Me.picSig8LB.Size = New System.Drawing.Size(38, 20)
        Me.picSig8LB.TabIndex = 37
        Me.picSig8LB.TabStop = False
        '
        'picSig26R
        '
        Me.picSig26R.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteRight
        Me.picSig26R.Location = New System.Drawing.Point(735, 251)
        Me.picSig26R.Name = "picSig26R"
        Me.picSig26R.Size = New System.Drawing.Size(38, 20)
        Me.picSig26R.TabIndex = 38
        Me.picSig26R.TabStop = False
        '
        'picSig24R
        '
        Me.picSig24R.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteRight
        Me.picSig24R.Location = New System.Drawing.Point(735, 153)
        Me.picSig24R.Name = "picSig24R"
        Me.picSig24R.Size = New System.Drawing.Size(38, 20)
        Me.picSig24R.TabIndex = 39
        Me.picSig24R.TabStop = False
        '
        'picSig10R
        '
        Me.picSig10R.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteRight
        Me.picSig10R.Location = New System.Drawing.Point(226, 251)
        Me.picSig10R.Name = "picSig10R"
        Me.picSig10R.Size = New System.Drawing.Size(38, 20)
        Me.picSig10R.TabIndex = 40
        Me.picSig10R.TabStop = False
        '
        'picSig12R
        '
        Me.picSig12R.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteRight
        Me.picSig12R.Location = New System.Drawing.Point(316, 298)
        Me.picSig12R.Name = "picSig12R"
        Me.picSig12R.Size = New System.Drawing.Size(38, 20)
        Me.picSig12R.TabIndex = 41
        Me.picSig12R.TabStop = False
        '
        'picSig8RA
        '
        Me.picSig8RA.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteRight
        Me.picSig8RA.Location = New System.Drawing.Point(226, 191)
        Me.picSig8RA.Name = "picSig8RA"
        Me.picSig8RA.Size = New System.Drawing.Size(38, 20)
        Me.picSig8RA.TabIndex = 42
        Me.picSig8RA.TabStop = False
        '
        'picSig4RB
        '
        Me.picSig4RB.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteRight
        Me.picSig4RB.Location = New System.Drawing.Point(77, 141)
        Me.picSig4RB.Name = "picSig4RB"
        Me.picSig4RB.Size = New System.Drawing.Size(38, 20)
        Me.picSig4RB.TabIndex = 43
        Me.picSig4RB.TabStop = False
        '
        'picSig4RA
        '
        Me.picSig4RA.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteRight
        Me.picSig4RA.Location = New System.Drawing.Point(77, 91)
        Me.picSig4RA.Name = "picSig4RA"
        Me.picSig4RA.Size = New System.Drawing.Size(38, 20)
        Me.picSig4RA.TabIndex = 44
        Me.picSig4RA.TabStop = False
        '
        'picSig8RB
        '
        Me.picSig8RB.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteRight
        Me.picSig8RB.Location = New System.Drawing.Point(304, 141)
        Me.picSig8RB.Name = "picSig8RB"
        Me.picSig8RB.Size = New System.Drawing.Size(38, 20)
        Me.picSig8RB.TabIndex = 45
        Me.picSig8RB.TabStop = False
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.lineCoburgYardLead, Me.lineCentropolis, Me.lineOttumwa, Me.lineCoburgEast, Me.lineBroadway, Me.lineCoburgWest, Me.lineBlock10, Me.lineIndicate, Me.lineControl, Me.lineBlock1A, Me.lineBlock2A, Me.lineBlock3A, Me.lineBlock3B, Me.lineBlock3R, Me.lineBlock4A, Me.lineBlock4B, Me.lineBlock4C, Me.lineBlock4D, Me.lineBlock4R, Me.lineBlock5A, Me.lineBlock5B, Me.lineBlock6A, Me.lineBlock6B, Me.lineBlock7A, Me.lineBlock7B, Me.lineBlock7C, Me.lineBlock7D, Me.lineBlock7E, Me.lineBlock7F, Me.lineBlock7G, Me.lineBlock7H, Me.lineBlock7R, Me.lineBlock8A, Me.lineBlock8B, Me.lineBlock8C, Me.lineBlock8D, Me.lineBlock8E, Me.lineBlock8R, Me.lineBlock9A, Me.lineBlock9B, Me.lineBlock9C, Me.lineBlock9D, Me.lineBlock9E, Me.lineBlock9F, Me.IndependenceA, Me.IndependenceB, Me.RockCreekA, Me.RockCreekB, Me.YardInterchange})
        Me.ShapeContainer2.Size = New System.Drawing.Size(1008, 661)
        Me.ShapeContainer2.TabIndex = 46
        Me.ShapeContainer2.TabStop = False
        '
        'lineCoburgYardLead
        '
        Me.lineCoburgYardLead.BorderColor = System.Drawing.Color.White
        Me.lineCoburgYardLead.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.lineCoburgYardLead.BorderWidth = 7
        Me.lineCoburgYardLead.Name = "lineCoburgYardLead"
        Me.lineCoburgYardLead.X1 = 765
        Me.lineCoburgYardLead.X2 = 816
        Me.lineCoburgYardLead.Y1 = 298
        Me.lineCoburgYardLead.Y2 = 298
        '
        'lineCentropolis
        '
        Me.lineCentropolis.BorderColor = System.Drawing.Color.White
        Me.lineCentropolis.BorderWidth = 7
        Me.lineCentropolis.Name = "lineCentropolis"
        Me.lineCentropolis.X1 = 13
        Me.lineCentropolis.X2 = 71
        Me.lineCentropolis.Y1 = 130
        Me.lineCentropolis.Y2 = 130
        '
        'lineOttumwa
        '
        Me.lineOttumwa.BorderColor = System.Drawing.Color.White
        Me.lineOttumwa.BorderWidth = 7
        Me.lineOttumwa.Name = "lineOttumwa"
        Me.lineOttumwa.X1 = 11
        Me.lineOttumwa.X2 = 69
        Me.lineOttumwa.Y1 = 80
        Me.lineOttumwa.Y2 = 80
        '
        'lineCoburgEast
        '
        Me.lineCoburgEast.BorderColor = System.Drawing.Color.White
        Me.lineCoburgEast.BorderWidth = 7
        Me.lineCoburgEast.Name = "lineCoburgEast"
        Me.lineCoburgEast.X1 = 860
        Me.lineCoburgEast.X2 = 918
        Me.lineCoburgEast.Y1 = 298
        Me.lineCoburgEast.Y2 = 298
        '
        'lineBroadway
        '
        Me.lineBroadway.BorderColor = System.Drawing.Color.White
        Me.lineBroadway.BorderWidth = 7
        Me.lineBroadway.Name = "lineBroadway"
        Me.lineBroadway.X1 = 792
        Me.lineBroadway.X2 = 850
        Me.lineBroadway.Y1 = 131
        Me.lineBroadway.Y2 = 131
        '
        'lineCoburgWest
        '
        Me.lineCoburgWest.BorderColor = System.Drawing.Color.White
        Me.lineCoburgWest.BorderWidth = 7
        Me.lineCoburgWest.Name = "lineCoburgWest"
        Me.lineCoburgWest.X1 = 252
        Me.lineCoburgWest.X2 = 310
        Me.lineCoburgWest.Y1 = 290
        Me.lineCoburgWest.Y2 = 290
        '
        'lineBlock10
        '
        Me.lineBlock10.BorderColor = System.Drawing.Color.White
        Me.lineBlock10.BorderWidth = 7
        Me.lineBlock10.Name = "lineBlock10"
        Me.lineBlock10.X1 = 728
        Me.lineBlock10.X2 = 786
        Me.lineBlock10.Y1 = 131
        Me.lineBlock10.Y2 = 131
        '
        'lineIndicate
        '
        Me.lineIndicate.BorderColor = System.Drawing.Color.White
        Me.lineIndicate.BorderWidth = 10
        Me.lineIndicate.Name = "lineIndicate"
        Me.lineIndicate.X1 = 494
        Me.lineIndicate.X2 = 524
        Me.lineIndicate.Y1 = 370
        Me.lineIndicate.Y2 = 370
        '
        'lineControl
        '
        Me.lineControl.BorderColor = System.Drawing.Color.White
        Me.lineControl.BorderWidth = 10
        Me.lineControl.Name = "lineControl"
        Me.lineControl.X1 = 420
        Me.lineControl.X2 = 450
        Me.lineControl.Y1 = 370
        Me.lineControl.Y2 = 370
        '
        'lblControl
        '
        Me.lblControl.AutoSize = True
        Me.lblControl.ForeColor = System.Drawing.Color.White
        Me.lblControl.Location = New System.Drawing.Point(416, 346)
        Me.lblControl.Name = "lblControl"
        Me.lblControl.Size = New System.Drawing.Size(40, 13)
        Me.lblControl.TabIndex = 47
        Me.lblControl.Text = "Control"
        '
        'lblIndication
        '
        Me.lblIndication.AutoSize = True
        Me.lblIndication.ForeColor = System.Drawing.Color.White
        Me.lblIndication.Location = New System.Drawing.Point(485, 346)
        Me.lblIndication.Name = "lblIndication"
        Me.lblIndication.Size = New System.Drawing.Size(53, 13)
        Me.lblIndication.TabIndex = 48
        Me.lblIndication.Text = "Indication"
        '
        'txtTrainMovements
        '
        Me.txtTrainMovements.Location = New System.Drawing.Point(0, 468)
        Me.txtTrainMovements.Multiline = True
        Me.txtTrainMovements.Name = "txtTrainMovements"
        Me.txtTrainMovements.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTrainMovements.Size = New System.Drawing.Size(504, 193)
        Me.txtTrainMovements.TabIndex = 49
        '
        'lblSignalMaintLog
        '
        Me.lblSignalMaintLog.AutoSize = True
        Me.lblSignalMaintLog.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSignalMaintLog.ForeColor = System.Drawing.Color.White
        Me.lblSignalMaintLog.Location = New System.Drawing.Point(504, 447)
        Me.lblSignalMaintLog.Name = "lblSignalMaintLog"
        Me.lblSignalMaintLog.Size = New System.Drawing.Size(218, 18)
        Me.lblSignalMaintLog.TabIndex = 50
        Me.lblSignalMaintLog.Text = "Signal Maintainer Log"
        '
        'lblTrainMovementLog
        '
        Me.lblTrainMovementLog.AutoSize = True
        Me.lblTrainMovementLog.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrainMovementLog.ForeColor = System.Drawing.Color.White
        Me.lblTrainMovementLog.Location = New System.Drawing.Point(3, 447)
        Me.lblTrainMovementLog.Name = "lblTrainMovementLog"
        Me.lblTrainMovementLog.Size = New System.Drawing.Size(198, 18)
        Me.lblTrainMovementLog.TabIndex = 51
        Me.lblTrainMovementLog.Text = "Train Movements Log"
        '
        'lblClock
        '
        Me.lblClock.AutoSize = True
        Me.lblClock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblClock.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClock.ForeColor = System.Drawing.Color.White
        Me.lblClock.Location = New System.Drawing.Point(394, 39)
        Me.lblClock.Name = "lblClock"
        Me.lblClock.Size = New System.Drawing.Size(90, 20)
        Me.lblClock.TabIndex = 52
        Me.lblClock.Text = "07:00 AM"
        '
        'lblBlock11
        '
        Me.lblBlock11.AutoSize = True
        Me.lblBlock11.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock11.ForeColor = System.Drawing.Color.White
        Me.lblBlock11.Location = New System.Drawing.Point(260, 298)
        Me.lblBlock11.Name = "lblBlock11"
        Me.lblBlock11.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock11.TabIndex = 53
        Me.lblBlock11.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock15
        '
        Me.lblBlock15.AutoSize = True
        Me.lblBlock15.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock15.ForeColor = System.Drawing.Color.White
        Me.lblBlock15.Location = New System.Drawing.Point(798, 90)
        Me.lblBlock15.Name = "lblBlock15"
        Me.lblBlock15.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock15.TabIndex = 54
        Me.lblBlock15.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock10
        '
        Me.lblBlock10.AutoSize = True
        Me.lblBlock10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock10.ForeColor = System.Drawing.Color.White
        Me.lblBlock10.Location = New System.Drawing.Point(740, 90)
        Me.lblBlock10.Name = "lblBlock10"
        Me.lblBlock10.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock10.TabIndex = 55
        Me.lblBlock10.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock5A
        '
        Me.lblBlock5A.AutoSize = True
        Me.lblBlock5A.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock5A.ForeColor = System.Drawing.Color.White
        Me.lblBlock5A.Location = New System.Drawing.Point(153, 139)
        Me.lblBlock5A.Name = "lblBlock5A"
        Me.lblBlock5A.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock5A.TabIndex = 56
        Me.lblBlock5A.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock5
        '
        Me.lblBlock5.AutoSize = True
        Me.lblBlock5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock5.ForeColor = System.Drawing.Color.White
        Me.lblBlock5.Location = New System.Drawing.Point(924, 141)
        Me.lblBlock5.Name = "lblBlock5"
        Me.lblBlock5.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock5.TabIndex = 57
        Me.lblBlock5.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock12
        '
        Me.lblBlock12.AutoSize = True
        Me.lblBlock12.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock12.ForeColor = System.Drawing.Color.White
        Me.lblBlock12.Location = New System.Drawing.Point(866, 309)
        Me.lblBlock12.Name = "lblBlock12"
        Me.lblBlock12.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock12.TabIndex = 58
        Me.lblBlock12.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock7
        '
        Me.lblBlock7.AutoSize = True
        Me.lblBlock7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock7.ForeColor = System.Drawing.Color.White
        Me.lblBlock7.Location = New System.Drawing.Point(444, 140)
        Me.lblBlock7.Name = "lblBlock7"
        Me.lblBlock7.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock7.TabIndex = 59
        Me.lblBlock7.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock14
        '
        Me.lblBlock14.AutoSize = True
        Me.lblBlock14.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock14.ForeColor = System.Drawing.Color.White
        Me.lblBlock14.Location = New System.Drawing.Point(16, 39)
        Me.lblBlock14.Name = "lblBlock14"
        Me.lblBlock14.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock14.TabIndex = 60
        Me.lblBlock14.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock13
        '
        Me.lblBlock13.AutoSize = True
        Me.lblBlock13.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock13.ForeColor = System.Drawing.Color.White
        Me.lblBlock13.Location = New System.Drawing.Point(16, 136)
        Me.lblBlock13.Name = "lblBlock13"
        Me.lblBlock13.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock13.TabIndex = 61
        Me.lblBlock13.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblCoburgYard
        '
        Me.lblCoburgYard.AutoSize = True
        Me.lblCoburgYard.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoburgYard.ForeColor = System.Drawing.Color.White
        Me.lblCoburgYard.Location = New System.Drawing.Point(697, 307)
        Me.lblCoburgYard.Name = "lblCoburgYard"
        Me.lblCoburgYard.Size = New System.Drawing.Size(118, 18)
        Me.lblCoburgYard.TabIndex = 62
        Me.lblCoburgYard.Text = "Coburg Yard"
        '
        'lblBlock8
        '
        Me.lblBlock8.AutoSize = True
        Me.lblBlock8.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock8.ForeColor = System.Drawing.Color.White
        Me.lblBlock8.Location = New System.Drawing.Point(444, 201)
        Me.lblBlock8.Name = "lblBlock8"
        Me.lblBlock8.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock8.TabIndex = 63
        Me.lblBlock8.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock6A
        '
        Me.lblBlock6A.AutoSize = True
        Me.lblBlock6A.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock6A.ForeColor = System.Drawing.Color.White
        Me.lblBlock6A.Location = New System.Drawing.Point(153, 201)
        Me.lblBlock6A.Name = "lblBlock6A"
        Me.lblBlock6A.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock6A.TabIndex = 64
        Me.lblBlock6A.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock6
        '
        Me.lblBlock6.AutoSize = True
        Me.lblBlock6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock6.ForeColor = System.Drawing.Color.White
        Me.lblBlock6.Location = New System.Drawing.Point(924, 201)
        Me.lblBlock6.Name = "lblBlock6"
        Me.lblBlock6.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock6.TabIndex = 65
        Me.lblBlock6.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock1
        '
        Me.lblBlock1.AutoSize = True
        Me.lblBlock1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock1.ForeColor = System.Drawing.Color.White
        Me.lblBlock1.Location = New System.Drawing.Point(643, 141)
        Me.lblBlock1.Name = "lblBlock1"
        Me.lblBlock1.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock1.TabIndex = 66
        Me.lblBlock1.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock2
        '
        Me.lblBlock2.AutoSize = True
        Me.lblBlock2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock2.ForeColor = System.Drawing.Color.White
        Me.lblBlock2.Location = New System.Drawing.Point(643, 203)
        Me.lblBlock2.Name = "lblBlock2"
        Me.lblBlock2.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock2.TabIndex = 67
        Me.lblBlock2.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock3
        '
        Me.lblBlock3.AutoSize = True
        Me.lblBlock3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock3.ForeColor = System.Drawing.Color.White
        Me.lblBlock3.Location = New System.Drawing.Point(778, 140)
        Me.lblBlock3.Name = "lblBlock3"
        Me.lblBlock3.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock3.TabIndex = 68
        Me.lblBlock3.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock4
        '
        Me.lblBlock4.AutoSize = True
        Me.lblBlock4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock4.ForeColor = System.Drawing.Color.White
        Me.lblBlock4.Location = New System.Drawing.Point(740, 202)
        Me.lblBlock4.Name = "lblBlock4"
        Me.lblBlock4.Size = New System.Drawing.Size(56, 32)
        Me.lblBlock4.TabIndex = 69
        Me.lblBlock4.Text = "XXXX >" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'lblBlock9
        '
        Me.lblBlock9.AutoSize = True
        Me.lblBlock9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock9.ForeColor = System.Drawing.Color.White
        Me.lblBlock9.Location = New System.Drawing.Point(127, 41)
        Me.lblBlock9.Name = "lblBlock9"
        Me.lblBlock9.Size = New System.Drawing.Size(40, 32)
        Me.lblBlock9.TabIndex = 70
        Me.lblBlock9.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9999"
        '
        'picSig26LB
        '
        Me.picSig26LB.Image = Global.KCSubCTCV3.My.Resources.Resources.WhiteLeft
        Me.picSig26LB.Location = New System.Drawing.Point(858, 271)
        Me.picSig26LB.Name = "picSig26LB"
        Me.picSig26LB.Size = New System.Drawing.Size(38, 20)
        Me.picSig26LB.TabIndex = 71
        Me.picSig26LB.TabStop = False
        '
        'picTraffic8West
        '
        Me.picTraffic8West.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic8West.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneWest
        Me.picTraffic8West.Location = New System.Drawing.Point(602, 230)
        Me.picTraffic8West.Name = "picTraffic8West"
        Me.picTraffic8West.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic8West.TabIndex = 73
        Me.picTraffic8West.TabStop = False
        '
        'picTraffic7EastA
        '
        Me.picTraffic7EastA.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic7EastA.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic7EastA.Location = New System.Drawing.Point(223, 170)
        Me.picTraffic7EastA.Name = "picTraffic7EastA"
        Me.picTraffic7EastA.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic7EastA.TabIndex = 74
        Me.picTraffic7EastA.TabStop = False
        '
        'picTraffic7EastB
        '
        Me.picTraffic7EastB.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic7EastB.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic7EastB.Location = New System.Drawing.Point(300, 120)
        Me.picTraffic7EastB.Name = "picTraffic7EastB"
        Me.picTraffic7EastB.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic7EastB.TabIndex = 75
        Me.picTraffic7EastB.TabStop = False
        '
        'picTraffic3East
        '
        Me.picTraffic3East.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic3East.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic3East.Location = New System.Drawing.Point(732, 170)
        Me.picTraffic3East.Name = "picTraffic3East"
        Me.picTraffic3East.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic3East.TabIndex = 76
        Me.picTraffic3East.TabStop = False
        '
        'picTraffic8East
        '
        Me.picTraffic8East.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic8East.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic8East.Location = New System.Drawing.Point(222, 230)
        Me.picTraffic8East.Name = "picTraffic8East"
        Me.picTraffic8East.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic8East.TabIndex = 72
        Me.picTraffic8East.TabStop = False
        '
        'picTraffic4East
        '
        Me.picTraffic4East.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic4East.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic4East.Location = New System.Drawing.Point(731, 230)
        Me.picTraffic4East.Name = "picTraffic4East"
        Me.picTraffic4East.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic4East.TabIndex = 77
        Me.picTraffic4East.TabStop = False
        '
        'picTraffic9EastA
        '
        Me.picTraffic9EastA.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic9EastA.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic9EastA.Location = New System.Drawing.Point(72, 70)
        Me.picTraffic9EastA.Name = "picTraffic9EastA"
        Me.picTraffic9EastA.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic9EastA.TabIndex = 78
        Me.picTraffic9EastA.TabStop = False
        '
        'picTraffic9EastB
        '
        Me.picTraffic9EastB.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic9EastB.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneEast
        Me.picTraffic9EastB.Location = New System.Drawing.Point(74, 120)
        Me.picTraffic9EastB.Name = "picTraffic9EastB"
        Me.picTraffic9EastB.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic9EastB.TabIndex = 79
        Me.picTraffic9EastB.TabStop = False
        '
        'picTraffic7WestA
        '
        Me.picTraffic7WestA.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic7WestA.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneWest
        Me.picTraffic7WestA.Location = New System.Drawing.Point(602, 170)
        Me.picTraffic7WestA.Name = "picTraffic7WestA"
        Me.picTraffic7WestA.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic7WestA.TabIndex = 80
        Me.picTraffic7WestA.TabStop = False
        '
        'picTraffic4West
        '
        Me.picTraffic4West.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic4West.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneWest
        Me.picTraffic4West.Location = New System.Drawing.Point(887, 230)
        Me.picTraffic4West.Name = "picTraffic4West"
        Me.picTraffic4West.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic4West.TabIndex = 81
        Me.picTraffic4West.TabStop = False
        '
        'picTraffic3West
        '
        Me.picTraffic3West.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic3West.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneWest
        Me.picTraffic3West.Location = New System.Drawing.Point(887, 170)
        Me.picTraffic3West.Name = "picTraffic3West"
        Me.picTraffic3West.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic3West.TabIndex = 82
        Me.picTraffic3West.TabStop = False
        '
        'picTraffic7WestB
        '
        Me.picTraffic7WestB.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic7WestB.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneWest
        Me.picTraffic7WestB.Location = New System.Drawing.Point(717, 121)
        Me.picTraffic7WestB.Name = "picTraffic7WestB"
        Me.picTraffic7WestB.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic7WestB.TabIndex = 83
        Me.picTraffic7WestB.TabStop = False
        '
        'picTraffic9West
        '
        Me.picTraffic9West.BackColor = System.Drawing.Color.Transparent
        Me.picTraffic9West.Image = Global.KCSubCTCV3.My.Resources.Resources.TrafficNoneWest
        Me.picTraffic9West.Location = New System.Drawing.Point(291, 120)
        Me.picTraffic9West.Name = "picTraffic9West"
        Me.picTraffic9West.Size = New System.Drawing.Size(11, 20)
        Me.picTraffic9West.TabIndex = 84
        Me.picTraffic9West.TabStop = False
        '
        'MainPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1008, 661)
        Me.Controls.Add(Me.picTraffic9West)
        Me.Controls.Add(Me.picTraffic7WestB)
        Me.Controls.Add(Me.picTraffic3West)
        Me.Controls.Add(Me.picTraffic4West)
        Me.Controls.Add(Me.picTraffic7WestA)
        Me.Controls.Add(Me.picTraffic9EastB)
        Me.Controls.Add(Me.picTraffic9EastA)
        Me.Controls.Add(Me.picTraffic4East)
        Me.Controls.Add(Me.picTraffic3East)
        Me.Controls.Add(Me.picTraffic7EastB)
        Me.Controls.Add(Me.picTraffic7EastA)
        Me.Controls.Add(Me.picTraffic8West)
        Me.Controls.Add(Me.picTraffic8East)
        Me.Controls.Add(Me.picSig26LB)
        Me.Controls.Add(Me.lblBlock9)
        Me.Controls.Add(Me.lblBlock4)
        Me.Controls.Add(Me.lblBlock3)
        Me.Controls.Add(Me.lblBlock2)
        Me.Controls.Add(Me.lblBlock1)
        Me.Controls.Add(Me.lblBlock6)
        Me.Controls.Add(Me.lblBlock6A)
        Me.Controls.Add(Me.lblBlock8)
        Me.Controls.Add(Me.lblCoburgYard)
        Me.Controls.Add(Me.lblBlock13)
        Me.Controls.Add(Me.lblBlock14)
        Me.Controls.Add(Me.lblBlock7)
        Me.Controls.Add(Me.lblBlock12)
        Me.Controls.Add(Me.lblBlock5)
        Me.Controls.Add(Me.lblBlock5A)
        Me.Controls.Add(Me.lblBlock10)
        Me.Controls.Add(Me.lblBlock15)
        Me.Controls.Add(Me.lblBlock11)
        Me.Controls.Add(Me.lblClock)
        Me.Controls.Add(Me.lblTrainMovementLog)
        Me.Controls.Add(Me.lblSignalMaintLog)
        Me.Controls.Add(Me.txtTrainMovements)
        Me.Controls.Add(Me.lblIndication)
        Me.Controls.Add(Me.lblControl)
        Me.Controls.Add(Me.picSig8RB)
        Me.Controls.Add(Me.picSig4RA)
        Me.Controls.Add(Me.picSig4RB)
        Me.Controls.Add(Me.picSig8RA)
        Me.Controls.Add(Me.picSig12R)
        Me.Controls.Add(Me.picSig10R)
        Me.Controls.Add(Me.picSig24R)
        Me.Controls.Add(Me.picSig26R)
        Me.Controls.Add(Me.picSig8LB)
        Me.Controls.Add(Me.picSig4L)
        Me.Controls.Add(Me.picSig10L)
        Me.Controls.Add(Me.picSig8LA)
        Me.Controls.Add(Me.picSig24L)
        Me.Controls.Add(Me.picSig26LA)
        Me.Controls.Add(Me.picTraffic6AWest)
        Me.Controls.Add(Me.picTraffic6AEast)
        Me.Controls.Add(Me.picTraffic5AWest)
        Me.Controls.Add(Me.picTraffic5AEast)
        Me.Controls.Add(Me.picTraffic2West)
        Me.Controls.Add(Me.picTraffic2East)
        Me.Controls.Add(Me.picTraffic1West)
        Me.Controls.Add(Me.picTraffic1East)
        Me.Controls.Add(Me.picTraffic6BWest)
        Me.Controls.Add(Me.picTraffic6BEast)
        Me.Controls.Add(Me.picTraffic5BWest)
        Me.Controls.Add(Me.picTraffic5BEast)
        Me.Controls.Add(Me.lblFreightLineJct)
        Me.Controls.Add(Me.lblSheffield)
        Me.Controls.Add(Me.lblRockCreek)
        Me.Controls.Add(Me.lblSouthwestJct)
        Me.Controls.Add(Me.picLock19)
        Me.Controls.Add(Me.picLock17)
        Me.Controls.Add(Me.picLock25Down)
        Me.Controls.Add(Me.picLock25Up)
        Me.Controls.Add(Me.picTurnout15)
        Me.Controls.Add(Me.picTurnout11)
        Me.Controls.Add(Me.picTurnout9Up)
        Me.Controls.Add(Me.picTurnout9Down)
        Me.Controls.Add(Me.picTurnout7)
        Me.Controls.Add(Me.picTurnout23Up)
        Me.Controls.Add(Me.picTurnout23Down)
        Me.Controls.Add(Me.picTurnout3)
        Me.Controls.Add(Me.txtLogMsg)
        Me.Controls.Add(Me.menuMain)
        Me.Controls.Add(Me.ShapeContainer2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuMain
        Me.Name = "MainPanel"
        Me.Text = "Milwaukee Road Kansas City Subdivision CTC"
        Me.menuMain.ResumeLayout(False)
        Me.menuMain.PerformLayout()
        CType(Me.picTurnout3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTurnout23Down, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTurnout23Up, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTurnout7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTurnout9Down, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTurnout9Up, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTurnout11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTurnout15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLock25Up, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLock25Down, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLock17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLock19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic5BEast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic5BWest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic6BWest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic6BEast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic1West, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic1East, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic2West, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic2East, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic5AWest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic5AEast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic6AWest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic6AEast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig26LA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig24L, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig8LA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig10L, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig4L, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig8LB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig26R, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig24R, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig10R, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig12R, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig8RA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig4RB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig4RA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig8RB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSig26LB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic8West, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic7EastA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic7EastB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic3East, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic8East, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic4East, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic9EastA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic9EastB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic7WestA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic4West, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic3West, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic7WestB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTraffic9West, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents timerMainLoop As System.Windows.Forms.Timer
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemParametersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunWithCMRISimulatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunWithCMRIToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopRunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommPort As System.IO.Ports.SerialPort
    Friend WithEvents txtLogMsg As System.Windows.Forms.TextBox
    Friend WithEvents ResumeRunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RepairSignalsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SignalTestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LampTestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents lineBlock4C As PowerPacks.LineShape
    Friend WithEvents picTurnout3 As PictureBox
    Friend WithEvents images As ImageList
    Friend WithEvents lineBlock4B As PowerPacks.LineShape
    Friend WithEvents picTurnout23Down As PictureBox
    Friend WithEvents picTurnout23Up As PictureBox
    Friend WithEvents picTurnout7 As PictureBox
    Friend WithEvents picTurnout9Down As PictureBox
    Friend WithEvents picTurnout9Up As PictureBox
    Friend WithEvents picTurnout11 As PictureBox
    Friend WithEvents picTurnout15 As PictureBox
    Friend WithEvents picLock25Up As PictureBox
    Friend WithEvents picLock25Down As PictureBox
    Friend WithEvents picLock17 As PictureBox
    Friend WithEvents picLock19 As PictureBox
    Friend WithEvents lineBlock7B As PowerPacks.LineShape
    Friend WithEvents lineBlock6B As PowerPacks.LineShape
    Friend WithEvents RockCreekA As PowerPacks.LineShape
    Friend WithEvents RockCreekB As PowerPacks.LineShape
    Friend WithEvents lineBlock5B As PowerPacks.LineShape
    Friend WithEvents IndependenceB As PowerPacks.LineShape
    Friend WithEvents IndependenceA As PowerPacks.LineShape
    Friend WithEvents lineBlock7F As PowerPacks.LineShape
    Friend WithEvents lineBlock7H As PowerPacks.LineShape
    Friend WithEvents lineBlock7G As PowerPacks.LineShape
    Friend WithEvents lineBlock8D As PowerPacks.LineShape
    Friend WithEvents lineBlock8E As PowerPacks.LineShape
    Friend WithEvents lineBlock4D As PowerPacks.LineShape
    Friend WithEvents YardInterchange As PowerPacks.LineShape
    Friend WithEvents lineBlock5A As PowerPacks.LineShape
    Friend WithEvents lineBlock9C As PowerPacks.LineShape
    Friend WithEvents lineBlock7C As PowerPacks.LineShape
    Friend WithEvents lineBlock8C As PowerPacks.LineShape
    Friend WithEvents lineBlock9D As PowerPacks.LineShape
    Friend WithEvents lineBlock3R As PowerPacks.LineShape
    Friend WithEvents lineBlock1A As PowerPacks.LineShape
    Friend WithEvents lineBlock3A As PowerPacks.LineShape
    Friend WithEvents lineBlock3B As PowerPacks.LineShape
    Friend WithEvents lineBlock7D As PowerPacks.LineShape
    Friend WithEvents lineBlock6A As PowerPacks.LineShape
    Friend WithEvents lineBlock9A As PowerPacks.LineShape
    Friend WithEvents lineBlock9B As PowerPacks.LineShape
    Friend WithEvents lineBlock9F As PowerPacks.LineShape
    Friend WithEvents lineBlock9E As PowerPacks.LineShape
    Friend WithEvents lineBlock4R As PowerPacks.LineShape
    Friend WithEvents lineBlock2A As PowerPacks.LineShape
    Friend WithEvents lineBlock4A As PowerPacks.LineShape
    Friend WithEvents lineBlock7R As PowerPacks.LineShape
    Friend WithEvents lineBlock8B As PowerPacks.LineShape
    Friend WithEvents lineBlock7E As PowerPacks.LineShape
    Friend WithEvents lineBlock8R As PowerPacks.LineShape
    Friend WithEvents lineBlock8A As PowerPacks.LineShape
    Friend WithEvents lineBlock7A As PowerPacks.LineShape
    Friend WithEvents lblSouthwestJct As Label
    Friend WithEvents lblRockCreek As Label
    Friend WithEvents lblSheffield As Label
    Friend WithEvents lblFreightLineJct As Label
    Friend WithEvents picTraffic5BEast As PictureBox
    Friend WithEvents picTraffic5BWest As PictureBox
    Friend WithEvents picTraffic6BWest As PictureBox
    Friend WithEvents picTraffic6BEast As PictureBox
    Friend WithEvents picTraffic1West As PictureBox
    Friend WithEvents picTraffic1East As PictureBox
    Friend WithEvents picTraffic2West As PictureBox
    Friend WithEvents picTraffic2East As PictureBox
    Friend WithEvents picTraffic5AWest As PictureBox
    Friend WithEvents picTraffic5AEast As PictureBox
    Friend WithEvents picTraffic6AWest As PictureBox
    Friend WithEvents picTraffic6AEast As PictureBox
    Friend WithEvents picSig26LA As PictureBox
    Friend WithEvents picSig24L As PictureBox
    Friend WithEvents picSig8LA As PictureBox
    Friend WithEvents picSig10L As PictureBox
    Friend WithEvents picSig4L As PictureBox
    Friend WithEvents picSig8LB As PictureBox
    Friend WithEvents picSig26R As PictureBox
    Friend WithEvents picSig24R As PictureBox
    Friend WithEvents picSig10R As PictureBox
    Friend WithEvents picSig12R As PictureBox
    Friend WithEvents picSig8RA As PictureBox
    Friend WithEvents picSig4RB As PictureBox
    Friend WithEvents picSig4RA As PictureBox
    Friend WithEvents picSig8RB As PictureBox
    Friend WithEvents ShapeContainer2 As PowerPacks.ShapeContainer
    Friend WithEvents lineIndicate As PowerPacks.LineShape
    Friend WithEvents lineControl As PowerPacks.LineShape
    Friend WithEvents lblControl As Label
    Friend WithEvents lblIndication As Label
    Friend WithEvents txtTrainMovements As TextBox
    Friend WithEvents lblSignalMaintLog As Label
    Friend WithEvents lblTrainMovementLog As Label
    Friend WithEvents lblClock As Label
    Friend WithEvents lineBlock10 As PowerPacks.LineShape
    Friend WithEvents lineCoburgWest As PowerPacks.LineShape
    Friend WithEvents lblBlock11 As Label
    Friend WithEvents lblBlock15 As Label
    Friend WithEvents lblBlock10 As Label
    Friend WithEvents lineBroadway As PowerPacks.LineShape
    Friend WithEvents lblBlock5A As Label
    Friend WithEvents lblBlock5 As Label
    Friend WithEvents lineCoburgEast As PowerPacks.LineShape
    Friend WithEvents lblBlock12 As Label
    Friend WithEvents lblBlock7 As Label
    Friend WithEvents lineCentropolis As PowerPacks.LineShape
    Friend WithEvents lineOttumwa As PowerPacks.LineShape
    Friend WithEvents lblBlock14 As Label
    Friend WithEvents lblBlock13 As Label
    Friend WithEvents lineCoburgYardLead As PowerPacks.LineShape
    Friend WithEvents lblCoburgYard As Label
    Friend WithEvents lblBlock8 As Label
    Friend WithEvents lblBlock6A As Label
    Friend WithEvents lblBlock6 As Label
    Friend WithEvents lblBlock1 As Label
    Friend WithEvents lblBlock2 As Label
    Friend WithEvents lblBlock3 As Label
    Friend WithEvents lblBlock4 As Label
    Friend WithEvents lblBlock9 As Label
    Friend WithEvents picSig26LB As PictureBox
    Friend WithEvents picTraffic8West As PictureBox
    Friend WithEvents picTraffic7EastA As PictureBox
    Friend WithEvents picTraffic7EastB As PictureBox
    Friend WithEvents picTraffic3East As PictureBox
    Friend WithEvents picTraffic8East As PictureBox
    Friend WithEvents picTraffic4East As PictureBox
    Friend WithEvents picTraffic9EastA As PictureBox
    Friend WithEvents picTraffic9EastB As PictureBox
    Friend WithEvents picTraffic7WestA As PictureBox
    Friend WithEvents picTraffic4West As PictureBox
    Friend WithEvents picTraffic3West As PictureBox
    Friend WithEvents picTraffic7WestB As PictureBox
    Friend WithEvents picTraffic9West As PictureBox
End Class
