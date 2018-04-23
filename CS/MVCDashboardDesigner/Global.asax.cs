using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DashboardCommon.Native.DashboardRestfulService;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Hosting;

namespace MVCDashboardDesigner
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DashboardDesignerConfig.RegisterService(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();

            DevExpress.Web.ASPxWebControl.CallbackError += Application_Error;

            DataBaseEditaleDashboardStorage dataBaseDashboardStorage = new DataBaseEditaleDashboardStorage(MVCDashboardDesigner.Properties.Settings.Default.DashboardStorageConnection);

            DashboardService.SetDashboardStorage(dataBaseDashboardStorage);

            DashboardSqlDataSource sqlDataSource = new DashboardSqlDataSource("SQL Data Source");
            TableQuery customerReportsQuery = new TableQuery("CustomerReports");
            customerReportsQuery.AddTable("CustomerReports").SelectColumns("CompanyName", "ProductName", "OrderDate", "ProductAmount");
            sqlDataSource.Queries.Add(customerReportsQuery);

            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
            dataSourceStorage.RegisterDataSource("sqlDataSource1", sqlDataSource.SaveToXml());
            DashboardService.SetDataSourceStorage(dataSourceStorage);
            DashboardService.DataApi.ConfigureDataConnection += DataApi_ConfigureDataConnection;

        }
        void DataApi_ConfigureDataConnection(object sender, ServiceConfigureDataConnectionEventArgs e)
        {
            if (e.DataSourceName == "SQL Data Source")
            {
                Access97ConnectionParameters accessParams = new Access97ConnectionParameters();
                accessParams.FileName = HostingEnvironment.MapPath("~/App_Data/nwind.mdb");
                e.ConnectionParameters = accessParams;
            }
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = System.Web.HttpContext.Current.Server.GetLastError();
            //TODO: Handle Exception
        }
    }
}