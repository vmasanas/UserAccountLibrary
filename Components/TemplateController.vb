
Imports DotNetNuke
Imports DotNetNuke.Entities.Modules
Imports System.Web.UI
Imports DotNetNuke.Entities.Profile

Namespace Connect.Libraries.UserManagement
    Public Class TemplateController

        Public Shared Function GetTemplate(ByVal strPath As String) As String


            If System.IO.File.Exists(strPath) Then
                Dim templ As String = ""
                Dim sr As New System.IO.StreamReader(strPath)
                templ = sr.ReadToEnd
                sr.Close()
                sr.Dispose()
                Return templ
            Else
                Return "Could not load template, sorry..."
            End If

        End Function

    End Class
End Namespace


