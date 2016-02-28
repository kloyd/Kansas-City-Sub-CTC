Module CTCLogic
    Dim theCMRI As InterfaceCMRI

    Public OB(80) As Integer          'Output byte array
    Public IB(60) As Integer        'Input byte array
    Public CT(15) As Integer         'Card type array
    Public TB(120) As Integer       'Transmit buffer array

    Public CODELAMP As Integer
    Public LAMPTEST As Boolean

    '**GLOBALIZE CONSTANTS FOR PACKING AND UNPACKING I/O BYTES
    Public B6, B4, B2, B0, B1, B3, B5, B7 As Integer
    Public W6, W4, W2, W1, W3, W5, W7 As Integer
    ' ** General purpose time delay and program counter vars
    Public TD(21) As Integer
    Public DescriptionOfTimer(21) As String

    Public CCDL, ICDL, SMDL, RTDL, LKDL, T1SAVE, T1, NUMDL, PCT As Integer
    ' ** Block Occupancy constants
    Public CLR, OCC, RTD As Integer
    ' ** Turnout position constants to drive switch motors
    Public TUN, TUR, SMOFF As Integer
    ' ** Searchlight signal aspects
    Public DRK, GRN, YEL, RED, REDGRN, GRNRED, YELRED, REDRED, REDYEL, REDDRK As Integer
    Public REDREDRED, REDREDGRN, REDGRNRED, GRNREDRED As Integer
    Public REDREDYEL, REDYELRED, YELREDRED As Integer
    ' ** Pushbutton pressed
    Public PP As Integer
    ' ** Switch and lock lever positions
    Public LNOR, LREV As Integer
    ' ** Dual Control switch motor in hand or motor
    Public HAND, MOTOR As Integer
    ' ** Signal Lever positions
    Public RIGHT, LEFT, LSTOP As Integer
    ' For traffic indicators.
    Public TRIGHT, TLEFT As Integer
    ' ** Switch Lever indication lamps
    Public DARKLT, NORLT, REVLT As Integer
    ' ** Signal Lever indication lamps
    Public LEFTLT, RIGHTLT, STOPLT As Integer
    ' ** Block detection
    Public BK1, BK2, BK3, BK4, BK5, BK6, BK7, BK8, BK9, BK10 As Integer
    ' ** previous state
    Public OBK1, OBK2, OBK3, OBK4, OBK5, OBK6, OBK7, OBK8, OBK9, OBK10 As Integer
    ' ** Occupancy lamps prior to indication delay.
    Public TL1, TL2, TL3, TL4, TL5, TL6, TL7, TL8, TL9, TL10 As Integer
    ' ** Occupancy lamps after indication delay.
    Public TL1K, TL2K, TL3K, TL4K, TL5K, TL6K, TL7K, TL8K, TL9K, TL10K As Integer
    ' ** Code Start Buttons
    Public CB2, CB4, CB8, CB10, CB12, CB16, CB18, CB20, CB24, CB26 As Integer
    ' ** Code Start Buttons - Latched values.
    Public CB2L, CB4L, CB8L, CB10L, CB12L, CB16L, CB18L, CB20L, CB24L, CB26L As Integer
    ' ** Counter for number of latched code start buttons
    Public CBLCNT As Integer
    ' Switch Lever input variables
    Public SWL1, SWL3, SWL7, SWL9, SWL11, SWL15, SWL23, SWL25 As Integer
    ' ** Switch Lever Input Requested values (latch when code button pressed)
    Public SWL1R, SWL3R, SWL7R, SWL9R, SWL11R, SWL15R, SWL23R, SWL25R As Integer
    ' ** Switch Lever indication lamps prior to indication
    Public SWL1LT, SWL3LT, SWL7LT, SWL9LT, SWL11LT, SWL15LT, SWL23LT, SWL25LT As Integer
    ' Switch Lever indication lamps after indication delay
    Public SWL1LTK, SWL3LTK, SWL7LTK, SWL9LTK, SWL11LTK, SWL15LTK, SWL23LTK, SWL25LTK As Integer
    ' Signal Lever input values
    Public SGL4, SGL8, SGL10, SGL12, SGL24, SGL26 As Integer
    ' Signal Lever input requested values. latched when code button pressed.
    Public SGL4R, SGL8R, SGL10R, SGL12R, SGL24R, SGL26R As Integer
    ' ** GLOBALIZE SIGNAL LEVER INDICATION LIGHTS (Prior to indication delay)
    Public SGL4LT, SGL8LT, SGL10LT, SGL12LT, SGL24LT, SGL26LT As Integer
    ' **GLOBALIZE SIGNAL LEVER INDICATION LIGHTS (After indication delay)
    Public SGL4LTK, SGL8LTK, SGL10LTK, SGL12LTK, SGL24LTK, SGL26LTK As Integer
    ' **GLOBALIZE TIME LOCKING VALUES AND NO VALUE
    Public TLV4, TLV8, TLV10, TLV12, TLV24, TLV26, NV As Integer
    ' ** GLOBALIZE Switch lock indicators
    Public SWLI3, SWLI7, SWLI9, SWLI11, SWLI15, SWLI17, SWLI19, SWLI23, SWLI25 As Integer
    ' **GLOBALIZE TRAFFIC INDICATION LIGHTS FOR OPTIONAL USAGE ON PANEL DISPLAY
    Public FK1, FK2, FK5, FK6 As Integer

    ' **GLOBALIZE MC TOGGLES - not used.
    Public MC16, MC22, MC28, MC32 As Integer

    ' **GLOBALIZE MC TOGGLE REQUESTED VALUES (value latched when code......button is pressed)
    Public MC16R, MC22R, MC28R, MC32R As Integer

    ' **GLOBALIZE MC TOGGLE INDICATION LIGHTS (Prior to Indication delay)
    Public MC16LT, MC22LT, MC28LT, MC32LT As Integer

    ' **GLOBALIZE MC TOGGLE INDICATION LIGHTS (After indication delay)
    Public MC16LTK, MC22LTK, MC28LTK, MC32LTK As Integer

    ' **GLOBALIZE INDICATION LIGHTS ON-OFF CONSTANTS
    Public LTON, LTOFF As Integer

    ' **GLOBALIZE DUAL CONTROL SWITCH MOTOR SELECTOR LEVER POSITION - not used
    Public SEL27, SEL31 As Integer

    ' **GLOBALIZE DUAL CONTROL SWITCH MOTOR HAND-THROW LEVER POSITION - not used
    Public HT27, HT31 As Integer

    ' **GLOBALIZE DUAL CONTROL SWITCH MOTOR PADLOCK INPUTS - not used
    Public PAD27, PAD31 As Integer

    ' **GLOBALIZE SWITCH MOTOR CONTROL LINES ** Customized.
    Public SM1, SM3, SM7, SM9, SM11, SM15, SM23, SM25 As Integer

    ' **GLOBALIZE EASTBOUND WAYSIDE SIGNALS
    Public SIG4RA, SIG4RB, SIG8RAB, SIG8RC, SIG10RABC, SIG12RA, SIG24RAB, SIG26RAB As Integer
    Public SIGF4R, SIGF8R, SIGF10R, SIGF24R, SIGF26R As Integer

    ' **GLOBALIZE WESTBOUND WAYSIDE SIGNALS
    Public SIG4LAB, SIG8LABC, SIG8LD, SIG10LAB, SIG24LA, SIG26LAB, SIG26LC As Integer
    Public SIGF4L, SIGF8L, SIGF10L, SIGF24L, SIGF26L As Integer

    ' **GLOBALIZE TRAFFIC STICKS FOR INTERMEDIATE SIGNALS
    ' KC Sub has no intermediate, but uses Traffic Sticks for blocks 1,2,5,6 and 9
    Public FS1, FS2, FS3, FS4, FS5, FS6, FS7, FS8, FS9, FS10 As Integer

    ' **GLOBALIZE DIRECTIONS FOR TRAFFIC STICKS
    Public EAST, WEST, NDT As Integer

    ' **GLOBALIZE FLASH VARIABLES USED TO FLASH SIGNAL ASPECTS
    Public FLASH, FCNT, FMAX As Integer

    ' Pulsed output
    Public CPULSE, PCNT, PMAX As Integer

    ' **GLOBALIZE FLASHING RED FLAG FOR SIGNALS THAT CAN DISPLAY FLASHING RED
    'Public SIG28RABFR, SIG36RFR

    ' **GLOBALIZE PARAMETER STORAGE LOCATION FOR TRANSMITTING INDICATION CODES
    Public TSTORE(7) As Integer

    ' **GLOBALIZE INDEX VARIABLES FOR INDEXING INTO INDICATION AND CONTROL CODES
    Public IC As Integer   'Index used in control code handling
    Public SI As Integer   'Station index used to indicate station transmitting...
    '...Indication Code

    ' **GLOBALIZE START INDICATION FLAG ARRAY
    Public STK(10) As Integer 'Dimension to number of reporting stations...
    '...(i.e., code buttons) 

    ' **GLOBALIZE STAGING YARD TRAFFIC LEVER INPUT
    Public YRDTFL As Integer 'Used by yardmaster to clear train in and...
    '...out of staging

    ' **GLOBALIZE CODE LIGHTS AND CODE SOUND CONTROL LINES
    Public CDEIND, CODESND, OLDCODESND As Integer

    ' **GLOBALIZE CONTROLLED LOCK LEVER AND LOCK LEVER REQUEST VALUES
    Public CLL17, CLL19, CLL17R, CLL19R As Integer

    ' **GLOBALIZE CONTROLLED LOCK LEVER INDICATION LIGHTS BEFORE AND AFTER DELAY
    Public CLL17LT, CLL19LT, CLL17LTK, CLL19LTK As Integer

    ' **GLOBALIZE SWITCH UNLOCKING CONTROL VARIABLES
    Public UL17, UL19 As Integer

    ' **GLOBALIZE SWITCH UNLOCKING REQUEST VARIABLES
    Public UL17R, UL19R As Integer

    ' **GLOBALIZE LOCK AND UNLOCK CONSTANTS
    Public LOCKED, UNLOCKED As Integer
    ' ** timer 'off'
    Public TMROFF As Integer
    ' **GLOBALIZE TURNOUT FEEDBACK FOR ELECTRICALLY LOCKED SWITCHES
    'Optional usage -- see text Chapter 23 for explanation
    Public TFB3, TFB7, TFB9, TFB11, TFB15, TFB23, TFB25 As Integer
    ' power off indicator
    Public PWRIND As Integer
    ' Fleet switches
    Public FLT8, FLT10, FLT24, FLT26 As Integer
    ' Annunciators and their requests.
    Public ANBV, ANCT, ANCW, ANCE, ANBT As Integer
    Public ANRBV, ANRCT, ANRCW, ANRCE, ANRBT As Integer
    ' Dispatcher
    Public ADBV, ADCT, ADCW, ADCE, ADBT, ANRESET As Integer

    ' ** I LIKE TRAFFIC LIGHTS, I LIKE TRAFFIC LIGHTS
    Public TrafficYellow, TrafficRed, TrafficGreen As Short
    Public DelayMedium, DelayLong, DelayShort As Short
    Public TrafficTimer As Integer
    Public TrafficLightState(5) As Short
    Public TrafficDelay(5) As Short
    Public TrafficCurrentState As Short
    ' Read position of Yard switch linked to 25 Lock
    Public SWI25 As Integer
    ' Annunciator for Yardmaster, Coburg West permission switch
    Public TrainWaitingCoburgWest, TrainWaitingCoburgEast As Integer
    ' Coburg West Input/Latch
    Public SWICW, CWSTATUS As Integer
    ' Coburg West train status constants.
    Public TrainClear, TrainWaiting, YardAccept, TrainInBlock
    Public CLOCKHOURS, CLOCKMINUTES, CLOCKSECONDS As Integer
    ' Train ID for every block 11 = bensenville, 12 = centropolis, 13 = coburg west, 14 = coburg east, 15 = Broadway Tower
    Public TrainID(15) As String
    Public LocoID(15) As String
    Public BlockOccupied(15) As Boolean
    Public SelectedBlock As Integer




    Sub DoOneControlCycle()
        ' Standard CMRI "Real Time Loop"
        REM**CALCULATE GENERAL FLASH VARIABLE FOR FLASHING SIGNAL ASPECTS
        FCNT = FCNT + 1           'Increment flash counter
        If FCNT = FMAX Then       'If count equals maximum count, then...
            FLASH = FLASH Xor 1   '...change state of flash by alternating...
            '...between 0 and 1 using XOR function and...
            FCNT = 0              '...reset flash counter to start new count
        End If
        REM**READ AND UNPACK INPUTS
        'Call READRR()
        Call ReadRailroad()

        REM**PERFORM CONTROL CODE FUNCTIONS
        ' Call CONTROLS()
        Call DoControls()

        REM**SET TRAFFIC STICKS FOR INTERMEDIATE SIGNALS
        ' Call SETSTICKS()
        Call SetTrafficSticks()

        REM**PERFORM POWER SWITCH MOTOR CONTROL FUNCTIONS
        Call CTCSwitch()

        If Not SignalTest.Visible Then
            REM**PERFORM ELECTRIC SWITCH LOCK FUNCTIONS
            Call SwitchLock()

            REM**PERFORM ROUTE CHECK EASTWARD FUNCTIONS
            Call RouteCheckEast()

            REM**PERFORM ROUTE CHECK WESTWARD FUNCTIONS
            Call RouteCheckWest()


            REM**PERFORM TIME LOCKING FUNCTIONS
            Call TimeLocking()

            REM**CLEAR TRAFFIC STICKS FOR INTERMEDIATE SIGNALS
            Call ClearTrafficSticks()

            REM**PERFORM INDICATION CODE FUNCTIONS
            Call Indications()


            REM**PERFORM OFFICE ONLY GENERATED INDICATION LIGHT CALCULATIONS
            Call OfficeIndications()

            REM Graphical Office indicators
            Call GraphicOfficeIndication()

        End If

        REM Traffic Lights
        Call AdvanceTraffic()

        REM**UPDATE DELAY TIME COUNTERS
        Call TimerCount()

        Call SimSignalFailure()

        ' Add in Power Out Indicator.
        REM**PACK AND WRITE OUTPUTS
        Call WriteRailroad()

    End Sub
    Sub InitializeConstants()
        REM**INITIALIZE CONSTANTS FOR PACKING AND UNPACKING I/O BYTES
        B0 = 1 : B1 = 2 : B2 = 4 : B3 = 8 : B4 = 16 : B5 = 32 : B6 = 64 : B7 = 128
        W1 = 1 : W2 = 3 : W3 = 7 : W4 = 15 : W5 = 31 : W6 = 63 : W7 = 127

        REM**INITIALIZE BLOCK OCCUPANCY CONSTANTS
        CLR = 0 ' Clear
        OCC = 1 ' Occupied
        RTD = 2 ' Routed
        OBK1 = 0 : OBK2 = 0 : OBK3 = 0 : OBK4 = 0 : OBK5 = 0 : OBK6 = 0 : OBK7 = 0 : OBK8 = 0 : OBK9 = 0 : OBK10 = 0

        REM**DEFINE ASPECT CONSTANTS FOR WAYSIDE SEARCHLIGHT SIGNALS
        REM**Values assume Searchlight Signals using 3-lead LEDs with...
        REM**...ports driving signals via SMINI configured for alternative...
        REM**...current sourcing rather than standard current sinking or...
        REM**...alternatively retaining all ports as standard current...
        REM**...sinking with RSSD cards inserted between SMINI outputs...
        REM**...and wayside signal inputs.
        DRK = 0         'SEARCHLIGHT SIGNAL DARK                   00
        GRN = 1         'SEARCHLIGHT SIGNAL GREEN                  01
        YEL = 3         'SEARCHLIGHT SIGNAL YELLOW                 11
        RED = 2         'SEARCHLIGHT SIGNAL RED                    10
        REDDRK = 2      'SEARCHLIGHT SIGNAL RED OVER DARK        0010
        REDGRN = 6      ' RED OVER GREEN                         0110
        GRNRED = 9      'SEARCHLIGHT SIGNAL GREEN OVER RED       1001
        YELRED = 11     'SEARCHLIGHT SIGNAL YELLOW OVER RED      1011
        REDRED = 10     'SEARCHLIGHT SIGNAL RED OVER RED         1010
        REDYEL = 14     'SEARCHLIGHT SIGNAL RED OVER YELLOW      1110      
        ' KCSub Specific.
        '**INITIALIZE SIGNAL ASPECT CONSTANTS - Single Head
        DRK = 0 'Dark   00
        GRN = 1 'Green  01
        YEL = 3 'Yellow  11
        RED = 2 'Red    10

        '**INITIALIZE SIGNAL ASPECT CONSTANTS - Double Head
        GRNRED = 6 'Green over red  0110
        REDGRN = 9 'Red over green 1001
        YELRED = 14 'Yellow over red 1110
        REDYEL = 11 'Red over yellow 1011
        REDRED = 10 'Red over red    1010

        '**INITIALIZE SIGNAL ASPECT CONSTANTS - Triple Head
        REDREDRED = &H2A 'Red over red over red    101010
        REDREDYEL = &H2B 'Red over red over yellow 101011
        REDYELRED = &H2E 'Red over yellow over red 101110
        YELREDRED = &H3A 'Yellow over red over red 111010
        GRNREDRED = &H1A 'Green over red over red  011010
        REDGRNRED = &H26 ' 100110 = Red over Green over Red
        REDREDGRN = &H29 ' 101001 = red over red over green

        REM**INITIALIZE TURNOUT POSITION CONSTANTS
        REM**Constants assume directly driving a Tortoise type stall motor...
        REM**...using 2 C/MRI output lines per machine such as in V3.0 Handbook...
        REM**...Fig. 7-23 or if padlock input not used, Fig. 7-15. This example...
        REM**...is specifically based upon using Fig. 7-23.
        REM**See other examples when using SMC12 card requiring only single...
        REM**...output line per machine.
        TUN = 1       'Switch motor control set to normal
        TUR = 2       'Switch motor control set to reverse

        REM**INITIALIZE PUSHBUTTON CONSTANT
        PP = 1        'Pushbutton pressed

        REM**SWITCH LEVER POSITION CONSTANTS (Also used for lock levers)
        LNOR = 1 ' 0 = bruce standard.      'Turnout (switch) lever normal
        LREV = 2 ' 1 = standard     'Turnout (switch) lever reverse

        REM**INITIALIZE HAND OPERATED SWITCH ELECTRIC LOCKING CONSTANTS
        LOCKED = 0    'Also used for setting unlock request to locked
        UNLOCKED = 1  'Also used for setting unlock request to unlocked 

        REM**DUAL CONTROL SWITCH MOTOR IN HAND OR MOTOR CONSTANTS
        MOTOR = 0     'Used for setting selector lever to motor (dispatcher control)
        HAND = 1      'Used for setting selector lever to hand (manual control)

        REM**SIGNAL LEVER POSITION CONSTANTS(Also used for traffic direction lights)
        LEFT = 2      'Signal lever left              10
        LSTOP = 0     'Signal lever at stop (normal)  00
        RIGHT = 1     'Signal lever right             01
        ' Alternates since my lights don't match these constants
        TLEFT = 1
        TRIGHT = 2
        REM**SWITCH LEVER INDICATION LIGHT CONSTANTS (Also used for lock lever lights)
        DARKLT = 0     'Both lights dark            00
        'NORLT = 2     'Normal light illuminated    10
        NORLT = 1 'kc sub
        'REVLT = 1     'Reverse light illuminated   01
        REVLT = 2 'kc sub 

        REM**SIGNAL LEVER INDICATION LIGHT CONSTANTS
        DARKLT = 0    'All three lights dark          000
        RIGHTLT = 1   'Signal Lever Right LED ON    001
        STOPLT = 2    'Signal Lever Normal LED ON   010
        LEFTLT = 4    'Signal Lever Left LED ON     100

        REM**INITIALIZE TRAFFIC STICK DIRECTION CONSTANTS
        WEST = 1      'West (as used in setting Traffic Sticks)
        EAST = 2      'East (by convention, east is even)     
        NDT = 0       'No direction-of-traffic

        REM**INITIALIZE TRAFFIC INDICATION LIGHTS
        FK1 = NDT : FK2 = NDT

        REM**INITIALIZE INDICATION LIGHTS ON-OFF CONSTANTS
        LTON = 1 : LTOFF = 0

        REM**INITIALIZE GENERAL PURPOSE TIME DELAY CONSTANTS
        CCDL = 5         'Control Code transmission delay (5 seconds)
        ICDL = 10        'Indication Code transmission delay (10 seconds)
        SMDL = 12        'Switch motor transition delay (12 seconds)
        RTDL = 60        'Signal running time delay (60 seconds)
        LKDL = 90        'Lock release time delay (90 seconds)
        ' ** debug time delays
        CCDL = 2         'Control Code transmission delay (5 seconds)
        ICDL = 2        'Indication Code transmission delay (10 seconds)
        SMDL = 10        'Switch motor transition delay (12 seconds)
        RTDL = 10        'Signal running time delay (60 seconds)
        LKDL = 10        'Lock release time delay (90 seconds)

        NUMDL = 21       'Number of independent delays
        Dim TD(NUMDL) As Integer 'Dynamically set number of independent asynchronous delays     
        TMROFF = -1   ' timer off

        REM**DEFINE FLASH VARIABLES FOR FLASHING SIGNAL ASPECTS
        FCNT = 0         'Initialize flash counter variable to zero
        FMAX = 5        'Initialize maximum count to set flash rate and...
        '...adjust this value once program operational...
        '...to obtain desired flash rate
        FLASH = 1        'Initialize flash variable to ON
        PMAX = 5
        CPULSE = 0
        OLDCODESND = 0
        CODESND = 0
        SIGF4L = 0 : SIGF4R = 0 : SIGF8L = 0 : SIGF8R = 0 : SIGF10L = 0 : SIGF10R = 0
        SIGF24L = 0 : SIGF24R = 0 : SIGF26L = 0 : SIGF26R = 0
        ' Coburg West yard status
        TrainClear = 0
        TrainWaiting = 1
        YardAccept = 2
        TrainInBlock = 3
        CWSTATUS = TrainClear

        LAMPTEST = False

        ' Keeping track of timer functions (can use for debug)
        DescriptionOfTimer(1) = "Control Code"
        DescriptionOfTimer(2) = "Indication Code"
        DescriptionOfTimer(3) = "Switch Motor 1"
        DescriptionOfTimer(4) = "Switch Motor 3"
        DescriptionOfTimer(5) = "Switch Motor 7"
        DescriptionOfTimer(6) = "Switch Motor 9"
        DescriptionOfTimer(7) = "Switch Motor 11"
        DescriptionOfTimer(8) = "Switch Motor 15"
        DescriptionOfTimer(9) = "Switch Motor 23"
        DescriptionOfTimer(10) = "Switch Motor 25"
        DescriptionOfTimer(11) = "TLV4"
        DescriptionOfTimer(12) = "TLV8"
        DescriptionOfTimer(13) = "TLV10"
        DescriptionOfTimer(14) = "TLV24"
        DescriptionOfTimer(15) = "TLV26"
        DescriptionOfTimer(16) = "LCK17"
        DescriptionOfTimer(17) = "LCK19"
        DescriptionOfTimer(18) = "TRAFFICLIGHTS"
        DescriptionOfTimer(19) = "Power Up Delay"
        DescriptionOfTimer(20) = "Signal Lamp failure"
        DescriptionOfTimer(21) = "TLV12"

        CLOCKHOURS = 7
        CLOCKMINUTES = 0
        CLOCKSECONDS = 0

        Randomize()

    End Sub
    Sub InitializeControls()

        REM**INITIALIZE SWITCH LEVER INDICATION LIGHTS TO NORMAL
        'Prior to indication delay
        SWL1LT = NORLT : SWL3LT = NORLT : SWL7LT = NORLT
        SWL9LT = NORLT : SWL11LT = NORLT : SWL15LT = NORLT
        SWL23LT = NORLT : SWL25LT = NORLT

        REM**INITIALIZE SWITCH LEVER INDICATION LIGHTS TO NORMAL
        'After indication delay
        SWL1LTK = NORLT : SWL3LTK = NORLT : SWL7LTK = NORLT
        SWL9LTK = NORLT : SWL11LTK = NORLT : SWL15LTK = NORLT
        SWL23LTK = NORLT : SWL25LTK = NORLT

        REM**INITIALIZE SIGNAL LEVER INDICATION LIGHTS TO NORMAL (STOP)
        'Prior to indication delay
        SGL4LT = STOPLT : SGL8LT = STOPLT : SGL10LT = STOPLT : SGL12LT = STOPLT
        SGL24LT = STOPLT : SGL26LT = STOPLT

        REM**INITIALIZE SIGNAL LEVER INDICATION LIGHTS TO NORMAL (STOP)
        'After indication delay
        SGL4LTK = STOPLT : SGL8LTK = STOPLT : SGL10LTK = STOPLT : SGL12LTK = STOPLT
        SGL24LTK = STOPLT : SGL26LTK = STOPLT

        REM**INITIALIZE SWITCH MOTOR CONTROL LINES TO NORMAL
        'Recommended when NOT using SMC12 card, as normal is non-zero
        SM1 = TUN : SM3 = TUN : SM7 = TUN : SM9 = TUN : SM11 = TUN
        SM15 = TUN : SM23 = TUN : SM25 = TUN

        REM**INITIALIZE CONTROLLED LOCK LEVER INDICATION LIGHTS TO NORMAL...
        '...prior to indication delay
        CLL17LT = NORLT : CLL19LT = NORLT

        REM**INITIALIZE CONTROLLED LOCK LEVER INDICATION LIGHTS TO NORMAL...
        '...after indication delay
        CLL17LTK = NORLT : CLL19LTK = NORLT

        REM**INITIALIZE SWITCH LEVER REQUESTS TO NORMAL
        SWL1R = LNOR : SWL3R = LNOR : SWL7R = LNOR : SWL9R = LNOR
        SWL11R = LNOR : SWL15R = LNOR : SWL23R = LNOR : SWL25R = LNOR

        REM**INITIALIZE SIGNAL LEVER REQUESTS TO NORMAL
        SGL4R = LSTOP : SGL8R = LSTOP : SGL10R = LSTOP : SGL12R = LSTOP
        SGL24R = LSTOP : SGL26R = LSTOP

        REM**INITIALIZE CONTROLLED LOCK LEVER REQUESTS TO NORMAL
        '...prior to indication delay
        CLL17R = LNOR : CLL19R = LNOR

        REM**INITIALIZE PADLOCK VARIABLES TO LOCKED AND HAND THROW INPUTS TO NORMAL
        PAD27 = LOCKED : PAD31 = LOCKED : HT27 = LNOR : HT31 = LNOR

        REM**INITIALIZE LOCK AND LOCK REQUEST VARIABLES TO LOCKED
        UL17R = LOCKED : UL19R = LOCKED
        UL17 = LOCKED : UL19 = LOCKED

        REM**INITIALIZE TURNOUT FEEDBACK VARIABLES TO NORMAL
        'TF25 = TUN : TF29 = TUN

        REM**INITIALIZE TRAFFIC STICKS TO NO-DIRECTION-OF-TRAFFIC
        FS1 = NDT : FS2 = NDT : FS3 = NDT : FS4 = NDT : FS5 = NDT : FS6 = NDT : FS7 = NDT : FS8 = NDT : FS9 = NDT : FS10 = NDT

        REM**INITIALIZE CALL-ON BUTTON LATCH TO NORMAL (Clear or No Value)
        'COB28L = NV

        REM INITIALIZE SWITCH LOCK INDICATORS
        SWLI3 = 0 : SWLI7 = 0 : SWLI9 = 0 : SWLI11 = 0 : SWLI15 = 0 : SWLI17 = 0 : SWLI19 = 0 : SWLI23 = 0 : SWLI25 = 0

        REM**INITIALIZE CODE LIGHTS TO OFF
        CDEIND = 0
        ' power timer off
        TD(19) = TMROFF
        TD(20) = 60 ' check for failed signal lamps every minute

        ' Set all signals to stop before checking TrafficSticks.
        SIG4LAB = REDRED
        SIG4RA = RED
        SIG4RB = RED
        SIG8LABC = REDREDRED
        SIG8LD = RED
        SIG8RAB = REDRED
        SIG8RC = RED
        SIG10LAB = REDRED
        SIG10RABC = REDREDRED
        SIG12RA = RED
        SIG24LA = RED
        SIG24RAB = REDRED
        SIG26LAB = REDRED
        SIG26LC = RED
        SIG26RAB = REDRED

        ' Reset annunciators
        ANBT = 0 : ANBV = 0 : ANCE = 0 : ANCW = 0 : ANCT = 0
        ADBT = 0 : ADBV = 0 : ADCE = 0 : ADCW = 0 : ADCT = 0
        TrainWaitingCoburgEast = 0 : TrainWaitingCoburgWest = 0
        CWSTATUS = TrainClear

    End Sub
    Sub InitializeRailroad(ByRef CMRI As InterfaceCMRI)
        Call InitializeConstants()
        LogEvent("Initialize Controls")
        Call InitializeControls()
        Call InitializeTrafficLights()
        LogEvent("Intialize Nodes")
        InitializeNodes(CMRI)

    End Sub
    Sub InitializeNodes(ByRef CMRI As InterfaceCMRI)
        ' throw away the current CMRI
        theCMRI = Nothing
        ' create a CMRI object
        theCMRI = CMRI
        ' Initialize the comm port.
        Dim errorCode As Integer

        errorCode = theCMRI.InitializePort(MainPanel.CommPort, COMPORT:=4, BAUD100:=96, MAXBUF:=128)
        '**INITIALIZE NODE 0 SMINI - CTC Panel Turnout Controller
        Call theCMRI.INIT(MainPanel.CommPort, UA:=0, DL:=0, strNDP:="M", iNumOutputBytes:=6, MAXTRIES:=2000, iNumInputBytes:=3, iNum2LeadSigs:=0, CT:=CT)
        '**INITIALIZE NODE 1 SMINI - CTC Panel Signal Controller
        Call theCMRI.INIT(MainPanel.CommPort, UA:=1, DL:=0, strNDP:="M", iNumOutputBytes:=6, MAXTRIES:=2000, iNumInputBytes:=3, iNum2LeadSigs:=0, CT:=CT)
        '**INITIALIZE NODE 2 SMINI - Sheffield/Rock Creek
        Call theCMRI.INIT(MainPanel.CommPort, UA:=2, DL:=0, strNDP:="M", iNumOutputBytes:=6, MAXTRIES:=2000, iNumInputBytes:=3, iNum2LeadSigs:=0, CT:=CT)
        '**INITIALIZE NODE 3 SMINI - Freight Line Jct
        CT(1) = 0 'Card 0 port A has no signals
        CT(2) = 0 'Card 0 port B has no signals connected
        CT(3) = 0 'Card 0 port C has no signals
        ' Node 3 Card 1 Port A = Signal24RightHead, Signal26RightHead
        ' 11111111
        CT(4) = &HFF
        ' Node 3 Card 1 Port B = Signal26LeftHead, Signal24LeftHead
        ' 00111111
        CT(5) = &HFF
        CT(6) = 0 'Card 1 port C has no signals
        Call theCMRI.INIT(MainPanel.CommPort, UA:=3, DL:=0, strNDP:="M", iNumOutputBytes:=6, MAXTRIES:=2000, iNumInputBytes:=3, iNum2LeadSigs:=8, CT:=CT)

    End Sub
    Sub InitializeTrafficLights()
        TrafficGreen = 4
        TrafficYellow = 2
        TrafficRed = 1
        DelayLong = 10
        DelayMedium = 5
        DelayShort = 1

        TrafficLightState(0) = TrafficGreen Or TrafficRed * 8
        TrafficLightState(1) = TrafficYellow Or TrafficRed * 8
        TrafficLightState(2) = TrafficRed Or TrafficRed * 8
        TrafficLightState(3) = TrafficRed Or TrafficGreen * 8
        TrafficLightState(4) = TrafficRed Or TrafficYellow * 8
        TrafficLightState(5) = TrafficRed Or TrafficRed * 8
        TrafficCurrentState = 0

        TrafficDelay(0) = DelayLong
        TrafficDelay(1) = DelayMedium
        TrafficDelay(2) = DelayShort
        TrafficDelay(3) = DelayLong
        TrafficDelay(4) = DelayMedium
        TrafficDelay(5) = DelayShort

        TD(18) = TrafficDelay(TrafficCurrentState)

    End Sub
    Sub AdvanceTraffic()
        ' has the required time elapsed?
        If TD(18) < 0 Then
            TrafficCurrentState = TrafficCurrentState + 1
            If TrafficCurrentState > 5 Then TrafficCurrentState = 0
            TD(18) = TrafficDelay(TrafficCurrentState)
        End If
    End Sub
    Sub ReadRailroad()
        '**SUBROUTINE TO READ ALL NODE INPUTS AND PERFORM UNPACKING OPERATIONS
        ' == NODE 0 == READ AND UNPACK INPUTS FOR NODE 0 (SMINI)
        ' Switch Lever positions on Node 0
        Call theCMRI.INPUTS(MainPanel.CommPort, iInputBuffer:=IB, iMaxTries:=2000, iMaxBuf:=128, iUA:=0, iNumInputs:=3)
        ' Positive inputs. Normal = 1 and Reverse =2
        ' if input = 0 then switch is in illegal position.
        ' Node 0, Card 2 A0-A7
        SWL1 = IB(1) \ B0 And W2
        SWL3 = IB(1) \ B2 And W2
        SWL7 = IB(1) \ B4 And W2
        SWL9 = IB(1) \ B6 And W2
        ' Node 0, Card 2, B0-B7
        SWL11 = IB(2) \ B0 And W2
        SWL15 = IB(2) \ B2 And W2
        CLL17 = IB(2) \ B4 And W2
        CLL19 = IB(2) \ B6 And W2
        ' Node 0, Card 2, C0-C7
        SWL23 = IB(3) \ B0 And W2
        SWL25 = IB(3) \ B2 And W2

        ' === NODE 1 ===
        Call theCMRI.INPUTS(MainPanel.CommPort, iInputBuffer:=IB, iMaxTries:=2000, iMaxBuf:=128, iUA:=1, iNumInputs:=3)

        ' Node 1, Card 2, A0-A7
        SGL26 = IB(1) \ B0 And W2
        SGL24 = IB(1) \ B2 And W2
        SGL10 = IB(1) \ B4 And W2
        SGL8 = IB(1) \ B6 And W2
        ' Node 1, Card 2, B0-B7
        SGL4 = IB(2) \ B0 And W2
        SGL12 = IB(2) \ B2 And W1

        ' annunciator reset button.
        ANRESET = IB(2) \ B3 And W1


        ' Node 1, Card 2, Port B6, B7 - top two code buttons
        CB2 = IB(2) \ B6 And W1
        CB4 = IB(2) \ B7 And W1
        ' Node 1, Card 2, Port C0-C7 - 8 code buttons.
        CB8 = IB(3) \ B0 And W1
        CB10 = IB(3) \ B1 And W1
        CB12 = IB(3) \ B2 And W1
        CB16 = IB(3) \ B3 And W1
        CB18 = IB(3) \ B4 And W1
        CB20 = IB(3) \ B5 And W1
        CB24 = IB(3) \ B6 And W1
        CB26 = IB(3) \ B7 And W1

        ' Node 1, Port C = Fleet switches (single bit)
        'FLT26 = IB(3) \ B0 And W1
        'FLT24 = IB(3) \ B1 And W1
        'FLT10 = IB(3) \ B2 And W1
        'FLT8 = IB(3) \ B3 And W1

        ' === NODE 2 ===
        Call theCMRI.INPUTS(MainPanel.CommPort, iInputBuffer:=IB, iMaxTries:=2000, iMaxBuf:=128, iUA:=2, iNumInputs:=3)
        ' Turnout positions on Node 2, Card 2, Port A - Read Turnout Indicators
        TFB3 = IB(1) \ B0 And W1
        TFB7 = IB(1) \ B1 And W1
        TFB9 = IB(1) \ B2 And W1
        TFB11 = IB(1) \ B3 And W1
        TFB15 = IB(1) \ B4 And W1
        TFB23 = IB(1) \ B5 And W1

        PWRIND = IB(2)
        If PWRIND = LTOFF Then
            TD(19) = 2 ' 2 second delay for power back on.
        End If

        ' === NODE 3 ===

        Call theCMRI.INPUTS(MainPanel.CommPort, iInputBuffer:=IB, iMaxTries:=2000, iMaxBuf:=128, iUA:=3, iNumInputs:=3)

        ' card 2 port a Blocks on Node 3 Port A
        ' If Power is back on and Power On delay is expired, Read the blocks.
        If PWRIND = LTON And TD(19) = TMROFF Then
            BK1 = IB(1) \ B0 And W1
            BK2 = IB(1) \ B1 And W1
            BK3 = IB(1) \ B2 And W1
            BK4 = IB(1) \ B3 And W1
            BK5 = IB(1) \ B4 And W1
            BK6 = IB(1) \ B5 And W1
            BK7 = IB(1) \ B6 And W1
            BK8 = IB(1) \ B7 And W1
            ' card 2 port b
            BK9 = IB(2) \ B0 And W1
            BK10 = IB(2) \ B1 And W1
            ' a little test of the input filters.
            ' 2011-02-14 - After installing the recommended filter RC components, I have never seen this Log message.
            If (OBK10 <> BK10) Then
                LogEvent("Block 10 changed state, " + CStr(BK10))
                OBK10 = BK10
            End If
        End If
        ' Node 3, Card 2, C0-C7
        ANRBV = IB(3) \ B0 And W1
        ANRCT = IB(3) \ B1 And W1
        ANRCE = IB(3) \ B2 And W1
        ANRCW = IB(3) \ B3 And W1
        ANRBT = IB(3) \ B4 And W1

        ' Get position of yard switch on Yardmasters Control panel. (and permission switch for West entrance)
        SWI25 = IB(2) \ B3 And W1
        SWICW = IB(2) \ B4 And W1

    End Sub
    Sub SetTrafficSticks()
        REM****************SUBROUTINE SETSTICKS******************
        REM** SET TRAFFIC STICK UPON SEQUENTIAL TRAIN MOVEMENT **
        REM******************************************************
        ' 
        Dim OldFS9 As Integer
        Dim OldFS3, OldFS4 As Integer

        OldFS3 = FS3
        OldFS4 = FS4

        REM FS1 North Main between Rock Creek and Freight Line
        ' Check East first (Left)
        If FS1 = NDT And TLV24 = LEFT And SWL23LTK = LNOR Then FS1 = EAST
        If FS1 = NDT And TLV26 = LEFT And SWL23LTK = LREV And SWL25LTK = LNOR Then FS1 = EAST
        ' Check West (Right)
        ' Check Turnouts 7 and 9. 7n9n, 7r9n, 7n9r, 7r9r==7n9r => three conditions. 15 must always be normal to set FS1.
        If FS1 = NDT And TLV8 = RIGHT And SWL15LTK = LNOR Then
            FS1 = WEST
        End If
        If FS1 = NDT And TLV10 = RIGHT And SWL9LTK = LREV And SWL15LTK = LNOR Then
            FS1 = WEST
        End If
        'If (FS1 = NDT And SIG10RABC <> REDREDRED And SWL7LT = LNOR And SWL9LT = LREV And SWL15LT = LNOR) Then FS1 = WEST
        REM FS2 South Main between Rock Creek and Freight Line
        ' Eastward first.
        If (FS2 = NDT And TLV26 = LEFT And SWL23LTK = LNOR And SWL25LTK = LNOR) Then FS2 = EAST
        If (FS2 = NDT And TLV26 = LEFT And SWL25LTK = LREV) Then FS2 = EAST
        ' Westward
        If (FS2 = NDT And SIG10RABC <> REDREDRED And SWL9LTK = LNOR And SWL11LTK = LNOR) Then FS2 = WEST
        If (FS2 = NDT And SIG12RA <> RED And SWL11LTK = LREV) Then FS2 = WEST
        If FS2 = NDT And TLV10 = RIGHT And SWL9LTK = LNOR Then FS2 = WEST
        If FS2 = NDT And TLV12 = RIGHT Then FS2 = WEST

        ' *** FS3 ***
        ' Eastward
        If FS3 = NDT And SIG24LA <> RED And SWL23LTK = LNOR Then
            FS3 = EAST
        End If
        If FS3 = NDT And SIG26LAB <> REDRED And SWL23LTK = LREV Then
            FS3 = EAST
        End If
        ' Westward
        If FS3 = NDT And SIG24RAB <> REDRED Then
            FS3 = WEST
        End If


        ' *** FS4 ***
        ' Eastward
        If FS4 = NDT And SWL25LTK = LNOR And SIG26LAB <> REDRED Then FS4 = EAST
        If FS4 = NDT And SWL25LTK = LREV And SIG26LC <> RED Then FS4 = EAST
        ' Westward
        If FS4 = NDT And SIG26RAB <> REDRED Then FS4 = WEST

        REM FS5 North Main between Sheffield and Freight Line
        ' Eastward
        If FS5 = NDT And SIG8LABC <> REDREDRED And SWL9LTK = LNOR And SWL15LTK = LNOR And SWL7LTK = LNOR Then
            FS5 = EAST
        End If
        If FS5 = NDT And SIG8LD <> RED And SWL9LTK = LNOR And SWL15LTK = LREV And SWL7LTK = LNOR Then
            FS5 = EAST
        End If
        ' Westward
        If FS5 = NDT And SIG24RAB <> REDRED And SWL23LTK = LNOR Then
            FS5 = WEST
        End If

        REM FS6 South Main between Sheffield and Frieght Line
        ' Eastward
        If FS6 = NDT And SIG10LAB <> REDRED And SWL11LTK = LNOR Then FS6 = EAST
        If FS6 = NDT And SIG8LABC <> REDREDRED And SWL9LTK = LREV Then FS6 = EAST
        If FS6 = NDT And SIG8LD <> RED And SWL9LTK = LREV And SWL15LTK = LREV Then FS6 = EAST
        ' Westward
        If FS6 = NDT And SIG26RAB <> REDRED And SWL25LTK = LNOR Then FS6 = WEST
        If FS6 = NDT And SIG24RAB <> REDRED And SWL23LTK = LREV Then FS6 = WEST

        ' FS7 - Eastward
        If FS7 = NDT And TLV8 = EAST Then FS7 = EAST

        ' FS7 - Westward
        If FS7 = NDT And TLV8 = WEST Then FS7 = WEST
        If FS7 = NDT And TLV10 = WEST And SWL9LTK = LREV Then FS7 = WEST

        ' FS8 - Eastward

        ' FS8 - Westward


        REM FS9 - Southwest Jct
        OldFS9 = FS9
        ' west
        If FS9 = NDT And TLV4 = RIGHT Then FS9 = WEST
        ' east
        ' Not certain why tlv8 heading into the bridge should condition FS9 - turning it off now.
        ' If FS9 = NDT And TLV8 = LEFT And SWL7LT = LREV And SWL9LT = LNOR Then FS9 = EAST
        If FS9 = NDT And TLV4 = LEFT Then FS9 = EAST
        If OldFS9 <> FS9 Then
            If FS9 = WEST Then LogEvent("SetTrafficSticks: FS9 = West.")
            If FS9 = EAST Then LogEvent("SetTrafficSticks: FS9 = East.")
        End If


        If OldFS3 <> FS3 Then
            If FS3 = WEST Then LogEvent("SetTrafficSticks: FS3 = West.")
            If FS3 = EAST Then LogEvent("SetTrafficSticks: FS3 = East.")
        End If

        If OldFS4 <> FS4 Then
            If FS4 = WEST Then LogEvent("SetTrafficSticks: FS4 = West.")
            If FS4 = EAST Then LogEvent("SetTrafficSticks: FS4 = East.")
        End If

        ' new checks
        If BK10 = OCC And TrainID(15) <> "" Then
            TrainID(10) = TrainID(15)
            TrainID(15) = ""
        End If

        If BK10 = OCC And BK7 = OCC And SIG8LD <> RED Then
            TrainID(7) = TrainID(10)
            LogTrain("OS Train " + TrainID(7) + " - Rock Creek Jct")
        End If

        If BK10 = CLR Then TrainID(10) = ""

    End Sub
    Sub DoControls()
        REM***********************SUBROUTINE CONTROLS *************************
        REM** HANDLES MULTIPLE CODE BUTTON PRESSES TO SEQUENTIALLY ESTABLISH **
        REM** REQUESTED VALUES OF MAINTAINER CALL, SWITCH LEVER AND SIGNAL   **
        REM** LEVER INCLUDING THE AFFECTS OF CONTROL CODE DELAYS             **
        REM********************************************************************

        REM *******************
        REM Illuminate Annunciators if field buttons pressed.
        REM *******************
        If ANRBV = 1 Then ANBV = 1 : ADBV = 1
        If ANRCT = 1 Then ANCT = 1 : ADCT = 1
        If ANRCW = 1 Then ANCW = 1 : ADCW = 1
        If ANRCE = 1 Then ANCE = 1 : ADCE = 1
        If ANRBT = 1 Then ANBT = 1 : ADBT = 1

        If ANRESET = 1 Then ANBV = 0 : ADBV = 0 : ANCT = 0 : ADCT = 0 : ANCW = 0 : ADCW = 0 : ANCE = 0 : ADCE = 0 : ANBT = 0 : ADBT = 0

        'Field Annunciators do not flash, but dispatcher ones will.
        ' Ebil Flash Dispatcher annunciators
        If ANBV = 1 And FLASH = 1 Then ADBV = 1 Else ADBV = 0
        If ANCT = 1 And FLASH = 1 Then ADCT = 1 Else ADCT = 0
        If ANCW = 1 And FLASH = 1 Then ADCW = 1 Else ADCW = 0
        If ANCE = 1 And FLASH = 1 Then ADCE = 1 Else ADCE = 0
        If ANBT = 1 And FLASH = 1 Then ADBT = 1 Else ADBT = 0

        REM **********
        REM Yardmaster annunciators
        REM **********
        ' if the yardmaster pushes button and a train is waiting, move status to Accept
        If SWICW = LTON And CWSTATUS = TrainWaiting Then
            CWSTATUS = YardAccept
        End If
        'if dispatcher takes away signal (10L will be red/red and block 8 will be clear)
        ' change status to clear
        If SIG10LAB = REDRED And SGL10R = LSTOP And SM11 = TUR And BK8 = CLR Then
            CWSTATUS = TrainClear
        End If
        ' if signal 10 is left and turnout 11 reverse and no train, make status TrainWaiting
        If SGL10R = LEFT And SM11 = TUR And CWSTATUS = TrainClear Then
            CWSTATUS = TrainWaiting
        End If

        If SGL10R = LEFT And SM11 = TUR Then
            If FLASH = 1 Then TrainWaitingCoburgWest = 1 Else TrainWaitingCoburgWest = 0
        End If
        If CWSTATUS = YardAccept Then ' Yardmaster has toggled Accept switch.
            TrainWaitingCoburgWest = 1
        End If
        If CWSTATUS = TrainInBlock Then
            TrainWaitingCoburgWest = 1
        End If
        If CWSTATUS = TrainClear Then
            TrainWaitingCoburgWest = 0
        End If

        If SGL26R = RIGHT And SM25 = TUR Then
            If FLASH = 1 Then TrainWaitingCoburgEast = 1 Else TrainWaitingCoburgEast = 0
        End If
        If SWI25 = LTON Then 'Yardmaster has opened turnout #25
            TrainWaitingCoburgEast = 0
        End If
        REM*******************************************
        REM**** CODE BUTTON LATCHING AND COUNTING ****
        REM*******************************************

        REM**IF CODE BUTTON IS PRESSED SET ITS LATCHED VALUE TO PRESSED           
        If CB2 = PP Then CB2L = PP
        If CB4 = PP Then CB4L = PP
        If CB8 = PP Then CB8L = PP
        If CB10 = PP Then CB10L = PP
        If CB12 = PP Then CB12L = PP
        If CB16 = PP Then CB16L = PP
        If CB18 = PP Then CB18L = PP
        If CB20 = PP Then CB20L = PP
        If CB24 = PP Then CB24L = PP
        If CB26 = PP Then CB26L = PP

        REM**COUNT HOW MANY CODE BUTTONS ARE LATCHED
        CBLCNT = 0  'Initialize number to zero and start counting
        If CB2L = PP Then CBLCNT = CBLCNT + 1
        If CB4L = PP Then CBLCNT = CBLCNT + 1
        If CB8L = PP Then CBLCNT = CBLCNT + 1
        If CB10L = PP Then CBLCNT = CBLCNT + 1
        If CB12L = PP Then CBLCNT = CBLCNT + 1
        If CB16L = PP Then CBLCNT = CBLCNT + 1
        If CB18L = PP Then CBLCNT = CBLCNT + 1
        If CB20L = PP Then CBLCNT = CBLCNT + 1
        If CB24L = PP Then CBLCNT = CBLCNT + 1
        If CB26L = PP Then CBLCNT = CBLCNT + 1

        'LogEvent("CBLCNT = " & CBLCNT)
        REM*********************************
        REM**** CONTROL CODE SCHEDULING ****
        REM*********************************

        REM**IF AN INDICATION CODE IS IN PROCESS, THEN HOLD OFF...
        '...CONTROL CODE PROCESSING
        If CDEIND = 1 Then GoTo CCEND

        REM**IF CONTROL CODE IS IN PROCESS, THEN CONTINUE WITH CODING
        If IC > 0 Then GoTo CCODE

        REM**IF NO CODE BUTTONS ARE LATCHED THEN SKIP CONTROL...
        '...CODE PROCESSING
        If CBLCNT = 0 Then GoTo CCEND

        REM**ONE OR MORE CODE BUTTONS ARE LATCHED SO IF A BUTTON...
        '... HAS NOT BEEN SELECTED THEN, IN STATION ORDER...
        '...SELECT THE NEXT BUTTON TO BE PROCESSED AND SET...
        '...THE CORRESPONDING START INDICATION FLAG
        If IC = 0 Then
            If CB2L = PP Then IC = 1 : STK(1) = 1 : GoTo CCODE
            If CB4L = PP Then IC = 2 : STK(2) = 1 : GoTo CCODE
            If CB8L = PP Then IC = 3 : STK(3) = 1 : GoTo CCODE
            If CB10L = PP Then IC = 4 : STK(4) = 1 : GoTo CCODE
            If CB12L = PP Then IC = 5 : STK(5) = 1 : GoTo CCODE
            If CB16L = PP Then IC = 6 : STK(6) = 1 : GoTo CCODE
            If CB18L = PP Then IC = 7 : STK(7) = 1 : GoTo CCODE
            If CB20L = PP Then IC = 8 : STK(8) = 1 : GoTo CCODE
            If CB24L = PP Then IC = 9 : STK(9) = 1 : GoTo CCODE
            If CB26L = PP Then IC = 10 : STK(10) = 1 : GoTo CCODE
        End If

        REM*************************************
        REM**** INDUCING CONTROL CODE DELAY ****
        REM*************************************

        REM**CODE BUTTON TO BE PROCESSED IS SELECTED SO...
CCODE:  '...PROCESS A CONTROL CODE CYCLE
        CDEIND = 2      'Turn on control code light (binary 10)
        CODESND = 2     'Turn on control code sound chip (binary 10)

        If TD(1) > 0 Then GoTo CCEND 'If delay active then branch to CCEND
        If TD(1) = 0 Then TD(1) = CCDL : GoTo CCEND 'If delay not active...
        '...then initialize delay and branch to CCEND 
        If TD(1) < 0 Then    'If coding delay complete then...
            ' Turn off Code Light and Sound
            CDEIND = 0
            CODESND = 0     '...turn off control code sound...
            TD(1) = 0       '...and reset coding time delay
        End If

        REM*********************************************************
        REM**   ACCEPT OR REJECT SETTING LEVER REQUESTED VALUES   **
        REM**(Action performed by field circuitry after Control...**
        REM**...Code delay has expired)                            **
        REM*********************************************************
        REM**CODING DELAY COMPLETE SO BRANCH TO PROCESS SELECTED BUTTON    
        REM***********************************************
        REM**  STATION CONTROL CODE SELECTION GROUP     **
        REM**(Actions taken at each OS section, after...**
        REM**...the Control Code delay has expired)     **
        REM***********************************************
        If (IC > 0 And IC < 11) Then
            Select Case IC
                Case 1
                    ' CB2 - Gate at Southwest - just follow switch lever 1
                    LogEvent("Checking Code button CB2")
                    If SWL1 <> 0 Then SWL1R = SWL1
                    IC = 0
                    CB2L = NV
                Case 2
                    ' CB4 - Switch 3, Signal 4
                    LogEvent("Checking Code button CB4")
                    If BK9 = CLR Then
                        'Extra checks for accepting Signal lever 4 - if we reject now, then the signal lamp will go back to stop.
                        ' 2012-06-01 - After consultation, determine that correct behaviour is to accept if the block is clear
                        ' field equipment will hold the request until it can be granted.
                        'If SWL7LT = LNOR Then SGL4R = SGL4
                        'If SWL7LT = LREV And FS9 = EAST And SGL4 = RIGHT Then GoTo SWL3Check
                        'If SGL4 = LEFT Then SGL4R = SGL4
                        SGL4R = SGL4
                        'extra check for lever stuck in middle position (0), don't accept twice while turnout delay in effect.
                        ' td(4) = SM3
SWL3Check:              If TLV4 = NV And SWL3 <> 0 Then SWL3R = SWL3
                    End If
                    IC = 0
                    CB4L = NV
                Case 3
                    LogEvent("Checking Code button CB8")
                    ' CB8 - Switch 7, Signal 8
                    If BK7 = CLR Then
                        ' all causes to reject the signal.
                        ' Westward traffic in block 6.
                        'If SGL8 = LEFT And SWL9LT = REVLT And FS6 = WEST Then GoTo SWL7Check
                        ' Westward traffic in block 5.
                        'If SGL8 = LEFT And SWL9LT = LNOR And SWL7LT = LNOR And FS5 = WEST Then GoTo SWL7Check
                        ' Eastward traffic in block 1.
                        'If SGL8 = RIGHT And SWL15LT = LNOR And FS1 = EAST Then GoTo SWL7Check
                        ' Check if FS9 against us.
                        'If SGL8 = LEFT And SWL9LT = LNOR And SWL7LT = LREV And FS9 = WEST Then GoTo SWL7Check
                        SGL8R = SGL8
                        'td(5) = SM7 And TD(5) = 0
SWL7Check:              If TLV8 = NV And SWL7 <> 0 Then SWL7R = SWL7
                    End If
                    IC = 0
                    CB8L = NV
                Case 4
                    ' CB10 - Switch 9, Signal 10
                    LogEvent("Checking Code button CB10")
                    If BK8 = CLR Then
                        ' Rejects
                        'If SGL10 = LEFT And SWL9LT = LNOR And SWL11LT = LNOR And FS6 = WEST Then GoTo SWL9Check
                        'If SGL10 = RIGHT And SWL9LT = LNOR And FS2 = EAST Then GoTo SWL9Check
                        'If SGL10 = RIGHT And SWL9LT = LREV And SWL15LT = LNOR And FS1 = EAST Then GoTo SWL9Check
                        'If TLV12 = RIGHT And SGL10 = RIGHT And SWL9 = LNOR Then GoTo SWL9Check
                        SGL10R = SGL10
                        'only accept switch lever if no signal cleared across, lever <> 0 and not running turnout delay.
                        ' switch 9 delay is TD(6) And TD(6) = 0
SWL9Check:              If TLV10 = NV And TLV8 = NV And SWL9 <> 0 Then
                            LogEvent("Accepting Switch 9 Lever input.")
                            SWL9R = SWL9
                        End If

                    End If
                    IC = 0
                    CB10L = NV
                Case 5
                    ' CB12 - Switch 11 and Signal 12
                    LogEvent("Checking Code button CB12")
                    If BK8 = CLR Then
                        'If SGL12 = RIGHT And TLV10 = LEFT Then GoTo SWL11Check
                        'If SGL12 = RIGHT And FS2 = EAST Then GoTo SWL11Check
                        SGL12R = SGL12
                        'And TD(7) = 0
SWL11Check:             If TLV10 = NV And TLV12 = NV And SWL11 <> 0 Then SWL11R = SWL11
                    End If
                    IC = 0
                    CB12L = NV
                Case 6
                    ' CB16 - Switch 15
                    LogEvent("Checking Code button CB16")
                    If BK7 = CLR Then
                        ' TD(8) = SM15 And TD(8) = 0
                        If TLV8 = NV And SWL15 <> 0 Then SWL15R = SWL15
                    End If
                    IC = 0
                    CB16L = NV
                Case 7
                    ' CB18 - Unlock 17
                    LogEvent("Checking Code button CB18")
                    If TLV8 = NV Then
                        If CLL17 <> 0 Then CLL17R = CLL17
                    End If
                    IC = 0
                    CB18L = NV
                Case 8
                    ' CB20 - Unlock 19
                    LogEvent("Checking Code button CB20")
                    If (TLV10 = NV And TLV12 = NV) Then
                        If CLL19 <> 0 Then CLL19R = CLL19
                    End If
                    IC = 0
                    CB20L = NV
                Case 9
                    ' CB24 - Switch 23, Signal 24
                    LogEvent("Checking Code button CB24")
                    If BK3 = CLR Then
                        'If SGL24 = RIGHT And SWL23LT = LNOR And FS5 = EAST Then GoTo SWL23Check
                        'If SGL24 = RIGHT And SWL23LT = LREV And FS6 = EAST Then GoTo SWL23Check
                        'If SGL24 = LEFT And FS1 = WEST Then GoTo SWL23Check
                        SGL24R = SGL24
                        ' TD(9) = SM23 delay And TD(9) = 0 - don't accept if train on block 4. (other end of crossover)
SWL23Check:             If TLV24 = NV And (TLV26 = NV Or SWL25LT = LREV) And SWL23 <> 0 And BK4 = CLR Then SWL23R = SWL23
                    End If
                    IC = 0
                    CB24L = NV
                Case 10
                    ' CB26 - Switch 25, Signal 26
                    LogEvent("Checking Code button CB26")
                    If BK4 = CLR Then
                        ' could accept until 23 lines up?
                        'If SGL26 = RIGHT And SWL25LT = LNOR And SWL23LT = LREV Then GoTo SWL25Check
                        'If SGL26 = RIGHT And SWL25LT = LNOR And FS6 = EAST Then GoTo SWL25Check
                        'If SGL26 = LEFT And SWL23LT = LNOR And FS2 = WEST Then GoTo SWL25Check
                        'If SGL26 = LEFT And SWL23LT = LREV And FS1 = WEST Then GoTo SWL25Check
                        SGL26R = SGL26
                        ' TD(10) = SM25 delay And TD(10) = 0
SWL25Check:             If TLV26 = NV And SWL25 <> 0 Then SWL25R = SWL25
                    End If
                    IC = 0
                    CB26L = NV
            End Select
        Else
            LogEvent(" IC = " & IC & " OUT OF RANGE AND RESETTING TO ZERO")
            IC = 0
        End If
CCEND:
    End Sub
    Sub CTCSwitch()
        REM******************SUBROUTINE SWITCHMOTOR*************************
        REM**INVOKES THE POWER SWITCH CONTROL (PSCTRL) SUBROUTINE TO      **
        REM**RELEASE SWITCH CONTROL WHEN SELECTOR LEVER IS PLACED IN      **
        REM**HAND AND TO CONTROL ALIGNMENT BASED UPON SWITCH LEVER        **
        REM**REQUESTED VALUE AND TLV WHEN SELECTOR LEVER IS IN MOTOR.     **
        REM**                                                             **
        REM**SUBROUTINE INCLUDES THE EFFECT OF SWITCH TRANSITIONING       **
        REM**DELAY AND ALSO DRIVES THE SWITCH INDICATION LIGHTS INCLUDING **
        REM**SETTING THEM TO DARK WHEN SWITCH IS OUT OF CORRESPONDENCE    **
        REM**AND IN TRANSIT.                                              **
        REM**                                                             **
        REM**NOTE: Selector lever input is simply set to MOTOR and the... **
        REM**      ...last two arguments set to zero for handling power...**
        REM**      ...switch motors without dual control.                 **
        REM*****************************************************************

        ' ** SM1 - Centropolis Gate
        Call PSCTRL(SWL1R, SWL1LT, MOTOR, SM1, 0, 3, 0, 0)

        REM* SM3 - Southwest Junction (Power only)
        Call PSCTRL(SWL3R, SWL3LT, MOTOR, SM3, BK9, 4, 0, 0)

        REM** SM7 Sheffield (Power only)
        Call PSCTRL(SWL7R, SWL7LT, MOTOR, SM7, BK7, 5, 0, 0)

        REM**SM9 Sheffield  (Power only)
        Call PSCTRL(SWL9R, SWL9LT, MOTOR, SM9, BK7, 6, 0, 0)

        REM ** SM11 Sheffield (Power Only)
        Call PSCTRL(SWL11R, SWL11LT, MOTOR, SM11, BK8, 7, 0, 0)

        REM**SM15 Sheffield (Power Only)
        Call PSCTRL(SWL15R, SWL15LT, MOTOR, SM15, BK7, 8, 0, 0)

        REM ** SM23 Freight Line (Power Only)
        Call PSCTRL(SWL23R, SWL23LT, MOTOR, SM23, BK3, 9, 0, 0)

        REM**SM25 Freight Line (Power Only)
        Call PSCTRL(SWL25R, SWL25LT, MOTOR, SM25, BK4, 10, 0, 0)
    End Sub
    Sub PSCTRL(ByVal SWLR, ByRef SWLLT, ByVal SEL, ByRef SM, ByVal DET, ByVal DI, ByVal HT, ByVal PAD)
        REM***************SUBROUTINE PSCTRL***************************
        REM**  Processes controls for dual control power switch...  **
        REM**    ...in CTC territory and provides feedback to...    **
        REM**    ...drive switch lever indication lights            **
        REM**            Version 1.1    7/20/2010                   **
        REM***********************************************************
        'This subroutine assumes that the dual control switch motors...
        '...are wired according to the application examples  presented...
        '...in Chapter 7 Fig. 7-23. When using other connection methods... 
        '...changes to some of the programming statements may be required... 
        '...such as adding an SM = SMOFF statement when lever is in hand and... 
        '...the switch motor is directly connected using local control only

        REM  SWLR  is the switch lever request input from the CTC machine
        REM  SWLLT is the switch lever indication lights on the CTC machine...
        '...prior to the application of indication code delay
        REM  SEL   is the selector lever in the field   (0 = MOTOR, 1 = HAND}
        REM  SM    is the switch motor control output
        REM  DET   is the occupancy detector input from the field
        REM  DI    is the delay timer index number
        REM  HT    is the hand lever toggle input from the field (0 = NORMAL, 1 = REVERSE)
        REM  PAD   is the padlock input from the field (0 = LOCKED, 1 = UNLOCKED)

        REM**HAND PROCESSING - CHECK IF SWITCH IS IN MOTOR OR HAND AND BRANCH ACCORDINGLY
        If SEL = HAND And PAD = UNLOCKED Then   'If switch motor is in hand (and...
            '...padlock unlocked) then...
            '...process hand protocol...
            '...else skip around to process...
            '...motor protocol
            If HT = LNOR Then SM = TUN Else SM = TUR '...switch is in hand so...
            '...align switch to setting...
            '...of hand-throw lever
            SWLLT = DARKLT      'Set both switch indication lights off...
            TD(DI) = 0         '...cancel any active in transit delay...
            GoTo PSPEND        '...and skip over all "in-motor" processing
        End If

        REM**MOTOR PROCESSING - POWER SWITCH PROTOCOL FOR SELECTOR LEVER IN MOTOR POSITION
        If TD(DI) > 0 Then GoTo PSPEND 'If switch in transit skip protocol
        If TD(DI) < 0 Then GoTo INCOR 'If transitioning complete then branch...
        '...to switch in correspondence processing

        REM**IF SWITCH IS IN-CORRESPONDENCE THEN EXECUTE IN-CORRESPONDENCE PROCESSING...
        '...ELSE EXECUTE OUT-OF-CORRESPONDENCE PROCESSING
        If ((SWLR = LNOR And SWLLT = NORLT And SM = TUN) Or (SWLR = LREV And SWLLT = REVLT And SM = TUR)) Then
            GoTo INCOR
        Else
            LogEvent(DescriptionOfTimer(DI) + " is out of correspondence.")
            GoTo OUTCOR
        End If

        REM**SWITCH IN-CORRESPONDENCE PROCESSING**
INCOR:
        If SM = TUN Then SWLLT = NORLT Else SWLLT = REVLT 'Set switch...
        '...indication lights to correspond to requested...
        TD(DI) = 0    '...lever position and clear switch transition timer
        GoTo PSPEND

        REM**SWITCH OUT-OF-CORRESPONDENCE PROCESSING**
OUTCOR:
        If DET = OCC Then GoTo PSPEND 'If OS occupied then skip setting switch
        SWLLT = DARKLT    'Switch out of correspondence so set switch...
        '...indication light inputs to dark...
        '...and initiate switch transition by...
        If SWLR = LNOR Then SM = TUN Else SM = TUR '...Setting switch motor...
        '...control to correspond to requested lever value...
        TD(DI) = SMDL '...and initiate switch transit time delay
        LogEvent("Setting switch delay for " + DescriptionOfTimer(DI))
        REM**PROCESSING COMPLETE
PSPEND:

    End Sub
    Sub RouteCheckEast()
        REM*****************SUBROUTINE ROUTECHECKEAST****************************
        REM**  USING THE LOGIC EQUIVALENT TO THAT PERFORMED BY THE PROTOTYPE'S **
        REM**  ROUTE CHECK NETWORK CALCULATES THE ASPECT OF ALL EASTBOUND      **
        REM**  SIGNALS. ROUTE SIGNALING, AS CONTRASTED TO SPEED SIGNALING, IS  **
        REM**  ASSUMED. FLASHING ASPECTS ARE INCLUDED WHERE APPROPRIATE.       **
        REM**********************************************************************

        REM**CALCULATE SIG4LAB
ESIG4L:
        SIG4LAB = REDRED
        ' SiGnalLever4Request
        If SGL4R <> LEFT Then GoTo ESIG8LA
        If SWL3LT = LTOFF Then GoTo ESIG8LA
        If BK9 = OCC Then GoTo ESIG8LA
        If FS9 = WEST Then GoTo ESIG8LA
        If SWL3LT <> NORLT Then
            SIG4LAB = REDGRN
        Else
            SIG4LAB = GRNRED
        End If

ESIG8LA:
        SIG8LABC = REDREDRED
        If SGL8R <> LEFT Then GoTo ESIG8LB ' lever is left
        If SWL7LT = LTOFF Or SWL9LT = LTOFF Or SWL15LT = LTOFF Then GoTo ESIG8LB 'turnouts in transit
        If BK7 = OCC Then GoTo ESIG8LB ' block is clear
        If TLV8 = RIGHT Then GoTo ESIG8LB '8R cleared
        If FS9 = WEST And SWL7LT = REVLT Then GoTo ESIG8LB '4R and sw7 set for opposing movement.
        If SWL15LT = REVLT Then GoTo ESIG8LB
        If FS5 = WEST And SWL7LT = LNOR And SWL9LT = LNOR Then GoTo ESIG8LB
        If SWL9LT = REVLT And BK8 = OCC Then GoTo ESIG8LB
        If SWL9LT = REVLT And FS6 = WEST Then GoTo ESIG8LB
        'If SWL9LT = REVLT And TLV26 = RIGHT And SWL25LT = NORLT Then GoTo ESIG8LB - not reqd when checking Traffic Stick.
        ' All tests passed, now set aspect according to turnouts.
        If SWL9LT = NORLT And SWL7LT = NORLT Then SIG8LABC = GRNREDRED
        If SWL9LT = REVLT Then SIG8LABC = REDGRNRED
        If SWL9LT = NORLT And SWL7LT = REVLT Then SIG8LABC = REDREDGRN

ESIG8LB:
        SIG8LD = RED
        If SGL8R <> LEFT Then GoTo ESIG10L
        If SWL7LT = LTOFF Or SWL9LT = LTOFF Or SWL15LT = LTOFF Then GoTo ESIG10L 'turnouts in transit
        If BK7 = OCC Then GoTo ESIG10L
        If TLV8 = RIGHT Then GoTo ESIG10L
        If SWL15LT = NORLT Then GoTo ESIG10L
        If CLL17LT = REVLT Then GoTo ESIG10L
        If SWL9LT = NORLT And FS5 = WEST Then GoTo ESIG10L
        If SWL9LT = REVLT And FS6 = WEST Then GoTo ESIG10L
        If SWL7LT = REVLT And FS9 = WEST Then GoTo ESIG10L
        If SWL9LT = REVLT And BK8 = OCC Then GoTo ESIG10L
        SIG8LD = GRN
        ANBT = 0 : ADBT = 0

ESIG10L:
        SIG10LAB = REDRED
        If SGL10R <> LEFT Then GoTo ESIG24L
        If SWL11LT = LTOFF Then GoTo ESIG24L
        If SWL9LT = LTOFF Then GoTo ESIG24L
        ' if a train was entering the yard and the block is now occupied, move cwstat to Yes
        If SWL11LT = REVLT And BK8 = OCC Then
            CWSTATUS = TrainInBlock
        End If
        If SWL11LT = REVLT And BK8 = TrainClear And CWSTATUS = TrainInBlock Then
            CWSTATUS = TrainClear
        End If
        If BK8 = OCC Then GoTo ESIG24L
        If SWL9LT = REVLT And SWL11LT = NORLT Then GoTo ESIG24L
        If TLV10 = RIGHT Then GoTo ESIG24L
        If FS6 = WEST Then GoTo ESIG24L
        'process normal route
        If SWL11LT = NORLT Then
            SIG10LAB = GRNRED
        End If
        'process reverse route - Only clear 10L if Yardmaster has accepted. 
        If SWL11LT = REVLT And CWSTATUS = YardAccept Then
            SIG10LAB = REDGRN
        End If


ESIG24L:
        SIG24LA = RED
        If SGL24R <> LEFT Then GoTo ESIG26LAB
        If SWL23LT = LTOFF Then GoTo ESIG26LAB
        If BK3 = OCC Then GoTo ESIG26LAB
        If SWL23LT <> NORLT Then GoTo ESIG26LAB
        If TLV24 = RIGHT Then GoTo ESIG26LAB
        If FS1 = WEST Then GoTo ESIG26LAB
        SIG24LA = GRN

ESIG26LAB:
        SIG26LAB = REDRED
        If SGL26R <> LEFT Then GoTo ESIG26LC
        If SWL23LT = LTOFF Or SWL25LT = LTOFF Then GoTo ESIG26LC
        If BK4 = OCC Then GoTo ESIG26LC
        If TLV26 = RIGHT And SWL23LT = NORLT Then GoTo ESIG26LC
        If FS2 = WEST And SWL23LT = NORLT Then GoTo ESIG26LC
        If TLV24 = RIGHT And SWL23LT = REVLT Then GoTo ESIG26LC
        If FS1 = WEST And SWL23LT = REVLT Then GoTo ESIG26LC
        If SWL25LT = REVLT Then GoTo ESIG26LC
        If SWL23LT = NORLT Then
            SIG26LAB = GRNRED
        Else
            SIG26LAB = REDGRN
        End If


ESIG26LC:
        SIG26LC = RED
        If SGL26R <> LEFT Then GoTo ESIGEND
        If SWL25LT = LTOFF Then GoTo ESIGEND
        If BK4 = OCC Then GoTo ESIGEND
        If TLV26 = RIGHT Then GoTo ESIGEND
        If SWL25LT <> REVLT Then GoTo ESIGEND
        SIG26LC = GRN
        ANCE = 0 : ADCE = 0
ESIGEND:

    End Sub
    Sub RouteCheckWest()
WSIG4R:
        SIG4RA = RED
        SIG4RB = RED
        ' SiGnalLever4Request
        If SWL3LT = LTOFF Then GoTo WSIG8R 'turnout in transit, skip
        If SGL4R <> RIGHT Then GoTo WSIG8R ' dispatcher requested 4R
        If BK9 = OCC Then GoTo WSIG8R ' not when plant occupied
        If TLV4 = LEFT Then GoTo WSIG8R ' not when running time.
        If TLV8 = LEFT And SWL7LT = REVLT And SWL9LT = NORLT Then GoTo WSIG8R ' not with 8Left cleared and running into this track.
        If SWL3LT <> REVLT Then
            SIG4RA = GRN
            ANBV = 0 : ADBV = 0
        Else
            SIG4RB = GRN
            ANCT = 0 : ADCT = 0
        End If

WSIG8R:
        SIG8RAB = REDRED
        SIG8RC = RED
        If SGL8R <> RIGHT Then GoTo WSIG10R 'dispatcher requested 8R
        If SWL7LT = LTOFF Or SWL9LT = LTOFF Or SWL15LT = LTOFF Then GoTo WSIG10R 'turnouts in transit
        If BK7 = OCC Then GoTo WSIG10R
        If SWL9LT = REVLT Then GoTo WSIG10R
        If TLV8 = LEFT Then GoTo WSIG10R
        If SWL15LT = NORLT And FS1 = EAST Then GoTo WSIG10R
        'If SWL15LT = NORLT And SWL23LT = REVLT And TLV26 = LEFT Then GoTo WSIG10R
        If SWL7LT = REVLT Then SIG8RC = GRN
        If SWL7LT = NORLT And SWL15LT = NORLT Then SIG8RAB = GRNRED
        If SWL7LT = NORLT And SWL15LT = REVLT Then SIG8RAB = REDGRN

WSIG10R:
        SIG10RABC = REDREDRED
        If SGL10R <> RIGHT Then GoTo WSIG12R
        If BK8 = OCC Then GoTo WSIG12R
        If SWL11LT = LTOFF Or SWL9LT = LTOFF Or SWL15LT = LTOFF Then GoTo WSIG12R
        If SWL9LT = NORLT And SWL11LT = REVLT Then GoTo WSIG12R
        If TLV10 = LEFT And SWL9LT = NORLT Then GoTo WSIG12R
        If SWL9LT = REVLT And TLV8 = LEFT Then GoTo WSIG12R
        If SWL9LT = NORLT And FS2 = EAST Then GoTo WSIG12R
        'check Unlock #19
        If CLL19LT = REVLT And SWL9LT = NORLT Then GoTo WSIG12R
        If SWL9LT = REVLT And SWL15LT = NORLT And FS1 = EAST Then GoTo WSIG12R
        If SWL9LT = NORLT And SWL11LT = NORLT Then SIG10RABC = GRNREDRED
        If SWL9LT = REVLT And SWL15LT = NORLT Then SIG10RABC = REDGRNRED
        If SWL9LT = REVLT And SWL15LT = REVLT Then SIG10RABC = REDREDGRN

WSIG12R:
        SIG12RA = RED
        If SGL12R <> RIGHT Then GoTo WSIG24R
        If BK8 = OCC Then GoTo WSIG24R
        If SWL11LT = LTOFF Then GoTo WSIG24R
        If TLV10 = LEFT Then GoTo WSIG24R
        If FS2 = EAST Then GoTo WSIG24R
        ' check unlock #19
        If CLL19LT = REVLT Then GoTo WSIG24R
        If SWL11LT = REVLT Then SIG12RA = GRN : ANCW = 0 : ADCW = 0

WSIG24R:
        SIG24RAB = REDRED
        If SGL24R <> RIGHT Then GoTo WSIG26R
        If BK3 = OCC Then GoTo WSIG26R
        If SWL23LT = 0 Then GoTo WSIG26R ' turnout in transit, exit
        If TLV24 = LEFT And SWL23LT = NORLT Then GoTo WSIG26R
        If TLV26 = LEFT And SWL23LT = REVLT And SWL25LT = NORLT Then GoTo WSIG26R
        If SWL23LT = NORLT And FS5 = EAST Then GoTo WSIG26R 'not against traffic.
        If SWL23LT = REVLT And FS6 = EAST Then GoTo WSIG26R
        If SWL23LT = NORLT Then
            SIG24RAB = GRNRED
        Else
            SIG24RAB = REDGRN
        End If

WSIG26R:
        SIG26RAB = REDRED
        If SGL26R <> RIGHT Then GoTo WSIGEND
        If BK4 = OCC Then GoTo WSIGEND
        If TLV26 = LEFT Then GoTo WSIGEND
        If SWL25LT = 0 Then GoTo WSIGEND ' turnout in transit
        If SWL25LT = NORLT And FS6 = EAST Then GoTo WSIGEND

        If SWL25LT = NORLT And SWL23LT = NORLT Then
            SIG26RAB = GRNRED
        Else
            ' Interlocked with Yardmaster, not until they open their switch.
            If SWI25 = LTON Then
                SIG26RAB = REDGRN
            End If
        End If

WSIGEND:

    End Sub
    Sub TimeLocking()
        REM*******************SUBROUTINE TIMELOCKING********************
        REM** INVOKES THE TLVPRO UTILITY SUBROUTINE, FOR EACH SIGNAL  **
        REM** LEVER, TO:                                              **
        REM**   1) SET TLV TO RIGHT OR LEFT WHEN SIGNAL IS CLEARED TO **
        REM**      RIGHT OR LEFT                                      **
        REM**   2) CAUSES A SIGNAL TO RUN TIME WHEN DISPATCHER KNOCKS **
        REM**      DOWN A CLEARED SIGNAL                              **
        REM**   3) RESETS TLV TO NO VALUE WHEN OS BECOMES OCCUPIED OR **
        REM**      ALTERNATIVELY WHEN A SIGNAL COMPLETES RUNNING TIME **
        REM*************************************************************

        Call TLVPRO(TLV4, SGL4R, SGL4LT, BK9, 11)
        Call TLVPRO(TLV8, SGL8R, SGL8LT, BK7, 12)
        Call TLVPRO(TLV10, SGL10R, SGL10LT, BK8, 13)
        Call TLVPRO(TLV12, SGL12R, SGL12LT, BK8, 21)
        Call TLVPRO(TLV24, SGL24R, SGL24LT, BK3, 14)
        Call TLVPRO(TLV26, SGL26R, SGL26LT, BK4, 15)

    End Sub
    Sub TLVPRO(ByRef TLV, ByRef SGLR, ByRef SGLLT, ByVal DET, ByVal ID)
        REM***********UTILITY SUBROUTINE TLVPRO*****************************
        REM** CALLED BY TIMELOCKING TO CALCULATE TIME LOCKING VALUE (TLV) **
        REM** TO RIGHT OR LEFT FOR EACH SIGNAL LEVER AND ACTIVATES SIGNAL **
        REM** RUNNING TIME WHEN DISPATCHER KNOCKS DOWN A CLEARED SIGNAL.  **
        REM** RESETS TLV TO NO VALUE, NV, WHEN OS SECTION BECOMES OCCUPIED**
        REM** OR ALTERNATIVELY WHEN SIGNAL COMPLETES RUNNING TIME.        **
        REM*****************************************************************
        REM  TLV   is the Time Locking Value
        REM  SGLR  is the signal lever request input from the CTC machine
        REM  SGLLT is the signal lever display lights on the CTC machine
        REM  DET   is the occupancy detector input from the field
        REM  ID    is the delay timer index number

        REM**SET TIME LOCKING VALUE WHEN SIGNAL IS CLEARED INTO OS SECTION
        If (TLV = NV And SGLLT = LEFTLT) Then TLV = LEFT
        If (TLV = NV And SGLLT = RIGHTLT) Then TLV = RIGHT

        REM**RESET TLV AND SIGNAL LEVER POSITION TO NORMAL WHEN OS OCCUPIED
        If DET = OCC Then    'If OS becomes occupied then...
            TLV = NV          '...reset TLV to no value
            TD(ID) = 0        '...cancel running time delay
            SGLR = LSTOP      '...reset signal lever request to normal
            SGLLT = STOPLT    '...reset signal indication lights...
        End If               '...to stop (i.e. prior to indication delay)

        REM**IF DISPATCHER KNOCKED DOWN SIGNAL THEN RUN TIME ON SIGNAL
        REM**(i.e. If signal lever request is set to stop while TLV is
        REM**...right or left, TLV <> NV, then run time on signal.)
        If (SGLR = LSTOP And TLV <> NV) Then   'Running time on signal
            If TD(ID) > 0 Then GoTo TLVEND 'If delay already active...
            '... then return to calling program

            If TD(ID) = 0 Then    'If timer not activated...
                TD(ID) = RTDL      '...then activate timer...
                GoTo TLVEND        '...and return to calling program
            End If

            If TD(ID) < 0 Then    'If timer expired then...
                TLV = NV         '...reset TLV to no value and...
                TD(ID) = 0       '...reset time delay to zero
            End If                '...to stop (normal) i.e. prior to delay
        End If
TLVEND:
    End Sub
    Sub SwitchLock()
        REM******************SUBROUTINE SWITCHLOCK***************************
        REM** CALCULATES THE PRECONDITION FOR MAKING THE NO RELEASE VERSUS **
        REM** QUICK RELEASE AND THEN INVOKES THE AUTOELOCK SUBROUTINE      **
        REM** FOR AUTOMATIC ELECTRIC LOCKS OR THE CNTLELOCK SUBROUTINE     **
        REM** FOR CONTROLLED ELECTRIC LOCKS                                **
        REM******************************************************************
        Dim NOREL As Integer
        Dim NBLK As Integer
        NBLK = CLR
        REM** Sugar Creek Controlled Electric Lock #17
        NOREL = 0           'Initialize to grant release (No_Release = 0)
        If (TLV8 = RIGHT And SM15 = TUR) Then NOREL = 1
        If (TLV8 = LEFT And SM15 = TUR) Then NOREL = 1
        Call CNTLELOCK(CLL17R, CLL17LT, CLL17R, 16, NBLK, NOREL, 0, UL17)

        REM** Independence Controlled Electric Lock #19
        NOREL = 0           'Initialize to grant release (No_Release = 0)
        If (TLV10 = RIGHT Or TLV10 = LEFT) Then NOREL = 1
        Call CNTLELOCK(CLL19R, CLL19LT, CLL19R, 17, NBLK, NOREL, 0, UL19)


    End Sub
    Sub AUTOELOCK(ByVal ULR, ByVal DI, ByVal BKR, ByVal BKT, ByVal NOREL, ByRef UL)
        REM*******************************************************************
        REM** AUTOMATIC ELECTRIC LOCK FOR HAND OPERATED SWITCHES SUBROUTINE **                 
        REM** Determines the locking/unlocking status of hand operated      **
        REM** switches that are protected by automatic electric locks       **
        REM*******************************************************************
        REM  ULR is the unlock request from train crew (0 = lock request ...
        REM  ...and 1 = unlock request
        REM  DI is the time delay array index number
        REM  BKR is the detection for the quick release section
        REM  BKT is the detection for the block containing the turnout, ...
        REM  ...but not including the releasing section, BKR, to be unlocked
        REM  NOREL is calculated condition, with BKR clear, that no release is granted
        REM  UL is the Locked/Unlocked result (0 = locked, 1 = unlocked)

        REM**CHECK WHETHER OR NOT SWITCH KEY INSERTED AND BRANCH ACCORDINGLY
        If ULR = LOCKED Then  'If switch key inserted, (i.e. requested value...
            '...still locked) then process lock protocol else...
            '...key is inserted so perform unlocking protocol

            REM**PROCESS LOCK PROTOCOL
            TD(DI) = 0     '...make sure any active timer delay is reset...
            UL = LOCKED    '...and lock up switch
            GoTo ALEND     'Processing complete so branch to end processing

            REM**PROCESS UNLOCKING PROTOCOL                                  
        Else              'UNLOCK REQUEST ACTIVE SO PROCESS UNLOCKING PROTOCOL
            If UL = UNLOCKED Then GoTo ALEND 'If unlock already granted, then...
            '...branch to end of processing
            If BKR = OCC Then GoTo AQUICKREL 'If release section occupied then...
            '...branch to perform quick release...
            If BKT = OCC Then GoTo ATIMEREL 'If block containing switch (not...
            '...including releasing section)...
            '...is occupied then branch to time...
            '...release
            If NOREL = 1 Then GoTo ANOREL 'If track section (not including block...
            '...containing switch) or OS sections...
            '...occupied or signal cleared or running...
            '...time then set up for no release
        End If

AQUICKREL:
        REM**PERFORM QUICK RELEASE
        TD(DI) = 0       'Make sure any active timer delay is reset...
        UL = UNLOCKED    '...and set switch unlocked and...
        GoTo ALEND       '...branch to end of auto-lock processing

ATIMEREL:
        REM**PERFORM TIMED RELEASE
        If TD(DI) = 0 Then TD(DI) = LKDL 'If timer not set then set to desired delay
        If TD(DI) > 0 Then GoTo ALEND 'Time delay still active so branch to end
        If TD(DI) < 0 Then               'If timer expired then...
            TD(DI) = 0                    '...reset timer to zero and...
            UL = UNLOCKED                 '...unlock switch and...
        End If
        GoTo ALEND                       '...branch to end of processing 

ANOREL:
        REM**PERFORM NO RELEASE
        TD(DI) = 0      'Make sure any active timer delay is reset...
        UL = LOCKED     '...and lock switch

        REM**AUTOMATIC LOCK PROCESSING COMPLETE
ALEND:
    End Sub
    Sub CNTLELOCK(ByVal CLLR, ByRef CLLLT, ByVal ULR, ByVal DI, ByVal BKT, ByVal NOREL, ByVal TFB, ByRef UL)
        REM**************************************************************
        REM** CONTROLLED ELECTRIC LOCK FOR HAND OPERATED SWITCHES      **                 
        REM** Determines the locking/unlocking status of hand operated **
        REM** switches that are protected by automatic electric locks  **
        REM**************************************************************
        REM  CLLR is the lock/unlock request from the Dispatcher (0 = lock request...
        REM  ... and 1 = unlock request)
        REM  CLLLT is the lock lights on the Dispatcher's CTC machine prior to...
        REM  ... the application of indication delay
        REM  ULR is the unlock request from train crew (0 = lock request and...
        REM  ... 1 = unlock request)
        REM  DI is the time delay array index number
        REM  BKT is the detection for the block containing the turnout to be unlocked
        REM  NOREL is calculated condition that no release is granted
        REM  TFB is the turnout feedback (which is optional)
        REM  UL is the Lock/Unlock result (0 = locked, 1 = unlocked)

        REM**CHECK IF DISPATCHER LOCK LEVER REQUEST IS NORMAL OR REVERSE
        If CLLR = LNOR Then    'If lock lever request is normal then process lock...
            '...protocol otherwise process unlock protocol

            REM**PROCESS LOCK PROTOCOL
            TD(DI) = 0         '...make sure any active timer delay is reset
            If TFB = TUR Then GoTo CLEND '**Optional** (see text Chapter 23 for details)
            ' No local switch key on KC Sub.
            'If ULR = UNLOCKED Then GoTo CLEND 'If switch key still inserted then skip...
            '...processing, otherwise...
            UL = LOCKED      '...lock up switch...
            CLLLT = NORLT    '...and set lock indication lights to normal (10)
            GoTo CLEND       'Processing complete so branch to end processing

            REM**PROCESS UNLOCKING PROTOCOL                                    
        Else   'DISPATCHER UNLOCK REQUEST ACTIVE SO PROCESS UNLOCKING PROTOCOL
            If UL = UNLOCKED Then GoTo CLEND 'If switch already unlocked then...
            '...branch to end of processing
            If BKT = OCC Then GoTo CTIMEREL 'If block containing switch occupied...
            '...then branch to time released
            If NOREL = 1 Then GoTo CNOREL 'If track or OS sections occupied or...
            '...signal cleared or running time...
            '...then set up for no release...
        End If                                '...otherwise perform quick release

CQUICKREL:
        REM**PERFORM QUICK RELEASE
        CLLLT = DARKLT         'Set switch lock indication lights to dark (00)  
        TD(DI) = 0            'Make sure any active timer delay is reset...
        If ULR = LOCKED Then GoTo CLEND 'If switch key not yet inserted then...
        '...skip processing else...
        UL = UNLOCKED         '...unlock switch and...
        CLLLT = REVLT         '...set lock indication lights to reverse (01)...
        GoTo CLEND            '...and branch to end of processing

CTIMEREL:
        REM**PERFORM TIME RELEASE
        CLLLT = DARKLT            'Set switch lock indication lights to dark (00)
        If TD(DI) = 0 Then TD(DI) = LKDL 'If timer not set then set to desired delay
        If TD(DI) > 0 Then GoTo CLEND 'Time delay still active so branch to end
        If TD(DI) < 0 Then               'If timer expired then...     

            If ULR = LOCKED Then GoTo CLEND 'If switch key not yet inserted then...
            '...skip processing else...
            TD(DI) = 0                        '...reset timer to zero and...
            UL = UNLOCKED                     '...unlock switch and set lock...
            CLLLT = REVLT                     '...indication lights to reverse (01)...
        End If
        GoTo CLEND                           '...and branch to end of processing   

CNOREL:
        REM**PERFORM NO RELEASE
        TD(DI) = 0         'Make sure any active timer delay is reset...
        UL = LOCKED        '...and keep switch locked

        REM**CONTROLLED LOCK PROCESSING COMPLETE
CLEND:
    End Sub
    Sub Indications()
        REM*************SUBROUTINE INDICATIONS*****************************
        REM**GENERATES AN INDICATION CODE FOR EACH TIME ONE OR MORE      **
        REM**FIELD PARAMETERS WITHIN A STATION CHANGES STATE. THEN, ONCE **
        REM**INDICATION CODE DELAY IS COMPLETE, IT UPDATES THE CTC PANEL **
        REM**DISPLAY. ADDITIONALLY, EVEN FOR THE CASE THAT A CONTROL     **
        REM**CODE DOES NOT GENERATE A PARAMETER CHANGE IN THE FIELD,     **
        REM**THE INDICATIONS SUBROUTINE RETURNS AN AUTOMATIC STATION     **
        REM**RECALL INDICATION CODE SIGNIFYING THAT THE CONTROL CODE     **
        REM**WAS RECEIVED AND THAT NO PARAMETER CHANGED STATE.           **
        REM**                                                            **
        REM**Note: Each parameter ending in a "K" refers to the delayed  **
        REM**displayed value on the CTC panel (e.g. TL28 is the effective**
        REM**state in the field versus TL28K is the delayed value as     **
        REM**observed at the CTC machine                                 **
        REM****************************************************************

        REM******************************************
        REM*** CALCULATE TRACK LIGHT STATUS        **
        REM** (Prior to inducing indication delay) **
        REM******************************************

        REM**DEFINE OCCUPANCY LIGHTS, PRIOR TO INTRODUCED CODING DELAY
        TL1 = BK1 : TL2 = BK2 : TL3 = BK3 : TL4 = BK4
        TL5 = BK5 : TL6 = BK6 : TL7 = BK7 : TL8 = BK8 : TL9 = BK9
        TL10 = BK10

        REM**IF AUTOMATIC ELECTRIC LOCK OR UNLOCKED REQUEST SET TO...
        '...UNLOCKED, THEN SET TRACK LIGHT INDICATION OCCUPIED


        REM****************************************************
        REM** CALCULATE SIGNAL LEVER INDICATION LIGHT STATUS **
        REM**  (Prior to inducing indication delay)          **
        REM****************************************************

        REM**CB4 SOUTHWEST JCT
L4:     If SIG4RA <> RED Then SGL4LT = RIGHTLT : GoTo L8
        If SIG4RB <> RED Then SGL4LT = RIGHTLT : GoTo L8
        If SIG4LAB <> REDRED Then SGL4LT = LEFTLT : GoTo L8
        If CB4L = PP Then SGL4LT = DARKLT : SGL4LTK = DARKLT : GoTo L8
        If SGL4R <> LSTOP Then SGL4LT = DARKLT : GoTo L8
        If TLV4 <> NV Then SGL4LT = DARKLT Else SGL4LT = STOPLT

        REM**CB8 SHEFFIELD
L8:     If SIG8RAB <> REDRED Then SGL8LT = RIGHTLT : GoTo L10
        If SIG8RC <> RED Then SGL8LT = RIGHTLT : GoTo L10
        If SIG8LABC <> REDREDRED Then SGL8LT = LEFTLT : GoTo L10
        If SIG8LD <> RED Then SGL8LT = LEFTLT : GoTo L10
        If CB8L = PP Then SGL8LT = DARKLT : SGL8LTK = DARKLT : GoTo L10
        If SGL8R <> LSTOP Then SGL8LT = DARKLT : GoTo L10
        If TLV8 <> NV Then SGL8LT = DARKLT Else SGL8LT = STOPLT

        ' Sheffield
L10:    If SIG10RABC <> REDREDRED Then SGL10LT = RIGHTLT : GoTo L12
        If SIG10LAB <> REDRED Then SGL10LT = LEFTLT : GoTo L12
        If CB10L = PP Then SGL10LT = DARKLT : SGL10LTK = DARKLT : GoTo L12
        If SGL10R <> LSTOP Then SGL10LT = DARKLT : GoTo L12
        If TLV10 <> NV Then SGL10LT = DARKLT Else SGL10LT = STOPLT

L12:
        If SIG12RA <> RED Then SGL12LT = RIGHTLT : GoTo L24
        If CB12L = PP Then SGL12LT = DARKLT : SGL12LTK = DARKLT : GoTo L24
        If SGL12R <> LSTOP Then SGL12LT = DARKLT : GoTo L24
        If TLV12 <> NV Then SGL12LT = DARKLT Else SGL12LT = STOPLT

        'Freight Line
L24:    If SIG24RAB <> REDRED Then SGL24LT = RIGHTLT : GoTo L26
        If SIG24LA <> RED Then SGL24LT = LEFTLT : GoTo L26
        If CB24L = PP Then SGL24LT = DARKLT : SGL24LTK = DARKLT : GoTo L26
        If SGL24R <> LSTOP Then SGL24LT = DARKLT : GoTo L26
        If TLV24 <> NV Then SGL24LT = DARKLT Else SGL24LT = STOPLT

L26:    If SIG26RAB <> REDRED Then SGL26LT = RIGHTLT : GoTo CKICODE
        If SIG26LAB <> REDRED Then SGL26LT = LEFTLT : GoTo CKICODE
        If SIG26LC <> RED Then SGL26LT = LEFTLT : GoTo CKICODE
        If CB26L = PP Then SGL26LT = DARKLT : SGL26LTK = DARKLT : GoTo CKICODE
        'deviation from code. do this check last.
        If SGL26R <> LSTOP Then SGL26LT = DARKLT : GoTo CKICODE
        If TLV26 <> NV Then SGL26LT = DARKLT Else SGL26LT = STOPLT : GoTo CKICODE
        'If SGL26R <> LSTOP Then SGL26LT = DARKLT

        REM***********************************************************
        REM**               INDICATION CODE SCHEDULING              **
        REM** (Set up for possibly transmitting an Indication Code) **
        REM***********************************************************
CKICODE:

        'dark out switches where there is no signal to darkout (on panel)
        'If CB16L = PP Then SWL15LT = DARKLT
        'manipulating panel lights outside of switch control routine causes havoc!!!
        ' ksl 2014-02-16

        'Check status for sending an Indication Code (CHKICODE)
        REM**IF A CONTROL CODE IN PROCESS, BRANCH TO ICEND
        If CDEIND = 2 Then GoTo ICEND

        REM**IF AN INDICATION CODE IN PROCESS, BRANCH TO CONTINUE WITH CODING
        If CDEIND = 1 Then GoTo INDCODE

        REM**IF CONTROL CODES ARE STACKED ACTIVE THEN HOLD OFF SENDING...
        '...ANY INDICATION CODE BY BRANCHING TO ICEND
        If CBLCNT > 0 Then GoTo ICEND

        REM**CODE LINE AVAILABLE SO LOOK TO PROCESS INDICATION CODE BY...
        '...SEARCHING IN STATION ORDER FOR THE LOWEST NUMBERED...
        '...STATION WITH A NEED TO TRANSMIT UPDATE

        REM********************************************
        REM** SELECT STATION GROUP TO BE TRANSMITTED **
        REM********************************************
        REM**INITIALIZE STATION INDEX TO ZERO
        SI = 0

        ' CB2 - Gate
        If STK(1) = 1 Then SI = 1 : GoTo S2
        If SWL1LTK <> SWL1LT Then SI = 1 : GoTo S2

        ' ** CB4 Switch 3, Signal 4, block 9
        If STK(2) = 1 Then SI = 2 : GoTo S4
        If TL9K <> TL9 Then SI = 2 : GoTo S4
        If SWL3LTK <> SWL3LT Then SI = 2 : GoTo S4
        If SGL4LTK <> SGL4LT Then SI = 2 : GoTo S4

        ' ** CB8 SWITCH 7, SIGNAL 8, block 7, block 1
        If STK(3) = 1 Then SI = 3 : GoTo S8
        If TL7K <> TL7 Then SI = 3 : GoTo S8
        If TL1K <> TL1 Then
            SI = 3 : GoTo S8
        End If
        'SI = 3 : GoTo S8
        If SWL7LTK <> SWL7LT Then SI = 3 : GoTo S8
        If SGL8LTK <> SGL8LT Then SI = 3 : GoTo S8

        ' ** CB10 Switch 9, Signal 10, block 8, block 2
        If STK(4) = 1 Then SI = 4 : GoTo S10
        If TL2K <> TL2 Then SI = 4 : GoTo S10
        If TL8K <> TL8 Then SI = 4 : GoTo S10
        If SWL9LTK <> SWL9LT Then SI = 4 : GoTo S10
        If SGL10LTK <> SGL10LT Then SI = 4 : GoTo S10

        ' ** CB12 switch 11
        If STK(5) = 1 Then SI = 5 : GoTo S12
        If SWL11LTK <> SWL11LT Then SI = 5 : GoTo S12
        If SGL12LTK <> SGL12LT Then SI = 5 : GoTo S12

        ' ** CB16 switch 15
        If STK(6) = 1 Then SI = 6 : GoTo S16
        If SWL15LTK <> SWL15LT Then SI = 6 : GoTo S16

        ' ** CB18 Lock 17
        If STK(7) = 1 Then SI = 7 : GoTo S18
        If CLL17LTK <> CLL17LT Then SI = 7 : GoTo S18

        ' ** CB20 Lock 19
        If STK(8) = 1 Then SI = 8 : GoTo S20
        If TL10K <> TL10 Then SI = 8 : GoTo S20
        If CLL19LTK <> CLL19LT Then SI = 8 : GoTo S20

        ' ** CB24 - Switch 23, Signal 24, Block 3, Block 5
        If STK(9) = 1 Then SI = 9 : GoTo S24
        If TL3K <> TL3 Then SI = 9 : GoTo S24
        If TL5K <> TL5 Then SI = 9 : GoTo S24
        If SWL23LTK <> SWL23LT Then SI = 9 : GoTo S24
        If SGL24LTK <> SGL24LT Then SI = 9 : GoTo S24

        ' ** CB26 - Switch 24, Signal 26, Block 4, Block 6
        If STK(10) = 1 Then SI = 10 : GoTo S26
        If TL4K <> TL4 Then SI = 10 : GoTo S26
        If TL6K <> TL6 Then SI = 10 : GoTo S26
        If SWL25LTK <> SWL25LT Then SI = 10 : GoTo S26
        If SGL26LTK <> SGL26LT Then SI = 10 : GoTo S26

        REM**REACHED POINT WITH SI = 0, SO NO STATION NEEDS TO SEND AN...
        '...INDICATION CODE SO BRANCH TO END INDICATION CODE PROCESSING  
        GoTo ICEND

        REM**********************************************************
        REM** STORE STATION GROUP PARAMETERS PRIOR TO TRANSMITTING **
        REM**********************************************************
        ' gate at Centropolis
S2:     TSTORE(1) = SWL1LT
        GoTo INDCODE

        ' ** CB4 Switch 3, Signal 4, block 9
S4:     TSTORE(1) = TL9
        TSTORE(2) = SWL3LT
        TSTORE(3) = SGL4LT
        GoTo INDCODE

        ' ** CB8 SWITCH 7, SIGNAL 8, block 7, block 1
S8:     TSTORE(1) = TL1
        TSTORE(2) = TL7
        TSTORE(3) = SWL7LT
        TSTORE(4) = SGL8LT
        GoTo INDCODE

        ' ** CB10 Switch 9, Signal 10, block 8, block 2
S10:    TSTORE(1) = TL2
        TSTORE(2) = TL8
        TSTORE(3) = SWL9LT
        TSTORE(4) = SGL10LT
        GoTo INDCODE

        ' ** CB12 switch 11
S12:    TSTORE(1) = SWL11LT
        TSTORE(2) = SGL12LT
        GoTo INDCODE

        ' ** CB16 switch 15
S16:    TSTORE(1) = SWL15LT
        GoTo INDCODE

        ' ** CB18 Lock 17
S18:    TSTORE(1) = CLL17LT
        GoTo INDCODE

        ' ** CB20 Lock 19
S20:    TSTORE(1) = CLL19LT
        TSTORE(2) = TL10
        GoTo INDCODE

        ' ** CB24 - Switch 23, Signal 24, Block 3, Block 5
S24:    TSTORE(1) = TL3
        TSTORE(2) = TL5
        TSTORE(3) = SWL23LT
        TSTORE(4) = SGL24LT
        GoTo INDCODE

        ' ** CB26 - Switch 25, Signal 26, Block 4, Block 6
S26:    TSTORE(1) = TL4
        TSTORE(2) = TL6
        TSTORE(3) = SWL25LT
        TSTORE(4) = SGL26LT

        REM************************************
        REM**  INDUCE INDICATION CODE DELAY  **
        REM************************************ 
        REM**PROCESS AN INDICATION CODE CYCLE
INDCODE:
        CDEIND = 1 ' turn on indication code light
        'codeind = 1      'Turn on Indication Code light and...
        'codeind = 1
        CODESND = 1     '...turn on Indication Code sound...
        '...if not already turned on
        If TD(2) > 0 Then GoTo ICEND 'Delay active so branch to ICEND
        If TD(2) = 0 Then TD(2) = ICDL : GoTo ICEND 'Delay not active so...
        '...initialize delay and branch to return to calling program
        If TD(2) < 0 Then     'If coding delay complete then...
            CDEIND = 0
            CODESND = 0
            TD(2) = 0          '...and reset coding time delay	      
        End If

        REM********************************************************************
        REM**SET DISPLAY INDICATIONS EQUAL TO STORED VALUES AT START OF DELAY**
        REM******************************************************************** 
        REM**CODING DELAY COMPLETE SO BRANCH TO SELECTED STATION PARAMETERS
        REM**RETREIVE PARAMETERS FROM STORAGE FOR SELECTED STATION GROUPING
        Select Case SI
            Case 1 'CB2
                SWL1LTK = TSTORE(1)
                SI = 0
                STK(1) = 0
            Case 2 ' CB4
                TL9K = TSTORE(1)
                SWL3LTK = TSTORE(2)
                SGL4LTK = TSTORE(3)
                SI = 0
                STK(2) = 0
            Case 3 ' CB8
                TL1K = TSTORE(1)
                TL7K = TSTORE(2)
                SWL7LTK = TSTORE(3)
                SGL8LTK = TSTORE(4)
                SI = 0
                STK(3) = 0
            Case 4 ' CB10
                TL2K = TSTORE(1)
                TL8K = TSTORE(2)
                SWL9LTK = TSTORE(3)
                SGL10LTK = TSTORE(4)
                SI = 0
                STK(4) = 0
            Case 5 ' CB12
                SWL11LTK = TSTORE(1)
                SGL12LTK = TSTORE(2)
                SI = 0
                STK(5) = 0
            Case 6 ' CB16
                SWL15LTK = TSTORE(1)
                SI = 0
                STK(6) = 0
            Case 7 ' CB18
                CLL17LTK = TSTORE(1)

                SI = 0
                STK(7) = 0
            Case 8 ' CB20
                CLL19LTK = TSTORE(1)
                TL10K = TSTORE(2)
                SI = 0
                STK(8) = 0
            Case 9 ' CB24
                TL3K = TSTORE(1)
                TL5K = TSTORE(2)
                SWL23LTK = TSTORE(3)
                SGL24LTK = TSTORE(4)
                SI = 0
                STK(9) = 0
            Case 10 ' CB26
                TL4K = TSTORE(1)
                TL6K = TSTORE(2)
                SWL25LTK = TSTORE(3)
                SGL26LTK = TSTORE(4)
                SI = 0
                STK(10) = 0
        End Select

ICEND:
    End Sub
    Sub OfficeIndications()
        REM**************SUBROUTINE OFFICE INDICATIONS*******************
        REM** GENERATES INDICATIONS THAT ARE STRICTLY OFFICE CREATED   **
        REM** INDICATIONS SUCH AS THE TRAFFIC DIRECTION INDICATION     **
        REM** LIGHTS THAT MAY BE OPTIONALLY DISPLAYED ON THE CTC PANEL **
        REM** OR IN SOME CASES A THIRD CENTER MOUNTED LIGHT AT SWITCH  **
        REM** LEVER POSITION                                           **
        REM**************************************************************
        'This example assumes traffic direction lights which are...
        '...an office function calculation only as established...
        '...by TLV values and not occupancy of adjacent blocks with...
        '...signal cleared as used to establish traffic direction...
        '...by vital circuitry in the field


        ' If doing an indication code, don't process office functions.
        If CDEIND = 1 Then
            Exit Sub
        End If

        ' Process CWSTATUS
        If BK8 = CLR And CWSTATUS = TrainInBlock Then
            CWSTATUS = TrainClear
        End If
        If FS1 = WEST Then FK1 = TRIGHT
        If FS1 = EAST Then FK1 = TLEFT
        If FS1 = NDT Then FK1 = NV

        If FS2 = WEST Then FK2 = TRIGHT
        If FS2 = EAST Then FK2 = TLEFT
        If FS2 = NDT Then FK2 = NV

        If FS5 = WEST Then FK5 = TRIGHT
        If FS5 = EAST Then FK5 = TLEFT
        If FS5 = NDT Then FK5 = NV

        If FS6 = WEST Then FK6 = TRIGHT
        If FS6 = EAST Then FK6 = TLEFT
        If FS6 = NDT Then FK6 = NV

        ' Switch lock off occupancy
        SWLI3 = LTOFF : SWLI7 = LTOFF : SWLI9 = LTOFF : SWLI11 = LTOFF
        SWLI15 = LTOFF : SWLI17 = LTOFF : SWLI19 = LTOFF : SWLI23 = LTOFF : SWLI25 = LTOFF
        If BK9 = OCC Then SWLI3 = LTON
        If BK7 = OCC Then
            SWLI7 = LTON
            SWLI9 = LTON
            SWLI15 = LTON
        End If
        If BK8 = OCC Then
            SWLI9 = LTON
            SWLI11 = LTON
        End If

        If BK3 = OCC Then
            SWLI23 = LTON
        End If

        If BK4 = OCC Then
            SWLI25 = LTON
            SWLI23 = LTON
        End If

        ' Also calculate switch locks off tlvnn
        If TLV4 <> NV Then
            SWLI3 = LTON
        End If

        If TLV8 <> NV Then
            SWLI15 = LTON
            SWLI9 = LTON
            SWLI7 = LTON
            If SWL15LTK = LREV Then
                SWLI17 = LTON
            End If
        End If

        If TLV10 = RIGHT Then
            SWLI9 = LTON
            If SWL9LTK = REVLT Then
                SWLI7 = LTON 'not sure about this one.
                SWLI15 = LTON
                If SWL15LTK = LREV Then
                    SWLI17 = LTON
                End If
            Else
                SWLI11 = LTON
                SWLI19 = LTON
            End If
        End If

        If TLV10 = LEFT Then
            SWLI11 = LTON
            SWLI19 = LTON
            If SWL11LT = LNOR Then
                SWLI9 = LTON
            End If
        End If

        If TLV12 = RIGHT Then
            SWLI11 = LTON
            SWLI19 = LTON
        End If

        If TLV24 = LEFT Then
            SWLI23 = LTON
        End If
        If TLV24 = RIGHT Then
            SWLI23 = LTON
            'If SWL23LTK = REVLT Then
            'SWLI25 = LTON
            'End If
        End If

        If TLV26 <> NV Then
            SWLI25 = LTON
            If SWL25LTK = LNOR Then
                SWLI23 = LTON
            End If
        End If

        Call UpdateTrainIDs()

    End Sub

    Private Sub UpdateTrainIDs()
        'use table logic

    End Sub

    Sub GraphicOfficeIndication()
        REM ********** Update the graphical Office display
        REM  not sure... testing with not using office code
        ' If doing an indication code, don't process office functions.
        'If CDEIND = 1 Then
        'Exit Sub
        'End If

        Call MainPanel.UpdateFormObjects()

    End Sub

    Sub TimerCount()
        REM***********************SUBROUTINE TIMERCNT***************************
        REM** UTILITY SUBROUTINE TO EXECUTE MULTIPLE ASYNCHRONOUS TIME DELAYS **
        REM** BY AUTOMATICALLY DECREMENTING EACH ACTIVE DELAY BY 1 SECOND     **
        REM** FOR EVERY 1 SECOND OF REAL-TIME LOOP OPERATION (used to...      **
        REM** emulate coding transmission time, track switch transition...     **
        REM** time, time release of electric locks and signals running time)  **
        REM*********************************************************************
        '	Timer	Use
        '	1	Control
        '	2	Indication
        '	3	SM1
        '	4	SM3
        '	5	SM7
        '	6	SM9
        '	7	SM11
        '	8	SM15
        '	9	SM23
        '	10	SM25
        '	11	TLV4
        '	12	TLV8
        '	13	TLV10
        '	14	TLV24
        '	15	TLV26
        '	16	LCK17
        '	17	LCK19
        '	18	TRAFFICLIGHTS
        '   19  Power Up Delay
        '   20  Signal Lamp failure
        '   21  TLV12
        T1 = TimeOfDay.Second
        'T1& = Timer                    'Update T1, an integer, to current time
        If T1 <> T1SAVE Then          'If 1 second has elapsed then...
            For NN = 1 To NUMDL         '...loop through all time delays and...
                If TD(NN) > 0 Then      '...if delay is active...
                    TD(NN) = TD(NN) - 1  '...decrement delay count by 1
                    If TD(NN) = 0 Then
                        TD(NN) = -1
                    End If
                    'If timer has expired then
                End If       '...set counter to -1 to signal delay complete
            Next NN          'After all timers have been checked...
            ' update fast clock
            CLOCKSECONDS = CLOCKSECONDS + 6 ' 6 to 1 fast time
            If CLOCKSECONDS >= 60 Then
                CLOCKSECONDS = 0
                CLOCKMINUTES = CLOCKMINUTES + 1
            End If
            If CLOCKMINUTES > 59 Then
                CLOCKMINUTES = 0
                CLOCKHOURS = CLOCKHOURS + 1
            End If
            If CLOCKHOURS > 23 Then
                CLOCKHOURS = 0
            End If
            T1SAVE = T1    '...set saved value of time to current time...
        End If              '...for next RTL cycle and...
        '...return to calling program
    End Sub
    Sub WriteRailroad()
        WriteNode0()
        WriteNode1()
        WriteNode2()
        WriteNode3()
    End Sub
    Sub ClearTrafficSticks()
        REM***********************SUBROUTINE TRAFFICCLEASTICKSR*****
        REM** CLEAR TRAFFIC STICK AFTER FOLLOWING SIGNAL UPGRADES **
        REM*********************************************************
        Dim OldFS9 As Integer

        ' Came straight through 24L
        If FS1 = EAST And TLV24 <> LEFT And SWL23LT = LNOR And BK1 = CLR And BK3 = CLR Then FS1 = NDT
        ' Came through 23 and 26L
        If FS1 = EAST And TLV26 <> LEFT And SWL23LT = LREV And BK1 = CLR And BK3 = CLR And BK4 = CLR Then FS1 = NDT

        ' Came straight through 8R
        If FS1 = WEST And TLV8 <> RIGHT And SWL9LT = LNOR And SWL15LTK = LNOR And BK7 = CLR And BK1 = CLR Then
            FS1 = NDT
        End If

        If FS1 = WEST And BK1 = CLR And SWL15LTK = LREV Then
            FS1 = NDT
        End If
        ' Came across through 9 and 10R
        If FS1 = WEST And TLV10 <> RIGHT And SWL9LT = LREV And BK8 = CLR And BK7 = CLR And BK1 = CLR Then
            FS1 = NDT
        End If

        ' FS2 - Eastward
        ' East - only via 26L.
        If FS2 = EAST And TLV26 <> LEFT And BK4 = CLR And BK2 = CLR Then FS2 = NDT
        ' Westward - only via 10R.
        If FS2 = WEST And TLV10 <> RIGHT And TLV12 <> RIGHT And BK8 = CLR And BK2 = CLR Then FS2 = NDT

        ' FS3 Eastward
        If FS3 = EAST And TLV24 <> LEFT And SWL23LTK = LNOR And BK3 = CLR And BK5 = CLR Then
            FS3 = NDT
            LogEvent("TrafficStick FS3 cleared.")
        End If
        If FS3 = EAST And TLV26 <> LEFT And SWL23LTK = LREV And BK3 = CLR And BK6 = CLR Then
            FS3 = NDT
            LogEvent("TrafficStick FS3 cleared.")
        End If
        ' FS3 Westward
        If FS3 = WEST And TLV24 <> RIGHT And BK3 = CLR And BK1 = CLR Then
            FS3 = NDT
            LogEvent("TrafficStick FS3 cleared.")
        End If

        ' FS4 Eastward
        If FS4 = EAST And TLV26 <> LEFT And BK4 = CLR And SWL25LTK = LNOR And BK6 = CLR Then
            FS4 = NDT
            LogEvent("TrafficStick FS4 cleared.")
        End If

        If FS4 = EAST And TLV26 <> LEFT And SWL25LTK = LREV And BK4 = CLR Then
            FS4 = NDT
            LogEvent("TrafficStick FS4 cleared.")
        End If

        ' FS4 Westward
        If FS4 = WEST And TLV26 <> RIGHT And SWL23LTK = LNOR And SWL25LTK = LNOR And BK4 = CLR And BK2 = CLR Then
            FS4 = NDT
            LogEvent("TrafficStick FS4 cleared.")
        End If

        If FS4 = WEST And TLV26 <> RIGHT And SWL23LTK = LNOR And SWL25LTK = LREV And BK4 = CLR Then
            FS4 = NDT
            LogEvent("TrafficStick FS4 cleared.")
        End If

        ' FS5 - Eastward
        If FS5 = EAST And TLV8 <> LEFT And BK7 = CLR And BK5 = CLR Then FS5 = NDT
        If FS5 = EAST And SWL7LTK = LREV And BK5 = CLR Then FS5 = NDT
        ' Westward
        If FS5 = WEST And TLV24 <> RIGHT And BK3 = CLR And BK5 = CLR Then FS5 = NDT

        ' FS6 Eastward
        If FS6 = EAST And TLV10 <> LEFT And SWL9LT = LNOR And BK8 = CLR And BK6 = CLR Then FS6 = NDT
        If FS6 = EAST And TLV8 <> LEFT And SWL9LT = LREV And BK8 = CLR And BK7 = CLR And BK6 = CLR Then FS6 = NDT
        ' Westward
        If FS6 = WEST And TLV26 <> RIGHT And SWL23LT = LNOR And BK4 = CLR And BK6 = CLR Then FS6 = NDT
        If FS6 = WEST And TLV24 <> RIGHT And SWL23LT = LREV And BK3 = CLR And BK4 = CLR And BK6 = CLR Then FS6 = NDT

        ' FS7 - Eastward
        'If FS7 = NDT And TLV8 = EAST Then FS7 = EAST
        If FS7 = EAST And TLV8 = NDT And BK7 = CLR Then FS7 = NDT

        ' FS7 - Westward
        'If FS7 = NDT And TLV8 = WEST Then FS7 = WEST
        If FS7 = WEST And TLV8 = NDT And BK7 = CLR And SWL9LTK = LNOR Then FS7 = NDT

        'If FS7 = NDT And TLV10 = WEST And SWL9LTK = LREV Then FS7 = WEST
        If FS7 = WEST And TLV10 = NDT And BK7 = CLR And SWL9LTK = LREV Then FS7 = NDT

        ' FS8 - Eastward
        If FS8 = EAST And TLV10 = NDT And BK8 = CLR Then FS8 = NDT
        ' 9 Reverse - signal 8 cleared left.
        If FS8 = EAST And TLV8 = NDT And BK8 = CLR And SWL9LTK = LNOR Then FS8 = NDT

        ' FS8 - Westward
        If FS8 = WEST And TLV8 = NDT And BK8 = CLR Then FS8 = NDT

        ' FS9
        OldFS9 = FS9
        If FS9 = EAST And TLV4 <> LEFT And BK9 = CLR Then FS9 = NDT
        'Else
        '     If TLV8 <> LEFT And BK9 = CLR And BK7 = CLR And SWL7LT = LREV Then FS9 = NDT
        ' End If
        If FS9 = WEST And TLV4 <> RIGHT And BK9 = CLR Then FS9 = NDT
        If OldFS9 <> FS9 Then
            LogEvent("ClearSticks: FS9 = Clear")
        End If
    End Sub
    Sub WriteNode0()
        ' Pack and Write output bytes for Node 0 (CTC Panel)
        ' Turnout indicators, 1,3,7,9,11,15,17,19,23,25
        ' Normal / Reverse
        ' SWI9 THRU SWI1

        ' -- Node 0, Card 0, Port A --
        OB(1) = 0 ' Always start clear!
        OB(1) = SWL1LTK ' SwitchPanelIndicator1

        OB(1) = SWL3LTK * B2 Or OB(1) 'TurnoutPositionOutput3 * B2 Or OB(1)
        OB(1) = SWL7LTK * B4 Or OB(1) 'TurnoutPositionOutput7 * B4 Or OB(1)
        OB(1) = SWL9LTK * B6 Or OB(1) 'TurnoutPositionOutput9 * B6 Or OB(1)


        ' -- Node 0, Card 0, Port B --

        OB(2) = CLL19LTK ' SwitchPanelIndicator19
        OB(2) = CLL17LTK * B2 Or OB(2) 'SwitchPanelIndicator17 * B2 Or OB(2)
        OB(2) = SWL15LTK * B4 Or OB(2) ' TurnoutPositionOutput15 * B4 Or OB(2)
        OB(2) = SWL11LTK * B6 Or OB(2) 'TurnoutPositionOutput11 * B6 Or OB(2)

        ' -- Node 0, Card 0, Port C --

        OB(3) = SWL23LTK 'TurnoutPositionOutput23
        OB(3) = SWL25LTK * B2 Or OB(3) 'SwitchPanelIndicator25 * B2 Or OB(3)
        OB(3) = TL10K * B4 Or OB(3)

        ' Turnout lock indicators - not used for CTC
        ' note: consider optionally showing the locks.
        ' -- Node 0, Card 1, Port A --
        OB(4) = 0
        OB(4) = SWLI25
        OB(4) = SWLI23 * B1 Or OB(4)
        OB(4) = SWLI19 * B2 Or OB(4)
        OB(4) = SWLI17 * B3 Or OB(4)
        OB(4) = SWLI15 * B4 Or OB(4)
        OB(4) = SWLI11 * B5 Or OB(4)
        OB(4) = SWLI9 * B6 Or OB(4)
        OB(4) = SWLI7 * B7 Or OB(4)
        ' -- Node 0, Card 1, Port B --
        OB(5) = SWLI3
        OB(5) = CDEIND * B1 Or OB(5)

        ' Node 0, Card 1, Port B Bit 4 = bell, Bit 5 = Control, Bit 6 = Indicator
        'If FLASH = 1 Then ' one-shot the code sound
        'CODESND = 0
        ' End If
        If CODESND <> OLDCODESND And CPULSE = 0 Then
            OLDCODESND = CODESND
            CPULSE = CODESND
            PCNT = 0
        End If

        If PCNT > PMAX Then
            CPULSE = 0
        Else
            PCNT = PCNT + 1
        End If

        OB(5) = CPULSE * B5 Or OB(5)


        ' -- Node 0, Card 1, Port C --
        ' Will be used for Traffic Stick Indicators
        OB(6) = FK1 'TrafficStick1
        OB(6) = FK2 * B2 Or OB(6) 'TrafficStick2 * B2 Or OB(6)
        OB(6) = FK5 * B4 Or OB(6) 'TrafficStick5 * B4 Or OB(6)
        OB(6) = FK6 * B6 Or OB(6) 'TrafficStick6 * B6 Or OB(6)

        If LAMPTEST Then
            OB(1) = 255
            OB(2) = 255
            OB(3) = 255
            OB(4) = 255
            OB(5) = 255
            OB(6) = 255
        End If
        Call theCMRI.OUTPUTS(MainPanel.CommPort, 0, 6, OB)

    End Sub
    Sub WriteNode1()
        ' Pack and Write for Node 1 (SMINI)
        ' CTC PANEL LAMPS

        ' BLOCK INDICATORS
        ' -- Node 1, Card 0, Port A --
        OB(1) = 0 ' start with all off
        OB(1) = TL5K
        OB(1) = TL6K * B1 Or OB(1)
        OB(1) = TL3K * B2 Or OB(1)
        OB(1) = TL4K * B3 Or OB(1)
        OB(1) = TL1K * B4 Or OB(1)
        OB(1) = TL2K * B5 Or OB(1)
        OB(1) = TL7K * B6 Or OB(1)
        OB(1) = TL8K * B7 Or OB(1)

        ' *** Node 1, Card 0, Port B
        OB(2) = 0
        OB(2) = TL5K Or OB(2)
        OB(2) = TL6K * B1 Or OB(2)
        OB(2) = TL9K * B2 Or OB(2)
        ' Dispatcher annunciators
        OB(2) = ADBV * B3 Or OB(2)
        OB(2) = ADCT * B4 Or OB(2)
        OB(2) = ADCW * B5 Or OB(2)
        OB(2) = ADCE * B6 Or OB(2)
        OB(2) = ADBT * B7 Or OB(2)

        ' -- Node 1, Card 0, Port C

        OB(3) = FK5 'TrafficStick5
        OB(3) = FK6 * B2 Or OB(3) 'TrafficStick6

        ' SIGNAL INDICATORS
        ' -- Node 1, Card 1, Port A --

        OB(4) = SGL26LTK

        ' -- Node 1, Card 1, Port B --
        OB(4) = SGL24LTK * B3 Or OB(4)


        OB(5) = SGL10LTK
        OB(5) = SGL8LTK * B3 Or OB(5)
        OB(5) = SGL12LTK * B6 Or OB(5)

        ' -- Node 1, Card 1, Port C

        OB(6) = SGL4LTK

        ' power off indicator lamp
        If PWRIND = 0 Then
            OB(6) = OB(6) Or 1 * B3
        End If

        If LAMPTEST Then
            OB(1) = 255
            OB(2) = 255
            OB(3) = 255
            OB(4) = 255
            OB(5) = 255
            OB(6) = 255
        End If

        Call theCMRI.OUTPUTS(MainPanel.CommPort, 1, 6, OB)

    End Sub
    Sub WriteNode2()
        '**PACK AND WRITE OUTPUT BYTES FOR NODE 2 (SMINI)
        ' Sheffield Jct and Rock Creek Jct
        ' -- Node 2, Card 0, Port A --
        OB(1) = SM1 'TurnoutOutput1
        OB(1) = SM3 * B2 Or OB(1) 'TurnoutOutput3 
        OB(1) = SM7 * B4 Or OB(1) 'TurnoutOutput7 
        OB(1) = SM9 * B6 Or OB(1) 'TurnoutOutput9 
        ' -- Node 2, Card 0, Port B --
        OB(2) = SM11 'TurnoutOutput11
        OB(2) = SM15 * B2 Or OB(2) 'TurnoutOutput15
        'OB(2) = TurnoutOutput17 * B4 Or OB(2)
        'OB(2) = TurnoutOutput19 * B6 Or OB(2)
        OB(2) = CLL17LTK * B4 Or OB(2) ' TurnoutOutput17 
        OB(2) = CLL19LTK * B6 Or OB(2) '   TurnoutOutput19 

        ' -- Node 2, Card 0, Port C --
        ' ob(3) 0 and 1 for electric locks 17 & 19
        If CLL17LTK = 1 Then
            OB(3) = 0
        Else
            OB(3) = 1
        End If
        If CLL19LTK = 1 Then
            OB(3) = 0 * B1 Or OB(3)
        Else
            OB(3) = 1 * B1 Or OB(3)
        End If


        ' Signal8RABC   = 6 outs => ob(3) AABBCCLL
        OB(3) = SIG8RAB * B4 Or OB(3) 'Signal8RightHeadAB 
        OB(3) = SIG8RC * B2 Or OB(3) 'Signal8RightHeadC 

        ' -- Node 2, Card 1, Port A
        ' Signal10RABCD = 8 outs => OB(4) AABBCCDD
        OB(4) = SIG10RABC * B2 'Signal10RightHeadABC * B2
        OB(4) = SIG12RA Or OB(4) 'Signal10RightHeadD Or OB(4)

        ' -- Node 2, Card 1, Port B --
        ' Signal8LABCD  = 8 outs => ob(5) DDAABBCC
        OB(5) = SIG8LABC * B2 'Signal8LeftHeadABC * B2
        OB(5) = SIG8LD Or OB(5) 'Signal8LeftHeadD Or OB(5)

        ' -- Node 2, Card 1, Port C --
        'Signal4RAB = 4 outs => OB(6) LLLLAABB
        OB(6) = SIG4RA * B2 'Signal4RightHeadA * B2
        OB(6) = SIG4RB Or OB(6) 'Signal4RightHeadB Or OB(6)

        'Signal4LAB = 4 outs => OB(6) AABBRRRR
        OB(6) = SIG4LAB * B4 Or OB(6) 'Signal4LeftHead * B4 Or OB(6)

        Call theCMRI.OUTPUTS(MainPanel.CommPort, 2, 6, OB)

    End Sub
    Sub WriteNode3()
        '**PACK AND WRITE OUTPUT BYTES FOR NODE 3 (SMINI)
        ' Freight Line Junction
        ' Turnouts 23 and 25
        ' Signal heads 22R/L, 24R/L
        ' -- Node 3, Card 0, Port A
        OB(1) = SM23 'TurnoutOutput23
        OB(1) = SM25 * B2 Or OB(1) 'TurnoutOutput25 * B2 Or OB(1)
        ' duplicate for crossover motors
        OB(1) = OB(1) Or SM23 * B4
        ' want these to stay at +12 v when lock open
        ' OB(1) = OB(1) Or SM25 * B6
        ' 25 Lock
        If SM25 = TUN Then
            ' hold 25B in Normal position.
            OB(1) = OB(1) Or SM25 * B6
            OB(2) = 0
        Else
            ' leave output bits 6 & 7 in off to leave both at 12 volts for toggle switch.
            ' just turn on bits 0 and 1. - pull LED to GND and toggle switch to GND
            OB(2) = 3 ' * B4 'Or OB(1) 'LK25 * B4 Or OB(1)
        End If

        ' since I killed an output transistor, Node 3, Card 0, Port B is substituting.
        ' fix this someday soon! ( 27/9/2007 , 9:18 pm)
        OB(2) = OB(2) Or ANBV * B2
        OB(2) = OB(2) Or ANCT * B3
        OB(2) = OB(2) Or ANCW * B4
        OB(2) = OB(2) Or ANCE * B5
        OB(2) = OB(2) Or ANBT * B6

        ' -- Node 3, Card 0, Port C
        ' Signal10LAB   = 4 outs => node 3 - freight line.
        OB(3) = SIG10LAB 'Signal10LeftHeadAB

        ' upper 2 bits for annuciators
        OB(3) = OB(3) Or TrainWaitingCoburgEast * B6
        OB(3) = OB(3) Or TrainWaitingCoburgWest * B7


        ' -- Node 3 Card 1 Port A = Signal24RightHead, Signal26RightHead
        ' 66664444
        OB(4) = SIG24RAB 'Signal24RightHead
        OB(4) = SIG26RAB * B4 Or OB(4) 'Signal26RightHead * B4 Or OB(4)
        ' -- Node 3 Card 1 Port B = Signal26LeftHead, Signal24LeftHead
        OB(5) = SIG24LA 'Signal24LeftHead
        'xxCCAABB
        'CAB
        OB(5) = SIG26LAB * B2 Or OB(5) 'Signal26LeftHead * B2 Or OB(5)
        OB(5) = SIG26LC * B6 Or OB(5)
        ' -- Node 3, Card 1, Port C = Traffic Lights
        OB(6) = TrafficLightState(TrafficCurrentState)
        'OB(6) = TrafficLightsNS * B3 Or OB(6)

        Call theCMRI.OUTPUTS(MainPanel.CommPort, 3, 6, OB)

    End Sub
    Sub LogEvent(ByVal msg)
        'write log message to Window
        Dim timeStamp As String
        timeStamp = Now()
        MainPanel.txtLogMsg.AppendText(timeStamp & " : " & msg & vbCrLf)
    End Sub
    Sub LogTrain(ByVal msg)
        ' write train event to train movement log.
        ' stamp with current fast clock time.
        Dim timeStamp As String
        timeStamp = FormatFastClock()
        MainPanel.txtTrainMovements.AppendText(timeStamp & " : " & msg & vbCrLf)
    End Sub
    Function FormatFastClock() As String
        Dim displayHours As String
        Dim ampm As String
        If CLOCKHOURS > 12 Then
            displayHours = Format(CLOCKHOURS - 12, "00")
            ampm = " PM"
        Else
            displayHours = Format(CLOCKHOURS, "00")
            ampm = " AM"
        End If
        Return displayHours + ":" + Format(CLOCKMINUTES, "00") + ampm
    End Function
    Sub SimSignalFailure()
        ' Simulate Failures on the system.
        Dim SigFail As Integer
        If TD(20) < 0 Then
            ' simulate burned out lamps
            If SIGF4L = LTOFF Then
                SigFail = CInt(Int((100 * Rnd()) + 1))
                'turn off for now.
                If SigFail > 100 Then
                    LogEvent("Signal 4 Left lamp failure.")
                    SIGF4L = LTON
                End If
            Else
                SIG4LAB = DRK
            End If
            TD(20) = 60 ' every minute, cause a 1 in 100 chance of signal failure.
        End If
    End Sub
End Module
