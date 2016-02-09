Imports System.Windows.Forms

Public Class DlgSigMaint

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If CheckBox2.Checked Then
            SIGF4L = LTON
        Else
            SIGF4L = LTOFF
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DlgSigMaint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If SIGF4L = LTON Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If
    End Sub
End Class
