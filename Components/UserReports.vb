Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports DotNetNuke.Common.Utilities

Namespace Connect.Libraries.UserManagement

    Public Class UserReportInfo

        Private _reportid As Integer
        Private _friendlyname As String
        Private _sql As String
        Private _needsparameters As Boolean
        Private _portalid As Integer

        Public Property ReportId() As Integer
            Get
                Return _reportid
            End Get
            Set(ByVal value As Integer)
                _reportid = value
            End Set
        End Property

        Public Property FriendlyName() As String
            Get
                Return _friendlyname
            End Get
            Set(ByVal value As String)
                _friendlyname = value
            End Set
        End Property

        Public Property Sql() As String
            Get
                Return _sql
            End Get
            Set(ByVal value As String)
                _sql = value
            End Set
        End Property

        Public Property NeedsParameters() As Boolean
            Get
                Return _needsparameters
            End Get
            Set(ByVal value As Boolean)
                _needsparameters = value
            End Set
        End Property

        Public Property PortalId() As Integer
            Get
                Return _portalid
            End Get
            Set(ByVal value As Integer)
                _portalid = value
            End Set
        End Property

    End Class

    Public Class UserReportsController

        Public Shared Function GetReport(ByVal ReportId As Integer) As UserReportInfo
            Return CBO.FillObject(Of UserReportInfo)(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("Connect_Users_GetReport", ReportId))
        End Function

        Public Shared Function GetReports(ByVal PortalId As Integer) As List(Of UserReportInfo)
            Return CBO.FillCollection(Of UserReportInfo)(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("Connect_Users_GetReports", PortalId))
        End Function

        Public Shared Sub AddReport(ByVal objReport As UserReportInfo)

            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("Connect_Users_AddReport", objReport.PortalId, objReport.FriendlyName, objReport.Sql, objReport.NeedsParameters)

        End Sub

        Public Shared Sub UpdateReport(ByVal objReport As UserReportInfo)
            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("Connect_Users_UpdateReport", objReport.ReportId, objReport.PortalId, objReport.FriendlyName, objReport.Sql, objReport.NeedsParameters)
        End Sub

        Public Shared Sub DeleteReport(ByVal ReportId As Integer)
            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("Connect_Users_DeleteReport", ReportId)
        End Sub

    End Class

End Namespace

