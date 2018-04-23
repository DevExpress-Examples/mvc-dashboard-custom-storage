Imports Microsoft.VisualBasic
Imports System.Web.Routing
Imports DevExpress.DashboardWeb
Imports DevExpress.DashboardWeb.Mvc

Public Class DashboardDesignerConfig
	Public Shared Sub RegisterService(ByVal routes As RouteCollection)
		routes.MapDashboardRoute()

		' Uncomment this line to save dashboards to the App_Data folder.
		'DashboardService.SetDashboardStorage(new DashboardFileStorage(@"~/App_Data/"));

		' Uncomment these lines to create an in-memory storage of dashboard data sources. Use the DataSourceInMemoryStorage.RegisterDataSource
		' method to register the existing data source in the created storage.
		'var dataSourceStorage = new DataSourceInMemoryStorage();
		'DashboardService.SetDataSourceStorage(dataSourceStorage);
	End Sub
End Class