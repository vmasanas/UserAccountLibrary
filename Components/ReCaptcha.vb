
Imports DotNetNuke
Imports DotNetNuke.Entities.Modules
Imports System.Web.UI
Imports DotNetNuke.Entities.Profile
Imports System.Net
Imports System.IO

Namespace Connect.Libraries.UserManagement
    Public Class ReCaptcha

        Public Shared Sub Validate(PrivateKey As String, ByRef IsValid As Boolean, ByRef Result As String)

            Dim strPrivateKey As String = PrivateKey
            Dim strRemoteIp As String = HttpContext.Current.Request.UserHostAddress
            Dim strChallenge As String = HttpContext.Current.Request.Form("recaptcha_challenge_field")
            Dim strResponse As String = HttpContext.Current.Request.Form("recaptcha_response_field")

            Dim postData As String = String.Format("privatekey={0}&remoteip={1}&challenge={2}&response={3}", strPrivateKey, strRemoteIp, strChallenge, strResponse)
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)

            Dim request As WebRequest = WebRequest.Create("http://www.google.com/recaptcha/api/verify")
            request.Method = "POST"
            request.ContentLength = byteArray.Length
            request.ContentType = "application/x-www-form-urlencoded"
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()

            Dim response As WebResponse = request.GetResponse()
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim lstResult As New List(Of String)
            While reader.Peek >= 0
                lstResult.Add(reader.ReadLine)
            End While

            reader.Close()
            dataStream.Close()
            response.Close()

            If lstResult.Count > 0 Then
                Try
                    IsValid = Boolean.Parse(lstResult(0))
                Catch
                End Try
                Try
                    Result = lstResult(1)
                Catch
                End Try
            End If

        End Sub

    End Class
End Namespace


