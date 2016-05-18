Public Class TestCMRI
    Implements InterfaceCMRI
    Private SMINI_Nodes As Collection
    Public Sub New()
        SMINI_Nodes = New Collection()
    End Sub
    Public Property SMININodes() As Collection
        Get
            Return SMINI_Nodes
        End Get
        Set(ByVal value As Collection)
            ' don't allow set
        End Set
    End Property
    Public Function INIT(ByRef CommObj As System.IO.Ports.SerialPort,
                         ByVal UA As Integer, ByVal DL As Integer,
                         ByVal strNDP As String,
                         ByVal iNumOutputBytes As Integer,
                         ByVal MAXTRIES As Integer,
                         ByVal iNumInputBytes As Integer,
                         ByVal iNum2LeadSigs As Integer,
                         ByRef CT() As Integer) As Integer Implements InterfaceCMRI.INIT
        Dim anSMINI As CMRISimulator
        anSMINI = New CMRISimulator(UA)
        SMINI_Nodes.Add(anSMINI, UA)
        anSMINI.Show()

    End Function

    Public Function InitializePort(ByRef CommObj As System.IO.Ports.SerialPort,
                                   ByVal COMPORT As Integer,
                                   ByVal BAUD100 As Integer,
                                   ByVal MAXBUF As Integer) As Integer Implements InterfaceCMRI.InitializePort

    End Function

    Public Function INPUTS(ByRef CommObj As System.IO.Ports.SerialPort, ByRef iInputBuffer() As Integer, ByVal iMaxTries As Integer, ByVal iMaxBuf As Integer, ByVal iUA As Integer, ByVal iNumInputs As Integer) As Integer Implements InterfaceCMRI.INPUTS
        Dim anSMINI As CMRISimulator
        anSMINI = SMINI_Nodes(iUA + 1)
        anSMINI.Inputs(iInputBuffer, iNumInputs)
    End Function

    Public Function OUTPUTS(ByRef CommObj As System.IO.Ports.SerialPort, ByRef UA As Integer, ByRef NO As Integer, ByRef iOutputBuffer() As Integer) As Integer Implements InterfaceCMRI.OUTPUTS
        Dim anSMINI As CMRISimulator
        anSMINI = SMINI_Nodes(UA + 1)
        anSMINI.Outputs(iOutputBuffer, NO)
    End Function
End Class
