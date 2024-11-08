Imports System.Net
Imports System.IO
Imports System
Imports System.ComponentModel
Imports System.Security.AccessControl

Public Class frmDownloadUpdates

    Public mlink As String
    Private _opcanceld As Boolean
    Private n_filecompleted As Integer
    Private totalentriestoprocess As Integer
    Private _appcukey As Microsoft.Win32.RegistryKey
    Private animatedimage As Image = My.Resources.check_green
    Private Sub OnFrameChanged(ByVal o As Object, ByVal e As EventArgs)
        'Force a call to the Paint event handler. 
        Me.Invalidate()
    End Sub
    Private Sub frmDownload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
        ServicePointManager.DefaultConnectionLimit = 9999
        Dim wc As New WebClient
        Dim curapp As String = My.Application.Info.Version.ToString
        Dim latestversion As String = wc.DownloadString(My.Settings.UpdateLink & "VersionBMIS.txt")
        Dim Infoupdate As String = wc.DownloadString(My.Settings.UpdateLink & "InfonewupdateBMIS.txt")


        If curapp = latestversion Then

            Label3.Visible = False
            Label5.Text = "Latest Version is :" & curapp
            Panel1.Visible = True
            lbluptodate.Visible = True
            tbinfo.Visible = False
            grpdownload.Visible = False
            PictureBox1.Image = Nothing
            Timer2.Enabled = True

            'Panel1.BackgroundImage = My.Resources.check_green
            Panel1.Refresh()


            'System.Threading.Thread.Sleep(5000)
            ' PictureBox1.Image = Nothing
            '  PictureBox1.Image = My.Resources.check_green_steady
        Else
            Panel1.Visible = False
            lbluptodate.Visible = False
            tbinfo.Visible = True
            grpdownload.Visible = True
            Label3.Text = "New Version is : " & latestversion
            tbinfo.Text = Infoupdate
            grpdownload.Visible = True
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Start()
        Button1.Enabled = False
        'Dim mlink = My.Settings.DownloadLink
        'GetDownloadSize(mlink)
        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim amount As Integer
        If System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Updatefolder\UpdaterBMIS.zip") Then
            Dim o As New System.IO.FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Updatefolder\UpdaterBMIS.zip")
            amount = o.Length
            'amount = amount / 1024
            pbar1.Value = amount
            pbar1.Refresh()
            lbldownload.Text = FormatFileSize(amount)
            lblerror.Visible = False
        Else

            lblerror.Visible = True
            '  pbar1.Value = 0
            lblerror.Text = "FOLDER -- " & Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Updatefolder\UpdaterBMIS.zip does not exist!"
        End If

    End Sub
    Private Delegate Sub setLabelTxtInvoker(ByVal text As String, ByVal lbl As Label)
    Private Sub setLabelTxt(ByVal text As String, ByVal lbl As Label)
        If lbl.InvokeRequired Then
            lbl.Invoke(New setLabelTxtInvoker(AddressOf setLabelTxt), text, lbl)
        Else
            lbl.Text = text
        End If
    End Sub
    Private Delegate Sub setProgressBarMax(ByVal max As Decimal, ByVal pbr As ProgressBar)
    Private Sub setprogressbarmaxvalue(ByVal max As Decimal, ByVal pbr As ProgressBar)
        If pbar1.InvokeRequired Then
            pbar1.Invoke(New setProgressBarMax(AddressOf setprogressbarmaxvalue), max, pbr)
        Else
            pbar1.Maximum = max
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If (Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Updatefolder")) Then
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Updatefolder")
        End If

        Dim userAccount As String = System.Windows.Forms.SystemInformation.UserName
        Dim folderinfo As IO.DirectoryInfo = New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Updatefolder")
        Dim folderAcl As New DirectorySecurity
        folderAcl.AddAccessRule(New FileSystemAccessRule(userAccount, FileSystemRights.Modify, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
        folderinfo.SetAccessControl(folderAcl)

        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Updatefolder\UpdaterBMIS.zip")
        Dim mlink = My.Settings.DownloadLink

        Dim msize As Integer
        Dim wr As WebRequest
        wr = WebRequest.Create(mlink)

        Dim webr As WebResponse = wr.GetResponse
        msize = webr.ContentLength

        Dim newsize As Integer = 0

        newsize = msize / 1024
        'pbar1.Maximum = newsize
        'pbar1.Refresh()
        'lblsize.Text = msize.ToString & " KB"
        setprogressbarmaxvalue(msize, pbar1)
        setLabelTxt(FormatFileSize(msize), lblsize)

        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
        ServicePointManager.DefaultConnectionLimit = 9999
        Dim wc As New WebClient
        wc.DownloadFile(mlink, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Updatefolder\UpdaterBMIS.zip")

        Exit Sub

        MsgBox("Wrong", 48, "Update")
    End Sub
    Public Function GetDownloadSize(ByVal URL As String) As Long

        Dim r As Net.WebRequest = Net.WebRequest.Create(URL)
        r.Method = Net.WebRequestMethods.Http.Head
        Using rsp = r.GetResponse()
            Return rsp.ContentLength
        End Using
    End Function
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.Dispose()
        frmExtractUpdates.ShowDialog()
        frmExtractUpdates.btnextract.PerformClick()
        pbar1.Value = 0
        pbar1.Maximum = 0

    End Sub



    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        PictureBox1.Image = My.Resources.check_green_3
        Timer2.Enabled = False
        Timer3.Enabled = True
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        PictureBox1.Image = Nothing
        PictureBox1.Image = My.Resources.check_green3_steady
        Timer3.Enabled = False
    End Sub
End Class