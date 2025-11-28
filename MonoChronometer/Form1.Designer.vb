<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ReplyText = New System.Windows.Forms.TextBox()
        Me.CommandText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdStartTest = New System.Windows.Forms.Button()
        Me.txtStart_λ = New System.Windows.Forms.TextBox()
        Me.txtStop_λ = New System.Windows.Forms.TextBox()
        Me.txt_λ_Increment = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdStopMotion = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtStepNo = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdInitiateTest = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtInitialDialReading = New System.Windows.Forms.TextBox()
        Me.cmdCalMonoChronomator = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtBacklash_λ = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSettleTime = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtHP3497Addr = New System.Windows.Forms.TextBox()
        Me.txtHP3497DataChnl = New System.Windows.Forms.TextBox()
        Me.txtGPIPIndex = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtHP497Reply = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTestDataFileName = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ReplyText)
        Me.GroupBox1.Controls.Add(Me.CommandText)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(1168, 744)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Size = New System.Drawing.Size(508, 217)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Terminal"
        Me.GroupBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(176, 148)
        Me.Button1.Margin = New System.Windows.Forms.Padding(6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(148, 58)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ReplyText
        '
        Me.ReplyText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReplyText.Location = New System.Drawing.Point(136, 98)
        Me.ReplyText.Margin = New System.Windows.Forms.Padding(6)
        Me.ReplyText.Name = "ReplyText"
        Me.ReplyText.Size = New System.Drawing.Size(334, 32)
        Me.ReplyText.TabIndex = 3
        '
        'CommandText
        '
        Me.CommandText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CommandText.Location = New System.Drawing.Point(136, 42)
        Me.CommandText.Margin = New System.Windows.Forms.Padding(6)
        Me.CommandText.Name = "CommandText"
        Me.CommandText.Size = New System.Drawing.Size(334, 32)
        Me.CommandText.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 104)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Reply:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 48)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Command:"
        '
        'cmdStartTest
        '
        Me.cmdStartTest.Enabled = False
        Me.cmdStartTest.Location = New System.Drawing.Point(566, 146)
        Me.cmdStartTest.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdStartTest.Name = "cmdStartTest"
        Me.cmdStartTest.Size = New System.Drawing.Size(238, 92)
        Me.cmdStartTest.TabIndex = 1
        Me.cmdStartTest.Text = "2 - Move to Initial Scan Position and Wait"
        Me.cmdStartTest.UseVisualStyleBackColor = True
        '
        'txtStart_λ
        '
        Me.txtStart_λ.Location = New System.Drawing.Point(540, 90)
        Me.txtStart_λ.Margin = New System.Windows.Forms.Padding(6)
        Me.txtStart_λ.Name = "txtStart_λ"
        Me.txtStart_λ.Size = New System.Drawing.Size(116, 31)
        Me.txtStart_λ.TabIndex = 2
        Me.txtStart_λ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtStop_λ
        '
        Me.txtStop_λ.Location = New System.Drawing.Point(934, 90)
        Me.txtStop_λ.Margin = New System.Windows.Forms.Padding(6)
        Me.txtStop_λ.Name = "txtStop_λ"
        Me.txtStop_λ.Size = New System.Drawing.Size(116, 31)
        Me.txtStop_λ.TabIndex = 3
        Me.txtStop_λ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_λ_Increment
        '
        Me.txt_λ_Increment.Location = New System.Drawing.Point(742, 90)
        Me.txt_λ_Increment.Margin = New System.Windows.Forms.Padding(6)
        Me.txt_λ_Increment.Name = "txt_λ_Increment"
        Me.txt_λ_Increment.Size = New System.Drawing.Size(116, 31)
        Me.txt_λ_Increment.TabIndex = 4
        Me.txt_λ_Increment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(544, 60)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "λ Start (nm)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(934, 60)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "λ Stop (nm)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(718, 60)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(172, 25)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "λ Increment (nm)"
        '
        'cmdStopMotion
        '
        Me.cmdStopMotion.Enabled = False
        Me.cmdStopMotion.Location = New System.Drawing.Point(1242, 467)
        Me.cmdStopMotion.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdStopMotion.Name = "cmdStopMotion"
        Me.cmdStopMotion.Size = New System.Drawing.Size(150, 69)
        Me.cmdStopMotion.TabIndex = 5
        Me.cmdStopMotion.Text = "Stop Motion"
        Me.cmdStopMotion.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(252, 398)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 44)
        Me.Label6.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(42, 396)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(162, 50)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Monochromator" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Position"
        '
        'txtStepNo
        '
        Me.txtStepNo.Location = New System.Drawing.Point(12, 338)
        Me.txtStepNo.Margin = New System.Windows.Forms.Padding(6)
        Me.txtStepNo.Name = "txtStepNo"
        Me.txtStepNo.Size = New System.Drawing.Size(236, 31)
        Me.txtStepNo.TabIndex = 12
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1224, 548)
        Me.Button2.Margin = New System.Windows.Forms.Padding(6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(186, 69)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "End Program"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmdInitiateTest
        '
        Me.cmdInitiateTest.Enabled = False
        Me.cmdInitiateTest.Location = New System.Drawing.Point(894, 146)
        Me.cmdInitiateTest.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdInitiateTest.Name = "cmdInitiateTest"
        Me.cmdInitiateTest.Size = New System.Drawing.Size(186, 67)
        Me.cmdInitiateTest.TabIndex = 14
        Me.cmdInitiateTest.Text = "3 -Initiate Scan"
        Me.cmdInitiateTest.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(278, 338)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 30)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Label10"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(78, 37)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(184, 50)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Monochromator" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dial Reading (nm)"
        '
        'txtInitialDialReading
        '
        Me.txtInitialDialReading.Location = New System.Drawing.Point(84, 90)
        Me.txtInitialDialReading.Margin = New System.Windows.Forms.Padding(6)
        Me.txtInitialDialReading.Name = "txtInitialDialReading"
        Me.txtInitialDialReading.Size = New System.Drawing.Size(172, 31)
        Me.txtInitialDialReading.TabIndex = 18
        Me.txtInitialDialReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdCalMonoChronomator
        '
        Me.cmdCalMonoChronomator.Location = New System.Drawing.Point(64, 146)
        Me.cmdCalMonoChronomator.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdCalMonoChronomator.Name = "cmdCalMonoChronomator"
        Me.cmdCalMonoChronomator.Size = New System.Drawing.Size(214, 69)
        Me.cmdCalMonoChronomator.TabIndex = 19
        Me.cmdCalMonoChronomator.Text = "1 - Calibrate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Monochromator"
        Me.cmdCalMonoChronomator.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(52, 308)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(153, 25)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Scan Progress"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtBacklash_λ)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cmdCalMonoChronomator)
        Me.GroupBox2.Controls.Add(Me.txtInitialDialReading)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.cmdInitiateTest)
        Me.GroupBox2.Controls.Add(Me.txtStepNo)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txt_λ_Increment)
        Me.GroupBox2.Controls.Add(Me.txtStop_λ)
        Me.GroupBox2.Controls.Add(Me.txtStart_λ)
        Me.GroupBox2.Controls.Add(Me.cmdStartTest)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 379)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox2.Size = New System.Drawing.Size(1132, 469)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Scan Parameters"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(346, 33)
        Me.Label18.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(116, 50)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "Backlash " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount (λ)"
        '
        'txtBacklash_λ
        '
        Me.txtBacklash_λ.Location = New System.Drawing.Point(342, 90)
        Me.txtBacklash_λ.Margin = New System.Windows.Forms.Padding(6)
        Me.txtBacklash_λ.Name = "txtBacklash_λ"
        Me.txtBacklash_λ.Size = New System.Drawing.Size(134, 31)
        Me.txtBacklash_λ.TabIndex = 22
        Me.txtBacklash_λ.Text = "10"
        Me.txtBacklash_λ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(54, 233)
        Me.Label15.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(302, 58)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Dial must be be between" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "200 nm and 1500 nm"
        Me.Label15.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtSettleTime)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtHP3497Addr)
        Me.GroupBox3.Controls.Add(Me.txtHP3497DataChnl)
        Me.GroupBox3.Controls.Add(Me.txtGPIPIndex)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(24, 23)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox3.Size = New System.Drawing.Size(790, 327)
        Me.GroupBox3.TabIndex = 52
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GPIB PROPERTIES"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(672, 217)
        Me.Label16.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 26)
        Me.Label16.TabIndex = 224
        Me.Label16.Text = "ms"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(168, 277)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(459, 26)
        Me.Label9.TabIndex = 223
        Me.Label9.Text = "(Click any Default Entry above to Change)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(456, 160)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(194, 52)
        Me.Label7.TabIndex = 222
        Me.Label7.Text = "4 - Time Delay to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     Read HP3497A"
        '
        'txtSettleTime
        '
        Me.txtSettleTime.Location = New System.Drawing.Point(510, 210)
        Me.txtSettleTime.Margin = New System.Windows.Forms.Padding(6)
        Me.txtSettleTime.Name = "txtSettleTime"
        Me.txtSettleTime.Size = New System.Drawing.Size(158, 32)
        Me.txtSettleTime.TabIndex = 221
        Me.txtSettleTime.Text = "100"
        Me.txtSettleTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(22, 160)
        Me.Label13.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(223, 52)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "3 - Set and Read" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     HP3497A Channel"
        '
        'txtHP3497Addr
        '
        Me.txtHP3497Addr.Location = New System.Drawing.Point(510, 115)
        Me.txtHP3497Addr.Margin = New System.Windows.Forms.Padding(6)
        Me.txtHP3497Addr.Name = "txtHP3497Addr"
        Me.txtHP3497Addr.Size = New System.Drawing.Size(158, 32)
        Me.txtHP3497Addr.TabIndex = 2
        Me.txtHP3497Addr.Text = "9"
        Me.txtHP3497Addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHP3497DataChnl
        '
        Me.txtHP3497DataChnl.Location = New System.Drawing.Point(72, 215)
        Me.txtHP3497DataChnl.Margin = New System.Windows.Forms.Padding(6)
        Me.txtHP3497DataChnl.Name = "txtHP3497DataChnl"
        Me.txtHP3497DataChnl.Size = New System.Drawing.Size(166, 32)
        Me.txtHP3497DataChnl.TabIndex = 53
        Me.txtHP3497DataChnl.Text = "10 "
        Me.txtHP3497DataChnl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGPIPIndex
        '
        Me.txtGPIPIndex.Location = New System.Drawing.Point(76, 112)
        Me.txtGPIPIndex.Margin = New System.Windows.Forms.Padding(6)
        Me.txtGPIPIndex.Name = "txtGPIPIndex"
        Me.txtGPIPIndex.Size = New System.Drawing.Size(166, 32)
        Me.txtGPIPIndex.TabIndex = 1
        Me.txtGPIPIndex.Text = "0"
        Me.txtGPIPIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(456, 81)
        Me.Label20.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(309, 26)
        Me.Label20.TabIndex = 100
        Me.Label20.Text = "2 - HP3497A Address (1 to 32)"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(10, 35)
        Me.Label19.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(568, 88)
        Me.Label19.TabIndex = 220
        Me.Label19.Text = "1 - GPIB-USB-HS (Blue Module) Interface Addresses:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     Default = 0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     Enter " & _
    "New Number 1 to 99 to change"
        Me.Label19.UseCompatibleTextRendering = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtHP497Reply
        '
        Me.txtHP497Reply.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHP497Reply.Location = New System.Drawing.Point(834, 58)
        Me.txtHP497Reply.Margin = New System.Windows.Forms.Padding(6)
        Me.txtHP497Reply.Name = "txtHP497Reply"
        Me.txtHP497Reply.Size = New System.Drawing.Size(668, 35)
        Me.txtHP497Reply.TabIndex = 55
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(892, 27)
        Me.Label14.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(171, 25)
        Me.Label14.TabIndex = 56
        Me.Label14.Text = "HP-3497A Reply"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(832, 256)
        Me.Label17.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(546, 25)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Save Data to File (File Name) - Program adds extension"
        '
        'txtTestDataFileName
        '
        Me.txtTestDataFileName.Location = New System.Drawing.Point(834, 287)
        Me.txtTestDataFileName.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTestDataFileName.Name = "txtTestDataFileName"
        Me.txtTestDataFileName.Size = New System.Drawing.Size(668, 31)
        Me.txtTestDataFileName.TabIndex = 57
        Me.txtTestDataFileName.Text = "Enter Test Data File Name "
        '
        'Timer1
        '
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1530, 860)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtTestDataFileName)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txtHP497Reply)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdStopMotion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Performax Terminal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ReplyText As System.Windows.Forms.TextBox
    Friend WithEvents CommandText As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdStartTest As System.Windows.Forms.Button
    Friend WithEvents txtStart_λ As System.Windows.Forms.TextBox
    Friend WithEvents txtStop_λ As System.Windows.Forms.TextBox
    Friend WithEvents txt_λ_Increment As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdStopMotion As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtStepNo As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdInitiateTest As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtInitialDialReading As System.Windows.Forms.TextBox
    Friend WithEvents cmdCalMonoChronomator As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHP3497Addr As System.Windows.Forms.TextBox
    Friend WithEvents txtGPIPIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtHP3497DataChnl As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtHP497Reply As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSettleTime As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTestDataFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtBacklash_λ As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
