Imports System.Math
Imports Microsoft.Office.Core
Imports System.Runtime.InteropServices
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Tools.Excel
Imports System.Drawing.Text
Imports System.Threading

Public Class frmMain
    Dim PulsesPer_λ, A, B, C, Dial, XYZ, Z As Single
    Dim cmdStr As String = ""
    Dim replyStr As String = ""
    Dim replystr2 As String = ""
    Dim HP3497Reply, Position, HP3497MoDay, HP3497Time, HP3497Channel As String
    Dim reply, HP3497aTOD, aaMonth, DateChar, aaDay, aaHr, aaMin, aaSec As String
    Dim aa, LF, ACDC, CreateExcelSheet, DataFileName, HPData As String
    Dim ret As Integer = 0
    Dim MeasTimeIntervalEntryError, LenAA, MoSlash, DaySlash, nn, ii As Integer
    Dim iStep, iRow, nSteps, FileNameEnteredFlag As Integer
    Dim Center_λ, Start_λ, Stop_λ, Expon, BacklashAmt As Single
    Dim BeginScan, PulsesToStart, SclesanRange, NewWaveLength As Single
    Dim λ_Increment, NoOfSteps, jDirec, MonoChromatorPosition As Single
    Dim xValue, vna, GPIBInterfaceIndex, HP3497Addr, MeasNo, SettlingTime, NumbrOfPoints, LastDataPointRow As Integer
    Dim ColumnHeadersRow1(), NanoMeterSet, HP3497Command As String
    Dim HP3497Volts As Double
    Dim DTNow As DateTime
    Dim DT, MeasDataFileName, ExcelDataFileName, CSVDataFileName, HP3497DataChannel As String
    Dim MeasYr As String

    Dim oExcel As Excel.Application
    Dim oBook As Excel.Workbook
    Dim oBooks As Excel.Workbooks
    Dim oSheet As Excel.Worksheet
    Dim misValue As Object = System.Reflection.Missing.Value

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label10.Text = ""
        Label10.Update()

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Private Sub cmdCalMonoChronomator_Click(sender As System.Object, e As System.EventArgs) Handles cmdCalMonoChronomator.Click

        '---------------------------------------------------------
        '  Runs when "1 - Calibrate MonoChromator" button is clicked.
        '  THIS ROUTINE CALIBRATES THE SYSTEM and
        'Creates Date/Time string to send to HP3497 to set clock and sends to the HP-3497A.
        '---------------------------------------------------------------

        TurnOnStprMotor()

        Dial = Val(txtInitialDialReading.Text)
        If Asc(Dial) = 0 Then Dial = 50
        If ((Dial >= 200) And (Dial <= 1500)) Then
            cmdStr = "PX=0"
            replyStr = PerformaxSendGetReply(cmdStr)
        Else
            DialOutOfBounds()
        End If

        CalibrateMonoChromator()

DialSettingOutOfBounds:

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Sub CalibrateMonoChromator()

        Dim myfont1 As New Font("Sans Serif", 9, FontStyle.Bold)

        '---------------------------------------------------------
        '  Runs when "1 - Calibrate MonoChromator" button is clicked.
        '  THIS ROUTINE CALIBRATES THE SYSTEM and
        'Creates Date/Time string to send to HP3497 to set clock and sends to the HP-3497A.
        '---------------------------------------------------------------

        SetHP3497DateTime()

        '------------------------------------------------------------------
        'Calibrate MonoChromator such that "Stepper Motor" zero is at the
        'dial reading input by user.  Must be between 200 and 1500 nanometers
        '-----------------------------------------------------------------'
 
        cmdStr = "PX"
        replyStr = PerformaxSendGetReply(cmdStr)
        txtStepNo.Text = "PX = " & replyStr
        XYZ = replyStr
        txtStepNo.Update()
        cmdStartTest.Enabled = True

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Private Sub cmdStartTest_Click(sender As System.Object, e As System.EventArgs) Handles cmdStartTest.Click
        
        '--------------------------------------------------------
        'Runs when "2 - Move to Initial Test Position and Wait" button is clicked
        '--------------------------------------------------------

        Dim cmdStr As String = ""
        Dim replyStr As String = ""
        Dim ret As Integer = 0

        MakeHP3497Measurement()   'Sets-up HP3497 Channel, Address, Settlint Time, GPIB Index

        MoveToInitial_λ()

        '   If (e.KeyCode = 13) Then 'keycode 13 = carriage return
        '       cmdStr = CommandText.Text
        'PerformaxSendGetReply uses DLL function fnPerformaxComSendRcv for sending commands and receiving replies
        '       replyStr = PerformaxSendGetReply(cmdStr)
        '       ReplyText.Text = replyStr 'Show the reply given from the Performax device
        '        CommandText.Text = ""
        '    End If

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Private Sub cmdInitiateTest_Click(sender As System.Object, e As System.EventArgs) Handles cmdInitiateTest.Click

        '------------------------------------------------------------------
        '  This routine runs when "3 - Initiate Test" button is clicked
        '==================================================================
        FileNameEnteredFlag = 0

        MakeHP3497Measurement()   'Sets-up HP3497 Channel, Address, Settlint Time, GPIB Index

        λ_Increment = txt_λ_Increment.Text

        NameAndSaveExcelDataFile()
        If FileNameEnteredFlag <> 1 Then GoTo NotReadyToProceed
        SetUpFiles()

        If FileNameEnteredFlag <> 1 Then GoTo NotReadyToProceed

        MeasNo = 0
        '----------------------------------------------
        '  Routine to get Stepper Motor PULSE rate
        '---------------------------------------------- 

        A = Abs(Start_λ - Stop_λ)
        C = A / λ_Increment
        NoOfSteps = Fix(Abs(C))

        B = ((1 * A) Mod (1 * λ_Increment)) '/ 100
        nSteps = NoOfSteps + 1
        If B <> 0 Then nSteps = nSteps + 1
        'Stop
        GetHP3497Data()

        '-------------------------------------------------
        Timer1.Enabled = True
        '-------------------------------------------------
        ' Stop
NotReadyToProceed:


    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        AcquireData()

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Sub AcquireData()

        '-----------------------------------------------------------------------------------
        '  move motor to subsequent wavelength positions
        '-----------------------------------------------------------------------------------
        'Stop
        If MeasNo < nSteps Then
            txtStepNo.Text = "Step " & Str(MeasNo + 1) & " / " & nSteps
            txtStepNo.Update()
            xValue = xValue - jDirec * λ_Increment * PulsesPer_λ
            cmdStr = "X" & xValue
            replyStr = PerformaxSendGetReply(cmdStr)
            MonitorStepperMotorPosition()
            GetHP3497Data()
        Else
            Timer1.Enabled = False
            cmdInitiateTest.Enabled = False
            Label10.Text = "SCAN COMPLETE"
            Label10.Update()
            FileClose(2)
            txtTestDataFileName.Text = "Enter Test Data File Name"
            txtTestDataFileName.Update()
            txtHP497Reply.Text = ""
            txtHP497Reply.Update()

        End If
        

        ' If B = 0 Then GoTo Done
        ' txtStepNo.Text = "Step " & Str(nSteps) & " / " & nSteps
        ' txtStepNo.Update()
        ' xValue = xValue - jDirec * B * PulsesPer_λ
        ' cmdStr = "X" & xValue
        ' replyStr = PerformaxSendGetReply(cmdStr)
        ' MonitorStepperMotorPosition()
        ' GetHP3497Data()
        ' cmdInitiateTest.Enabled = False
        ' Done:
        ' cmdInitiateTest.Enabled = False


 
    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Sub MoveToInitial_λ()

        Label10.Text = ""
        Label10.Update()
        cmdInitiateTest.Enabled = True
        PulsesPer_λ = 25000    'Set number of pulses to drive counter/grating one wavelength
        Center_λ = Dial
        Start_λ = txtStart_λ.Text
        '--------------------------------------------------------------------------
        ' Check Start λ to have a value vs being a null
        '--------------------------------------------------------------------------
        If txtStart_λ.Text = "" Then
            Start_λ = 50
        End If
        '----------------------------------------------------------
        '  Verify start wavelength is between 200 and 1500 namometers
        '---------------------------------------------------------
        If ((Start_λ < 200) Or (Start_λ > 1500)) Then
            Start_λError()
            GoTo EndPointOutOfBounds
        End If
        Stop_λ = txtStop_λ.Text
        '--------------------------------------------------------------------------
        ' Check Start λ to have a value vs being a null
        '--------------------------------------------------------------------------
        If txtStop_λ.Text = "" Then
            Stop_λ = 1550
        End If
        If ((Stop_λ < 200) Or (Stop_λ > 1500)) Then
            Stop_λError()
            GoTo EndPointOutOfBounds
        End If
        jDirec = Sign(Stop_λ - Start_λ)

        BacklashAmt = Val(txtBacklash_λ.Text)

        BeginScan = Center_λ - Start_λ + (jDirec * BacklashAmt)

        '----------------------------------------------
        '  Set Stepper Motor to "High Speed"
        '----------------------------------------------x
        cmdStr = "HSPD=40000"
        'cmdStr = "HSPD=10000"
        replyStr = PerformaxSendGetReply(cmdStr)    'Send command to motor
        '----------------------------------------------
        '  Set-up to move stepper motor to an absolute position value
        '----------------------------------------------
        xValue = BeginScan * PulsesPer_λ      ' define the beginning position of the stepper motor
        cmdStr = "X" & xValue                 ' send cmd to move motor to test "start" position
        '     PerformaxSendGetReply uses DLL function fnPerformaxComSendRcv for sending commands and receiving replies
        replyStr = PerformaxSendGetReply(cmdStr)     ' move the motor
        MonitorStepperMotorPosition()
        Thread.Sleep(300)
        xValue = xValue - (jDirec * BacklashAmt * PulsesPer_λ)
        cmdStr = "X" & xValue
        replyStr = PerformaxSendGetReply(cmdStr)
        MonitorStepperMotorPosition()

EndPointOutOfBounds:

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Sub TurnOnStprMotor()
        '----------------------------------------------
        '  Turn Stepper Motor ON
        '----------------------------------------------
        cmdStr = "EO=1"
        ' PerformaxSendGetReply uses DLL function fnPerformaxComSendRcv for sending commands and receiving replies
        replyStr = PerformaxSendGetReply(cmdStr)
        ' Threading.Thread.Sleep(100)   'Wait for Command to complete

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Sub MonitorStepperMotorPosition()

        '----------------------------------------------
        '  Routine to monitor Stepper Motor position while moving to commanded position
        '----------------------------------------------
        Label6.BackColor = Color.White
        Label6.Update()

        cmdStr = "PX"
        replyStr = PerformaxSendGetReply(cmdStr)
        Label6.Update()
        While replyStr <> xValue
            cmdStr = "PX"                                ' instr to monitor motor position
            replyStr = PerformaxSendGetReply(cmdStr)     ' send and get get motor position
            Label6.Text = Format(Dial - (Val(replyStr) / PulsesPer_λ), "####.000")
            Label6.Update()
        End While
        MonoChromatorPosition = Format(Dial - (Val(replyStr) / PulsesPer_λ), "####.000")
        Label6.Update()
        Label6.BackColor = Color.Red
        Label6.Update()

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Private Sub cmdStopMotion_Click(sender As System.Object, e As System.EventArgs) Handles cmdStopMotion.Click

        cmdStr = "STOP"
        '     PerformaxSendGetReply uses DLL function fnPerformaxComSendRcv for sending commands and receiving replies
        replyStr = PerformaxSendGetReply(cmdStr)
        Timer1.Enabled = False
        cmdInitiateTest.Enabled = True

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        End
    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Sub SetHP3497DateTime()

        aaMonth = Format(Now, "MM")
        aaDay = Format(Now, "dd")
        aaHr = Format(Now, "hh")
        aaMin = Format(Now, "mm")
        aaSec = Format(Now, "ss")
        MeasYr = Format(Now, "yyyy")

        HP3497aTOD = aaMonth & aaDay & aaHr & aaMin & aaSec

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Sub MakeHP3497Measurement()

        HP3497Reply = Space$(100)

        ' Define GPIB INterface Address
        If txtGPIPIndex.Text = "" Then
            GPIBInterfaceIndex = 0
        Else
            GPIBInterfaceIndex = Val(txtGPIPIndex.Text)
        End If

        ' Define HP3479A GPIB Address
        If txtHP3497Addr.Text = "" Then
            HP3497Addr = 9
        Else
            HP3497Addr = Val(txtHP3497Addr.Text)
        End If

        ' Define HP3479A Data Channel to Set and Read
        If txtHP3497DataChnl.Text = "" Then
            HP3497DataChannel = 10
        Else
            HP3497DataChannel = Val(txtHP3497DataChnl.Text)
        End If

        ' Define Instrument Settling Time
        If txtSettleTime.Text = "" Then
            SettlingTime = 100
        Else
            SettlingTime = Val(txtSettleTime.Text)
        End If

        'Stop

        Call ibdev(GPIBInterfaceIndex, HP3497Addr, 0, 13, 1, 12, vna)      'Note thefirst argument is the IEEE-488 board/Interface index e.g. GPIB0, 1 where "0", "1" is the index number 
        Call ibclr(vna)
        Call ibwrt(vna, "TD" & HP3497aTOD)

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Sub GetHP3497Data()

        MeasNo = MeasNo + 1
        HP3497Command = "VF3AI" & HP3497DataChannel
        'Stop
        Call ibwrt(vna, HP3497Command)
        Call ibwrt(vna, "VS")
        Threading.Thread.Sleep(SettlingTime)
        Call ibrd(vna, HP3497Reply)
        txtHP497Reply.Text = HP3497Reply
        txtHP497Reply.Update()
        HPData = HP3497Reply

        iRow = MeasNo + 2
        oSheet.Range("A" & iRow).Value = MeasNo

        HP3497MoDay = Mid(HPData, 1, 5) & ":" & MeasYr
        oSheet.Range("B" & iRow).Value = HP3497MoDay

        HP3497Time = Mid(HPData, 7, 8)
        oSheet.Range("C" & iRow).Value = HP3497Time

        NanoMeterSet = Str(MonoChromatorPosition)
        oSheet.Range("D" & iRow).Value = NanoMeterSet

        HP3497Volts = Val(Mid(HPData, 16, 9))
        Expon = Val(Mid(HPData, 26, 2))
        HP3497Volts = HP3497Volts * 10 ^ Expon
        oSheet.Range("E" & iRow).Value = HP3497Volts

        HP3497Channel = Mid(HPData, 29, 4)
        oSheet.Range("F" & iRow).Value = HP3497Channel

        WriteLine(2, MeasNo, HP3497MoDay, HP3497Time, MonoChromatorPosition, HP3497Volts, HP3497Channel)

        'Stop

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Sub SetUpFiles()

        Dim xAxis As Excel.Axis
        Dim yaxis As Excel.Axis
        Dim oChart As Excel.Chart
        Dim oSeries As Excel.Series

        oExcel = New Excel.Application
        oBook = oExcel.Workbooks.Add(misValue)
        oSheet = oBook.Sheets("sheet1")

        oExcel.Visible = True
        oBooks = oExcel.Workbooks

        oSheet.Range("J3").Select()
        oBook.ActiveSheet.Shapes.AddChart.Select()
        oBook.ActiveChart.ChartType = Excel.XlChartType.xlXYScatterSmoothNoMarkers
        oBook.ActiveChart.SeriesCollection.NewSeries()

        oBook.SaveAs(Filename:=ExcelDataFileName & ".xlsx")

        CSVDataFileName = ExcelDataFileName & ".csv"
        FileOpen(2, CSVDataFileName, OpenMode.Output)

        ColumnHeadersRow1 = {"Meas No.", "Meas Date" & Chr(10) & "(Mo:Day)", "Meas Time" & Chr(10) & _
                    "(Hr:Min:Sec)", "Mono-" & Chr(10) & "Chrono" & Chr(10) & "Position" & Chr(10) & "(nm)", _
                    "Meas Volts" & Chr(10) & "(Volts)", "Channel"}

        oSheet.Range("A1:F1").Value = ColumnHeadersRow1
        oBook.ActiveChart.Legend.Delete()

        NumbrOfPoints = 4 + Abs((Start_λ - Stop_λ) / λ_Increment)
        LastDataPointRow = NumbrOfPoints

        oBook.ActiveChart.SeriesCollection(1).XValues = "=Sheet1!$D$3:$D$" & LastDataPointRow
        oBook.ActiveChart.SeriesCollection(1).Values = "=Sheet1!$E$3:$E$" & LastDataPointRow

        yaxis = CType(oBook.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary), Excel.Axis)
        xAxis = CType(oBook.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary), Excel.Axis)
        xAxis.HasTitle = True
        xAxis.AxisTitle.Text = "Wavelength (nm)"
        yaxis.HasTitle = True
        yaxis.AxisTitle.Text = "Intensity"

        oBook.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).Select()
        If Stop_λ >= Start_λ Then
            oBook.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).MinimumScale = Start_λ
            oBook.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).MaximumScale = Stop_λ
        Else
            oBook.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).MinimumScale = Stop_λ
            oBook.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).MaximumScale = Start_λ
        End If

        '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        '  SEE http://www.mrexcel.com/forum/showthread.php?352472-Excel-2007-Line-Chart-TOO-THICK!
        '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        oChart = oBook.ActiveChart
        For Each oSeries In oChart.SeriesCollection
            oSeries.Format.Line.Weight = 1
        Next oSeries

    End Sub

    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    Sub NameAndSaveExcelDataFile()

        ExcelDataFileName = txtTestDataFileName.Text
        If ((ExcelDataFileName = "") Or (Mid(ExcelDataFileName, 1, 5) = "Enter")) Then
            txtTestDataFileName.BackColor = Color.Red
            txtTestDataFileName.Text = "?????"
            txtTestDataFileName.Update()
        Else
            If ExcelDataFileName = "?????" Then
                GoTo StillNotReady
            End If
            ExcelDataFileName = txtTestDataFileName.Text
            FileNameEnteredFlag = 1
            Button1.Enabled = True
        End If
        'Stop
StillNotReady:

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    Sub txtInitialDialReading_Click(sender As Object, e As System.EventArgs) Handles txtInitialDialReading.Click

        txtInitialDialReading.BackColor = Color.White
        txtInitialDialReading.Text = ""
        Label15.Visible = False
        Label15.Update()
        txtInitialDialReading.Update()
        If ((Dial >= 200) And (Dial <= 1500)) Then
            cmdInitiateTest.Enabled = True
        End If

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    Sub DialOutOfBounds()

        txtInitialDialReading.BackColor = Color.Red
        txtInitialDialReading.Update()
        Label15.Text = "Dial must be be between" & Chr(10) & Chr(13) & "200 nm and 1500 nm"
        Label15.Visible = True
        Label15.Update()


    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    Sub Start_λError()

        txtStart_λ.BackColor = Color.Red
        txtStart_λ.Update()
        Label15.Text = "Start_λ must be be between" & Chr(10) & Chr(13) & "200 nm and 1500 nm"
        Label15.Visible = True
        Label15.Update()
        'Stop

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    Private Sub txtStart_λ_Click1(sender As Object, e As System.EventArgs) Handles txtStart_λ.Click

        txtStart_λ.BackColor = Color.White
        txtStart_λ.Text = ""
        Label15.Visible = False
        Label15.Update()

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    Private Sub txtStop_λ_Click1(sender As Object, e As System.EventArgs) Handles txtStop_λ.Click

        txtStop_λ.BackColor = Color.White
        txtStop_λ.Text = ""
        Label15.Visible = False
        Label15.Update()

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    Sub Stop_λError()

        txtStop_λ.BackColor = Color.Red
        txtStop_λ.Update()
        Label15.Text = "Stop_λ must be be between" & Chr(10) & Chr(13) & "200 nm and 1500 nm"
        Label15.Visible = True
        Label15.Update()

    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    Private Sub txtTestDataFileName_Click(sender As Object, e As System.EventArgs) Handles txtTestDataFileName.Click

        txtTestDataFileName.Text = ""
        txtTestDataFileName.BackColor = Color.White
        txtTestDataFileName.Update()

    End Sub

End Class