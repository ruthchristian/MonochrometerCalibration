Option Explicit On

Module PerformaxModule
    Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    Public Declare Function fnPerformaxComGetNumDevices _
        Lib "PerformaxCom" _
        Alias "_fnPerformaxComGetNumDevices@4" _
        (ByRef lpwdNumDevices As Integer) _
    As Integer

    Public Declare Function fnPerformaxComGetProductString _
        Lib "PerformaxCom" _
        Alias "_fnPerformaxComGetProductString@12" _
        (ByVal dwDeviceNum As Integer, _
         ByRef lpvDeviceString As Byte, _
         ByVal dwFlags As Integer) _
    As Integer

    Public Declare Function fnPerformaxComOpen _
        Lib "PerformaxCom" _
        Alias "_fnPerformaxComOpen@8" _
        (ByVal dwDevice As Integer, _
         ByRef cyHandle As Integer) _
    As Integer

    Public Declare Function fnPerformaxComClose _
        Lib "PerformaxCom" _
        Alias "_fnPerformaxComClose@4" _
        (ByVal cyHandle As Integer) _
    As Integer

    Public Declare Function fnPerformaxComSetTimeouts _
        Lib "PerformaxCom" _
        Alias "_fnPerformaxComSetTimeouts@8" _
        (ByVal dwReadTimeout As Integer, _
         ByVal dwWriteTimeout As Integer) _
    As Integer

    Public Declare Function fnPerformaxComSendRecv _
        Lib "PerformaxCom" _
        Alias "_fnPerformaxComSendRecv@20" _
        (ByVal cyHandle As Integer, _
         ByRef lpWBuffer As Byte, _
         ByVal lNumBytesToWrite As Integer, _
         ByVal lNumBytesToRead As Integer, _
         ByRef lpRBuffer As Byte) _
    As Integer

    Public Const PERFORMAX_RETURN_SERIAL_NUMBER = &H0
    Public Const PERFORMAX_RETURN_DESCRIPTION = &H1
    Public Const PERFORMAX_MAX_DEVICE_STRLEN = 256
    Public Const INVALID_HANDLE_VALUE = &H1

    'Variables used within the project
    Public hUSBDevice  'global handle that is set when connected with the usb device
    Public Status      'status, value to set when communicating with the board to determine success
    Public Function PerformaxSendGetReply(ByVal cmdStr As String) As String
        Dim BytesWriteRequest As Long
        Dim BytesReadRequest As Long
        Dim cc As String
        Dim ci, i, endfound As Integer
        Dim sendStr() As Byte
        Dim ReplyBuffer() As Byte
        Dim replyStr As String

        ReDim sendStr(64)
        ReDim ReplyBuffer(64)

        If (Len(cmdStr) > 64) Then
            PerformaxSendGetReply = -1
            Exit Function
        End If

        For i = 1 To Len(cmdStr)
            cc = Mid(cmdStr, i, 1)
            sendStr(i - 1) = Asc(cc)
        Next i
        For i = Len(cmdStr) To 63
            sendStr(i) = 0
        Next i
        BytesWriteRequest = 64
        BytesReadRequest = 64

        Status = fnPerformaxComSendRecv(hUSBDevice, sendStr(0), BytesWriteRequest, BytesReadRequest, ReplyBuffer(0))

        replyStr = ""
        endfound = 0
        For i = 1 To 64
            cc = Chr(ReplyBuffer(i - 1))
            ci = Asc(cc)
            If (ci = 0) Then
                endfound = 1
            End If
            If (endfound = 0) Then
                replyStr = replyStr + cc
            End If
        Next i

        If (replyStr = "") Then
            fnPerformaxComClose(hUSBDevice)
            MsgBox("Error communication.  Closing application...")
            End
        End If

        If (Len(replyStr) < 0) Then
            MsgBox("No Reply Error.  Check communication cable or power!")
            fnPerformaxComClose(hUSBDevice)
            End
        End If
        PerformaxSendGetReply = replystr
    End Function
    Public Sub MemSet(ByVal Buffer() As Byte, ByVal Value As Byte, ByVal Amount As Long)
        'this function sets all elements of on array to 0
        Dim i

        For i = 0 To (Amount - 1)
            Buffer(i) = Value
        Next
    End Sub
    Public Function ConvertToVBString(ByVal str)
        Dim NewString As String
        Dim i As Integer

        'for the received string array, loop until we get
        'a 0 char, or until the max length has been obtained
        'then add the ascii char value to a vb string
        i = 0
        Do While (i < PERFORMAX_MAX_DEVICE_STRLEN) And (str(i) <> 0)
            NewString = NewString + Chr(str(i))
            i = i + 1
        Loop
        ConvertToVBString = NewString
    End Function
    Public Function BitAND(ByVal tv1 As Long, ByVal tv2 As Long) As Long
        Dim result, temp1, temp2, v1, v2 As Long
        Dim i As Integer

        result = 0
        v1 = tv1
        v2 = tv2
        For i = 23 To 0 Step -1 '*** 32 bit numbers
            temp1 = v1 \ (2 ^ i) 'gets the bit of text1.text
            v1 = v1 - temp1 * (2 ^ i) 'subtracts it from the number
            temp2 = v2 \ (2 ^ i) 'gets the bit of text2.text
            v2 = v2 - temp2 * (2 ^ i) 'subtracts it from the number
            If temp1 = 1 And temp2 = 1 Then 'If both are equal to 1 then return a 1
                result = result + (2 ^ i) 'This returns a decimal number
            End If
        Next i
        BitAND = result
    End Function

    Public Function BitOR(ByVal tv1 As Long, ByVal tv2 As Long) As Long
        Dim result, temp1, temp2, v1, v2 As Long
        Dim i As Integer

        result = 0
        v1 = tv1
        v2 = tv2
        For i = 23 To 0 Step -1 '24 bit numbers accepted
            temp1 = v1 \ (2 ^ i) 'gets the bit of text1.text
            v1 = v1 - temp1 * (2 ^ i) 'subtracts it from the number
            temp2 = v2 \ (2 ^ i) 'gets the bit of text2.text
            v2 = v2 - temp2 * (2 ^ i) 'subtracts it from the number
            If temp1 = 1 Or temp2 = 1 Then ' If one or the other or both=1 then return a 1
                result = result + (2 ^ i) 'This returns a decimal number
            End If
        Next i
        BitOR = result
    End Function

    Public Function BitShiftLeft(ByVal v1 As Long, ByVal v2 As Long) As Long
        Dim result As Long

        result = v1 * 2 ^ v2 ' This shifts the bits
        BitShiftLeft = result
    End Function

    Public Function BitShiftRight(ByVal v1 As Long, ByVal v2 As Long) As Long
        Dim result As Long

        result = v1 \ 2 ^ v2 ' This shifts the bits
        BitShiftRight = result
    End Function
End Module
