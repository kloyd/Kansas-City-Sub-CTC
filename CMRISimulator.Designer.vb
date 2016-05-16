<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CMRISimulator
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
        Me.SuspendLayout()
        '
        'CMRISimulator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 582)
        Me.Name = "CMRISimulator"
        Me.Text = "CMRISimulator"
        Me.ResumeLayout(False)

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        OutputStatesCard0 = New ButtonArray(Me)
        OutputStatesCard1 = New ButtonArray(Me)
        InputsArray = New CheckBoxArray(Me)

    End Sub
    Public Sub New(ByVal nodeNumber As Integer)
        iNode = nodeNumber
        InitializeComponent()
        OutputStatesCard0 = New ButtonArray(Me)
        OutputStatesCard1 = New ButtonArray(Me)
        InputsArray = New CheckBoxArray(Me)
    End Sub

    Public Sub New(ByVal nodeNumber As Integer, parentForm As Form)
        iNode = nodeNumber
        InitializeComponent()
        OutputStatesCard0 = New ButtonArray(Me)
        OutputStatesCard1 = New ButtonArray(Me)
        InputsArray = New CheckBoxArray(Me)
        Parent = parentForm
    End Sub

End Class
