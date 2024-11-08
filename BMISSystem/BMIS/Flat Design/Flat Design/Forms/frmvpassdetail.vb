Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient

Imports System.Drawing.Printing
Imports System.Reflection
Imports System.Text

Imports System.Drawing.Imaging
Public Class frmvpassdetail
    Dim r As Integer
    Dim a As New OpenFileDialog
    Dim bytImage() As Byte
    Dim bfile As String
    Dim strFileName As String
    Dim strFileName2 As String
    Dim strStream As ADODB.Stream
    Dim FileSize As UInt32
    Dim fileloc As String = Nothing
    Dim genfile As String = Nothing
    Dim mcmd As MySqlCommand
    Dim dtb As DataTable

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Function retrieve_travdetail(tvid As String)
      
        condb()

        Dim hd1 As String = Nothing
        Dim d1 As String = Nothing
        Dim d2 As String = Nothing
        Dim d3 As String = Nothing

        Dim sigp As String = Nothing
        Dim ntb As String = Nothing
       
        Using mcmd = New MySqlCommand("SELECT * FROM travel_agency_detail001 WHERE travid=@tvid AND active ='1'", cdb)
            mcmd.Parameters.AddWithValue("@tvid", tvid)
            dtb = retrieve_data_from_command(mcmd)
            If dtb.Rows.Count > 0 Then
                For Each r As DataRow In dtb.Rows
                    If Not IsDBNull(r("headerlogo")) Then
                        pbox1.Image = Byte2Image(r("headerlogo"))
                    End If
                    If Not IsDBNull(r("notedbysig")) Then
                        pbox2.Image = Byte2Image(r("notedbysig"))
                    End If

                    If Not IsDBNull(r("detail1").ToString()) Then
                        tb1.Text = r("detail1").ToString()
                    End If
                    If Not IsDBNull(r("detail2").ToString()) Then
                        tb2.Text = r("detail2").ToString()
                    End If

                    If Not IsDBNull(r("note").ToString()) Then
                        tb3.Text = r("note").ToString()
                    End If

                    If Not IsDBNull(r("notedby").ToString()) Then
                        tb4.Text = r("notedby").ToString()
                    End If
                Next
            End If
            mcmd.Dispose()
        End Using

        condb_close(cdb)
        Return True
    End Function
    Private Sub frmvpassdetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each control As Control In Me.Controls ' Check every control
            If control.GetType().Equals(GetType(TextBox)) Then ' Proceed if it is a TextBox
                Dim textBox As TextBox = control ' So we have the right type
                AddHandler textBox.MouseEnter, Sub() textBox.BorderStyle = BorderStyle.FixedSingle ' Mouse over state
                AddHandler textBox.MouseLeave, Sub() textBox.BorderStyle = BorderStyle.None ' Mouse away state
                textBox.BorderStyle = BorderStyle.None ' Set initial state
            End If
        Next

        retrieve_travdetail(1)
    End Sub

    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btnb1.Click
        strFileName = Nothing

        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        ' fd.Filter = "All files (*.jpg)|*.jpg|All files (*.*)|*.*"
        fd.Filter = "All files (*.jpg, *.bmp)|*.jpg"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        If System.IO.Directory.Exists(Application.StartupPath + "\qimages") Then
        Else
            MkDir(Application.StartupPath + ("\qimages"))
        End If
        If fd.ShowDialog() = DialogResult.OK Then

            strFileName = fd.FileName
            pbox1.Image = SafeImageFromFile(strFileName)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        Me.Dispose()
        MainForm.btnDashboard.PerformClick()
    End Sub

    Private Sub btnb2_Click(sender As Object, e As EventArgs) Handles btnb2.Click
        strFileName2 = Nothing

        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        ' fd.Filter = "All files (*.jpg)|*.jpg|All files (*.*)|*.*"
        fd.Filter = "All files (*.jpg, *.bmp)|*.jpg"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        dsktopath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\travlogo001"
        If System.IO.Directory.Exists(dsktopath) Then
        Else
            MkDir(dsktopath)
        End If
        If fd.ShowDialog() = DialogResult.OK Then

            strFileName2 = fd.FileName
            pbox2.Image = SafeImageFromFile(strFileName2)
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        update_trav(1)
    End Sub

    Function update_trav(trav As String)

        'Dim arrImage1() As Byte
        'Dim arrImage2() As Byte
        'Dim mstream As New System.IO.MemoryStream()
        'pbox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
        'arrImage1 = mstream.GetBuffer()
        'Dim FileSize1 As UInt32
        'Dim FileSize2 As UInt32
        'FileSize1 = mstream.Length
        Dim fi1 As New IO.FileInfo(strFileName)
        Dim fi2 As New IO.FileInfo(strFileName2)

        If fi1.Length > 0 And fi2.Length > 0 Then

            Dim fname1 As String = Nothing
            Dim fname2 As String = Nothing
            fname1 = fi1.Name
            fname2 = fi2.Name

            Dim strNewFileName1 As String
            Dim strNewFileName2 As String
            Dim extn As String = fi1.Extension
            strNewFileName1 = fname1.Substring(0, fname1.Length - fi1.Extension.Length) & "_resize" & extn


            extn = fi2.Extension
            strNewFileName2 = fname2.Substring(0, fname2.Length - fi2.Extension.Length) & "_resize" & extn

            If File.Exists(strFileName) Then
                Dim original1 As Image = Image.FromFile(strFileName)
                Dim original2 As Image = Image.FromFile(strFileName2)

                Dim stream1 As New System.IO.MemoryStream()
                Dim resized As Image = ResizeImage(original1, New Size(600, 486))
                ' resized.Save(fi1.DirectoryName + "/" + strNewFileName1, System.Drawing.Imaging.ImageFormat.Jpeg)
                'resized.Dispose()
                resized.Save(stream1, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim arrImage1() As Byte = stream1.GetBuffer()
                Dim FileSize As UInt32
                FileSize = stream1.Length
                stream1.Close()

                Dim stream2 As New System.IO.MemoryStream()
                Dim resized2 As Image = ResizeImage(original2, New Size(600, 486))
                'resized2.Save(fi1.DirectoryName + "/" + strNewFileName2, System.Drawing.Imaging.ImageFormat.Jpeg)
                resized2.Save(stream2, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim arrImage2() As Byte = stream2.GetBuffer()
                Dim FileSize2 As UInt32
                FileSize2 = stream2.Length
                stream2.Close()

                'Dim nwpath1 As String = fi1.DirectoryName + "\" + strNewFileName1
                'Dim nwpath2 As String = fi2.DirectoryName + "\" + strNewFileName2
                condb()

                'Dim hd1 As String = Nothing
                Dim d1 As String = Nothing
                Dim d2 As String = Nothing
                Dim d3 As String = Nothing

                'Dim sigp As String = Nothing
                Dim ntb As String = Nothing


                d1 = tb1.Text.Trim
                d2 = tb2.Text.Trim
                d3 = tb3.Text.Trim

                ntb = tb4.Text.Trim
                Using mcmd = New MySqlCommand("UPDATE travel_agency_detail001 SET headerlogo=@hd,detail1=@d1,detail2=@d2,note=@d3,notedbysig=@sig,notedby=@ntb WHERE travid=@tvid AND active ='1'", cdb)
                    mcmd.Parameters.AddWithValue("@tvid", trav)
                    'Create an empty stream in memory.'


                    ' Dim hd1 As Byte() = imgToByteArray(resized)
                    ' Dim sigp As Byte() = imgToByteArray(resized2)

                    mcmd.Parameters.AddWithValue("@hd", arrImage1)
                    mcmd.Parameters.AddWithValue("@sig", arrImage2)

                    mcmd.Parameters.AddWithValue("@d1", d1)
                    mcmd.Parameters.AddWithValue("@d2", d2)
                    mcmd.Parameters.AddWithValue("@d3", d3)

                    mcmd.Parameters.AddWithValue("@ntb", ntb)
                    mcmd.ExecuteNonQuery()
                    mcmd.Dispose()
                    MsgBox("Updated", 64, "UPDATED")
                End Using
            End If
            condb_close(cdb)
        Else
            MsgBox("Please select file/s first!", 48, "No Files Selected")
        End If

        Return True
    End Function


End Class