Imports Microsoft.VisualBasic
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DashboardCommon.Native.DashboardRestfulService
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Linq
Imports System.Web
Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Web.Hosting

Namespace MVCDashboardDesigner
	' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	' visit http://go.microsoft.com/?LinkId=9394801

	Public Class MvcApplication
		Inherits System.Web.HttpApplication
		Protected Sub Application_Start()
			DashboardDesignerConfig.RegisterService(RouteTable.Routes)
			AreaRegistration.RegisterAllAreas()

			WebApiConfig.Register(GlobalConfiguration.Configuration)
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
			RouteConfig.RegisterRoutes(RouteTable.Routes)

			ModelBinders.Binders.DefaultBinder = New DevExpress.Web.Mvc.DevExpressEditorsBinder()

			AddHandler DevExpress.Web.ASPxWebControl.CallbackError, AddressOf Application_Error

			Dim dataBaseDashboardStorage As New DataBaseEditaleDashboardStorage(My.Settings.Default.DashboardStorageConnection)

			DashboardService.SetDashboardStorage(dataBaseDashboardStorage)

			Dim sqlDataSource As New DashboardSqlDataSource("SQL Data Source")
			Dim customerReportsQuery As New TableQuery("CustomerReports")
			customerReportsQuery.AddTable("CustomerReports").SelectColumns("CompanyName", "ProductName", "OrderDate", "ProductAmount")
			sqlDataSource.Queries.Add(customerReportsQuery)

			Dim dataSourceStorage As New DataSourceInMemoryStorage()
			dataSourceStorage.RegisterDataSource("sqlDataSource1", sqlDataSource.SaveToXml())
			DashboardService.SetDataSourceStorage(dataSourceStorage)
			AddHandler DashboardService.DataApi.ConfigureDataConnection, AddressOf DataApi_ConfigureDataConnection

		End Sub
		Private Sub DataApi_ConfigureDataConnection(ByVal sender As Object, ByVal e As ServiceConfigureDataConnectionEventArgs)
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