Imports System.Configuration
Imports System.Web.Routing
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DashboardWeb.Mvc
Imports MVCDashboardDesigner

Public Class DashboardConfig
    Public Shared Sub RegisterService(ByVal routes As RouteCollection)
        routes.MapDashboardRoute("api/dashboard", "DefaultDashboard")

        Dim dataBaseDashboardStorage = New DataBaseEditaleDashboardStorage(ConfigurationManager.ConnectionStrings("DashboardStorageConnection").ConnectionString)

        DashboardConfigurator.Default.SetDashboardStorage(dataBaseDashboardStorage)

        Dim dataSourceStorage As New DataSourceInMemoryStorage()
        Dim objDataSource As New DashboardObjectDataSource("Object Data Source", GetType(SalesPersonData))
        objDataSource.DataMember = "GetSalesData"
        dataSourceStorage.RegisterDataSource("objectDataSource", objDataSource.SaveToXml())

        DashboardConfigurator.Default.SetDataSourceStorage(dataSourceStorage)
    End Sub
End Class
