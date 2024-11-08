Imports System.Net
Imports System.IO
Imports System
Imports System.ComponentModel
Imports System.Security.AccessControl
Public Class frmManageUpdate
    Dim g_filename As String = Nothing
    Dim oldexe As String = Nothing
    Private Sub btnInstall_Click(sender As Object, e As EventArgs) Handles btnInstall.Click
        If (Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\UpdateApp\UpBMIS")) Then
            MsgBox("Folder doesn't exists", 48)
        Else
            Try

                ' Dim currentdir = Application.StartupPath
                '  My.Computer.FileSystem.CopyDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\UpdateApp\updater", currentdir, True)

                ' My.Computer.FileSystem.CopyDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\UpdateApp\updater", Application.StartupPath, True)

                ' My.Computer.FileSystem.CopyDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\UpdateApp\MUBuildingSchedViewer", Application.StartupPath, True)

                CopyFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\UpdateApp\UpBMIS", Application.StartupPath)
                btndel.PerformClick()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, 48, "Error Detected")
            End Try

        End If
    End Sub
    Public Sub CopyFolder(sourceFolder As String, destFolder As String)
        Try
            If Not Directory.Exists(destFolder) Then
                Directory.CreateDirectory(destFolder)
            End If
            Dim files As String() = Directory.GetFiles(sourceFolder)
            For Each file__1 As String In files
                Dim name As String = Path.GetFileName(file__1)
                If name <> "thumbs.db" And name <> "BMISUpdateManager.exe" And name <> "BMISUpdateManager.vshost.exe" Then

                    If name = My.Settings.AppNameFull Then
                        My.Computer.FileSystem.RenameFile(destFolder & "\" & My.Settings.AppNameFull, My.Settings.AppN & "_" & System.DateTime.Now.ToString("MMddyyyyHHmmss") & ".exe")
                        oldexe = destFolder & "\" & My.Settings.AppN & "_" & System.DateTime.Now.ToString("MMddyyyyHHmmss") & ".exe"
                    End If
                    Dim dest As String = Path.Combine(destFolder, name)
                    File.Copy(file__1, dest, True)
                End If
            Next
            Dim folders As String() = Directory.GetDirectories(sourceFolder)
            For Each folder As String In folders
                Dim name As String = Path.GetFileName(folder)
                Dim dest As String = Path.Combine(destFolder, name)
                CopyFolder(folder, dest)
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString, 48, "Error Detected")
        End Try
       
    End Sub
    Private Sub appNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles appNameToolStripMenuItem.Click
        frmAppName.ShowDialog()
    End Sub

    Private Sub frmManageUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        g_filename = Nothing
        tslblstatus.Text = Date.Today.Year & "@ Maintained and Develop By Topingcoy"
        lblsoftwarename.Text = My.Settings.AppN
    End Sub
    Sub delete_downloaded_file_folder()
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\UpdateApp\UpBMIS"
        System.IO.Directory.Delete(path, True)
        btnstartap.PerformClick()
    End Sub
    Private Sub btndel_Click(sender As Object, e As EventArgs) Handles btndel.Click
        delete_downloaded_file_folder()
    End Sub

    Private Sub btnstartap_Click(sender As Object, e As EventArgs) Handles btnstartap.Click
        ' Dim proc As New System.Diagnostics.Process
        ' proc = Process.Start(Application.StartupPath & "\" & My.Settings.AppNameFull, "")

        Timer1.Interval = My.Settings.TimerInterval
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        pbar1.Value += 1
        If pbar1.Value <= 38 Then
            lblsoftstatus.Text = "Installing the software..."
        ElseIf pbar1.Value <= 60 Then
            lblsoftstatus.Text = "Adding new features..."
        ElseIf pbar1.Value <= 90 Then
            lblsoftstatus.Text = "Installing Components..."
        ElseIf pbar1.Value <= 100 Then
            lblsoftstatus.Text = "Please wait..."
        End If

        If pbar1.Value = 100 Then
            Timer1.Dispose()
            btnkill.PerformClick()
        End If
    End Sub

    Private Sub btnkill_Click(sender As Object, e As EventArgs) Handles btnkill.Click
        Dim killprocess() As Process = System.Diagnostics.Process.GetProcessesByName(My.Settings.AppN)

        For Each mykill As Process In killprocess
            mykill.Kill()
        Next

        If oldexe <> Nothing Then
            System.IO.File.Delete(oldexe)
        End If

        oldexe = Nothing
        Dim proc As New System.Diagnostics.Process

        proc = Process.Start(Application.StartupPath & "\" & My.Settings.AppNameFull, "")

        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
        ServicePointManager.DefaultConnectionLimit = 9999
        Try

            If g_filename <> Nothing Then
               
                Dim request As FtpWebRequest = CType(FtpWebRequest.Create("ftp://151.106.124.135//UpdaterBMIS.zip"), FtpWebRequest)
                request.Credentials = New NetworkCredential("u469758770.forexeupdate", "Exeupdater2023!@#")
                request.Method = WebRequestMethods.Ftp.UploadFile
                lblftpstatus.Text = "Please wait..."
                'Using fileStream As Stream = File.OpenRead("C:\Users\TES-USER\Desktop\Updater.zip"),
                '      ftpStream As Stream = request.GetRequestStream()
                '    fileStream.CopyTo(ftpStream)
                'End Using
                pbar1.Maximum = 1
                pbar1.Value = 0
                Using fileStream As Stream = File.OpenRead(g_filename), ftpStream As Stream = request.GetRequestStream()
                    lblftpstatus.Text = "Logged In..."
                    lblftpstatus.ForeColor = Color.Blue
                    pbar1.Maximum = fileStream.Length
                    Dim filen As Integer = 0
                    filen = fileStream.Length
                    'MsgBox(fileStream.Length)
                    Dim read As Integer
                    Do
                        lblftpstatus.Text = "Uploading file/s..."
                        Dim buffer() As Byte = New Byte(10240) {}
                        read = fileStream.Read(buffer, 0, buffer.Length)
                        If read > 0 Then

                            '  MsgBox(fileStream.Position)
                            ftpStream.Write(buffer, 0, read)

                            If fileStream.Position > filen Then
                                MsgBox(fileStream.Position)
                            Else
                                pbar1.Value = fileStream.Position
                                pbar1.Refresh()
                            End If

                            ' Console.WriteLine("Uploaded {0} bytes", fileStream.Position)
                        End If
                    Loop While read > 0
                End Using
                'Dim request As FtpWebRequest = WebRequest.Create("ftp://ftp.benzengineering.info/Updater.zip") ' WebRequest.Create("ftp://ftp.example.com/remote/path/file.zip")
                'request.Credentials = New NetworkCredential("u469758770.jonrywapo", "Jonrywapo2023!@#")
                'request.Method = WebRequestMethods.Ftp.UploadFile

                'Using fileStream As Stream = File.OpenRead("C:\Users\TES-USER\Desktop\Updater.zip"), ftpStream As Stream = request.GetRequestStream()
                '    Dim read As Integer
                '    Do
                '        Dim buffer() As Byte = New Byte(10240) {}
                '        read = fileStream.Read(buffer, 0, buffer.Length)
                '        If read > 0 Then
                '            ftpStream.Write(buffer, 0, read)
                '            Console.WriteLine("Uploaded {0} bytes", fileStream.Position)
                '        End If
                '    Loop While read > 0
                'End Using
                'Dim sessionOptions As New SessionOptions
                'With sessionOptions
                '    .Protocol = Protocol.Sftp
                '    .HostName = "test.rebex.net"
                '    .UserName = "demo"
                '    .Password = "password"
                '    ' From WinSCP client  
                '    .SshHostKeyFingerprint = "ssh-rsa 2048 03:61:c4:98:f1:ff:7d:23:97:51:07:13:88:b8:c5:55"
                'End With

                'Using session As New Session
                '    session.Open(sessionOptions)
                '    Dim directory As RemoteDirectoryInfo = session.ListDirectory("/pub/example")
                '    Dim fileInfo As RemoteFileInfo
                '    For Each fileInfo In directory.Files
                '        Console.WriteLine(
                '            "{0} with size {1}, permissions {2} and last modification at {3}",
                '            fileInfo.Name, fileInfo.Length, fileInfo.FilePermissions,
                '            fileInfo.LastWriteTime)
                '    Next
                'End Using

                MsgBox("uploaded!")
            End If
            
        Catch ex As Exception
            '  MsgBox(ex.Message.ToString)
            lblftpstatus.Text = "Error..." & ex.Message.ToString
            lblftpstatus.ForeColor = Color.Red
        End Try
       
        'My.Computer.Network.UploadFile("C:\Users\TES-USER\Desktop\Updater.zip", "https://my.mu.edu.ph/exeupdate/myapp1/Updater.zip")
    End Sub

    Private Sub btnbrwfile_Click(sender As Object, e As EventArgs) Handles btnbrwfile.Click
        Dim opendialog1 As OpenFileDialog
        opendialog1 = New OpenFileDialog
        If (String.IsNullOrEmpty(g_filename)) Then
            Dim ipath As String = Nothing
            ipath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString


            opendialog1.InitialDirectory = ipath
        Else
            opendialog1.InitialDirectory = IIf(File.Exists(g_filename), Path.GetDirectoryName(g_filename), g_filename)
        End If
        opendialog1.Filter = "zip files|*.zip|EXE files|*.exe|All Files|*.*"
        opendialog1.FilterIndex = 1
        opendialog1.RestoreDirectory = True

        If (opendialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            g_filename = opendialog1.FileName
            ts_statfilename.Text = g_filename
        Else
            g_filename = Nothing
        End If
    End Sub
End Class