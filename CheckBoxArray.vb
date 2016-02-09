Public Class CheckBoxArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostForm As System.Windows.Forms.Form
    Public Function AddNewCheckBox(ByVal Left As Integer, ByVal CheckBoxLabel As String) As Windows.Forms.CheckBox
        ' Create a new instance of the Button class.
        Dim aCheckBox As New System.Windows.Forms.CheckBox()
        ' Add the button to the collection's internal list.
        Me.List.Add(aCheckBox)
        ' Add the button to the controls collection of the form 
        ' referenced by the HostForm field.
        HostForm.Controls.Add(aCheckBox)
        ' Set intial properties for the button object.
        aCheckBox.Top = Count * 22
        aCheckBox.Left = Left
        aCheckBox.Tag = Me.Count
        aCheckBox.Text = CheckBoxLabel
        aCheckBox.Width = 200
        ' Visual Basic
        AddHandler aCheckBox.Click, AddressOf ClickHandler
        Return aCheckBox
    End Function
    Public Sub New(ByVal host As System.Windows.Forms.Form)
        HostForm = host
    End Sub
    Default Public ReadOnly Property Item(ByVal Index As Integer) As System.Windows.Forms.CheckBox
        Get
            Return CType(Me.List.Item(Index), System.Windows.Forms.CheckBox)
        End Get
    End Property
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            ' Remove the last button added to the array from the host form 
            ' controls collection. Note the use of the default property in 
            ' accessing the array.
            HostForm.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub ClickHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        
    End Sub
End Class
