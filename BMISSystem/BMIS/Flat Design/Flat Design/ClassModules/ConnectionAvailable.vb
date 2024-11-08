Imports System.Net
Module ConnectionAvailable
    Public Function isConnectionAvailable() As Boolean
        Dim objURL As New System.Uri("https://www.google.com")
        Dim objWebRreq As System.Net.WebRequest

        objWebRreq = System.Net.WebRequest.Create(objURL)
        Dim objresp As System.Net.WebResponse

        Try
            objresp = objWebRreq.GetResponse
            objresp.Close()
            objresp = Nothing
            Return True
        Catch ex As Exception
            objresp = Nothing
            objWebRreq = Nothing
            MsgBox(ex.Message.ToString, 48)
            Return False
        End Try
    End Function

    Public Function FormatFileSize(ByVal Size As Long) As String
        Try
            Dim KB As Integer = 1024
            Dim MB As Integer = KB * KB
            ' Return size of file in kilobytes.
            If Size < KB Then
                Return (Size.ToString("D") & " bytes")
            Else
                Select Case Size / KB
                    Case Is < 1000
                        Return (Size / KB).ToString("N") & " KB"
                    Case Is < 1000000
                        Return (Size / MB).ToString("N") & " MB"
                    Case Is < 10000000
                        Return (Size / MB / KB).ToString("N") & " GB"
                End Select
            End If
        Catch ex As Exception
            Return Size.ToString
        End Try
        Return True
    End Function
End Module
