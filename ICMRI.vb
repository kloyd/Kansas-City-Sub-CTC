Public Interface InterfaceCMRI
    Function InitializePort(ByRef CommObj As System.IO.Ports.SerialPort, ByVal COMPORT As Integer, ByVal BAUD100 As Integer, ByVal MAXBUF As Integer) As Integer
    Function INIT(ByRef CommObj As System.IO.Ports.SerialPort, ByVal UA As Integer, ByVal DL As Integer, ByVal strNDP As String, ByVal iNumOutputBytes As Integer, ByVal MAXTRIES As Integer, ByVal iNumInputBytes As Integer, ByVal iNum2LeadSigs As Integer, ByRef CT() As Integer) As Integer
    Function INPUTS(ByRef CommObj As System.IO.Ports.SerialPort, ByRef iInputBuffer() As Integer, ByVal iMaxTries As Integer, ByVal iMaxBuf As Integer, ByVal iUA As Integer, ByVal iNumInputs As Integer) As Integer
    Function OUTPUTS(ByRef CommObj As System.IO.Ports.SerialPort, ByRef UA As Integer, ByRef NO As Integer, ByRef iOutputBuffer() As Integer) As Integer
End Interface
