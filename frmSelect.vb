Public Class FrmSelect

    Private Sub FrmSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        hUSBDevice = INVALID_HANDLE_VALUE

        If Not GetDeviceList Then 'no communication with Performax can be made
            Me.Visible = False
            MsgBox("No Performax Device Found!.")
            End
        End If
    End Sub

    Private Function GetDeviceList() As Boolean
        Dim DevNum As Integer
        Dim DevStr(PERFORMAX_MAX_DEVICE_STRLEN) As Byte
        Dim NewDevStr As String
        Dim tempStr As String
        Dim i, j As Integer

        'fnPerformaxComGetNumDevices DLL function for getting the total number of connected Performax devices
        Status = fnPerformaxComGetNumDevices(DevNum)

        j = 0
        If Status = 1 Then
            For i = 0 To (DevNum - 1) 'get all connected Performax devices
                'fnPerformaxComGetProductString DLL function for getting the product string of a Performax device
                Status = fnPerformaxComGetProductString(i, DevStr(0), PERFORMAX_RETURN_SERIAL_NUMBER)
                NewDevStr = ConvertToVBString(DevStr)

                '-----------------------------------------------------------------
                'If (InStr(1, StrConv(NewDevStr, vbUpperCase), "UMD")) Then
                'DeviceList.Items.Add(NewDevStr, j)
                'j = j + 1
                'End If
                '-----------------------------------------------------------------

                tempStr = i
                NewDevStr = NewDevStr + " , Index=" + tempStr
                'add the Performax device to the selection list
                DeviceList.Items.Add(NewDevStr)  'COMMENTED OUT when lines between ----- were entered 5-25-14
                j = j + 1  'COMMENTED OUT when lines between ----- were entered 5-25-14
            Next
            If (j > 0) Then
                GetDeviceList = True
            Else
                GetDeviceList = False 'if no Performax devices
            End If
        Else
            GetDeviceList = False 'if no communication
        End If

    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Close(frmMain)
        Me.Close()
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim selectedDevice As Integer
        Dim deviceStr As String
        Dim tempStr As String
        Dim deviceIndex As Integer

        selectedDevice = DeviceList.SelectedIndex

        If (selectedDevice < 0) Then
            MsgBox("Please select a Performax device first.")
            Exit Sub
        Else
            deviceStr = DeviceList.Items(selectedDevice)
            deviceIndex = InStr(deviceStr, "=") + 1
            tempStr = Mid(deviceStr, deviceIndex, Len(deviceStr))
            deviceIndex = tempStr
            'fnPerformaxComSetTimeouts DLL function sends timeout values in milliseconds
            Status = fnPerformaxComSetTimeouts(5000, 5000)
            'fnPerformaxComOpen DLL function for opening communication with Performax
            Status = fnPerformaxComOpen(deviceIndex, hUSBDevice)

            If Status = 0 Then
                Me.Visible = False
                MsgBox("Error opening device. Application is aborting. Reset hardware and try again.")
                End
            End If
        End If

        Me.Visible = False 'hide select form
        frmMain.Visible = True 'show the terminal
    End Sub
End Class
