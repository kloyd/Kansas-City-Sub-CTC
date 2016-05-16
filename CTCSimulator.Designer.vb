<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CTCSimulator
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
        Me.CTCTab = New System.Windows.Forms.TabControl()
        Me.SuspendLayout()
        '
        'CTCTab
        '
        Me.CTCTab.Dock = System.Windows.Forms.DockStyle.Top
        Me.CTCTab.Location = New System.Drawing.Point(0, 0)
        Me.CTCTab.Name = "CTCTab"
        Me.CTCTab.SelectedIndex = 0
        Me.CTCTab.Size = New System.Drawing.Size(1244, 649)
        Me.CTCTab.TabIndex = 0
        Me.CTCTab.Visible = False
        '
        'CTCSimulator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1244, 652)
        Me.Controls.Add(Me.CTCTab)
        Me.IsMdiContainer = True
        Me.Name = "CTCSimulator"
        Me.Text = "CTCSimulator"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CTCTab As TabControl
End Class
