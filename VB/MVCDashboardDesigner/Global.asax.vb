Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports System
Imports System.Web.Hosting
Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Routing

Namespace MVCDashboardDesigner
	' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	' visit http://go.microsoft.com/?LinkId=9394801

	Public Class MvcApplication
		Inherits System.Web.HttpApplication

		Protected Sub Application_Start()
			AreaRegistration.RegisterAllAreas()

			WebApiConfig.Register(GlobalConfiguration.Configuration)
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
			RouteConfig.RegisterRoutes(RouteTable.Routes)

			ModelBinders.Binders.DefaultBinder = New DevExpress.Web.Mvc.DevExpressEditorsBinder()

			AddHandler DevExpress.Web.ASPxWebControl.CallbackError, AddressOf Application_Error

			Dim dataBaseDashboardStorage As New DataBaseEditaleDashboardStorage(My.Settings.Default.DashboardStorageConnection)

			DashboardConfigurator.Default.SetDashboardStorage(dataBaseDashboardStorage)

			Dim sqlDataSource As New DashboardSqlDataSource("SQL Data Source")
			Dim customerReportsQuery As SelectQuery = SelectQueryFluentBuilder.AddTable("CustomerReports").SelectColumn("CompanyName").SelectColumn("ProductName").SelectColumn("OrderDate").SelectColumn("ProductAmount").Build("CustomerReportsQuery")
			sqlDataSource.Queries.Add(customerReportsQuery)

			Dim dataSourceStorage As New DataSourceInMemoryStorage()
			dataSourceStorage.RegisterDataSource("sqlDataSource1", sqlDataSource.SaveToXml())
			DashboardConfigurator.Default.SetDataSourceStorage(dataSourceStorage)
			AddHandler DashboardConfigurator.Default.ConfigureDataConnection, AddressOf DataApi_ConfigureDataConnection
		End Sub

		Private Sub DataApi_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureDataConnectionWebEventArgs)
			If e.DataSourceName = "SQL Data Source" Then
				Dim accessParams As New Access97ConnectionParameters()
				accessParams.FileName = HostingEnvironment.MapPath("~/App_Data/nwind.mdb")
				e.ConnectionParameters = accessParams
			End If
		End Sub

		Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
			Dim exception As Exception = System.Web.HttpContext.Current.Server.GetLastError()
			'TODO: Handle Exception
		End Sub
	End Class
End Namespace