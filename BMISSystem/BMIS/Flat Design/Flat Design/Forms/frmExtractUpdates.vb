Imports System.Net
Imports System.IO
Imports System
Imports System.ComponentModel
Imports Ionic.Zip
Public Class frmExtractUpdates
    Private _bgworker1 As System.ComponentModel.BackgroundWorker
    Private _opcancel As Boolean
    Private nfilescompleted As Integer
    Private total_process As Integer
    Private _appcukey As Microsoft.Win32.RegistryKey
    Private appregpath As String = "Software\Ionic\VBunzip"
    Private rvn_zpfile As String = "zipfile"
    Private rvn_extractdir As String = "extractdir"

    Private Delegate Sub ZipProgress(ByVal e As ExtractProgressEventArgs)

    Private Sub frmextract_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveFormToRegistry()
        btncancel.PerformClick()
        frmDownloadUpdates.Timer1.Enabled = False

        'Me.Close()

    End Sub

    Private Sub frmextract_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tb2.UseSystemPasswordChar = True
        tb1.UseSystemPasswordChar = True
        tb1.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Updatefolder\UpdaterBMIS.zip"
        tb2.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\UpdateApp"


        Control.CheckForIllegalCrossThreadCalls = False

    End Sub



    Private Sub KickOffExtract()
        lblstatus.Text = "Installing..."
        Dim arg(2) As String
        arg(0) = Me.tb1.Text
        arg(1) = Me.tb2.Text

        _bgworker1 = New System.ComponentModel.BackgroundWorker
        _bgworker1.WorkerSupportsCancellation = False
        _bgworker1.WorkerReportsProgress = False
        Try
            AddHandler Me._bgworker1.DoWork, New DoWorkEventHandler(AddressOf Me.UnzipFile)
            _bgworker1.RunWorkerAsync(arg)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, 48)
        End Try



    End Sub

    Private Sub UnzipFile(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim extractcancelled As Boolean = False
        Dim args() As String = e.Argument
        Dim ziptoread As String = Me.tb1.Text.Trim
        Dim extractdir As String = Me.tb2.Text.Trim

        Try
            pbar2.Visible = True
            Using zip As ZipFile = ZipFile.Read(ziptoread)
                total_process = zip.Entries.Count
                SetProgressBarMax(zip.Entries.Count)

                AddHandler zip.ExtractProgress, New EventHandler(Of ExtractProgressEventArgs)(AddressOf Me.zip_ExtractProgress)

                zip.ExtractAll(extractdir, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)
            End Using

        Catch ex As Exception
            MsgBox("Problem during extract. {0}" & ex.Message.ToString, 48)
        End Try

        ResetUI()

    End Sub


    Private Sub btnextract_Click(sender As Object, e As EventArgs) Handles btnextract.Click
        ' frmMySettings.Show()
        ' frmMySettings.btnOK.PerformClick()

        Dim sfiletoextract As String = Me.tb1.Text
        Dim sdestination As String = Me.tb2.Text

        If Not File.Exists(sfiletoextract) Then
            MsgBox("File doesn't exist!", 48, "Installation Corrupt!")
            Exit Sub
        End If

        If Not String.IsNullOrEmpty(sfiletoextract) And Not String.IsNullOrEmpty(sdestination) Then
            If Not Directory.Exists(sdestination) Then
                Directory.CreateDirectory(sdestination)
            End If
            nfilescompleted = 0
            _opcancel = False
            btnextract.Enabled = False
            btncancel.Enabled = True
            btnbrwloc.Enabled = False
            btnbrwextract.Enabled = False

            tb1.Enabled = False
            tb2.Enabled = False
            pbar2.Visible = True
            KickOffExtract()
        Else
            MsgBox("Please make sure the source of the file, and the location is specified!", 48, "Fill in all fields!")
        End If
    End Sub


    Private Sub btnbrwloc_Click(sender As Object, e As EventArgs) Handles btnbrwloc.Click
        Dim opendialog1 As OpenFileDialog

        If (String.IsNullOrEmpty(tb1.Text)) Then
            opendialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString
        Else
            opendialog1.InitialDirectory = IIf(File.Exists(Me.tb1.Text), Path.GetDirectoryName(Me.tb1.Text), Me.tb1.Text)
        End If
        opendialog1.Filter = "zip files|*.zip|EXE files|*.exe|All Files|*.*"
        opendialog1.FilterIndex = 1
        opendialog1.RestoreDirectory = True

        If (opendialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.tb1.Text = opendialog1.FileName
            If File.Exists(tb1.Text) Then
                Me.btnextract_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnbrwextract_Click(sender As Object, e As EventArgs) Handles btnbrwextract.Click
        Dim dlg As New FolderBrowserDialog

        dlg.Description = "Choose the extract folder: "
        dlg.ShowNewFolderButton = False
        dlg.SelectedPath = Me.tb2.Text

        If (dlg.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.tb2.Text = dlg.SelectedPath
        End If
    End Sub

    Private Sub chk1_CheckedChanged(sender As Object, e As EventArgs) Handles chk1.CheckedChanged
        If chk1.Checked = True Then
            tb2.UseSystemPasswordChar = False
            tb1.UseSystemPasswordChar = False
        Else
            tb2.UseSystemPasswordChar = True
            tb1.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub chk2_CheckedChanged(sender As Object, e As EventArgs) Handles chk2.CheckedChanged
        If chk2.Checked = True Then
            btnbrwloc.Enabled = True
            btnbrwextract.Enabled = True

            tb2.UseSystemPasswordChar = False
            tb1.UseSystemPasswordChar = False

        Else
            btnbrwloc.Enabled = False
            btnbrwextract.Enabled = False
            tb2.UseSystemPasswordChar = True
            tb1.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        _opcancel = True
        pbar2.Maximum = 1
        pbar2.Value = 0
        lblstatus.Text = "Cancelled..."
        pbar2.Visible = False
    End Sub

    Private Sub SaveFormToRegistry()
        If _appcukey IsNot Nothing Then
            If Not String.IsNullOrEmpty(tb1.Text) Then
                _appcukey.SetValue(rvn_zpfile, Me.tb1.Text)
            End If

            If Not String.IsNullOrEmpty(tb2.Text) Then
                _appcukey.SetValue(rvn_extractdir, tb2.Text)
            End If
        End If
    End Sub

    Private Sub LoadFormFromRegistry()
        If _appcukey IsNot Nothing Then
            Dim s As String = Nothing

            s = _appcukey.GetValue(rvn_zpfile)
            If Not String.IsNullOrEmpty(s) Then
                Me.tb1.Text = s
            End If

            s = _appcukey.GetValue(rvn_extractdir)
            If Not String.IsNullOrEmpty(s) Then
                tb2.Text = s
            End If
        End If
    End Sub

    Public ReadOnly Property AppCuKey() As Microsoft.Win32.RegistryKey
        Get
            If (_appcukey Is Nothing) Then
                Me._appcukey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(appregpath, True)

                If (Me._appcukey Is Nothing) Then
                    Me._appcukey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(appregpath)
                End If
            End If
            Return _appcukey

        End Get
    End Property

    Private Sub DeleteDirectory(ByVal dirName As String)
        Throw New NotImplementedException
    End Sub

    Private Sub StepEntryProgress(ByVal e As ExtractProgressEventArgs)
        If pbar2.InvokeRequired Then
            pbar2.Invoke(New ZipProgress(AddressOf StepEntryProgress), New Object() {e})
        Else
            pbar2.PerformStep()
            System.Threading.Thread.Sleep(100)

            nfilescompleted = nfilescompleted + 1
            lblstatus.Text = String.Format("{0} of {1} files...({2})", nfilescompleted, total_process, e.CurrentEntry.FileName)
            Me.Update()
        End If
    End Sub

    Private Sub zip_ExtractProgress(ByVal sender As Object, ByVal e As ExtractProgressEventArgs)
        If _opcancel Then
            e.Cancel = True
            Return
        End If

        If (e.EventType = Ionic.Zip.ZipProgressEventType.Extracting_AfterExtractEntry) Then
            StepEntryProgress(e)
        ElseIf (e.EventType) = ZipProgressEventType.Extracting_BeforeExtractAll Then

        End If
    End Sub

    Private Sub SetProgressBarMax(ByVal n As Integer)
        If pbar2.InvokeRequired Then
            pbar2.Invoke(New Action(Of Integer)(AddressOf SetProgressBarMax), New Object() {n})
        Else
            pbar2.Value = 0
            pbar2.Maximum = n
            pbar2.Step = 1
        End If
    End Sub

    Private Sub DeleteRecursiveFolder(ByVal sTargetDir As String)
        Try
            If File.GetAttributes(sTargetDir) = FileAttributes.ReadOnly Then
                File.SetAttributes(sTargetDir, FileAttributes.Normal)
            End If

            Dim filelist As String() = Directory.GetFiles(sTargetDir)
            Dim dirs As String() = Directory.GetDirectories(sTargetDir)


            For Each folder As String In dirs
                DeleteRecursiveFolder(folder)
            Next

            For Each fileName As String In filelist
                Dim fi As New FileInfo(fileName)
                File.SetAttributes(fileName, FileAttributes.Normal)
                File.Delete(fileName)
            Next
            Directory.Delete(sTargetDir, True)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, 48)
            Return
        End Try
    End Sub

    Private Function DirectoryExists(ByVal spath As String) As Boolean
        Try
            If System.IO.Directory.GetDirectories(spath).Length > 0 Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Private Sub ResetUI()
        If btncancel.InvokeRequired Then
            btncancel.Invoke(New Action(AddressOf ResetUI), New Object() {})
        Else
            btnextract.Enabled = True
            btnbrwloc.Enabled = True
            btnbrwextract.Enabled = True
            btncancel.Enabled = False
            tb1.Enabled = True
            tb2.Enabled = True

            pbar2.Maximum = 1
            pbar2.Value = 0
            Me.btnextract.Focus()
            Dim proc As New System.Diagnostics.Process()
            proc = Process.Start(Application.StartupPath & "\BMISUpdateManager.exe", "")
            Application.Exit()
        End If
    End Sub
End Class