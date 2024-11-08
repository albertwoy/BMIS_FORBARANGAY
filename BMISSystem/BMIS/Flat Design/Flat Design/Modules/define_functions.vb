Imports System
Imports System.IO

Imports MySql.Data.MySqlClient
Imports System.Data.Sql
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Imports System.Drawing.Printing
Imports System.Text
Imports System.Drawing.Imaging
Imports MessagingToolkit.QRCode.Codec
Imports System.Drawing.Text

Imports System.Configuration
Imports System.Security.Cryptography

Imports System.Net
Imports System.Linq
Module defune_functions
    Public selectedmenu As Integer = 0
    Public enc As System.Text.UTF8Encoding

    Public cString As String = Nothing
    Public cString2 As String = "Server=192.168.1.1; User Id=root; Password=123456789;Database=dbname; pooling=false;"


    Public adb As OleDbConnection
    Public sFmat As String = "###,###,###,##0.00"
    Public mypath As String = Nothing
    Public ptpath As String = Nothing
    Public seltabindex As Integer = 0
    Public seldbname As String = Nothing
    Public ntpg As TabPage
    Public rmbtabtflag As Boolean = False
    Public BoldedRows As New List(Of DataGridViewRow)
    Dim gdr As MySqlDataReader
    Public usertyp As String = Nothing

    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    'Public _user, _pass, _name, _usertype As String
    Private tripleDes As New TripleDESCryptoServiceProvider
    Public str_user As String
    Public str_pass As String
    Public str_role As String
    Public str_name As String
    Public _user, _userid, _pass, _name, _usertype As String

   

    Public dtps1 As Date = Now.ToString
    Public dtps2 As Date = Now.ToString
    Public dtps3 As Date = Now.ToString

    'Public prep As New ReportDocument
    'Public ds As New DataSet1
    'Public ds2 As New DataSet2
    'Public dt As DataTable = ds.Tables("rcvDataTable")
    'Public dtc As DataTable = ds.Tables("supCM")
    'Public dtStockIn As DataTable = ds.Tables("dtStockIn")
    'Public dtStockTransfer As DataTable = ds2.Tables("dtStockTransfer")
    'Public dtSalesInvoice As DataTable = ds.Tables("dtSalesInvoice")
    'Public dtExpress As DataTable = ds.Tables("dtExpressColl")
    Public currentopenform As Form
    Public r1 As DataRow
    Public r2 As DataRow
    Public cmdmtype As String = Nothing
    Public bmppath As String = Nothing
    Public dsktopath As String = Nothing

    Public dsktopath2 As String = Nothing
    Public trs As String = Nothing
    Dim DoubleBytes As Double

    Public filepath_directory As String = Nothing
    Public qrCode As New QRCodeEncoder

    Public cm As MySqlCommand
    Public my_dataadapter As MySqlDataAdapter
    Public my_datatab As DataTable
    Public cdb As MySqlConnection = Nothing
    Function closeallforms(frm As Form)
        For Each Form In My.Application.OpenForms
            If Form.name <> "Mainform" Then
                If Form.name <> frm.Name Then
                    ' Form.Dispose()
                End If
            End If

        Next
        Return True
    End Function
    
    Public Function GetFileSize(ByVal TheFile As String) As String
        If TheFile.Length = 0 Then Return ""
        If Not System.IO.File.Exists(TheFile) Then Return ""
        '---
        Dim TheSize As ULong = My.Computer.FileSystem.GetFileInfo(TheFile).Length
        Dim SizeType As String = ""
        Try
            Select Case TheSize
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(TheSize / 1099511627776) 'TB
                    Return FormatNumber(DoubleBytes, 2) & " TB"
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(TheSize / 1073741824) 'GB
                    Return FormatNumber(DoubleBytes, 2) & " GB"
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(TheSize / 1048576) 'MB
                    Return FormatNumber(DoubleBytes, 2) & " MB"
                Case 1024 To 1048575
                    DoubleBytes = CDbl(TheSize / 1024) 'KB
                    Return FormatNumber(DoubleBytes, 2) & " KB"
                Case 0 To 1023
                    DoubleBytes = TheSize ' bytes
                    Return FormatNumber(DoubleBytes, 2) & " bytes"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try

    End Function

    Public Sub checkupdate()
        If My.Settings.UpdateLink = "" Or My.Settings.DownloadLink = "" Then
            Exit Sub
        End If
        If MainForm.Panel6.Visible = False Then
            ConnectionAvailable.isConnectionAvailable()
            If ConnectionAvailable.isConnectionAvailable = True Then
                Try
                    ServicePointManager.Expect100Continue = True
                    ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
                    ServicePointManager.DefaultConnectionLimit = 9999
                    Dim wc As New WebClient
                    '  MsgBox(My.Settings.UpdateLink)
                    Dim newversion As String = Nothing
                    Dim currentapp As String = Nothing

                    newversion = wc.DownloadString(My.Settings.UpdateLink & "VersionFJK.txt")
                    currentapp = My.Application.Info.Version.ToString()

                    If currentapp <> newversion Then
                        MainForm.Panel6.Visible = True
                        MainForm.txtnewversion.Text = "New Version is: " & newversion
                    End If
                Catch ex As Exception
                    MainForm.tsupdatelab.Text = ex.Message.ToString & " - Update link is not OK"
                    MainForm.tsupdatelab.ForeColor = Color.Red
                    'MsgBox(ex.Message.ToString & " - Update link is not OK", 48)
                End Try
            Else
                MainForm.tsupdatelab.Text = "Internet Connection Unavailable ( x ) - please check "
                MainForm.tsupdatelab.ForeColor = Color.Red
                Exit Sub
            End If
        End If

    End Sub
    
    Public Function retrieve_data_from_command(ByVal cc As MySqlCommand)
        Dim dtnew As DataTable
        dtnew = New DataTable
        dtnew.Clear()
        Using adp = New MySqlDataAdapter(cc)
            adp.Fill(dtnew)
        End Using
        Return dtnew
    End Function

    Public Function condb()
        Try
            Dim sFileName As String
            Dim x As Integer = 0

            seldbname = "bmis_fordistrib00123"
            sFileName = Application.StartupPath & "\" & "ips.txt"

            Dim mysvr As String = Nothing
            Dim myun As String = Nothing
            Dim mypd As String = Nothing

            For Each line As String In File.ReadLines(sFileName)
                x += 1
                If x = 1 Then
                    mysvr = DecryptNew(line)
                ElseIf x = 2 Then
                    myun = DecryptNew(line)
                ElseIf x = 3 Then
                    mypd = DecryptNew(line)
                End If
            Next
            '    MsgBox(mysvr & " " & myun & " " & mypd)

            dsktopath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\GENFILES"

            If (Not System.IO.Directory.Exists(dsktopath)) Then
                System.IO.Directory.CreateDirectory(dsktopath)
            End If
          
            cString = "Server=" & mysvr & "; User Id=" & myun & "; Password= " & mypd & "; Database=" & seldbname & ";pooling=false;Convert Zero Datetime=True;Allow Zero Datetime=True;"
            cdb = New MySqlConnection(cString)
            cdb.Open()
            MainForm.lblconnectionstatus.Text = "CONNECTION SUCCESSFUL"
            MainForm.lblconnectionstatus.ForeColor = Color.DarkBlue
            Return True
        Catch ex As Exception
            MainForm.lblconnectionstatus.Text = "CONNECTION TO DATABASE UNSUCCESSFUL"
            MainForm.lblconnectionstatus.ForeColor = Color.DarkRed
            Return False
        End Try
    End Function

    Public Function condb_close(ByVal database_connection As MySqlConnection)
        'If cdb.open Then

        database_connection.Close()
        '   database_connection.Close()

        '  End If
        Return True
    End Function
    Public Function savetrails(ByVal usid As String, ByVal trans As String, ByVal dt As Date)
        Dim svt As MySqlCommand
        svt = New MySqlCommand("INSERT INTO bmis_user_trail_001(userid,trans,dsaved) VALUES(@usid,@trans,@ds)", cdb)
        svt.Parameters.AddWithValue("@usid", usid)
        svt.Parameters.AddWithValue("@trans", trans)
        svt.Parameters.AddWithValue("@ds", dt)
        svt.ExecuteNonQuery()
        Return True
    End Function
    Public Sub condb2()
        'Try
        '    cdb2 = New MySqlConnection(cString2)
        '    KCCMain.sts2.Text = "Connected to Server!"
        '    KCCMain.sts2.ForeColor = Color.Blue
        '    KCCMain.Time_Server.Enabled = True
        'Catch ex As Exception
        '    KCCMain.sts2.Text = "Error Connecting to Server " & ex.Message.ToString
        '    KCCMain.sts2.ForeColor = Color.Red
        'End Try
    End Sub

    Public Function cmdb(ByVal mp As String) As Boolean
        Try
            Dim mpath As String = Nothing
            mpath = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Data Source=" + Strings.LCase(mp) + ";Jet OLEDB:Database Password=mxx6re"
            adb = New OleDbConnection(mpath)

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try
        Return True
    End Function

    Function centerme(cobject)
        Dim xx As Integer = CInt((cobject.ClientSize.Width / 2) - (cobject.Width / 2))
        Dim yy As Integer = CInt((cobject.ClientSize.Height / 2) - (cobject.Height / 2))
        cobject.Location = New Point(xx, yy)
        Return cobject
    End Function
    Function center_object(ByVal obj As Object, ByVal frm As Form)
        obj.Location = New Point((frm.Width \ 2) - (obj.Width \ 2), (frm.Height \ 2) - (obj.Height \ 2))
        Return obj
    End Function
    Function centerme1(cobject)
        Dim xx As Integer = CInt((MainForm.ClientSize.Width / 2) - (cobject.Width / 2))
        Dim yy As Integer = CInt((MainForm.ClientSize.Height / 2) - (cobject.Height / 2)) - 100
        cobject.Location = New Point(xx, yy)
        Return cobject
    End Function
    Function centerme3(cobject)
        Dim xx As Integer = CInt((MainForm.ClientSize.Width / 2) - (cobject.Width / 2))
        Dim yy As Integer = CInt((MainForm.ClientSize.Height / 2) - (cobject.Height / 2))
        cobject.Location = New Point(xx, yy)
        Return cobject
    End Function
    Public Sub closeallchild()
        For Each frm As Form In MainForm.MdiChildren()
            frm.Close()
        Next
    End Sub
    'Public Function returndata(ByVal d As String)
    '    'frmotransac.tbsemp.Text = d
    '    'Return True
    'End Function

    Public Function Byte2Image(ByVal ByteArr() As Byte) As Image
        'will turn a byte array to an image
        Dim ImageStream As MemoryStream

        Try
            If ByteArr.GetUpperBound(0) > 0 Then
                ImageStream = New MemoryStream(ByteArr)
                Return Image.FromStream(ImageStream)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Function Amt2Word(number As Decimal) As String
        Dim a As Decimal
        Dim rstring As String
        Dim onestr As String
        Dim twostr As String
        Dim tenstr As String
        Dim unitstr As String
        Dim exponent As Integer
        Dim dum As Decimal
        Dim dumstr As String
        a = number
        rstring = ""
        If number > 999999999999.99 Then
            Amt2Word = ""
        End If

        onestr = "ONE   TWO   THREE FOUR  FIVE  SIX   SEVEN EIGHT NINE "
        twostr = "ELEVEN   TWELVE   THIRTEEN FOURTEEN FIFTEEN  SIXTEEN  SEVENTEEN EIGHTEEN NINETEEN  "
        tenstr = "TEN    TWENTY THIRTY FORTY  FIFTY  SIXTY  SEVENTYEIGHTY NINETY "
        unitstr = "THOUSAND MILLION BILLION "

        rstring = ""

        If Int(a / 1000000000) <> 0 Then
            exponent = 11
        ElseIf Int(a / 1000000) <> 0 Then
            exponent = 8
        ElseIf Int(a / 1000) <> 0 Then
            exponent = 5
        ElseIf Int(a / 1) <> 0 Then
            exponent = 2
        Else
            exponent = 0
            rstring = "0"
        End If
        Do While exponent > 0
            dum = Int(a / (10 ^ exponent))
            If dum <> 0 Then
                dumstr = Trim(Mid(onestr, (((dum - 1) * 6) + 1), 6)) & " HUNDRED "
                rstring = rstring & dumstr
                a = a - (dum * (10 ^ exponent))
            End If
            If a < 1 Then
                If exponent / 3 >= 1 Then
                    dumstr = Trim(Mid(unitstr, (((Int(exponent / 3) - 1) * 8) + 1), 8)) & " "
                    rstring = rstring & dumstr
                End If
                Exit Do
            End If
            dum = Int(a / (10 ^ (exponent - 2)))
            If dum <> 0 Then
                If dum > 10 And dum < 20 Then
                    dumstr = Trim(Mid(twostr, ((((dum - 10) - 1) * 9) + 1), 9)) & " "
                    rstring = rstring & dumstr
                    a = a - (dum * (10 ^ (exponent - 2)))
                ElseIf dum < 10 Then
                    dumstr = Trim(Mid(onestr, (((dum - 1) * 6) + 1), 6)) & " "
                    rstring = rstring & dumstr
                    a = a - (dum * (10 ^ (exponent - 2)))
                Else
                    dumstr = Trim(Mid(tenstr, (((Int(dum / 10) - 1) * 7) + 1), 7)) & " "
                    rstring = rstring & dumstr
                    a = a - (Int(dum / 10) * (10 ^ (exponent - 1)))
                    dum = Int(a / (10 ^ (exponent - 2)))
                    If dum <> 0 Then
                        dumstr = Trim(Mid(onestr, (((dum - 1) * 6) + 1), 6)) & " "
                        rstring = rstring & dumstr
                        a = a - (dum * (10 ^ (exponent - 2)))
                    End If
                End If
            End If
            If exponent / 3 >= 1 Then
                dumstr = Trim(Mid(unitstr, (((Int(exponent / 3) - 1) * 8) + 1), 8)) & " "
                rstring = rstring & dumstr
            End If
            If a < 1 Then
                Exit Do
            End If
            exponent = exponent - 3
        Loop
        dumstr = "Pesos and " & Format((a * 100), "#0") & "/100"
        rstring = rstring & dumstr
        Amt2Word = rstring
    End Function
    Public Function getdate()
        Dim dtms As String = Nothing
        Dim qy As String = Nothing
        Dim cg As New MySqlCommand
        Dim gndnw As MySqlDataReader
        qy = "SELECT DATE_FORMAT(CURDATE(),'%Y-%m-%d') mdate"
        cg = New MySqlCommand(qy, cdb)
        gndnw = cg.ExecuteReader()
        If gndnw.HasRows = True Then
            gndnw.Read()
            dtms = gndnw("mdate")
        End If
        gndnw.Dispose()
        cg.Dispose()

        Return dtms

    End Function

    Public Function setselindex(ByVal cb As ComboBox, ByVal vv As String)
        Dim s As Integer = 0
        Dim flg As Boolean = False
        For Each item In cb.Items
            If item.value = vv Then
                flg = True
                Exit For
            Else
                flg = False
            End If
            s += 1
        Next

        If flg = False Then
            s = -1
        End If

        Return s
    End Function

    Function rpchar(ByVal mstr, ByVal crev)
        Return mstr.Replace(crev, "")
    End Function

    Public Function gettime2(ByVal x As Integer)

        Dim dtm2 As String = Nothing
        Dim qy As String = Nothing
        Dim cg2 As New MySqlCommand


        qy = "SELECT DATE_FORMAT(CURDATE(),'%Y-%m-%d') mdate,DATE_FORMAT(CURDATE(),'%b %e, %Y') formaldate,TIME_FORMAT(CURTIME(),'%h:%i:%s %p') mtime, " & _
            "CONCAT(DATE_FORMAT(CURDATE(),'%y'),TIME_FORMAT(CURTIME(),'%s')) mdateq "
        cg2 = New MySqlCommand(qy, cdb)
        Using nwgdr2 As MySqlDataReader = cg2.ExecuteReader()
            If nwgdr2.HasRows = True Then
                nwgdr2.Read()
                If x = 1 Then
                    dtm2 = nwgdr2("mtime")
                ElseIf x = 2 Then
                    dtm2 = nwgdr2("formaldate")
                ElseIf x = 3 Then
                    dtm2 = nwgdr2("mdate")
                ElseIf x = 4 Then
                    dtm2 = nwgdr2("mdateq")
                End If
            End If

        End Using

        cg2.Dispose()

        Return dtm2

    End Function

    Public Function gettime(ByVal x As Integer)
        condb()
        Dim dtm As String = Nothing
        Dim qy As String = Nothing
        Dim cg As New MySqlCommand
        Dim gdr As MySqlDataReader
        qy = "SELECT DATE_FORMAT(CURDATE(),'%Y-%m-%d') mdate,DATE_FORMAT(CURDATE(),'%b %e, %Y') formaldate,TIME_FORMAT(CURTIME(),'%h:%i:%s %p') mtime, CONCAT(DATE_FORMAT(CURDATE(),'%m%d%Y'),TIME_FORMAT(CURTIME(),'%h%i%s%p')) dtetime"
        cg = New MySqlCommand(qy, cdb)
        gdr = cg.ExecuteReader()
        If gdr.HasRows = True Then
            gdr.Read()
            If x = 1 Then
                dtm = gdr("mtime")
            ElseIf x = 2 Then
                dtm = gdr("formaldate")
            ElseIf x = 3 Then
                dtm = gdr("mdate")
            ElseIf x = 4 Then
                dtm = gdr("dtetime")
            End If
        End If
        gdr.Dispose()
        cg.Dispose()
        condb_close(cdb)
        Return dtm

    End Function

    Public Function GetCurrentAge(ByVal dob As Date) As String
        Dim CurrentDate, Years, ThisYear, Months, ThisMonth, Days
        CurrentDate = CDate(dob)
        Years = DateDiff("yyyy", CurrentDate, Now.Date)
        ThisYear = DateAdd("yyyy", Years, CurrentDate)
        Months = DateDiff("m", ThisYear, Now.Date)
        ThisMonth = DateAdd("m", Months, ThisYear)
        Days = DateDiff("d", ThisMonth, Now.Date)

        Do While (Days < 0) Or (Months < 0)
            If Days < 0 Then
                Months = Months - 1
                ThisMonth = DateAdd("m", Months, ThisYear)
                Days = DateDiff("d", ThisMonth, Now.Date)
            End If
            If Months < 0 Then
                Years = Years - 1
                ThisYear = DateAdd("yyyy", Years, CurrentDate)
                Months = DateDiff("m", ThisYear, Now.Date)
                ThisMonth = DateAdd("m", Months, ThisYear)
                Days = DateDiff("d", ThisMonth, Now.Date)
            End If
        Loop

        Dim gys As String = Nothing
        gys = Years & "Y/" & Months & "M/" & Days & "D/"
        Return gys
    End Function

    Public Function GetYears(ByVal dob As Date) As String
        Dim CurrentDate, Years, ThisYear, Months, ThisMonth, Days
        CurrentDate = CDate(dob)
        Years = DateDiff("yyyy", CurrentDate, Now.Date)
        ThisYear = DateAdd("yyyy", Years, CurrentDate)
        Months = DateDiff("m", ThisYear, Now.Date)
        ThisMonth = DateAdd("m", Months, ThisYear)
        Days = DateDiff("d", ThisMonth, Now.Date)

        Do While (Days < 0) Or (Months < 0)
            If Days < 0 Then
                Months = Months - 1
                ThisMonth = DateAdd("m", Months, ThisYear)
                Days = DateDiff("d", ThisMonth, Now.Date)
            End If
            If Months < 0 Then
                Years = Years - 1
                ThisYear = DateAdd("yyyy", Years, CurrentDate)
                Months = DateDiff("m", ThisYear, Now.Date)
                ThisMonth = DateAdd("m", Months, ThisYear)
                Days = DateDiff("d", ThisMonth, Now.Date)
            End If
        Loop

        Dim gys As String = Nothing
        gys = Years
        Return gys
    End Function

    Public Function GetMonths(ByVal dob As Date) As String
        Dim CurrentDate, Years, ThisYear, Months, ThisMonth, Days
        CurrentDate = CDate(dob)
        Years = DateDiff("yyyy", CurrentDate, Now.Date)
        ThisYear = DateAdd("yyyy", Years, CurrentDate)
        Months = DateDiff("m", ThisYear, Now.Date)
        ThisMonth = DateAdd("m", Months, ThisYear)
        Days = DateDiff("d", ThisMonth, Now.Date)

        Do While (Days < 0) Or (Months < 0)
            If Days < 0 Then
                Months = Months - 1
                ThisMonth = DateAdd("m", Months, ThisYear)
                Days = DateDiff("d", ThisMonth, Now.Date)
            End If
            If Months < 0 Then
                Years = Years - 1
                ThisYear = DateAdd("yyyy", Years, CurrentDate)
                Months = DateDiff("m", ThisYear, Now.Date)
                ThisMonth = DateAdd("m", Months, ThisYear)
                Days = DateDiff("d", ThisMonth, Now.Date)
            End If
        Loop
        Dim gys As String = Nothing
        gys = Months
        Return gys
    End Function

    Public Function GetYearofService(ByVal dob As Date) As String
        Dim CurrentDate, Years, ThisYear, Months, ThisMonth, Days
        CurrentDate = CDate(dob)
        Years = DateDiff("yyyy", CurrentDate, Now.Date)
        ThisYear = DateAdd("yyyy", Years, CurrentDate)
        Months = DateDiff("m", ThisYear, Now.Date)
        ThisMonth = DateAdd("m", Months, ThisYear)
        Days = DateDiff("d", ThisMonth, Now.Date)

        Do While (Days < 0) Or (Months < 0)
            If Days < 0 Then
                Months = Months - 1
                ThisMonth = DateAdd("m", Months, ThisYear)
                Days = DateDiff("d", ThisMonth, Now.Date)
            End If
            If Months < 0 Then
                Years = Years - 1
                ThisYear = DateAdd("yyyy", Years, CurrentDate)
                Months = DateDiff("m", ThisYear, Now.Date)
                ThisMonth = DateAdd("m", Months, ThisYear)
                Days = DateDiff("d", ThisMonth, Now.Date)
            End If
        Loop
        Dim gys As String = Nothing
        gys = Years & "Y/" & Months & "M/" & Days & "D/"
        Return gys
    End Function

    Function savelogs(ByVal mystrng As String)
        Dim mstrn() As String = Nothing
        mstrn = mystrng.Split("-")
        'db.Execute("INSERT INTO userlogs(userid,emp_no,Remarks,tdate) VALUES('" & mstrn(0) & "', '" & mstrn(1) & "','" & mstrn(2) & "','" & getdatetime(1) & "')")
        Return True
    End Function

    ' Function focusontab(ByVal tpname As String)
    'For Each tp As TabPage In MDIParent1.mytab.TabPages
    '    If tp.Name = tpname Then
    '        KCCMain.mytab.SelectTab(tp)
    '        seltabindex = KCCMain.mytab.SelectedIndex
    '        Exit For
    '    End If
    'Next
    'Return True
    ' End Function
    ' Function addnewtab(ByVal tb As TabPage, ByVal fm As Form, ByVal fn As String)
    'ntpg = New TabPage(fn)
    'ntpg.Name = fn
    'fm.Visible = True
    'fm.FormBorderStyle = FormBorderStyle.None
    'fm.Dock = DockStyle.Fill
    'KCCMain.mytab.TabPages.Add(ntpg)
    'KCCMain.mytab.SelectTab(ntpg)
    'KCCMain.mytab.SizeMode = TabSizeMode.FillToRight
    'Dim x As Integer = 0
    'x = KCCMain.mytab.SelectedIndex
    'seltabindex = x
    'KCCMain.mytab.TabPages(x).Controls.Add(fm)
    'Return True
    'End Function

    Function exeupdater()
        Do While True
            Dim client As New Net.WebClient
            Dim newVersion As String = client.DownloadString("https://my.mu.edu.ph/updatedexe/MUInsurance.txt")
            If newVersion <> IO.File.ReadAllText("Your programs file location") Then
                For Each p As Process In Process.GetProcesses
                    If p.ProcessName = "MUInsurance" Then 'If you don't know what your program's process name is, simply run your program, run windows task manager, select 'processes' tab, scroll down untill you find your programs name.
                        p.Kill()
                    End If
                Next
                IO.File.Delete("old program file location")
                client.DownloadFile("hhttps://my.mu.edu.ph/updatedexe/MUInsurance.exe", "where ever you want to download your new program to (file location)")
                client.Dispose()
            End If
            Threading.Thread.Sleep(300000) 'freeze thread for 5 mins...
        Loop
        Return True
    End Function



    Public Function SafeImageFromFile1(path As String) As Image
        Using fs As New FileStream(path, FileMode.Open, FileAccess.Read)
            Dim img = Image.FromStream(fs)
            Return img
        End Using
    End Function

    Function myd(str As String)
        myd = Replace(str, ",", "")
        Return myd
    End Function

    Function savetrail(mytrail As String)
        Dim myt As String = Nothing
        myt = mytrail
        Dim qst As String = Nothing
        qst = "INSERT INTO biotrail(tdetail,tdate) VALUES('" & myt & "','" & gettime2(1) & "')"
        Dim tr As MySqlCommand
        tr = New MySqlCommand(qst, cdb)
        tr.ExecuteNonQuery()
        tr.Dispose()
        Return True
    End Function

    Sub AuditTrail(ByVal plog As String, ByVal pmod As String)
        condb()
        Dim sdate As String = Now.ToString("yyyy-MM-dd")

        cmd = New MySqlCommand("insert into AuditTrail (user, transactions, module, sdate, stime)values (@user, @transactions, @module, @sdate, @stime)", cdb)

        With cmd
            .Parameters.AddWithValue("@user", _user)
            .Parameters.AddWithValue("@transactions", plog)
            .Parameters.AddWithValue("@module", pmod)
            .Parameters.AddWithValue("@sdate", sdate)
            .Parameters.AddWithValue("@stime", Now.ToLongTimeString)
            .ExecuteNonQuery()
        End With
        condb_close(cdb)
    End Sub

    Function GetTransNo() As String
        Dim sdate As String = Now.ToString("yyMMdd")
        Dim cmd As MySqlCommand
        cmd = New MySqlCommand("select transno from poheader where transno like '" & sdate & "%' order by pkno desc", cdb)
        Using rd As MySqlDataReader = cmd.ExecuteReader
            If rd.HasRows Then
                rd.Read()
                GetTransNo = Format(CLng(rd.Item("transno").ToString) + 1)
            Else
                GetTransNo = sdate & "101"
            End If
            rd.Close()
        End Using
        Return GetTransNo
    End Function

    Sub PopUser()

    End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub
    Public Function menudisabler()

        With MainForm
            '.tsviewmnu.Enabled = False
            '.tstoolsmnu.Enabled = False
            '.tshelpmnu.Enabled = False
            '.tslogin.Enabled = True
            '.tslogout.Enabled = False
            '.tsnewmnu.Enabled = False
            '.ToolStrip11.Enabled = False
        End With
        Return False
    End Function
    Public Function menuenabler()

        With MainForm


        End With

        Dim rt As MySqlCommand
        Dim active As String = "Y"
        rt = New MySqlCommand("SELECT * FROM filepath_001 where pathactive=@active", cdb)
        rt.Parameters.AddWithValue("@active", active)
        Using rd As MySqlDataReader = rt.ExecuteReader
            If rd.HasRows Then
                rd.Read()
                filepath_directory = rd("filepathname").ToString
            Else
                filepath_directory = Application.StartupPath & "\mbankfiles"
                If (Not System.IO.Directory.Exists(filepath_directory)) Then
                    System.IO.Directory.CreateDirectory(filepath_directory)
                End If
            End If
            rt.Dispose()
        End Using


        Return False
    End Function

    Public Function GenerateRandomString(ByRef iLength As Integer) As String
        Dim rdm As New Random()
        Dim allowChrs() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
        Dim sResult As String = ""

        For i As Integer = 0 To iLength - 1
            sResult += allowChrs(rdm.Next(0, allowChrs.Length))
        Next

        Return sResult
    End Function
    Public Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
                    percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function
    Public Function imgToByteConverter(ByVal inImg As Image) As Byte()
        Dim imgCon As New ImageConverter()
        Return DirectCast(imgCon.ConvertTo(inImg, GetType(Byte())), Byte())
    End Function
    Public Function imgToByteArray(ByVal img As Image) As Byte()
        Using mStream As New MemoryStream()
            img.Save(mStream, img.RawFormat)
            Return mStream.ToArray()
        End Using
    End Function
    Public Function SafeImageFromFile(path As String) As Image
        Using fs As New FileStream(path, FileMode.Open, FileAccess.Read)
            Dim img = Image.FromStream(fs)
            Return img
        End Using
    End Function
    Function qrcodeGen(qrcod As String) As Image
        Try

            qrCode.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE
            qrCode.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L
            ' Dim img As Bitmap
            qrCode.QRCodeScale = 10
            '' img = qrCode.Encode("ddef04d8-7450-42d1-bc48-a94c3d6dae66")
            Return qrCode.Encode(qrcod, System.Text.Encoding.UTF8)

        Catch ex As Exception
            Dim errtext As String

            errtext = ex.Message & " ( Error )"

            Dim bitmap As New Bitmap(1, 1)
            Dim font As New Font("Arial", 25, FontStyle.Regular, GraphicsUnit.Pixel)
            Dim graphics As Graphics = graphics.FromImage(bitmap)
            Dim width As Integer = CInt(graphics.MeasureString(errtext, font).Width)
            Dim height As Integer = CInt(graphics.MeasureString(errtext, font).Height)
            bitmap = New Bitmap(bitmap, New Size(width, height))
            graphics = graphics.FromImage(bitmap)
            graphics.Clear(Color.White)
            graphics.SmoothingMode = SmoothingMode.AntiAlias
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias
            graphics.DrawString(errtext, font, New SolidBrush(Color.FromArgb(255, 0, 0)), 0, 0)
            graphics.Flush()
            graphics.Dispose()
            'Dim fileName As String = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) & ".jpg"
            'bitmap.Save(Server.MapPath("~/images/") & fileName, ImageFormat.Jpeg)
            ' imgText.ImageUrl = "~/images/" & fileName
            ' imgText.Visible = True
            Return bitmap
        End Try
    End Function
    Public Function EncryptNew(clearText As String) As String
        Dim EncryptionKey As String = "MuInsurance2023!@#"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

    Public Function DecryptNew(cipherText As String) As String
        ' Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim EncryptionKey As String = "MuInsurance2023!@#"

        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function

    Public Function renum(ByVal dtb As DataTable)

        If dtb.Columns.Contains("No") Then
            dtb.Columns.Remove("No")
        End If

        Dim nwcol = New DataColumn("No", GetType(Int32))
        dtb.Columns.Add(nwcol)
        nwcol.SetOrdinal(0)

        Dim x As Integer = 0
        For Each rwx As DataRow In dtb.Rows
            x += 1
            rwx("No") = x
        Next


        Return True
    End Function

    Public Function IS_EMPTY(ByVal pText As Object) As Boolean
        If pText.text = String.Empty Then
            pText.backcolor = Color.LemonChiffon
            pText.focus()
            MsgBox("Required missing field", vbCritical)
            IS_EMPTY = True
        Else
            pText.backcolor = Color.White
            IS_EMPTY = False
        End If
    End Function

    Public Function GetRecords(ByVal sql As String, ByVal _count As String)
        condb()
        cmd = New MySqlCommand(sql, cdb)
        _count = cmd.ExecuteScalar.ToString
        condb_close(cdb)
        Return _count
    End Function

End Module
