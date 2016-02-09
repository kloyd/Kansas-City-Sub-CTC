Public Class CMRISimulator
    Dim OutputStatesCard0 As ButtonArray
    Dim OutputStatesCard1 As ButtonArray
    Dim InputsArray As CheckBoxArray
    Dim iNode As Integer
    Dim Bitz(8) As Short
    Dim B0, B1, B2, B3, B4, B5, B6, B7 As Short
    Dim W1, W2, W3, W4, W5, W6, W7 As Short
    Public Sub SetNode(ByVal nodeNumber As Integer)
        iNode = nodeNumber
        Me.Text = "CMRI Node #" & iNode
    End Sub
    Public Sub Inputs(ByRef inputBuffer() As Integer, ByVal iNumberBytes As Integer)
        Dim whichBit As Short
        Dim whichCard As Short
        For whichCard = 0 To 2
            inputBuffer(whichCard + 1) = 0
            For whichBit = 0 To 7
                If InputsArray.Item(whichCard * 8 + whichBit).Checked Then
                    inputBuffer(whichCard + 1) = inputBuffer(whichCard + 1) + Bitz(whichBit + 1)
                End If
            Next
        Next
    End Sub
    Public Sub Outputs(ByRef outputBuffer() As Integer, ByVal iNumberBytes As Integer)
        Dim whichBit As Short
        Dim whichCard As Short
        For whichCard = 0 To 2
            For whichBit = 0 To 7
                If (outputBuffer(whichCard + 1) \ Bitz(whichBit + 1) And W1) = 1 Then
                    OutputStatesCard0.Item(whichCard * 8 + whichBit).BackColor = Color.Green
                Else
                    OutputStatesCard0.Item(whichCard * 8 + whichBit).BackColor = Color.Silver
                End If
                If (outputBuffer(whichCard + 4) \ Bitz(whichBit + 1) And W1) = 1 Then
                    OutputStatesCard1.Item(whichCard * 8 + whichBit).BackColor = Color.Green
                Else
                    OutputStatesCard1.Item(whichCard * 8 + whichBit).BackColor = Color.Silver
                End If
            Next
        Next
    End Sub

    Private Sub CMRISimulator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim n As Integer
        For n = 1 To 8
            Bitz(n) = 2 ^ (n - 1)
        Next

        B0 = 1 : B1 = 2 : B2 = 4 : B3 = 8 : B4 = 16 : B5 = 32 : B6 = 64 : B7 = 128
        W1 = 1 : W2 = 3 : W3 = 7 : W4 = 15 : W5 = 31 : W6 = 63 : W7 = 127
        CreateOutputsAndInputs()
        Me.Text = "CMRI Node #" & iNode
    End Sub
    Private Sub CreateOutputsAndInputs()
        Dim n As Integer
        For n = 1 To 24
            OutputStatesCard0.AddNewButton(25, "Node " & iNode & ", Output Card 0, Output " & n)
            OutputStatesCard1.AddNewButton(275, "Node " & iNode & ", Output Card 1, Output " & n)
            InputsArray.AddNewCheckBox(550, "Node " & iNode & ", Input Card 2, Line " & n)
        Next
        If iNode = 0 Then
            AssignNode0Labels()
        End If
        If iNode = 1 Then
            AssignNode1Labels()
        End If
        If iNode = 2 Then
            AssignNode2Labels()
        End If
        If iNode = 3 Then
            AssignNode3Labels()
        End If
    End Sub
    Private Sub AssignNode0Labels()
        InputsArray.Item(0).Text = "Switch Lever 1 Normal"
        InputsArray.Item(0).Checked = True
        InputsArray.Item(1).Text = "Switch Lever 1 Reverse"
        InputsArray.Item(2).Text = "Switch Lever 3 Normal"
        InputsArray.Item(2).Checked = True
        InputsArray.Item(3).Text = "Switch Lever 3 Reverse"
        InputsArray.Item(4).Text = "Switch Lever 7 Normal"
        InputsArray.Item(4).Checked = True
        InputsArray.Item(5).Text = "Switch Lever 7 Reverse"
        InputsArray.Item(6).Text = "Switch Lever 9 Normal"
        InputsArray.Item(6).Checked = True
        InputsArray.Item(7).Text = "Switch Lever 9 Reverse"
        InputsArray.Item(8).Text = "Switch Lever 11 Normal"
        InputsArray.Item(8).Checked = True
        InputsArray.Item(9).Text = "Switch Lever 11 Reverse"
        InputsArray.Item(10).Text = "Switch Lever 15 Normal"
        InputsArray.Item(10).Checked = True
        InputsArray.Item(11).Text = "Switch Lever 15 Reverse"
        InputsArray.Item(12).Text = "Switch Lever 17 Normal"
        InputsArray.Item(12).Checked = True
        InputsArray.Item(13).Text = "Switch Lever 17 Reverse"
        InputsArray.Item(14).Text = "Switch Lever 19 Normal"
        InputsArray.Item(14).Checked = True
        InputsArray.Item(15).Text = "Switch Lever 19 Reverse"
        InputsArray.Item(16).Text = "Switch Lever 23 Normal"
        InputsArray.Item(16).Checked = True
        InputsArray.Item(17).Text = "Switch Lever 23 Reverse"
        InputsArray.Item(18).Text = "Switch Lever 25 Normal"
        InputsArray.Item(18).Checked = True
        InputsArray.Item(19).Text = "Switch Lever 25 Reverse"

        OutputStatesCard0.Item(0).Text = "Turnout 1 Indicator Normal"
        OutputStatesCard0.Item(1).Text = "Turnout 1 Indicator Reverse"
        OutputStatesCard0.Item(2).Text = "Turnout 3 Indicator Normal"
        OutputStatesCard0.Item(3).Text = "Turnout 3 Indicator Reverse"
        OutputStatesCard0.Item(4).Text = "Turnout 7 Indicator Normal"
        OutputStatesCard0.Item(5).Text = "Turnout 7 Indicator Reverse"
        OutputStatesCard0.Item(6).Text = "Turnout 9 Indicator Normal"
        OutputStatesCard0.Item(7).Text = "Turnout 9 Indicator Reverse"
        OutputStatesCard0.Item(8).Text = "Turnout 19 Indicator Normal"
        OutputStatesCard0.Item(9).Text = "Turnout 19 Indicator Reverse"
        OutputStatesCard0.Item(10).Text = "Turnout 17 Indicator Normal"
        OutputStatesCard0.Item(11).Text = "Turnout 17 Indicator Reverse"
        OutputStatesCard0.Item(12).Text = "Turnout 15 Indicator Normal"
        OutputStatesCard0.Item(13).Text = "Turnout 15 Indicator Reverse"
        OutputStatesCard0.Item(14).Text = "Turnout 11 Indicator Normal"
        OutputStatesCard0.Item(15).Text = "Turnout 11 Indicator Reverse"
        OutputStatesCard0.Item(16).Text = "Turnout 23 Indicator Normal"
        OutputStatesCard0.Item(17).Text = "Turnout 23 Indicator Reverse"
        OutputStatesCard0.Item(18).Text = "Turnout 25 Indicator Normal"
        OutputStatesCard0.Item(19).Text = "Turnout 25 Indicator Reverse"
        OutputStatesCard1.Item(0).Text = "Switch Lock Indicator 25"
        OutputStatesCard1.Item(1).Text = "Switch Lock Indicator 23"
        OutputStatesCard1.Item(2).Text = "Switch Lock Indicator 19"
        OutputStatesCard1.Item(3).Text = "Switch Lock Indicator 17"
        OutputStatesCard1.Item(4).Text = "Switch Lock Indicator 15"
        OutputStatesCard1.Item(5).Text = "Switch Lock Indicator 11"
        OutputStatesCard1.Item(6).Text = "Switch Lock Indicator 9"
        OutputStatesCard1.Item(7).Text = "Switch Lock Indicator 7"
        OutputStatesCard1.Item(8).Text = "Switch Lock Indicator 3"
        OutputStatesCard1.Item(9).Text = "Indication Code"
        OutputStatesCard1.Item(10).Text = "Control Code"
        OutputStatesCard1.Item(16).Text = "Block 1 Traffic East"
        OutputStatesCard1.Item(17).Text = "Block 1 Traffic West"
        OutputStatesCard1.Item(18).Text = "Block 2 Traffic East"
        OutputStatesCard1.Item(19).Text = "Block 2 Traffic West"
        OutputStatesCard1.Item(20).Text = "Block 5 Traffic East"
        OutputStatesCard1.Item(21).Text = "Block 5 Traffic West"
        OutputStatesCard1.Item(22).Text = "Block 6 Traffic East"
        OutputStatesCard1.Item(23).Text = "Block 6 Traffic West"
    End Sub
    Private Sub AssignNode1Labels()
        ' Node 1, Card 2, Port A 0-7
        InputsArray.Item(0).Text = "Signal Lever 26 Right"
        InputsArray.Item(1).Text = "Signal Lever 26 Left"
        InputsArray.Item(2).Text = "Signal Lever 24 Right"
        InputsArray.Item(3).Text = "Signal Lever 24 Left"
        InputsArray.Item(4).Text = "Signal Lever 10 Right"
        InputsArray.Item(5).Text = "Signal Lever 10 Left"
        InputsArray.Item(6).Text = "Signal Lever 8 Right"
        InputsArray.Item(7).Text = "Signal Lever 8 Left"
        ' Node 1, Card 2, Port B 8-15
        InputsArray.Item(8).Text = "Signal Lever 4 Right"
        InputsArray.Item(9).Text = "Signal Lever 4 Left"
        InputsArray.Item(10).Text = "Signal Lever 12 Right"
        InputsArray.Item(11).Text = "Annunciator Reset"
        InputsArray.Item(14).Text = "CB2"
        InputsArray.Item(15).Text = "CB4"
        ' Node 1, Card 2, Port C 16-23
        InputsArray.Item(16).Text = "CB8"
        InputsArray.Item(17).Text = "CB10"
        InputsArray.Item(18).Text = "CB12"
        InputsArray.Item(19).Text = "CB16"
        InputsArray.Item(20).Text = "CB18"
        InputsArray.Item(21).Text = "CB20"
        InputsArray.Item(22).Text = "CB24"
        InputsArray.Item(23).Text = "CB26"
        ' BLOCK INDICATORS
        ' -- Node 1, Card 0, Port A --
        OutputStatesCard0.Item(0).Text = "Block5"
        OutputStatesCard0.Item(1).Text = "Block6"
        OutputStatesCard0.Item(2).Text = "Block3"
        OutputStatesCard0.Item(3).Text = "Block4"
        OutputStatesCard0.Item(4).Text = "Block1"
        OutputStatesCard0.Item(5).Text = "Block2"
        OutputStatesCard0.Item(6).Text = "Block7"
        OutputStatesCard0.Item(7).Text = "Block8"
        ' *** Node 1, Card 0, Port B
        OutputStatesCard0.Item(8).Text = "Block5"
        OutputStatesCard0.Item(9).Text = "Block6"
        OutputStatesCard0.Item(10).Text = "Block9"
        OutputStatesCard0.Item(11).Text = "Train waiting at Bensenville"
        OutputStatesCard0.Item(12).Text = "Train waiting at Centropolis"
        OutputStatesCard0.Item(13).Text = "Train waiting at Coburg West"
        OutputStatesCard0.Item(14).Text = "Train waiting at Coburg East"
        OutputStatesCard0.Item(15).Text = "Train waiting at Broadway Tower"
        ' -- Node 1, Card 0, Port C
        OutputStatesCard0.Item(16).Text = "Traffic Block 5 East"
        OutputStatesCard0.Item(17).Text = "Traffic Block 5 West"
        OutputStatesCard0.Item(18).Text = "Traffic Block 6 East"
        OutputStatesCard0.Item(19).Text = "Traffic Block 6 West"
        ' SIGNAL INDICATORS
        ' -- Node 1, Card 1, Port A --
        OutputStatesCard1.Item(0).Text = "SignalIndicator 26 Right"
        OutputStatesCard1.Item(1).Text = "SignalIndicator 26 Stop"
        OutputStatesCard1.Item(2).Text = "SignalIndicator 26 Left"
        OutputStatesCard1.Item(3).Text = "SignalIndicator 24 Right"
        OutputStatesCard1.Item(4).Text = "SignalIndicator 24 Stop"
        OutputStatesCard1.Item(5).Text = "SignalIndicator 24 Left"
        ' -- Node 1, Card 1, Port B --
        OutputStatesCard1.Item(8).Text = "SignalIndicator 10 Right"
        OutputStatesCard1.Item(9).Text = "SignalIndicator 10 Stop"
        OutputStatesCard1.Item(10).Text = "SignalIndicator 10 Left"
        OutputStatesCard1.Item(11).Text = "SignalIndicator 8 Right"
        OutputStatesCard1.Item(12).Text = "SignalIndicator 8 Stop"
        OutputStatesCard1.Item(13).Text = "SignalIndicator 8 Left"
        ' -- Node 1, Card 1, Port C
        OutputStatesCard1.Item(16).Text = "SignalIndicator 4 Right"
        OutputStatesCard1.Item(17).Text = "SignalIndicator 4 Stop"
        OutputStatesCard1.Item(18).Text = "SignalIndicator 4 Left"
        OutputStatesCard1.Item(19).Text = "Power Off"

    End Sub
    Private Sub AssignNode2Labels()
        InputsArray.Item(0).Text = "Turnout 3 Position"
        InputsArray.Item(1).Text = "Turnout 7 Position"
        InputsArray.Item(2).Text = "Turnout 9 Position"
        InputsArray.Item(3).Text = "Turnout 11 Position"
        InputsArray.Item(4).Text = "Turnout 15 Position"
        InputsArray.Item(5).Text = "Turnout 23 Position"
        InputsArray.Item(8).Text = "Power Off Indicator"
       
        ' -- Node 2, Card 0, Port A --
        OutputStatesCard0.Item(0).Text = "Turnout Output 1 Normal"
        OutputStatesCard0.Item(1).Text = "Turnout Output 1 Reverse"
        OutputStatesCard0.Item(2).Text = "Turnout Output 3 Normal"
        OutputStatesCard0.Item(3).Text = "Turnout Output 3 Reverse"
        OutputStatesCard0.Item(4).Text = "Turnout Output 7 Normal"
        OutputStatesCard0.Item(5).Text = "Turnout Output 7 Reverse"
        OutputStatesCard0.Item(6).Text = "Turnout Output 9 Normal"
        OutputStatesCard0.Item(7).Text = "Turnout Output 9 Reverse"
        ' -- Node 2, Card 0, Port B --
        OutputStatesCard0.Item(8).Text = "Turnout Output 11 Normal"
        OutputStatesCard0.Item(9).Text = "Turnout Output 11 Reverse"
        OutputStatesCard0.Item(10).Text = "Turnout Output 15 Normal"
        OutputStatesCard0.Item(11).Text = "Turnout Output 15 Reverse"
        OutputStatesCard0.Item(12).Text = "Turnout Output 17 Normal"
        OutputStatesCard0.Item(13).Text = "Turnout Output 17 Reverse"
        OutputStatesCard0.Item(14).Text = "Turnout Output 19 Normal"
        OutputStatesCard0.Item(15).Text = "Turnout Output 19 Reverse"

        ' -- Node 2, Card 0, Port C --
        ' ob(3) 0 and 1 for electric locks 17 & 19
        OutputStatesCard0.Item(16).Text = "Lock 17 Open"
        OutputStatesCard0.Item(17).Text = "Lock 19 Open"

        ' Signal8RABC   = 6 outs => ob(3) AABBCCLL
        OutputStatesCard0.Item(18).Text = "Signal 8 Right Head C Green"
        OutputStatesCard0.Item(19).Text = "Signal 8 Right Head C Red"
        OutputStatesCard0.Item(20).Text = "Signal 8 Right Head B Green"
        OutputStatesCard0.Item(21).Text = "Signal 8 Right Head B Red"
        OutputStatesCard0.Item(22).Text = "Signal 8 Right Head A Green"
        OutputStatesCard0.Item(23).Text = "Signal 8 Right Head A Red"
        ' -- Node 2, Card 1, Port A
        ' Signal10RABCD = 8 outs => OB(4) AABBCCDD
        OutputStatesCard1.Item(0).Text = "Signal 10 Right Head D Green"
        OutputStatesCard1.Item(1).Text = "Signal 10 Right Head D Red"
        OutputStatesCard1.Item(2).Text = "Signal 10 Right Head C Green"
        OutputStatesCard1.Item(3).Text = "Signal 10 Right Head C Red"
        OutputStatesCard1.Item(4).Text = "Signal 10 Right Head B Green"
        OutputStatesCard1.Item(5).Text = "Signal 10 Right Head B Red"
        OutputStatesCard1.Item(6).Text = "Signal 10 Right Head A Green"
        OutputStatesCard1.Item(7).Text = "Signal 10 Right Head A Red"
        ' -- Node 2, Card 1, Port B --
        ' Signal8LABCD  = 8 outs => ob(5) AABBCCDD
        OutputStatesCard1.Item(8).Text = "Signal 8 Left Head D Green"
        OutputStatesCard1.Item(9).Text = "Signal 8 Left Head D Red"
        OutputStatesCard1.Item(10).Text = "Signal 8 Left Head C Green"
        OutputStatesCard1.Item(11).Text = "Signal 8 Left Head C Red"
        OutputStatesCard1.Item(12).Text = "Signal 8 Left Head B Green"
        OutputStatesCard1.Item(13).Text = "Signal 8 Left Head B Red"
        OutputStatesCard1.Item(14).Text = "Signal 8 Left Head A Green"
        OutputStatesCard1.Item(15).Text = "Signal 8 Left Head A Red"
        ' -- Node 2, Card 1, Port C --
        'Signal4RAB = 4 outs => OB(6) LLLLAABB
        OutputStatesCard1.Item(16).Text = "Signal 4 Right Head B Green"
        OutputStatesCard1.Item(17).Text = "Signal 4 Right Head B Red"
        OutputStatesCard1.Item(18).Text = "Signal 4 Right Head A Green"
        OutputStatesCard1.Item(19).Text = "Signal 4 Right Head A Red"
        'Signal4LAB = 4 outs => OB(6) AABBRRRR
        OutputStatesCard1.Item(20).Text = "Signal 4 Left Head B Green"
        OutputStatesCard1.Item(21).Text = "Signal 4 Left Head B Red"
        OutputStatesCard1.Item(22).Text = "Signal 4 Left Head A Green"
        OutputStatesCard1.Item(23).Text = "Signal 4 Left Head A Red"
    End Sub
    Private Sub AssignNode3Labels()
        ' 0 - 7
        InputsArray.Item(0).Text = "Block 1 detector"
        InputsArray.Item(1).Text = "Block 2 detector"
        InputsArray.Item(2).Text = "Block 3 detector"
        InputsArray.Item(3).Text = "Block 4 detector"
        InputsArray.Item(4).Text = "Block 5 detector"
        InputsArray.Item(5).Text = "Block 6 detector"
        InputsArray.Item(6).Text = "Block 7 detector"
        InputsArray.Item(7).Text = "Block 8 detector"
        ' 8 - 15
        InputsArray.Item(8).Text = "Block 9 detector"
        InputsArray.Item(9).Text = "Block 10 detector"

        InputsArray.Item(11).Text = "Yard switch 25 open"
        InputsArray.Item(12).Text = "Yard Permission switch west"

        ' Node 3, Card 2, C0-C7
        InputsArray.Item(16).Text = "Bensenville Departure Request"
        InputsArray.Item(17).Text = "Centropolis Departure Request"
        InputsArray.Item(18).Text = "Coburg East Departure Request"
        InputsArray.Item(19).Text = "Coburg West Departure Request"
        InputsArray.Item(20).Text = "Broadway Tower Departure Request"

        ' Node 3, Card 0, A0-A7
        OutputStatesCard0.Item(0).Text = "Turnout Output 23 Normal"
        OutputStatesCard0.Item(1).Text = "Turnout Output 23 Reverse"
        OutputStatesCard0.Item(2).Text = "Turnout Output 25 Normal"
        OutputStatesCard0.Item(3).Text = "Turnout Output 25 Reverse"
        OutputStatesCard0.Item(4).Text = "25 Lock Open"

        ' Node 3, Card 0, B0-B7
        OutputStatesCard0.Item(8).Text = "25 Unlock LED"
        OutputStatesCard0.Item(9).Text = "25 Yard switch power"
        OutputStatesCard0.Item(10).Text = "Bensenville Annunciator"
        OutputStatesCard0.Item(11).Text = "Centropolis Annunciator"
        OutputStatesCard0.Item(12).Text = "Coburg West Annunciator"
        OutputStatesCard0.Item(13).Text = "Coburg East Annunciator"
        OutputStatesCard0.Item(14).Text = "Broadway Tower Annunciator"

        ' -- Node 3, Card 0, Port C
        ' Signal10LAB   = 4 outs => node 3 - freight line.
        OutputStatesCard0.Item(16).Text = "Signal 10 Left Head B Green"
        OutputStatesCard0.Item(17).Text = "Signal 10 Left Head B Red"
        OutputStatesCard0.Item(18).Text = "Signal 10 Left Head A Green"
        OutputStatesCard0.Item(19).Text = "Signal 10 Left Head A Red"

        '-- Last two bits for Coburg West/East Train Waiting indicators (flashing)
        OutputStatesCard0.Item(22).Text = "Freight Line Train Waiting"
        OutputStatesCard0.Item(23).Text = "Coburg West Train Waiting"

        ' -- Node 3 Card 1 Port A = Signal24RightHead, Signal26RightHead
        ' 66664444
        OutputStatesCard1.Item(0).Text = "Signal 24 Right Head B Green"
        OutputStatesCard1.Item(1).Text = "Signal 24 Right Head B Red"
        OutputStatesCard1.Item(2).Text = "Signal 24 Right Head A Green"
        OutputStatesCard1.Item(3).Text = "Signal 24 Right Head A Red"
        OutputStatesCard1.Item(4).Text = "Signal 26 Right Head B Green"
        OutputStatesCard1.Item(5).Text = "Signal 26 Right Head B Red"
        OutputStatesCard1.Item(6).Text = "Signal 26 Right Head A Green"
        OutputStatesCard1.Item(7).Text = "Signal 26 Right Head A Red"
        ' -- Node 3 Card 1 Port B = Signal26LeftHead, Signal24LeftHead
        OutputStatesCard1.Item(8).Text = "Signal 24 Left Head A Green"
        OutputStatesCard1.Item(9).Text = "Signal 24 Left Head A Red"
        OutputStatesCard1.Item(10).Text = "Signal 26 Left Head B Green"
        OutputStatesCard1.Item(11).Text = "Signal 26 Left Head B Red"
        OutputStatesCard1.Item(12).Text = "Signal 26 Left Head A Green"
        OutputStatesCard1.Item(13).Text = "Signal 26 Left Head A Red"
        OutputStatesCard1.Item(14).Text = "Signal 26 Left Head C Green"
        OutputStatesCard1.Item(15).Text = "Signal 26 Left Head C Red"
        ' -- Node 3, Card 1, Port C = Traffic Lights
        OutputStatesCard1.Item(16).Text = "traffic light E-W Red"
        OutputStatesCard1.Item(17).Text = "traffic light E-W Yellow"
        OutputStatesCard1.Item(18).Text = "traffic light E-W Green"
        OutputStatesCard1.Item(19).Text = "traffic light N-S Red"
        OutputStatesCard1.Item(20).Text = "traffic light N-S Yellow"
        OutputStatesCard1.Item(21).Text = "traffic light N-S Green"
    End Sub
End Class