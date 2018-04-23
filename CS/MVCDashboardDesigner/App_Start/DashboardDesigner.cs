using System.Web.Routing;
using DevExpress.DashboardWeb;
using DevExpress.DashboardWeb.Mvc;

public class DashboardDesignerConfig
{
    public static void RegisterService(RouteCollection routes)
    {
        routes.MapDashboardRoute();

        // Uncomment this line to save dashboards to the App_Data folder.
        //DashboardService.SetDashboardStorage(new DashboardFileStorage(@"~/App_Data/"));

        // Uncomment these lines to create an in-memory storage of dashboard data sources. Use the DataSourceInMemoryStorage.RegisterDataSource
        // method to register the existing data source in the created storage.
        //var dataSourceStorage = new DataSourceInMemoryStorage();
        //DashboardService.SetDataSourceStorage(dataSourceStorage);
    }
}