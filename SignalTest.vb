Public Class SignalTest

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    
    Private Sub cmbSignal24RA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSignal24RA.SelectedIndexChanged
        SIG24RAB = SIG24RAB And 3
        Select Case cmbSignal24RA.Text
            Case "Red"
                SIG24RAB = RED * B2 Or SIG24RAB
            Case "Yellow"
                SIG24RAB = YEL * B2 Or SIG24RAB
            Case "Green"
                SIG24RAB = GRN * B2 Or SIG24RAB
            Case Else
                SIG24RAB = RED * B2 Or SIG24RAB

        End Select
    End Sub

    Private Sub cmbSignal24RB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSignal24RB.SelectedIndexChanged
        SIG24RAB = SIG24RAB And 12
        Select Case cmbSignal24RB.Text
            Case "Red"
                SIG24RAB = RED Or SIG24RAB
            Case "Yellow"
                SIG24RAB = YEL Or SIG24RAB
            Case "Green"
                SIG24RAB = GRN Or SIG24RAB
            Case Else
                SIG24RAB = RED Or SIG24RAB

        End Select
    End Sub

    Private Sub cmbSignal26RightA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSignal26RightA.SelectedIndexChanged
        SIG26RAB = SIG26RAB And 3
        Select Case cmbSignal26RightA.Text
            Case "Red"
                SIG26RAB = RED * B2 Or SIG26RAB
            Case "Yellow"
                SIG26RAB = YEL * B2 Or SIG26RAB
            Case "Green"
                SIG26RAB = GRN * B2 Or SIG26RAB
            Case Else
                SIG26RAB = RED * B2 Or SIG26RAB

        End Select
    End Sub

    Private Sub cmbSignal26RightB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSignal26RightB.SelectedIndexChanged
        SIG26RAB = SIG26RAB And 12
        Select Case cmbSignal26RightB.Text
            Case "Red"
                SIG26RAB = RED Or SIG26RAB
            Case "Yellow"
                SIG26RAB = YEL Or SIG26RAB
            Case "Green"
                SIG26RAB = GRN Or SIG26RAB
            Case Else
                SIG26RAB = RED Or SIG26RAB

        End Select
    End Sub
End Class