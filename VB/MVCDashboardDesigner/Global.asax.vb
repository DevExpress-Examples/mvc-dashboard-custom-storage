Imports System
Imports System.Configuration
Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Routing
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb

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

			Dim dataBaseDashboardStorage = New DataBaseEditaleDashboardStorage(ConfigurationManager.ConnectionStrings("DashboardStorageConnection").ConnectionString)

			DashboardConfigurator.Default.SetDashboardStorage(dataBaseDashboardStorage)

			Dim dataSourceStorage As New DataSourceInMemoryStorage()
			Dim objDataSource As New DashboardObjectDataSource("Object Data Source", GetType(SalesPersonData))

			objDataSource.DataMember = "GetSalesData"

			dataSourceStorage.RegisterDataSource("objectDataSource", objDataSource.SaveToXml())

			DashboardConfigurator.Default.SetDataSourceStorage(dataSourceStorage)
		End Sub

		Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
			Dim exception As Exception = System.Web.HttpContext.Current.Server.GetLastError()
			'TODO: Handle Exception
		End Sub
	End Class
End Namespace