Imports System.Windows.Forms

Public Class DlgSystemParams

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    
    Private Sub DlgSystemParams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCCDL.Text = CCDL        'Control Code transmission delay (5 seconds)
        txtICDL.Text = ICDL         'Indication Code transmission delay (10 seconds)
        txtSMDL.Text = SMDL        'Switch motor transition delay (12 seconds)
        txtRTDL.Text = RTDL        'Signal running time delay (60 seconds)
        'LKDL = 90        'Lock release time delay (90 seconds)
    End Sub

End Class
