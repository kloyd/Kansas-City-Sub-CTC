Imports System.IO.Ports
Public Class CMRI
    Implements InterfaceCMRI
    'These are error trap flags for future use.

    Friend ABORTIN As Integer 'Flag set to 1 when by iReceiveByte subprogram...
    '...aborts reading inputs, otherwise = 0
    Friend INTRIES As Integer 'Number of input tries counter
    Friend INITERR As Integer 'Flag set by INIT subprogram when detects...
    '...and error in initialization input data

    Function InitializePort(ByRef CommObj As SerialPort, _
                            ByVal COMPORT As Integer, ByVal BAUD100 As Integer, _
                            ByVal MAXBUF As Integer) As Integer Implements InterfaceCMRI.InitializePort
        'CommObj  = PC COM port as implemented on the main form
        'COMPORT  = port number
        'BAUD100  = PC baud rate divided by 100
        'MAXBUF   = Maximum number of input bytes allowed in MSComm's...
        '      ...input data buffer before declare PC overrun error

        'The routine returns OK (0) or an error code

        Dim InitErr As Integer

        InitErr = 0
        '**CHECK FOR VALID NUMBER FOR PC COM PORT (COM1 THRU COM4)
        If COMPORT = 1 Then GoTo COMOK
        If COMPORT = 2 Then GoTo COMOK
        If COMPORT = 3 Then GoTo COMOK
        If COMPORT = 4 Then GoTo COMOK
        If COMPORT = 5 Then GoTo COMOK
        If COMPORT = 6 Then GoTo COMOK
        LogEvent("***ERROR*** COMPORT = " & COMPORT & " MUST = 1 - 6")
        InitErr = 1
COMOK:

        '**CHECK FOR VALID BAUD RATE
        If BAUD100 = 96 Then GoTo BAUDOK
        If BAUD100 = 192 Then GoTo BAUDOK
        If BAUD100 = 288 Then GoTo BAUDOK
        If BAUD100 = 576 Then GoTo BAUDOK
        If BAUD100 = 1152 Then GoTo BAUDOK
        LogEvent("***ERROR*** BAUD100 = " & BAUD100)
        LogEvent("Valid BAUD100 values are 96, 192, 228, 576 and 1152")
        InitErr = 1
BAUDOK:

        '**CHECK FOR VALID RANGE OF MAXBUF
        If MAXBUF < 1 Or MAXBUF > 262 Then
            LogEvent("***ERROR*** MAXBUF = " & MAXBUF)
            LogEvent("Valid MAXBUF range is 1 through 262")
            InitErr = 1
        End If

        'if there was an initialization data error, return an error message and abort port init
        If InitErr <> 0 Then Return InitErr

        '**Close PC communications port if already opened so can initialize parameters

        If CommObj.IsOpen = True Then
            CommObj.Close()
        End If

        '**SET MScomm1 TO SELECTED PORT
        'The object name is formatted like "COM4"
        CommObj.PortName = "COM" & CStr(COMPORT)
        CommObj.BaudRate = BAUD100 * 100   'the system needs the full baud rate!!
        CommObj.Parity = IO.Ports.Parity.None
        CommObj.DataBits = 8
        CommObj.StopBits = IO.Ports.StopBits.One
        CommObj.Handshake = Handshake.None

        '**INITIALIZE REMAINDER OF MSComm1 PROPERTIES

        CommObj.WriteBufferSize = MAXBUF
        CommObj.ReadBufferSize = MAXBUF
        CommObj.Open()
        CommObj.DiscardInBuffer()
        CommObj.DiscardOutBuffer()


        Return InitErr
    End Function
    Function INIT(ByRef CommObj As SerialPort, _
                  ByVal UA As Integer, _
                  ByVal DL As Integer, _
                  ByVal strNDP As String, _
                  ByVal iNumOutputBytes As Integer, _
                  ByVal MAXTRIES As Integer, _
                  ByVal iNumInputBytes As Integer, _
                  ByVal iNum2LeadSigs As Integer, _
                  ByRef CT() As Integer) As Integer Implements InterfaceCMRI.INIT
        '**********************************************
        '**               ***INIT***                 **
        '*******VISUAL BASIC VERSION USING MSComm******
        '**     NODE INITIALIZATION SUBROUTINE       **
        '** for use with SMINI nodes ONLY            **
        '**********************************************

        ' **NOTE: This subroutine must be executed correctly prior to...
        '         ...invoking INPUTS and OUTPUTS subroutines
        '  Following parameters must be defined in the application...
        '    ...program prior to invoking INIT:
        '       CommObj  = The communications control on the main form:  System.Ports.IO.Serialport
        '       UA       = USIC address (range 0 to 127) unless using...
        '       
        '       DL       = USIC transmission delay
        '       strNDP     = Node definition parameter = "M", "N" or "X"
        '       iNumOutputBytes = number of output bytes in the buffer
        '       iNumInputBytes = number of input bytes in the buffer
        '       MAXTRIES = Maximum number of PC tries to read input...
        '                ... bytes prior to PC aborting inputs


        'For SMINI applications:
        '       iNum2LeadSigs       = Number of 2-lead searchlight signals...
        '                          ...requiring yellow oscillation feature
        'Only for SMINI case when NS > 0 i.e. signals are present
        '       CT(1) through CT(6) = Card type definition elements...
        '       ...defining signal bit locations within each...
        '       ...of the SMINI's 6 output ports


        Dim LM As Integer
        Dim MT As Integer

        Dim NSCNT As Integer
        Dim I As Integer
        Dim iOutputBuffer(20) As Integer ' output buffer to allow for clearing of contents...

        '**BEGIN INITIALIZATION OF USIC, SUSIC OR SMINI
        '**Initialize intries counter and initialization error flag
        INTRIES = 0 'Initialize INTRIES counter to zero
        INITERR = 0 'Initialize error flag to zero
        '
        '
        'NOTE: ERRORS GO TO MESSAGE BOX, they would be better sent to a system log on a form....
        '
        '
        If strNDP <> "M" Then
            LogEvent("ERROR - SMINI ONLY")

            INITERR = 1
        End If


        '**CHECK FOR VALID RANGE OF USIC ADDRESS
        'NOTE: range 0 - 15 is not checked for Classic USIC with 68701
        If UA > 127 Then
            LogEvent("***ERROR*** UA = " & UA & " Out of range 0 to 127")
            INITERR = 1
        End If

        '***************************************************************
        'Initialize the serial port only once!
        '***************************************************************



CHKMINI:
        '*************BEGIN SMINI SPECIFIC PARAMETER CHECKING************
        '**CHECK FOR VALID NI, NO AND NS USING SMINI
        If iNumInputBytes <> 3 Then
            LogEvent("INVALID NUMBER OF INPUT BYTES = " & iNumInputBytes & "MUST BE iNumInputBytes = 3 FOR SMINI")
            INITERR = 1
        End If

        If iNumOutputBytes <> 6 Then
            LogEvent("INVALID iNumOuputBytes = " & iNumOutputBytes & "MUST BE iNumOutputBytes = 6 FOR SMINI")
            INITERR = 1
        End If

        If iNum2LeadSigs = 0 Then GoTo INCHKCMP 'No signals so branch to initialization...
        '...checking complete

        '**SMINI HAS 2-LEAD OSCILLATING SIGNAL SO CHECK IF NS IN RANGE
        If iNum2LeadSigs > 24 Then
            LogEvent("**ERROR** iNum2LeadSigs = " & iNum2LeadSigs & " OUT OF RANGE 0 TO 24 FOR SMINI")
            INITERR = 1
        End If

        '**CHECK FOR VALID CT ARRAY ELEMENTS WHILE COUNTING SIGNALS TO EQUAL NS
        NSCNT = 0 'Initialize signal count to zero
        For I = 1 To 6 'Loop through 6 SMINI CT elements
            If CT(I) = 0 Then GoTo NEXTCT
            If CT(I) = 3 Then NSCNT = NSCNT + 1 : GoTo NEXTCT
            If CT(I) = 6 Then NSCNT = NSCNT + 1 : GoTo NEXTCT
            If CT(I) = 12 Then NSCNT = NSCNT + 1 : GoTo NEXTCT
            If CT(I) = 24 Then NSCNT = NSCNT + 1 : GoTo NEXTCT
            If CT(I) = 48 Then NSCNT = NSCNT + 1 : GoTo NEXTCT
            If CT(I) = 96 Then NSCNT = NSCNT + 1 : GoTo NEXTCT
            If CT(I) = 192 Then NSCNT = NSCNT + 1 : GoTo NEXTCT
            If CT(I) = 15 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 27 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 51 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 99 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 195 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 30 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 54 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 102 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 198 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 60 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 108 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 204 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 120 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 216 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 240 Then NSCNT = NSCNT + 2 : GoTo NEXTCT
            If CT(I) = 63 Then NSCNT = NSCNT + 3 : GoTo NEXTCT
            If CT(I) = 123 Then NSCNT = NSCNT + 3 : GoTo NEXTCT
            If CT(I) = 243 Then NSCNT = NSCNT + 3 : GoTo NEXTCT
            If CT(I) = 111 Then NSCNT = NSCNT + 3 : GoTo NEXTCT
            If CT(I) = 207 Then NSCNT = NSCNT + 3 : GoTo NEXTCT
            If CT(I) = 219 Then NSCNT = NSCNT + 3 : GoTo NEXTCT
            If CT(I) = 126 Then NSCNT = NSCNT + 3 : GoTo NEXTCT
            If CT(I) = 222 Then NSCNT = NSCNT + 3 : GoTo NEXTCT
            If CT(I) = 246 Then NSCNT = NSCNT + 3 : GoTo NEXTCT
            If CT(I) = 252 Then NSCNT = NSCNT + 3 : GoTo NEXTCT
            If CT(I) = 255 Then NSCNT = NSCNT + 4 : GoTo NEXTCT
            LogEvent("**ERROR** INVALID CT(" & I & ") = " & CStr(CT(I)) & " FOR SMINI")
            INITERR = 1
NEXTCT:
        Next I

        If NSCNT <> iNum2LeadSigs Then
            LogEvent("**ERROR** SIGNAL COUNT FROM CTs <> iNum2LeadSigs FOR SMINI")
            INITERR = 1
        End If


INCHKCMP:

        '**DEFINE INITIALIZATION MESSAGE PARAMETERS
        MT = Asc("I") 'Define message type = "I" (decimal 73)
        iOutputBuffer(1) = Asc(strNDP) 'Define node definition parameter
        iOutputBuffer(2) = CInt(DL / 256) 'Set USIC delay high-order byte
        iOutputBuffer(3) = DL - (iOutputBuffer(2) * 256) 'Set USIC delay low-order byte
        iOutputBuffer(4) = iNum2LeadSigs 'Define number of card sets of 4 for...
        'USIC and SUSIC cases and the...
        '...number of 2-lead yellow aspect...
        '...oscillating signals for the SMINI.
        LM = 4 'Initialize length of message to start of loading CT elements


        '**SMINI-NODE ("M") SO CHECK IF REQUIRES 2-LEAD OSCILLATION...
        '...SEARCHLIGHT SIGNALS
        If iNum2LeadSigs = 0 Then GoTo TXMSG 'No signals so hold message length at...
        '...LM = 4 and branch to transmit packet

        '**SMINI CASE WITH SIGNALS (NS > 0) SO LOOP THROUGH TO LOAD...
        For I = 1 To 6 '...signal location CT array elements...
            LM = LM + 1 '...into output byte array while...
            iOutputBuffer(LM) = CT(I) '...accumulating message length
        Next I

        '**FORM INITIALIZATION PACKET AND TRANSMIT TO INTERFACE
TXMSG:
        LogEvent("Intializing Node #" + CStr(UA))
        If TransmitPackage(CommObj, UA, MT, LM, iOutputBuffer) <> 0 Then
            INITERR = 1
        End If
        'Invoke transmit packet subroutine

        '**COMPLETED USE OF OUTPUT BYTE ARRAY SO CLEAR IT BEFORE EXIT SUBROUTINE

        For I = 1 To iNumOutputBytes
            iOutputBuffer(I) = 0
        Next I

INITRET:  'Return status to calling routine
        INIT = INITERR
    End Function
    Function INPUTS(ByRef CommObj As SerialPort, _
                    ByRef iInputBuffer() As Integer, _
                    ByVal iMaxTries As Integer, _
                    ByVal iMaxBuf As Integer, _
                    ByVal iUA As Integer, _
                    ByVal iNumInputs As Integer) As Integer Implements InterfaceCMRI.INPUTS
        '******************************************************
        '**                ***INPUTS***                      **
        '***********VISUAL BASIC VERSION USING MSComm**********
        '** SUBROUTINE TO READ INPUT BYTES IB(1) THRU IB(NI) **
        '**   for use with USIC, SUSIC and SMINI nodes       **
        '******************************************************
        '**TRANSMIT POLL REQUEST TO INITIATE RECEIVING DATA BACK FROM...
        '...INTERFACE HARDWARE
        Dim iMessageType As Integer
        Dim iInByte As Integer
        Dim iMsg(6) As Integer
        Dim I As Integer
        Dim iInputError As Integer
        ' if a stop has been initialized, just exit the routine

        iInputError = 0

REPOL:
        iMessageType = Asc("P") 'Define message type as poll request "P" (decimal 80)

        CommObj.DiscardInBuffer() 'Clear input buffer count and content...
        '...to insure clean start for receiving input bytes

        iInputError = TransmitPackage(CommObj, iUA, iMessageType, 0, iMsg) 'Invoke transmit packet subroutine to transmit...
        '...poll request message to external hardware

        '**LOOP ON RECEIVING INPUT BYTES UNTIL RECEIVE A Start-of-Text (STX)
GETSTX:
        iInputError = iReceiveByte(CommObj, iMaxTries, iUA, iMaxBuf, iInByte)  'Receive input byte into iInbyte variable location

        If iInputError <> 0 Then GoTo INPUTRET 'if there was a read error, just exit

        If iInByte <> 2 Then GoTo GETSTX 'Input byte not STX so branch...
        '...back to read another byte

        '**RECEIVED STX SO READ NEXT BYTE AND SEE IF RETURNED DATA IS...
        '...COMING FROM THE CORRECT USIC ADDRESS

        iInputError = iReceiveByte(CommObj, iMaxTries, iUA, iMaxBuf, iInByte) 'Receive input byte which should be USIC address
        If iInputError <> 0 Then GoTo INPUTRET
        iInByte = iInByte - 65 'Subtract offset of 65 from address and...
        '...check that matches node that was polled
        If iInByte <> iUA Or iInputError <> 0 Then
            LogEvent("ERROR; Received bad UA = " & iInByte)
            GoTo REPOL
        End If

        '**CORRECT UA IS REPLYING BACK TO PC SO CHECK IF "R" MESSAGE
        'iInByte = iReceiveByte(iMaxTries, iUA, iMaxBuf) 'Receive input byte which should be "R"
        iInputError = iReceiveByte(CommObj, iMaxTries, iUA, iMaxBuf, iInByte)

        If iInputError <> 0 Then
            GoTo INPUTRET
        End If

        If iInByte <> 82 Then
            LogEvent("Error received not = R for UA = " & iUA)
            GoTo GETSTX
        End If

        '**MESSAGE IS "R" SO LOOP THROUGH READING INPUTS FROM INPUT PORTS...
        '...ON INTERFACE HARDWARE
        For I = 1 To iNumInputs 'Loop through number of input ports (3 for SMINI)
            iInputError = iReceiveByte(CommObj, iMaxTries, iUA, iMaxBuf, iInByte) 'Receive input byte

            If iInputError <> 0 Then GoTo INPUTRET

            If iInByte = 2 Then
                LogEvent("ERROR: No DLE ahead of 2 for UA = " & iUA) : GoTo REPOL
            End If
            If iInByte = 3 Then
                LogEvent("ERROR: No DLE ahead of 3 for UA = " & iUA) : GoTo REPOL
            End If

            If iInByte = 16 Then 'If byte is DLE, skip it and read the next one...
                iInputError = iReceiveByte(CommObj, iMaxTries, iUA, iMaxBuf, iInByte)
            End If

            If iInputError <> 0 Then GoTo INPUTRET

            iInputBuffer(I) = iInByte 'store valid input byte
        Next I

        '**RECEIVED ALL NI INPUT BYTES SO CHECK FOR End-of-Text (ETX = 3)
        iInputError = iReceiveByte(CommObj, iMaxTries, iUA, iMaxBuf, iInByte) 'Receive input byte which should be ETX
        If iInputError <> 0 Then GoTo INPUTRET

        If iInByte <> 3 Then
            LogEvent("ERROR: ETX NOT PROPERLY RECEIVED FOR iUA = " & iUA)
            iInputError = 1
        End If


INPUTRET:  'Receive message complete so execute RETURN via ENDSUB
        Return iInputError
        'Note: if aborted inputs then ABORTIN = 1 else = 0
    End Function
    Function OUTPUTS(ByRef CommObj As SerialPort, _
                     ByRef UA As Integer, _
                     ByRef NO As Integer, _
                     ByRef iOutputBuffer() As Integer) As Integer Implements InterfaceCMRI.OUTPUTS
        '********************************************************
        '**                ***OUTPUTS***                       **
        '************VISUAL BASIC VERSION USING MSComm***********
        '** SUBROUTINE TO WRITE OUTPUT BYTES iOutputBuffer(1) THRU iOutputBuffer(NO) **
        '**     for use with USIC, SUSIC and SMINI nodes       **
        '********************************************************
        '**TRANSMIT DATA FROM PC TO OUTPUT PORTS ON INTERFACE HARDWARE
        Dim OUTPUTERR As Integer
        OUTPUTERR = 0
        Dim iAscT As Integer
        iAscT = Asc("T") 'Define message type = "T" (decimal 84)
        'LM = NO        'Define message length as number of output ports (for SMINI this is = 6)
        'CommObj.OutBufferCount = 0 'Clear output buffer count and output buffer...

        CommObj.DiscardOutBuffer()

        '...content to insure clean start for...
        '...transmitting output bytes
        OUTPUTERR = TransmitPackage(CommObj, UA, iAscT, NO, iOutputBuffer)
        'Invoke transmit packet subroutine
        'Transmit message complete so return to calling program, passing on any error info
        Return (OUTPUTERR)
    End Function
    Function iReceiveByte(ByRef CommObj As System.IO.Ports.SerialPort, ByVal iMaxTries As Integer, ByRef iUA As Integer, ByRef iMaxBuf As Integer, ByRef iInputByte As Integer) As Integer
        '************************************************
        '**               ***iReceiveByte***           **
        '********VISUAL BASIC VERSION USING MSComm*******
        '** SUBROUTINE TO RECEIVE BYTE AT PC FROM NODE **
        '** for use with USIC, SUSIC and SMINI nodes   **
        '************************************************
        Dim INBYTE As Integer
        Dim iReceiveByteError As Integer


        '**INITIALIZE INPUT TRIES COUNTER AND ABORTING INPUT FLAG
        INTRIES = 0 'Initialize input tries counter to 0
        ABORTIN = 0 'Initialize aborting input flag to 0
        iReceiveByteError = 0  ' Initialize error flag to zero

        '**SET UP A MAJOR LOOP STARTING AT INLOOP FOR PC TO RECEIVE AN...
        '...INPUT BYTE FROM THE INTERFACE HARDWARE
        '**START LOOP BY CHECKING FOR PC OVERRUN ERROR
INLOOP:
        System.Windows.Forms.Application.DoEvents() 'Comment out to reduce background activities (if...
        '...required for overall satisfactory VB operation)
        If CommObj.BytesToRead > iMaxBuf Then
            'If CommObj.InBufferCount > iMaxBuf Then 'If more than maximum...
            '...allowable bytes in buffer...
            '...then PC considered being...
            '...overrun by C/MRI hardware
            LogEvent("PC overrun at node = " & iUA & " with iMaxBuf = " & CStr(iMaxBuf))
            iReceiveByteError = 1
        End If

        '**CHECK IF INPUT TRIES EXCEED MAXIMUM ALLOWED
        INTRIES = INTRIES + 1 'Increment input tries counter
        If INTRIES > iMaxTries Then 'If counter exceeds maximum tries...
            '    ...then abort reading inputs
            ABORTIN = 1
            INTRIES = 0
            LogEvent("INPUT TRIES EXCEEDED " & iMaxTries & " NODE = " & CStr(iUA) & " ABORTING INPUT")
            INBYTE = 0 'Aborted input so set input byte value to 0
            'CommObj.InBufferCount = 0 'Clear input buffer count and content...
            CommObj.DiscardInBuffer()
            iReceiveByteError = 1
            GoTo RXRET '...and branch to receive input byte return
        End If

        '**READING INPUTS NOT ABORTED SO CHECK TO SEE IF INPUT BUFFER...
        '...IS LOADED WITH ONE OR MORE INPUT BYTES

        'let the system do some stuff while waiting for the data
        System.Windows.Forms.Application.DoEvents()

        If CommObj.BytesToRead = 0 Then
            GoTo INLOOP 'If input buffer...
            '...not yet loaded then branch back to beginning...
            '...of input loop to try read again
        End If
        '**PC SERIAL INPUT BUFFER IS LOADED SO RECEIVE INPUT BYTE

        INBYTE = CommObj.ReadByte

        'Form1.Print INBYTE    '!!!!Optional printout of input byte for test and debug
        'Note: Invoking this print slows PC...
        '...significantly so will most likely need...
        '...to significantly increase USIC delay (DL)

RXRET:  'Received byte complete so execute return to calling program

        'Shift the data to the function for passage of data
        iInputByte = INBYTE  'Place the input byte into the address passed by the caller
        iReceiveByte = iReceiveByteError

    End Function


    Function TransmitPackage(ByRef CommObj As System.IO.Ports.SerialPort, ByRef UA As Integer, ByVal iMessageType As Integer, ByVal iMessageLength As Integer, ByRef OutputBuffer() As Integer) As Integer

        Dim bTransmitBuffer(80) As Byte
        Dim iXmitPointer As Integer

        Dim I As Integer

        Dim iXmitError As Integer
        '***************************************************
        '**                ***TransmitPackage***                   **
        '*********VISUAL BASIC VERSION USING MSComm*********
        '** SUBROUTINE TO TRANSMIT PACKET FROM PC TO NODE **
        '**   for use with  SMINI nodes                   **
        '***************************************************

        'The routine is fed the node number (UA), the type of message, the length of message and a buffer with the information
        'contained in the message.
        'The message is then assigned a header, and put into the transmit buffer for sending to the SMINI.
        'Clear the output buffer first....
        CommObj.DiscardOutBuffer()

        iXmitError = 0  ' NOTE: the error funcion is not really implemented yet - transmissions are made, and only the
        ' receive side knows if anything went wrong - this is only a place holder for future enhancement.

        'Create the message header information for SMINI
        bTransmitBuffer(1) = 255 'Set 1st synchronization byte to all 1's
        bTransmitBuffer(2) = 255 'Set 2nd synchronization byte to all 1's
        bTransmitBuffer(3) = 2 'Define start-of-text (STX = 2)
        bTransmitBuffer(4) = CByte(UA + 65) 'Add 65 offset to USIC address
        bTransmitBuffer(5) = CByte(iMessageType) 'Define message type

        iXmitPointer = 6 'Define next position for transmit pointer

        'If this is only a poll request - branch out of loop and transmit....

        If iMessageType = 80 Then
            GoTo ENDMSG 'Poll request so branch to end message
        End If

        'Process through a normal instruction set of data, adding the DLE bytes as necessary

        For I = 1 To iMessageLength 'Loop to set up output data...
            '...including DLE processing

            If OutputBuffer(I) = 2 Then bTransmitBuffer(iXmitPointer) = 16 : iXmitPointer = iXmitPointer + 1 : GoTo DATABYT
            If OutputBuffer(I) = 3 Then bTransmitBuffer(iXmitPointer) = 16 : iXmitPointer = iXmitPointer + 1 : GoTo DATABYT
            If OutputBuffer(I) = 16 Then bTransmitBuffer(iXmitPointer) = 16 : iXmitPointer = iXmitPointer + 1

DATABYT:

            bTransmitBuffer(iXmitPointer) = CByte(OutputBuffer(I)) 'Move actual data byte to transmit buffer
            iXmitPointer = iXmitPointer + 1 'Increment pointer to next byte position
        Next I

        ' END MESSAGE FORMATION WITH End-of-text
ENDMSG:
        bTransmitBuffer(iXmitPointer) = 3 'Add end-of-text (ETX = 3)

        '**LOOP TO LOAD PACKET TO BE TRANSMITTED INTO MSComm's OUTPUT BUFFER


        CommObj.Write(bTransmitBuffer, 1, iXmitPointer)
EMTY:
        System.Windows.Forms.Application.DoEvents() 'Return control to Windows for doing Windows activity

        If CommObj.BytesToWrite > 0 Then GoTo EMTY 'If transmit buffer...

        '...is not empty then branch back to wait for buffer to empty
        'Transmission of output bytes is complete so execute RETURN via END SUB

XMITEXIT:
        TransmitPackage = iXmitError
    End Function
End Class
