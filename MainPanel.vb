Public Class MainPanel
    Private theCMRI As InterfaceCMRI
    Private Block1, Block2, Block3, Block4, Block5, Block6, Block7, Block8, Block9, Block10 As Integer
    Private Signal4Selected As PictureBox
    Private Signal8Selected As PictureBox
    Private Signal10Selected As PictureBox
    Private Signal12Selected As PictureBox
    Private Signal24Selected As PictureBox
    Private Signal26Selected As PictureBox
    Private Sig4Dir, Sig8Dir, Sig10Dir, Sig12Dir, Sig24Dir, Sig26Dir As Integer
    Private Turnout3SavedPic As New PictureBox
    Private Turnout7SavedPic As New PictureBox
    Private Turnout9SavedDownPic As New PictureBox
    Private Turnout9SavedUpPic As New PictureBox
    Private Turnout11SavedPic As New PictureBox
    Private Turnout15SavedPic As New PictureBox
    Private Turnout23SavedDownPic As New PictureBox
    Private Turnout23SavedUpPic As New PictureBox
    Private Turnout25SavedPic As New PictureBox


    Function CheckExit() As Boolean
        'Dim response As MsgBoxResult
        Dim loopRunning As Boolean
        loopRunning = timerMainLoop.Enabled
        timerMainLoop.Enabled = False
        'response = MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNo, "Exit the CTC Application")
        'If response = MsgBoxResult.Yes Then
        End
        'End If
        timerMainLoop.Enabled = loopRunning
        Return True
    End Function
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If CheckExit() Then
        End If
    End Sub

    Private Sub RunWithCMRISimulatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunWithCMRISimulatorToolStripMenuItem.Click
        theCMRI = New TestCMRI()
        Call InitializeRailroad(theCMRI)
        Call DoOneControlCycle()
        timerMainLoop.Interval = 10
        timerMainLoop.Enabled = True
    End Sub

    Private Sub RunWithCMRIToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RunWithCMRIToolStripMenuItem.Click
        theCMRI = New CMRI()
        Call InitializeRailroad(theCMRI)
        Me.StopRunToolStripMenuItem.Enabled = True
        Me.ResumeRunToolStripMenuItem.Enabled = False
        Call DoOneControlCycle()
        timerMainLoop.Interval = 100
        timerMainLoop.Enabled = True
    End Sub

    Private Sub StopRunToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StopRunToolStripMenuItem.Click
        timerMainLoop.Enabled = False
        Me.ResumeRunToolStripMenuItem.Enabled = True
        Me.StopRunToolStripMenuItem.Enabled = False
    End Sub

    Private Sub timerMainLoop_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timerMainLoop.Tick
        'Don't allow the loop to run again, while we are doing the railroad.
        timerMainLoop.Enabled = False
        Call DoOneControlCycle()
        timerMainLoop.Enabled = True
    End Sub
    Private Sub MainPanel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = CheckExit()
    End Sub

    Private Sub ResumeRunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumeRunToolStripMenuItem.Click
        timerMainLoop.Enabled = True
        Me.ResumeRunToolStripMenuItem.Enabled = False
        Me.StopRunToolStripMenuItem.Enabled = True
    End Sub

    Private Sub RepairSignalsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepairSignalsToolStripMenuItem.Click
        DlgSigMaint.ShowDialog()

    End Sub

    Private Sub SystemParametersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemParametersToolStripMenuItem.Click
        If DlgSystemParams.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CCDL = DlgSystemParams.txtCCDL.Text         'Control Code transmission delay (5 seconds)
            ICDL = DlgSystemParams.txtICDL.Text        'Indication Code transmission delay (10 seconds)
            SMDL = DlgSystemParams.txtSMDL.Text        'Switch motor transition delay (12 seconds)
            RTDL = DlgSystemParams.txtRTDL.Text        'Signal running time delay (60 seconds)
            'LKDL = 90        'Lock release time delay (90 seconds)
        End If
    End Sub

    Private Sub SignalTestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignalTestToolStripMenuItem.Click
        SignalTest.Show()

    End Sub

    Private Sub LampTestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LampTestToolStripMenuItem.Click
        ' Toggle LampTest - CTC WriteRailroad logic will use LAMPTEST to turn on all lamps.
        If LAMPTEST Then
            LAMPTEST = False
        Else
            LAMPTEST = True
        End If
        LampTestToolStripMenuItem.Checked = LAMPTEST
    End Sub
    Private Sub MainPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub UpdateFormObjects()
        UpdateBlocksFromRead() ' get block occupied/clear from C/MRI nodes
        UpdateBlockOccupancyLines() ' set occupied/clear/routed based on TLVnn and FSnn
        UpdateSignals() ' make signals clear/stop/running time
        UpdateTurnouts()
        UpdateTrafficSticks()
        UpdateFlash()
        UpdateClock()
        UpdateTrainIDs()
    End Sub

    Private Sub UpdateClock()
        ' redraw clock
        lblClock.Text = FormatFastClock()
    End Sub

    Private Sub UpdateTrainIDs()
        Dim scratch As String

        If CDEIND = 1 Then
            Exit Sub
        End If

        scratch = TrainID(1) + Chr(13) + LocoID(1)
        'If FS1 = EAST Then scratch = "< " + TrainID(1) + Chr(13) + LocoID(1)
        'If FS1 = WEST Then scratch = TrainID(1) + " >" + Chr(13) + LocoID(1)
        lblBlock1.Text = scratch

        scratch = TrainID(2) + Chr(13) + LocoID(2)
        'If FS2 = EAST Then scratch = "< " + TrainID(2) + Chr(13) + LocoID(2)
        'If FS2 = WEST Then scratch = TrainID(2) + " >" + Chr(13) + LocoID(2)
        lblBlock2.Text = scratch

        scratch = TrainID(3) + Chr(13) + LocoID(3)
        'If FS3 = EAST Then scratch = "< " + TrainID(3) + Chr(13) + LocoID(3)
        'If FS3 = WEST Then scratch = TrainID(3) + " >" + Chr(13) + LocoID(3)
        lblBlock3.Text = scratch

        scratch = TrainID(4) + Chr(13) + LocoID(4)
        'If FS4 = EAST Then scratch = "< " + TrainID(4) + Chr(13) + LocoID(4)
        'If FS4 = WEST Then scratch = TrainID(4) + " >" + Chr(13) + LocoID(4)
        lblBlock4.Text = scratch

        scratch = TrainID(5) + Chr(13) + LocoID(5)
        'If FS5 = EAST Then scratch = "< " + TrainID(5) + Chr(13) + LocoID(5)
        'If FS5 = WEST Then scratch = TrainID(5) + " >" + Chr(13) + LocoID(5)
        lblBlock5.Text = scratch
        lblBlock5A.Text = scratch

        scratch = TrainID(6) + Chr(13) + LocoID(6)
        'If FS6 = EAST Then scratch = "< " + TrainID(6) + Chr(13) + LocoID(6)
        'If FS6 = WEST Then scratch = TrainID(6) + " >" + Chr(13) + LocoID(6)
        lblBlock6.Text = scratch
        lblBlock6A.Text = scratch

        scratch = TrainID(7) + Chr(13) + LocoID(7)
        'If FS7 = EAST Then scratch = "< " + TrainID(7) + Chr(13) + LocoID(7)
        'If FS7 = WEST Then scratch = TrainID(7) + " >" + Chr(13) + LocoID(7)
        lblBlock7.Text = scratch

        scratch = TrainID(8) + Chr(13) + LocoID(8)
        'If FS8 = EAST Then scratch = "< " + TrainID(8) + Chr(13) + LocoID(8)
        'If FS8 = WEST Then scratch = TrainID(8) + " >" + Chr(13) + LocoID(8)
        lblBlock8.Text = scratch

        scratch = TrainID(9) + Chr(13) + LocoID(9)
        'If FS9 = EAST Then scratch = "< " + TrainID(9) + Chr(13) + LocoID(9)
        'If FS9 = WEST Then scratch = TrainID(9) + " >" + Chr(13) + LocoID(9)
        lblBlock9.Text = scratch

        scratch = TrainID(10) + Chr(13) + LocoID(10)
        'If FS10 = EAST Then scratch = "< " + TrainID(10) + Chr(13) + LocoID(10)
        'If FS10 = WEST Then scratch = TrainID(10) + " >" + Chr(13) + LocoID(10)
        lblBlock10.Text = scratch

        scratch = TrainID(11) + Chr(13) + LocoID(11)
        lblBlock11.Text = scratch

        scratch = TrainID(12) + Chr(13) + LocoID(12)
        lblBlock12.Text = scratch

        scratch = TrainID(13) + Chr(13) + LocoID(13)
        lblBlock13.Text = scratch

        scratch = TrainID(14) + Chr(13) + LocoID(14)
        lblBlock14.Text = scratch

        scratch = TrainID(15) + Chr(13) + LocoID(15)
        lblBlock15.Text = scratch

        'Dim labelRef As Label
        'For n = 1 To 15
        'labelRef = Me.Controls("lblBlock" & n)
        'labelRef.Text = TrainID(n) + Chr(13) + LocoID(n)
        'Next

    End Sub

    Sub UpdateFlash()
        If SGL4LTK = DARKLT Then
            If Not IsNothing(Signal4Selected) Then
                If FLASH Then
                    If Sig4Dir = LEFTLT Then
                        Signal4Selected.Image = KCSubCTCV3.My.Resources.WhiteLeft
                    Else
                        Signal4Selected.Image = KCSubCTCV3.My.Resources.WhiteRight
                    End If
                Else
                    If Sig4Dir = LEFTLT Then
                        Signal4Selected.Image = KCSubCTCV3.My.Resources.GreenLeft
                    Else
                        Signal4Selected.Image = KCSubCTCV3.My.Resources.GreenRight
                    End If
                End If
            End If
        End If
        If SGL8LTK = DARKLT Then
            If Not IsNothing(Signal8Selected) Then
                If FLASH Then
                    If Sig8Dir = LEFTLT Then
                        Signal8Selected.Image = KCSubCTCV3.My.Resources.WhiteLeft
                    Else
                        Signal8Selected.Image = KCSubCTCV3.My.Resources.WhiteRight
                    End If
                Else
                    If Sig8Dir = LEFTLT Then
                        Signal8Selected.Image = KCSubCTCV3.My.Resources.GreenLeft
                    Else
                        Signal8Selected.Image = KCSubCTCV3.My.Resources.GreenRight
                    End If
                End If
            End If
        End If
        If SGL10LTK = DARKLT Then
            If Not IsNothing(Signal10Selected) Then
                If FLASH Then
                    If Sig10Dir = LEFTLT Then
                        Signal10Selected.Image = KCSubCTCV3.My.Resources.WhiteLeft
                    Else
                        Signal10Selected.Image = KCSubCTCV3.My.Resources.WhiteRight
                    End If
                Else
                    If Sig10Dir = LEFTLT Then
                        Signal10Selected.Image = KCSubCTCV3.My.Resources.GreenLeft
                    Else
                        Signal10Selected.Image = KCSubCTCV3.My.Resources.GreenRight
                    End If
                End If
            End If
        End If
        If SGL12LTK = DARKLT Then
            If Not IsNothing(Signal12Selected) Then
                If FLASH Then
                    If Sig12Dir = LEFTLT Then
                        Signal12Selected.Image = KCSubCTCV3.My.Resources.WhiteLeft
                    Else
                        Signal12Selected.Image = KCSubCTCV3.My.Resources.WhiteRight
                    End If
                Else
                    If Sig12Dir = LEFTLT Then
                        Signal12Selected.Image = KCSubCTCV3.My.Resources.GreenLeft
                    Else
                        Signal12Selected.Image = KCSubCTCV3.My.Resources.GreenRight
                    End If
                End If
            End If
        End If
        If SGL24LTK = DARKLT Then
            If Not IsNothing(Signal24Selected) Then
                If FLASH Then
                    If Sig24Dir = LEFTLT Then
                        Signal24Selected.Image = KCSubCTCV3.My.Resources.WhiteLeft
                    Else
                        Signal24Selected.Image = KCSubCTCV3.My.Resources.WhiteRight
                    End If
                Else
                    If Sig24Dir = LEFTLT Then
                        Signal24Selected.Image = KCSubCTCV3.My.Resources.GreenLeft
                    Else
                        Signal24Selected.Image = KCSubCTCV3.My.Resources.GreenRight
                    End If
                End If
            End If
        End If

        If SGL26LTK = DARKLT Then
            If Not IsNothing(Signal26Selected) Then
                If FLASH Then
                    If Sig26Dir = LEFTLT Then
                        Signal26Selected.Image = KCSubCTCV3.My.Resources.WhiteLeft
                    Else
                        Signal26Selected.Image = KCSubCTCV3.My.Resources.WhiteRight
                    End If
                Else
                    If Sig26Dir = LEFTLT Then
                        Signal26Selected.Image = KCSubCTCV3.My.Resources.GreenLeft
                    Else
                        Signal26Selected.Image = KCSubCTCV3.My.Resources.GreenRight
                    End If
                End If
            End If
        End If


        ' Flash turnouts that are out of correspondence.
        If SWL3LTK = DARKLT Then
            If FLASH Then
                picTurnout3.Image = KCSubCTCV3.My.Resources.TurnoutLeftDownBlank
            Else
                picTurnout3.Image = Turnout3SavedPic.Image
            End If
        End If
        If SWL7LTK = DARKLT Then
            If FLASH Then
                picTurnout7.Image = KCSubCTCV3.My.Resources.TurnoutRightUpBlank
            Else
                picTurnout7.Image = Turnout7SavedPic.Image
            End If
        End If
        If SWL9LTK = DARKLT Then
            If FLASH Then
                picTurnout9Down.Image = KCSubCTCV3.My.Resources.TurnoutLeftDownBlank
                picTurnout9Up.Image = KCSubCTCV3.My.Resources.TurnoutLeftUpBlank
            Else
                picTurnout9Down.Image = Turnout9SavedDownPic.Image
                picTurnout9Up.Image = Turnout9SavedUpPic.Image
            End If
        End If
        If SWL11LTK = DARKLT Then
            If FLASH Then
                picTurnout11.Image = KCSubCTCV3.My.Resources.TurnoutLeftDownBlank
            Else
                picTurnout11.Image = Turnout11SavedPic.Image
            End If
        End If
        If SWL15LTK = DARKLT Then
            If FLASH Then
                picTurnout15.Image = KCSubCTCV3.My.Resources.TurnoutLeftUpBlank
            Else
                picTurnout15.Image = Turnout15SavedPic.Image
            End If
        End If
        If SWL23LTK = DARKLT Then
            If FLASH Then
                picTurnout23Down.Image = KCSubCTCV3.My.Resources.TurnoutRightDownBlank
                picTurnout23Up.Image = KCSubCTCV3.My.Resources.TurnoutRightUpBlank
            Else
                picTurnout23Down.Image = Turnout23SavedDownPic.Image
                picTurnout23Up.Image = Turnout23SavedUpPic.Image
            End If
        End If
        If SWL25LTK = DARKLT Then
            If FLASH Then
                picLock25Down.Image = KCSubCTCV3.My.Resources.TurnoutRightDownBlank
            Else
                picLock25Down.Image = Turnout25SavedPic.Image
            End If
        End If
    End Sub
    Sub UpdateTurnouts()
        If CDEIND = 1 Then
            Exit Sub
        End If
        UpdateTurnout3()
        UpdateTurnout7()
        UpdateTurnout9()
        UpdateTurnout11()
        UpdateTurnout15()
        UpdateTurnout17()
        UpdateTurnout19()
        UpdateTurnout23()
        UpdateTurnout25()
    End Sub
    Sub UpdateTurnout3()
        If SWL3LTK = NORLT Then
            Turnout3SavedPic.Image = KCSubCTCV3.My.Resources.TurnoutLeftDownNormal
            Select Case Block9
                Case CLR
                    picTurnout3.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownNormal
                Case OCC
                    picTurnout3.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownNormalRed
                Case RTD
                    picTurnout3.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownNormalGreen
            End Select
        Else
            Turnout3SavedPic.Image = KCSubCTCV3.My.Resources.TurnoutLeftDownReverse
            Select Case Block9
                Case CLR
                    picTurnout3.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownReverse
                Case OCC
                    picTurnout3.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownReverseRed
                Case RTD
                    picTurnout3.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownReverseGreen
            End Select
        End If

    End Sub
    Sub UpdateTurnout7()
        Select Case SWL7LTK
            Case NORLT
                Turnout7SavedPic.Image = KCSubCTCV3.My.Resources.TurnoutRightUpNormal
                Select Case Block7
                    Case CLR
                        picTurnout7.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpNormal
                    Case OCC
                        If SWL9LTK = NORLT Then
                            picTurnout7.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpNormalRed
                        End If
                    Case RTD
                        If SWL9LTK = NORLT Then
                            picTurnout7.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpNormalGreen
                        End If
                End Select
            Case REVLT
                Turnout7SavedPic.Image = KCSubCTCV3.My.Resources.TurnoutRightUpReverse
                Select Case Block7
                    Case CLR
                        picTurnout7.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpReverse
                    Case OCC
                        If SWL9LTK = NORLT Then
                            picTurnout7.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpReverseRed
                        End If
                    Case RTD
                        If SWL9LTK = NORLT Then
                            picTurnout7.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpReverseGreen
                        End If
                End Select

        End Select
    End Sub
    Sub UpdateTurnout9()
        Select Case SWL9LTK
            Case NORLT
                Turnout9SavedDownPic.Image = KCSubCTCV3.My.Resources.TurnoutLeftDownNormal
                Turnout9SavedUpPic.Image = KCSubCTCV3.My.Resources.TurnoutLeftUpNormal
                Select Case Block7
                    Case CLR
                        picTurnout9Down.Image = Global.KCSubCTCV3.My.Resources.TurnoutLeftDownNormal
                    Case OCC
                        picTurnout9Down.Image = Global.KCSubCTCV3.My.Resources.TurnoutLeftDownNormalRed
                    Case RTD
                        picTurnout9Down.Image = Global.KCSubCTCV3.My.Resources.TurnoutLeftDownNormalGreen
                End Select
                Select Case Block8
                    Case CLR
                        picTurnout9Up.Image = Global.KCSubCTCV3.My.Resources.TurnoutLeftUpNormal
                    Case OCC
                        If SWL11LTK = NORLT Then
                            picTurnout9Up.Image = Global.KCSubCTCV3.My.Resources.TurnoutLeftUpNormalRed
                        End If
                    Case RTD
                        If SWL11LTK = NORLT Then
                            picTurnout9Up.Image = Global.KCSubCTCV3.My.Resources.TurnoutLeftUpNormalGreen
                        End If
                End Select
            Case REVLT
                Turnout9SavedDownPic.Image = KCSubCTCV3.My.Resources.TurnoutLeftDownReverse
                Turnout9SavedUpPic.Image = KCSubCTCV3.My.Resources.TurnoutLeftUpReverse
                Select Case Block7
                    Case CLR
                        picTurnout9Down.Image = Global.KCSubCTCV3.My.Resources.TurnoutLeftDownReverse
                    Case OCC
                        picTurnout9Down.Image = Global.KCSubCTCV3.My.Resources.TurnoutLeftDownReverseRed
                    Case RTD
                        picTurnout9Down.Image = Global.KCSubCTCV3.My.Resources.TurnoutLeftDownReverseGreen
                End Select
                Select Case Block8
                    Case CLR
                        picTurnout9Up.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftUpReverse
                    Case OCC
                        picTurnout9Up.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftUpReverseRed
                    Case RTD
                        picTurnout9Up.Image = Global.KCSubCTCV3.My.Resources.TurnoutLeftUpReverseGreen
                End Select
        End Select
    End Sub
    Sub UpdateTurnout11()
        Select Case SWL11LTK
            Case NORLT
                Turnout11SavedPic.Image = KCSubCTCV3.My.Resources.TurnoutLeftDownNormal
                Select Case Block8
                    Case CLR
                        picTurnout11.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownNormal
                    Case OCC
                        If SWL9LTK = NORLT Then
                            picTurnout11.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownNormalRed
                        End If
                    Case RTD
                        If SWL9LTK = NORLT Then
                            picTurnout11.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownNormalGreen
                        End If
                End Select
            Case REVLT
                Turnout11SavedPic.Image = KCSubCTCV3.My.Resources.TurnoutLeftDownReverse
                Select Case Block8
                    Case CLR
                        picTurnout11.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownReverse
                    Case OCC
                        If SWL9LTK = NORLT Then
                            picTurnout11.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownReverseRed
                        End If
                    Case RTD
                        If SWL9LTK = NORLT Then
                            picTurnout11.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftDownReverseGreen
                        End If
                End Select
        End Select
    End Sub
    Sub UpdateTurnout15()
        Select Case SWL15LTK
            Case NORLT
                Turnout15SavedPic.Image = KCSubCTCV3.My.Resources.TurnoutLeftUpNormal
                Select Case Block7
                    Case CLR
                        picTurnout15.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftUpNormal
                    Case OCC
                        picTurnout15.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftUpNormalRed
                    Case RTD
                        picTurnout15.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftUpNormalGreen
                End Select
            Case REVLT
                Turnout15SavedPic.Image = KCSubCTCV3.My.Resources.TurnoutLeftUpReverse
                Select Case Block7
                    Case CLR
                        picTurnout15.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftUpReverse
                    Case OCC
                        picTurnout15.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftUpReverseRed
                    Case RTD
                        picTurnout15.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutLeftUpReverseGreen
                End Select

        End Select
    End Sub
    Sub UpdateTurnout17()
        picLock17.Image = Global.KCSubCTCV3.My.Resources.LockLeftUpLocked
        If Block7 = OCC And SWL15LTK = REVLT Then
            picLock17.Image = Global.KCSubCTCV3.My.Resources.LockLeftUpOccupied
        End If
        If Block7 = RTD And SWL15LTK = REVLT Then
            picLock17.Image = Global.KCSubCTCV3.My.Resources.LockLeftUpGreen
        End If
        If UL17 = UNLOCKED Then
            picLock17.Image = Global.KCSubCTCV3.My.Resources.LockLeftUpUnlocked
        End If
    End Sub
    Sub UpdateTurnout19()
        picLock19.Image = KCSubCTCV3.My.Resources.LockLeftDownLocked
        If Block8 = OCC And SWL9LTK = NORLT Then
            picLock19.Image = KCSubCTCV3.My.Resources.LockLeftDownOccupied
        End If
        If Block8 = RTD And SWL9LTK = NORLT Then
            picLock19.Image = KCSubCTCV3.My.Resources.LockLeftDownGreen
        End If
        If UL19 = UNLOCKED Then
            picLock19.Image = KCSubCTCV3.My.Resources.LockLeftDownUnlocked
        End If
    End Sub
    Sub UpdateTurnout23()
        Select Case SWL23LTK
            Case NORLT
                Turnout23SavedUpPic.Image = KCSubCTCV3.My.Resources.TurnoutRightUpNormal
                Turnout23SavedDownPic.Image = KCSubCTCV3.My.Resources.TurnoutRightDownNormal
                Select Case Block3
                    Case CLR
                        picTurnout23Down.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightDownNormal
                    Case OCC
                        picTurnout23Down.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightDownNormalRed
                    Case RTD
                        picTurnout23Down.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightDownNormalGreen
                End Select
                Select Case Block4
                    Case CLR
                        picTurnout23Up.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpNormal
                    Case OCC
                        If SWL25LTK = NORLT Then
                            picTurnout23Up.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpNormalRed
                        End If
                    Case RTD
                        If SWL25LTK = NORLT Then
                            picTurnout23Up.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpNormalGreen
                        End If
                End Select
            Case REVLT
                Turnout23SavedDownPic.Image = KCSubCTCV3.My.Resources.TurnoutRightDownReverse
                Turnout23SavedUpPic.Image = KCSubCTCV3.My.Resources.TurnoutRightUpReverse
                Select Case Block3
                    Case CLR
                        picTurnout23Down.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightDownReverse
                    Case OCC
                        picTurnout23Down.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightDownReverseRed
                    Case RTD
                        picTurnout23Down.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightDownReverseGreen
                End Select
                Select Case Block4
                    Case CLR
                        picTurnout23Up.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpReverse
                    Case OCC
                        picTurnout23Up.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpReverseRed
                    Case RTD
                        picTurnout23Up.Image = Global.KCSubCTCV3.My.Resources.Resources.TurnoutRightUpReverseGreen
                End Select
        End Select
    End Sub
    Sub UpdateTurnout25()
        picLock25Down.Image = KCSubCTCV3.My.Resources.TurnoutRightDownNormal
        Turnout25SavedPic.Image = KCSubCTCV3.My.Resources.TurnoutRightDownNormal
        picLock25Up.Image = KCSubCTCV3.My.Resources.LockRightUpLocked
        Select Case Block4
            Case CLR
                If SWL25LTK = LNOR Then
                    picLock25Down.Image = KCSubCTCV3.My.Resources.TurnoutRightDownNormal
                End If
                If SWL25LTK = LREV Then
                    picLock25Down.Image = KCSubCTCV3.My.Resources.TurnoutRightDownReverse
                End If
            Case RTD And TLV26 <> NDT
                If SWL25LTK = LNOR And SWL23LTK = LNOR Then
                    picLock25Down.Image = KCSubCTCV3.My.Resources.TurnoutRightDownNormalGreen
                End If
                If SWL25LTK = LREV Then
                    picLock25Down.Image = KCSubCTCV3.My.Resources.TurnoutRightDownReverseGreen
                End If
            Case OCC
                If SWL25LTK = LNOR And SWL23LTK = LNOR Then
                    picLock25Down.Image = KCSubCTCV3.My.Resources.TurnoutRightDownNormalRed
                End If
                If SWL25LTK = LREV Then
                    picLock25Down.Image = KCSubCTCV3.My.Resources.TurnoutRightDownReverseRed
                End If
                If SWL23LTK = LREV Then
                    picTurnout23Up.Image = KCSubCTCV3.My.Resources.TurnoutRightUpReverseRed
                End If
        End Select

        If SWL25LTK = LREV Then
            'Turnout25SavedPic.Image = KCSubCTCV3.My.Resources.TurnoutRightDownReverse
            'picLock25Down.Image = KCSubCTCV3.My.Resources.TurnoutRightDownReverse
            picLock25Up.Image = KCSubCTCV3.My.Resources.LockRightUpUnlocked
        End If
    End Sub
    Sub UpdateBlocksFromRead()
        Select Case CDEIND
            Case 0
                lineControl.BorderColor = Color.White
                lineIndicate.BorderColor = Color.White
            Case 1
                lineIndicate.BorderColor = Color.Red
                lineControl.BorderColor = Color.White
            Case 2
                lineControl.BorderColor = Color.Red
                lineIndicate.BorderColor = Color.White
        End Select
        ' Follow occupancy detectors
        ' If doing an indication code, don't process office functions.
        If CDEIND = 1 Then
            Exit Sub
        End If
        Block1 = BK1
        Block2 = BK2
        Block3 = BK3
        Block4 = BK4
        Block5 = BK5
        Block6 = BK6
        Block7 = BK7
        Block8 = BK8
        Block9 = BK9
        Block10 = BK10
    End Sub
    Sub UpdateSignals()
        If CDEIND = 1 Then
            Exit Sub
        End If
        UpdateSignal4()
        UpdateSignal8()
        UpdateSignal10()
        UpdateSignal12()
        UpdateSignal24()
        UpdateSignal26()
    End Sub
    Sub UpdateSignal4()

        Select Case SGL4LTK 'SGL4LT = RIGHTLT
            Case LEFTLT

                Signal4Selected = picSig4L
                Sig4Dir = LEFTLT
                picSig4RA.Image = KCSubCTCV3.My.Resources.RedRight
                picSig4RB.Image = KCSubCTCV3.My.Resources.RedRight
                picSig4L.Image = KCSubCTCV3.My.Resources.GreenLeft
            Case RIGHTLT

                Sig4Dir = RIGHTLT
                If SWL3LTK = NORLT Then
                    Signal4Selected = picSig4RA
                    picSig4RA.Image = KCSubCTCV3.My.Resources.GreenRight
                    picSig4RB.Image = KCSubCTCV3.My.Resources.RedRight
                    picSig4L.Image = KCSubCTCV3.My.Resources.RedLeft
                Else
                    Signal4Selected = picSig4RB
                    picSig4RA.Image = KCSubCTCV3.My.Resources.RedRight
                    picSig4RB.Image = KCSubCTCV3.My.Resources.GreenRight
                    picSig4L.Image = KCSubCTCV3.My.Resources.RedLeft
                End If
            Case STOPLT
                picSig4RA.Image = KCSubCTCV3.My.Resources.RedRight
                picSig4RB.Image = KCSubCTCV3.My.Resources.RedRight
                picSig4L.Image = KCSubCTCV3.My.Resources.RedLeft
                Signal4Selected = Nothing
            Case DARKLT
                ' see if running time

        End Select

    End Sub
    Sub UpdateSignal8()

        Select Case SGL8LTK
            Case LEFTLT
                Sig8Dir = LEFTLT

                picSig8RA.Image = KCSubCTCV3.My.Resources.RedRight
                picSig8RB.Image = KCSubCTCV3.My.Resources.RedRight
                If SWL15LTK = NORLT Then
                    Signal8Selected = picSig8LA
                    picSig8LA.Image = KCSubCTCV3.My.Resources.GreenLeft
                    picSig8LB.Image = KCSubCTCV3.My.Resources.RedLeft
                Else
                    Signal8Selected = picSig8LB
                    picSig8LA.Image = KCSubCTCV3.My.Resources.RedLeft
                    picSig8LB.Image = KCSubCTCV3.My.Resources.GreenLeft
                End If
            Case RIGHTLT
                Sig8Dir = RIGHTLT

                picSig8LA.Image = KCSubCTCV3.My.Resources.RedLeft
                picSig8LB.Image = KCSubCTCV3.My.Resources.RedLeft
                If SWL7LTK = NORLT Then
                    Signal8Selected = picSig8RA
                    picSig8RA.Image = KCSubCTCV3.My.Resources.GreenRight
                    picSig8RB.Image = KCSubCTCV3.My.Resources.RedRight
                Else
                    Signal8Selected = picSig8RB
                    picSig8RA.Image = KCSubCTCV3.My.Resources.RedRight
                    picSig8RB.Image = KCSubCTCV3.My.Resources.GreenRight
                End If
            Case STOPLT
                picSig8RA.Image = KCSubCTCV3.My.Resources.RedRight
                picSig8RB.Image = KCSubCTCV3.My.Resources.RedRight
                picSig8LA.Image = KCSubCTCV3.My.Resources.RedLeft
                picSig8LB.Image = KCSubCTCV3.My.Resources.RedLeft
                Signal8Selected = Nothing
            Case DARKLT
                ' what goes here
        End Select
    End Sub
    Sub UpdateSignal10()
        Select Case SGL10LTK
            Case LEFTLT
                Sig10Dir = LEFTLT
                picSig10L.Image = KCSubCTCV3.My.Resources.GreenLeft
                Signal10Selected = picSig10L
            Case RIGHTLT
                Sig10Dir = RIGHTLT
                Signal10Selected = picSig10R
                picSig10R.Image = KCSubCTCV3.My.Resources.GreenRight
            Case STOPLT
                picSig10L.Image = KCSubCTCV3.My.Resources.RedLeft
                picSig10R.Image = KCSubCTCV3.My.Resources.RedRight
                Signal10Selected = Nothing
        End Select
    End Sub
    Sub UpdateSignal12()
        Select Case SGL12LTK
            Case LEFTLT
                ' *** never true
            Case RIGHTLT
                Sig12Dir = RIGHTLT
                Signal12Selected = picSig12R
                picSig12R.Image = KCSubCTCV3.My.Resources.GreenRight
            Case STOPLT
                picSig12R.Image = KCSubCTCV3.My.Resources.RedRight
                Signal12Selected = Nothing
        End Select
    End Sub



    Private Sub lblCoburgWest_Click(sender As Object, e As EventArgs) Handles lblBlock11.Click
        Dim trainID As String
        trainID = InputBox("Enter the Train ID", "Assign departing train to block.", "None")
        If trainID <> "None" Then
            lblBlock11.Text = trainID
            LogTrain(trainID + " called, on duty.")
        End If
    End Sub


    Sub UpdateSignal24()
        Select Case SGL24LTK
            Case LEFTLT
                Sig24Dir = LEFTLT
                Signal24Selected = picSig24L
                picSig24L.Image = KCSubCTCV3.My.Resources.GreenLeft
            Case RIGHTLT
                Sig24Dir = RIGHTLT
                Signal24Selected = picSig24R
                picSig24R.Image = KCSubCTCV3.My.Resources.GreenRight
            Case STOPLT
                Signal24Selected = Nothing
                picSig24L.Image = KCSubCTCV3.My.Resources.RedLeft
                picSig24R.Image = KCSubCTCV3.My.Resources.RedRight
        End Select
    End Sub
    Sub UpdateSignal26()
        Select Case SGL26LTK
            Case LEFTLT
                Sig26Dir = LEFTLT
                If SWL25LTK = LNOR Then
                    Signal26Selected = picSig26LA
                    picSig26LA.Image = KCSubCTCV3.My.Resources.GreenLeft
                Else
                    Signal26Selected = picSig26LB
                    picSig26LB.Image = KCSubCTCV3.My.Resources.GreenLeft
                End If
            Case RIGHTLT
                Sig26Dir = RIGHTLT
                Signal26Selected = picSig26R
                picSig26R.Image = KCSubCTCV3.My.Resources.GreenRight
            Case STOPLT
                Signal26Selected = Nothing
                picSig26LA.Image = KCSubCTCV3.My.Resources.RedLeft
                picSig26LB.Image = KCSubCTCV3.My.Resources.RedLeft
                picSig26R.Image = KCSubCTCV3.My.Resources.RedRight
        End Select
    End Sub
    Sub UpdateTrafficSticks()
        If CDEIND = 1 Then
            Exit Sub
        End If

        UpdateTrafficFS1()
        UpdateTrafficFS2()
        UpdateTrafficFS3()
        UpdateTrafficFS4()
        UpdateTrafficFS5()
        UpdateTrafficFS6()
        UpdateTrafficFS7()
        UpdateTrafficFS8()
        UpdateTrafficFS9()

    End Sub

    Private Sub UpdateTrafficFS9()
        If FS9 = NDT Then
            If Block9 = OCC Then
                picTraffic9West.Image = My.Resources.TrafficOccupiedEastEnd
                If SWL3LTK = LNOR Then
                    picTraffic9EastA.Image = My.Resources.TrafficOccupiedWestEnd
                Else
                    picTraffic9EastB.Image = My.Resources.TrafficOccupiedWestEnd
                End If
            Else
                picTraffic9West.Image = My.Resources.TrafficNoneWest
                picTraffic9EastA.Image = My.Resources.TrafficNoneEast
                picTraffic9EastB.Image = My.Resources.TrafficNoneEast
            End If
        Else
            If FS9 = EAST Then
                If Block9 = OCC Then
                    picTraffic9West.Image = My.Resources.TrafficOccupiedEastEnd
                    If SWL3LTK = LNOR Then
                        picTraffic9EastA.Image = My.Resources.TrafficOccupiedEast
                    Else
                        picTraffic9EastB.Image = My.Resources.TrafficOccupiedEast
                    End If
                Else
                    picTraffic9West.Image = My.Resources.TrafficClearedEastEnd
                    If SWL3LTK = LNOR Then
                        picTraffic9EastA.Image = My.Resources.TrafficClearedEast
                    Else
                        picTraffic9EastB.Image = My.Resources.TrafficClearedEast
                    End If

                End If
            Else
                If Block9 = OCC Then
                    picTraffic9West.Image = My.Resources.TrafficOccupiedWest
                    If SWL3LTK = LNOR Then
                        picTraffic9EastA.Image = My.Resources.TrafficOccupiedWestEnd
                    Else
                        picTraffic9EastB.Image = My.Resources.TrafficOccupiedWestEnd
                    End If
                Else
                    picTraffic9West.Image = My.Resources.TrafficClearedWest
                    If SWL3LTK = LNOR Then
                        picTraffic9EastA.Image = My.Resources.TrafficClearedWestEnd
                    Else
                        picTraffic9EastB.Image = My.Resources.TrafficClearedWestEnd
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub UpdateTrafficFS8()
        If FS8 = NDT Then
            If Block8 = OCC Then
                picTraffic8West.Image = My.Resources.TrafficOccupiedEastEnd
                picTraffic8East.Image = My.Resources.TrafficOccupiedWestEnd
            Else
                picTraffic8West.Image = My.Resources.TrafficNoneWest
                picTraffic8East.Image = My.Resources.TrafficNoneEast
            End If
        Else
            If FS8 = EAST Then
                If Block8 = OCC Then
                    picTraffic8West.Image = My.Resources.TrafficOccupiedEastEnd
                    picTraffic8East.Image = My.Resources.TrafficOccupiedEast
                Else
                    picTraffic8West.Image = My.Resources.TrafficClearedEastEnd
                    picTraffic8East.Image = My.Resources.TrafficClearedEast
                End If
            Else
                If Block8 = OCC Then
                    picTraffic8West.Image = My.Resources.TrafficOccupiedWest
                    If SWL11LTK = LNOR Then
                        picTraffic8East.Image = My.Resources.TrafficOccupiedWestEnd
                    End If

                Else
                    If SWL9LTK = LNOR Then
                        picTraffic8West.Image = My.Resources.TrafficClearedWest
                    End If
                    picTraffic8East.Image = My.Resources.TrafficClearedWestEnd
                End If
            End If
        End If
    End Sub

    Private Sub UpdateTrafficFS7()
        ' Block 7
        If FS7 = NDT Then
            If Block7 = OCC Then
                If SWL15LTK = LNOR Then
                    picTraffic7WestA.Image = My.Resources.TrafficOccupiedWestEnd

                Else
                    picTraffic7WestB.Image = My.Resources.TrafficOccupiedWestEnd
                End If
                If SWL7LTK = LNOR Then
                    If SWL9LTK = LNOR Then
                        picTraffic7EastA.Image = My.Resources.TrafficOccupiedEastEnd
                    End If
                Else
                    picTraffic7EastB.Image = My.Resources.TrafficOccupiedEastEnd
                End If
            Else
                picTraffic7WestA.Image = My.Resources.TrafficNoneWest
                picTraffic7EastA.Image = My.Resources.TrafficNoneEast
                picTraffic7WestB.Image = My.Resources.TrafficNoneWest
                picTraffic7EastB.Image = My.Resources.TrafficNoneEast
            End If
        Else
            If FS7 = EAST Then
                If Block7 = OCC Then
                    If SWL15LTK = LNOR Then
                        picTraffic7WestA.Image = My.Resources.TrafficOccupiedWestEnd
                    Else
                        picTraffic7WestB.Image = My.Resources.TrafficOccupiedWestEnd
                    End If

                    picTraffic7EastA.Image = My.Resources.TrafficOccupiedEast
                Else
                    ' block routed and east
                    If SWL7LTK = LNOR Then
                        If SWL9LTK = LNOR Then
                            picTraffic7EastA.Image = My.Resources.TrafficClearedEast
                        End If
                    Else
                        picTraffic7EastB.Image = My.Resources.TrafficClearedEast
                    End If
                    If SWL15LTK = LNOR Then
                        picTraffic7WestA.Image = My.Resources.TrafficClearedEastEnd
                    Else
                        picTraffic7WestB.Image = My.Resources.TrafficClearedEastEnd
                    End If
                End If
            Else
                ' cleared west
                If Block7 = OCC Then
                    If SWL15LTK = LNOR Then
                        picTraffic7WestA.Image = My.Resources.TrafficOccupiedWest
                    Else
                        picTraffic7WestB.Image = My.Resources.TrafficOccupiedWest
                    End If
                    If SWL7LTK = LNOR Then
                        If SWL9LTK = LNOR Then
                            picTraffic7EastA.Image = My.Resources.TrafficOccupiedWestEnd
                        End If
                    Else
                        picTraffic7EastB.Image = My.Resources.TrafficOccupiedWestEnd
                    End If
                Else
                    'cleared not occupied
                    If SWL7LTK = LNOR Then
                        If SWL9LTK = LNOR Then
                            picTraffic7EastA.Image = My.Resources.TrafficClearedWestEnd
                        End If
                    Else
                        picTraffic7EastB.Image = My.Resources.TrafficClearedWestEnd
                    End If
                    If SWL15LTK = LNOR Then
                        picTraffic7WestA.Image = My.Resources.TrafficClearedWest
                    Else
                        picTraffic7WestB.Image = My.Resources.TrafficClearedWest
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub UpdateTrafficFS6()
        If FS6 = NDT Then
            If Block6 = OCC Then
                picTraffic6AWest.Image = My.Resources.TrafficOccupiedEastEnd
                picTraffic6AEast.Image = My.Resources.TrafficOccupiedWestEnd
                picTraffic6BWest.Image = My.Resources.TrafficOccupiedEastEnd
                picTraffic6BEast.Image = My.Resources.TrafficOccupiedWestEnd
            Else
                picTraffic6AWest.Image = My.Resources.TrafficNoneWest
                picTraffic6AEast.Image = My.Resources.TrafficNoneEast
                picTraffic6BWest.Image = My.Resources.TrafficNoneWest
                picTraffic6BEast.Image = My.Resources.TrafficNoneEast
            End If

        Else
            If FS6 = EAST Then
                ' "<< East"
                If Block6 = OCC Then
                    picTraffic6AWest.Image = My.Resources.TrafficOccupiedEastEnd
                    picTraffic6AEast.Image = My.Resources.TrafficOccupiedEast
                    picTraffic6BWest.Image = My.Resources.TrafficOccupiedEastEnd
                    picTraffic6BEast.Image = My.Resources.TrafficOccupiedEast
                Else
                    picTraffic6AWest.Image = My.Resources.TrafficClearedEastEnd
                    picTraffic6AEast.Image = My.Resources.TrafficClearedEast
                    picTraffic6BWest.Image = My.Resources.TrafficClearedEastEnd
                    picTraffic6BEast.Image = My.Resources.TrafficClearedEast
                End If

            Else
                ' "West >>"
                If Block6 = OCC Then
                    picTraffic6AWest.Image = My.Resources.TrafficOccupiedWest
                    picTraffic6AEast.Image = My.Resources.TrafficOccupiedWestEnd
                    picTraffic6BWest.Image = My.Resources.TrafficOccupiedWest
                    picTraffic6BEast.Image = My.Resources.TrafficOccupiedWestEnd
                Else
                    picTraffic6AWest.Image = My.Resources.TrafficClearedWest
                    picTraffic6AEast.Image = My.Resources.TrafficClearedWestEnd
                    picTraffic6BWest.Image = My.Resources.TrafficClearedWest
                    picTraffic6BEast.Image = My.Resources.TrafficClearedWestEnd
                End If
            End If
        End If
    End Sub

    Private Sub UpdateTrafficFS5()
        If FS5 = NDT Then
            If Block5 = OCC Then
                picTraffic5AWest.Image = My.Resources.TrafficOccupiedEastEnd
                picTraffic5AEast.Image = My.Resources.TrafficOccupiedWestEnd
                picTraffic5BWest.Image = My.Resources.TrafficOccupiedEastEnd
                picTraffic5BEast.Image = My.Resources.TrafficOccupiedWestEnd
            Else
                picTraffic5AWest.Image = My.Resources.TrafficNoneWest
                picTraffic5AEast.Image = My.Resources.TrafficNoneEast
                picTraffic5BWest.Image = My.Resources.TrafficNoneWest
                picTraffic5BEast.Image = My.Resources.TrafficNoneEast
            End If

        Else
            If FS5 = EAST Then
                ' "<< East"
                If Block5 = OCC Then
                    picTraffic5AWest.Image = My.Resources.TrafficOccupiedEastEnd
                    picTraffic5AEast.Image = My.Resources.TrafficOccupiedEast
                    picTraffic5BWest.Image = My.Resources.TrafficOccupiedEastEnd
                    picTraffic5BEast.Image = My.Resources.TrafficOccupiedEast
                Else
                    picTraffic5AWest.Image = My.Resources.TrafficClearedEastEnd
                    picTraffic5AEast.Image = My.Resources.TrafficClearedEast
                    picTraffic5BWest.Image = My.Resources.TrafficClearedEastEnd
                    picTraffic5BEast.Image = My.Resources.TrafficClearedEast
                End If

            Else
                ' "West >>"
                If Block5 = OCC Then
                    picTraffic5AWest.Image = My.Resources.TrafficOccupiedWest
                    picTraffic5AEast.Image = My.Resources.TrafficOccupiedWestEnd
                    picTraffic5BWest.Image = My.Resources.TrafficOccupiedWest
                    picTraffic5BEast.Image = My.Resources.TrafficOccupiedWestEnd
                Else
                    picTraffic5AWest.Image = My.Resources.TrafficClearedWest
                    picTraffic5AEast.Image = My.Resources.TrafficClearedWestEnd
                    picTraffic5BWest.Image = My.Resources.TrafficClearedWest
                    picTraffic5BEast.Image = My.Resources.TrafficClearedWestEnd
                End If
            End If
        End If

    End Sub
    Private Sub UpdateTrafficFS4()
        Select Case FS4
            Case NDT
                If Block4 = OCC Then
                    If SWL23LTK = LNOR And SWL25LTK = LNOR Then
                        picTraffic4West.Image = My.Resources.TrafficOccupiedEastEnd
                        picTraffic4East.Image = My.Resources.TrafficOccupiedWestEnd
                    End If
                    If SWL23LTK = LREV And SWL25LTK = LNOR Then
                        picTraffic4West.Image = My.Resources.TrafficOccupiedEastEnd
                        'picTraffic4East.Image = My.Resources.TrafficOccupiedWestEnd
                    End If
                    If SWL23LTK = LNOR And SWL25LTK = LREV Then
                        'picTraffic4West.Image = My.Resources.TrafficOccupiedEastEnd
                        picTraffic4East.Image = My.Resources.TrafficOccupiedWestEnd
                    End If
                    If SWL23LTK = LREV And SWL25LTK = LREV Then
                        picTraffic4West.Image = My.Resources.TrafficOccupiedEastEnd
                        picTraffic4East.Image = My.Resources.TrafficOccupiedWestEnd
                    End If

                Else
                    picTraffic4West.Image = My.Resources.TrafficNoneWest
                    picTraffic4East.Image = My.Resources.TrafficNoneEast
                End If
            Case EAST
                If Block4 = OCC Then
                    If SWL23LTK = LNOR Then
                        picTraffic4East.Image = My.Resources.TrafficOccupiedEast
                    End If
                    If SWL23LTK = LREV And SWL25LTK = LREV Then
                        picTraffic4East.Image = My.Resources.TrafficOccupiedEast
                    End If
                    picTraffic4West.Image = My.Resources.TrafficOccupiedEastEnd

                Else
                    If SWL25LTK = LNOR And BK3 = CLR Then
                        picTraffic4West.Image = My.Resources.TrafficClearedEastEnd
                    End If
                    If SWL23LTK = LREV And BK3 = OCC Then
                        ' train is still routed, but cleared from block 4 and not block 3.
                        picTraffic4West.Image = My.Resources.TrafficNoneWest
                    End If
                    If SWL23LTK = LNOR Then
                        picTraffic4East.Image = My.Resources.TrafficClearedEast
                    End If
                End If

            Case WEST
                If Block4 = OCC Then
                    If SWL25LTK = LNOR And SWL23LTK = LNOR Then
                        picTraffic4West.Image = My.Resources.TrafficOccupiedWest
                        picTraffic4East.Image = My.Resources.TrafficOccupiedWestEnd
                    End If
                    If SWL25LTK = LREV And SWL23LTK = LNOR Then
                        picTraffic4West.Image = My.Resources.TrafficOccupiedWest
                        picTraffic4East.Image = My.Resources.TrafficOccupiedWestEnd
                    End If
                    If SWL25LTK = LNOR And SWL23LTK = LREV Then
                        picTraffic4West.Image = My.Resources.TrafficOccupiedWest
                        'picTraffic4East.Image = My.Resources.TrafficOccupiedWestEnd
                    End If
                    If SWL25LTK = LREV And SWL23LTK = LREV Then
                        picTraffic4West.Image = My.Resources.TrafficOccupiedWest
                        picTraffic4East.Image = My.Resources.TrafficOccupiedWestEnd
                    End If
                Else
                    If SWL25LTK = LNOR And SWL23LTK = LNOR Then
                        picTraffic4West.Image = My.Resources.TrafficClearedWest
                    End If
                    If SIG24RAB = REDGRN Then
                        picTraffic4West.Image = My.Resources.TrafficClearedWest
                    End If
                    If SIG26RAB <> REDRED Then
                        picTraffic4East.Image = My.Resources.TrafficClearedWestEnd
                    End If
                End If
            Case Else
                ' nuffin
        End Select

    End Sub

    Private Sub UpdateTrafficFS3()
        If FS3 = NDT Then
            If Block3 = OCC Then
                If SWL23LTK = LNOR Then
                    picTraffic3West.Image = My.Resources.TrafficOccupiedEastEnd
                    picTraffic3East.Image = My.Resources.TrafficOccupiedWestEnd
                Else
                    picTraffic3East.Image = My.Resources.TrafficOccupiedWestEnd
                End If

            Else
                    picTraffic3West.Image = My.Resources.TrafficNoneWest
                picTraffic3East.Image = My.Resources.TrafficNoneEast
            End If
        Else
            If FS3 = EAST Then
                If Block3 = OCC Then
                    If SWL23LTK = LNOR Then
                        picTraffic3West.Image = My.Resources.TrafficOccupiedEastEnd
                    End If
                    picTraffic3East.Image = My.Resources.TrafficOccupiedEast
                Else
                    If SWL23LTK = LNOR Then
                        picTraffic3West.Image = My.Resources.TrafficClearedEastEnd
                    End If
                    picTraffic3East.Image = My.Resources.TrafficClearedEast
                End If
            Else
                If Block3 = OCC Then
                    If SWL23LTK = LNOR Then
                        picTraffic3West.Image = My.Resources.TrafficOccupiedWest
                    End If
                    picTraffic3East.Image = My.Resources.TrafficOccupiedWestEnd
                Else
                    If SWL23LTK = LNOR Then
                        picTraffic3West.Image = My.Resources.TrafficClearedWest
                    End If
                    picTraffic3East.Image = My.Resources.TrafficClearedWestEnd
                End If
            End If
        End If
    End Sub

    Private Sub UpdateTrafficFS2()
        If FS2 = NDT Then
            If Block2 = OCC Then
                picTraffic2West.Image = My.Resources.TrafficOccupiedEastEnd
                picTraffic2East.Image = My.Resources.TrafficOccupiedWestEnd
            Else
                picTraffic2West.Image = My.Resources.TrafficNoneWest
                picTraffic2East.Image = My.Resources.TrafficNoneEast
            End If
        Else
            If FS2 = EAST Then
                If Block2 = OCC Then
                    picTraffic2West.Image = My.Resources.TrafficOccupiedEastEnd
                    picTraffic2East.Image = My.Resources.TrafficOccupiedEast
                Else
                    picTraffic2West.Image = My.Resources.TrafficClearedEastEnd
                    picTraffic2East.Image = My.Resources.TrafficClearedEast
                End If
            Else
                If Block2 = OCC Then
                    picTraffic2West.Image = My.Resources.TrafficOccupiedWest
                    picTraffic2East.Image = My.Resources.TrafficOccupiedWestEnd
                Else
                    picTraffic2West.Image = My.Resources.TrafficClearedWest
                    picTraffic2East.Image = My.Resources.TrafficClearedWestEnd
                End If
            End If
        End If
    End Sub

    Private Sub UpdateTrafficFS1()
        If FS1 = NDT Then
            If Block1 = OCC Then
                picTraffic1West.Image = My.Resources.TrafficOccupiedEastEnd
                picTraffic1East.Image = My.Resources.TrafficOccupiedWestEnd
            Else
                picTraffic1West.Image = My.Resources.TrafficNoneWest
                picTraffic1East.Image = My.Resources.TrafficNoneEast
            End If
        Else
            If FS1 = EAST Then
                If Block1 = OCC Then
                    picTraffic1West.Image = My.Resources.TrafficOccupiedEastEnd
                    picTraffic1East.Image = My.Resources.TrafficOccupiedEast
                Else
                    picTraffic1West.Image = My.Resources.TrafficClearedEastEnd
                    picTraffic1East.Image = My.Resources.TrafficClearedEast
                End If
            Else
                If Block1 = OCC Then
                    picTraffic1West.Image = My.Resources.TrafficOccupiedWest
                    picTraffic1East.Image = My.Resources.TrafficOccupiedWestEnd
                Else
                    picTraffic1West.Image = My.Resources.TrafficClearedWest
                    picTraffic1East.Image = My.Resources.TrafficClearedWestEnd
                End If
            End If
        End If

    End Sub

    Private Sub lineCentropolis_Click(sender As Object, e As EventArgs) Handles lineCentropolis.Click
        SelectedBlock = 13
        If InputTrainID(SelectedBlock) Then
            LogTrain(TrainID(SelectedBlock) + " called, on duty.")
        End If
    End Sub

    Private Sub lineCoburgWest_Click(sender As Object, e As EventArgs) Handles lineCoburgWest.Click
        SelectedBlock = 11
        If InputTrainID(SelectedBlock) Then
            LogTrain(TrainID(SelectedBlock) + " called, on duty.")
        End If
    End Sub

    Private Sub lineCoburgEast_Click(sender As Object, e As EventArgs) Handles lineCoburgEast.Click
        SelectedBlock = 12
        If InputTrainID(SelectedBlock) Then
            LogTrain(TrainID(SelectedBlock) + " called, on duty.")
        End If
    End Sub

    Private Sub lineOttumwa_Click(sender As Object, e As EventArgs) Handles lineOttumwa.Click
        SelectedBlock = 14
        If InputTrainID(SelectedBlock) Then
            LogTrain(TrainID(SelectedBlock) + " called, on duty.")
        End If
    End Sub

    Sub UpdateBlockOccupancyLines()
        If CDEIND = 1 Then
            Exit Sub
        End If
        UpdateBlock1()
        UpdateBlock2()
        UpdateBlock3()
        UpdateBlock4()
        UpdateBlock5()
        UpdateBlock6()
        UpdateBlock7()
        UpdateBlock8()
        UpdateBlock9()
        UpdateBlock10()
    End Sub
    Private Sub UpdateBlock1()
        If FS1 = WEST Then
            If Block1 = CLR Then Block1 = RTD
        End If
        If FS1 = EAST Then
            If Block1 = CLR Then Block1 = RTD
        End If
        Select Case Block1
            Case OCC
                lineBlock1A.BorderColor = Color.Red
            Case CLR
                lineBlock1A.BorderColor = Color.White
            Case RTD
                lineBlock1A.BorderColor = Color.Green
        End Select
    End Sub
    Private Sub UpdateBlock2()
        If FS2 = WEST Or FS2 = EAST Then
            If Block2 = CLR Then Block2 = RTD
        End If
        Select Case Block2
            Case OCC
                lineBlock2A.BorderColor = Color.Red
            Case CLR
                lineBlock2A.BorderColor = Color.White
            Case RTD
                lineBlock2A.BorderColor = Color.Green
        End Select
    End Sub
    Private Sub UpdateBlock3()
        If TLV24 <> NV Then
            If Block3 = CLR Then Block3 = RTD
        End If
        If TLV26 = EAST And SWL23LTK = LREV Then
            If Block3 = CLR Then Block3 = RTD
        End If
        If Block4 = OCC And SWL23LTK = LREV And FS3 = EAST Then
            If Block3 = CLR Then Block3 = RTD
        End If
        Select Case Block3
            Case OCC
                lineBlock3A.BorderColor = Color.Red
                If SWL23LTK = NORLT Then
                    lineBlock3B.BorderColor = Color.Red
                    lineBlock3R.BorderColor = Color.White
                Else
                    lineBlock3B.BorderColor = Color.White
                    lineBlock3R.BorderColor = Color.Red
                End If
            Case CLR
                lineBlock3A.BorderColor = Color.White
                lineBlock3B.BorderColor = Color.White
                lineBlock3R.BorderColor = Color.White
            Case RTD
                lineBlock3A.BorderColor = Color.Green
                If SWL23LTK = NORLT Then
                    lineBlock3B.BorderColor = Color.Green
                    lineBlock3R.BorderColor = Color.White
                Else
                    lineBlock3B.BorderColor = Color.White
                    lineBlock3R.BorderColor = Color.Green
                End If
        End Select
    End Sub
    Private Sub UpdateBlock4()
        If TLV26 <> NV Then
            If Block4 = CLR Then Block4 = RTD
        End If
        If TLV24 = WEST And SWL23LTK = LREV Then
            If Block4 = CLR Then Block4 = RTD
        End If
        If Block3 = OCC And SWL23LTK = LREV And FS6 = WEST Then
            If Block4 = CLR Then Block4 = RTD
        End If
        Select Case Block4
            Case OCC
                If SWL23LTK = NORLT Then
                    lineBlock4A.BorderColor = Color.Red
                End If
                If SWL23LTK = NORLT And SWL25LTK = NORLT Then
                    lineBlock4B.BorderColor = Color.Red
                    lineBlock4C.BorderColor = Color.Red
                End If
                If SWL23LTK = REVLT Then
                    lineBlock4R.BorderColor = Color.Red
                    lineBlock4C.BorderColor = Color.Red
                End If
                If SWL25LTK = REVLT Then
                    lineBlock4A.BorderColor = Color.Red
                    lineBlock4D.BorderColor = Color.Red
                    YardInterchange.BorderColor = Color.Red
                End If
            Case CLR
                lineBlock4A.BorderColor = Color.White
                lineBlock4B.BorderColor = Color.White
                lineBlock4C.BorderColor = Color.White
                lineBlock4D.BorderColor = Color.White
                lineBlock4R.BorderColor = Color.White
                YardInterchange.BorderColor = Color.White
            Case RTD
                If SWL23LTK = NORLT Then
                    lineBlock4A.BorderColor = Color.Green
                End If
                If SWL23LTK = NORLT And SWL25LTK = NORLT Then
                    lineBlock4B.BorderColor = Color.Green
                    lineBlock4C.BorderColor = Color.Green
                End If
                If SWL23LTK = REVLT Then
                    lineBlock4R.BorderColor = Color.Green
                    lineBlock4C.BorderColor = Color.Green
                End If
                If SWL25LTK = REVLT And SIG26RAB <> REDRED Then
                    lineBlock4D.BorderColor = Color.Green
                    YardInterchange.BorderColor = Color.Green
                End If
        End Select

    End Sub
    Private Sub UpdateBlock5()
        If FS5 <> NV Then
            If Block5 = CLR Then Block5 = RTD
        End If
        Select Case Block5
            Case OCC
                lineBlock5A.BorderColor = Color.Red
                lineBlock5B.BorderColor = Color.Red
            Case CLR
                lineBlock5A.BorderColor = Color.White
                lineBlock5B.BorderColor = Color.White
            Case RTD
                lineBlock5A.BorderColor = Color.Green
                lineBlock5B.BorderColor = Color.Green
        End Select

    End Sub
    Private Sub UpdateBlock6()
        If FS6 <> NV Then
            If Block6 = CLR Then Block6 = RTD
        End If

        Select Case Block6
            Case OCC
                lineBlock6A.BorderColor = Color.Red
                lineBlock6B.BorderColor = Color.Red
            Case CLR
                lineBlock6A.BorderColor = Color.White
                lineBlock6B.BorderColor = Color.White
            Case RTD
                lineBlock6A.BorderColor = Color.Green
                lineBlock6B.BorderColor = Color.Green
        End Select
    End Sub
    Private Sub UpdateBlock7()
        'If TLV8 = NV Then
        'If Block7 = RTD And SWL9LTK = NORLT Then
        'Block7 = CLR
        'End If
        'If Block8 = RTD And SWL9LTK = REVLT And Block7 = CLR Then
        'Block7 = CLR
        'End If
        'End If
        If FS7 <> NDT Then
            If Block7 = CLR Then Block7 = RTD
        End If
        ' If FS7 = WEST And SWL9LTK = LREV Then
        ' If Block7 = CLR Then Block7 = RTD
        ' End If
        ' If Block8 = OCC And SWL9LTK = LREV And FS7 = WEST Then
        ' If Block7 = CLR Then Block7 = RTD
        ' End If
        Select Case Block7
            Case OCC
                If SWL7LTK = NORLT And SWL9LTK = NORLT Then
                    lineBlock7A.BorderColor = Color.Red
                End If
                If SWL7LTK = REVLT And SWL9LTK = NORLT Then
                    lineBlock7E.BorderColor = Color.Red
                    lineBlock7D.BorderColor = Color.Red
                End If
                If SWL9LTK = REVLT Then
                    lineBlock7R.BorderColor = Color.Red
                End If
                If SWL15LTK = REVLT Then
                    lineBlock7H.BorderColor = Color.Red
                    lineBlock7G.BorderColor = Color.Red
                    lineBlock7F.BorderColor = Color.Red
                End If
                If SWL15LTK = NORLT Then
                    lineBlock7C.BorderColor = Color.Red
                End If
                lineBlock7B.BorderColor = Color.Red
            Case RTD
                If SWL7LTK = NORLT And SWL9LTK = NORLT Then
                    lineBlock7A.BorderColor = Color.Green
                End If
                If SWL7LTK = REVLT And SWL9LTK = NORLT Then
                    lineBlock7E.BorderColor = Color.Green
                    lineBlock7D.BorderColor = Color.Green
                End If
                If SWL9LTK = REVLT Then
                    lineBlock7R.BorderColor = Color.Green
                End If
                If SWL15LTK = REVLT Then
                    lineBlock7H.BorderColor = Color.Green
                    lineBlock7G.BorderColor = Color.Green
                    lineBlock7F.BorderColor = Color.Green
                End If
                If SWL15LTK = NORLT Then
                    lineBlock7C.BorderColor = Color.Green
                End If
                lineBlock7B.BorderColor = Color.Green
            Case CLR
                lineBlock7A.BorderColor = Color.White
                lineBlock7B.BorderColor = Color.White
                lineBlock7C.BorderColor = Color.White
                lineBlock7D.BorderColor = Color.White
                lineBlock7E.BorderColor = Color.White
                lineBlock7F.BorderColor = Color.White
                lineBlock7G.BorderColor = Color.White
                lineBlock7H.BorderColor = Color.White
                lineBlock7R.BorderColor = Color.White
        End Select
    End Sub
    Private Sub UpdateBlock8()
        ' If TLV8 = NV Then
        'If Block8 = RTD And SWL9LTK = REVLT And Block7 = CLR Then
        'Block8 = CLR
        'End If
        'Else
        'If Block8 = CLR And SWL9LTK = REVLT Then
        'Block8 = RTD
        'End If
        'End If
        If FS8 <> NDT And BK8 = CLR Then 'something is routed.
            Block8 = RTD
        End If

        If TLV10 <> CLR Then
            If Block8 = CLR Then Block8 = RTD
        End If
        If TLV12 <> NV Then
            If Block8 = CLR Then Block8 = RTD
        End If
        Select Case Block8
            Case OCC
                If SWL11LTK = NORLT Then
                    lineBlock8A.BorderColor = Color.Red
                End If
                If SWL9LTK = NORLT Then
                    lineBlock8B.BorderColor = Color.Red
                    lineBlock8C.BorderColor = Color.Red
                Else
                    lineBlock8R.BorderColor = Color.Red
                End If
                If SWL9LTK = REVLT Then
                    lineBlock8A.BorderColor = Color.Red
                End If
                If SWL9LTK = NORLT And SWL11LTK = REVLT Then
                    lineBlock8D.BorderColor = Color.Red
                    lineBlock8E.BorderColor = Color.Red
                End If
            Case RTD
                If SWL11LTK = NORLT Then
                    lineBlock8A.BorderColor = Color.Green
                End If
                If SWL9LTK = NORLT Then
                    lineBlock8B.BorderColor = Color.Green
                    lineBlock8C.BorderColor = Color.Green
                Else
                    lineBlock8R.BorderColor = Color.Green
                End If
                If SWL9LTK = REVLT Then
                    lineBlock8A.BorderColor = Color.Green
                End If
                If SWL9LTK = NORLT And SWL11LTK = REVLT Then
                    lineBlock8D.BorderColor = Color.Green
                    lineBlock8E.BorderColor = Color.Green
                End If
            Case CLR
                lineBlock8A.BorderColor = Color.White
                lineBlock8B.BorderColor = Color.White
                lineBlock8C.BorderColor = Color.White
                lineBlock8D.BorderColor = Color.White
                lineBlock8E.BorderColor = Color.White
                lineBlock8R.BorderColor = Color.White
        End Select

    End Sub
    Private Sub UpdateBlock9()
        If FS9 <> NV Then
            If Block9 = CLR Then Block9 = RTD
        End If
        Select Case Block9
            Case OCC
                If SWL3LTK = NORLT Then
                    lineBlock9A.BorderColor = Color.Red
                Else
                    lineBlock9B.BorderColor = Color.Red
                    lineBlock9C.BorderColor = Color.Red
                End If
                lineBlock9D.BorderColor = Color.Red
                lineBlock9E.BorderColor = Color.Red
                lineBlock9F.BorderColor = Color.Red
            Case RTD
                If SWL3LTK = NORLT Then
                    lineBlock9A.BorderColor = Color.Green
                Else
                    lineBlock9B.BorderColor = Color.Green
                    lineBlock9C.BorderColor = Color.Green
                End If
                lineBlock9D.BorderColor = Color.Green
                lineBlock9E.BorderColor = Color.Green
                lineBlock9F.BorderColor = Color.Green
            Case CLR
                lineBlock9A.BorderColor = Color.White
                lineBlock9B.BorderColor = Color.White
                lineBlock9C.BorderColor = Color.White
                lineBlock9D.BorderColor = Color.White
                lineBlock9E.BorderColor = Color.White
                lineBlock9F.BorderColor = Color.White
        End Select

    End Sub

    Sub UpdateBlock10()
        Select Case Block10
            Case CLR
                lineBlock10.BorderColor = Color.White
            Case OCC
                lineBlock10.BorderColor = Color.Red
        End Select

    End Sub
    Private Sub lineBroadway_Click(sender As Object, e As EventArgs) Handles lineBroadway.Click
        SelectedBlock = 15
        If InputTrainID(SelectedBlock) Then
            LogTrain(TrainID(SelectedBlock) + " called, on duty.")
        End If
    End Sub
    Function InputTrainID(BlockNumber) As Boolean
        If DlgAddTrain.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TrainID(BlockNumber) = DlgAddTrain.txtTrainID.Text
            LocoID(BlockNumber) = DlgAddTrain.txtLoco.Text
            Return True
        Else
            Return False
        End If
    End Function
End Class
