<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignalTest
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbSignal24RA = New System.Windows.Forms.ComboBox()
        Me.cmbSignal24RB = New System.Windows.Forms.ComboBox()
        Me.cmbSignal26RightA = New System.Windows.Forms.ComboBox()
        Me.cmbSignal26RightB = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(558, 272)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 1
        Me.OK_Button.Text = "OK"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(233, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Signal 24 Right A"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(233, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Signal 24 Right B"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(233, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Signal 26 Right A"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(233, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Signal 26 Right B"
        '
        'cmbSignal24RA
        '
        Me.cmbSignal24RA.FormattingEnabled = True
        Me.cmbSignal24RA.Items.AddRange(New Object() {"Red", "Yellow", "Green"})
        Me.cmbSignal24RA.Location = New System.Drawing.Point(359, 102)
        Me.cmbSignal24RA.Name = "cmbSignal24RA"
        Me.cmbSignal24RA.Size = New System.Drawing.Size(132, 21)
        Me.cmbSignal24RA.TabIndex = 6
        '
        'cmbSignal24RB
        '
        Me.cmbSignal24RB.FormattingEnabled = True
        Me.cmbSignal24RB.Items.AddRange(New Object() {"Red", "Yellow", "Green"})
        Me.cmbSignal24RB.Location = New System.Drawing.Point(359, 129)
        Me.cmbSignal24RB.Name = "cmbSignal24RB"
        Me.cmbSignal24RB.Size = New System.Drawing.Size(132, 21)
        Me.cmbSignal24RB.TabIndex = 7
        '
        'cmbSignal26RightA
        '
        Me.cmbSignal26RightA.FormattingEnabled = True
        Me.cmbSignal26RightA.Items.AddRange(New Object() {"Red", "Yellow", "Green"})
        Me.cmbSignal26RightA.Location = New System.Drawing.Point(359, 158)
        Me.cmbSignal26RightA.Name = "cmbSignal26RightA"
        Me.cmbSignal26RightA.Size = New System.Drawing.Size(132, 21)
        Me.cmbSignal26RightA.TabIndex = 8
        '
        'cmbSignal26RightB
        '
        Me.cmbSignal26RightB.FormattingEnabled = True
        Me.cmbSignal26RightB.Items.AddRange(New Object() {"Red", "Yellow", "Green"})
        Me.cmbSignal26RightB.Location = New System.Drawing.Point(359, 185)
        Me.cmbSignal26RightB.Name = "cmbSignal26RightB"
        Me.cmbSignal26RightB.Size = New System.Drawing.Size(132, 21)
        Me.cmbSignal26RightB.TabIndex = 9
        '
        'SignalTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 324)
        Me.Controls.Add(Me.cmbSignal26RightB)
        Me.Controls.Add(Me.cmbSignal26RightA)
        Me.Controls.Add(Me.cmbSignal24RB)
        Me.Controls.Add(Me.cmbSignal24RA)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OK_Button)
        Me.Name = "SignalTest"
        Me.Text = "SignalTest"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbSignal24RA As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSignal24RB As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSignal26RightA As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSignal26RightB As System.Windows.Forms.ComboBox
End Class
