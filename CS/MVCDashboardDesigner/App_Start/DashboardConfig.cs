using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DashboardWeb.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MVCDashboardDesigner.App_Start {
    public class DashboardConfig {
        public static void RegisterService(RouteCollection routes) {
            routes.MapDashboardRoute("api/dashboard", "DefaultDashboard");

            var dataBaseDashboardStorage = new DataBaseEditaleDashboardStorage(
                ConfigurationManager.ConnectionStrings["DashboardStorageConnection"].ConnectionString);

            DashboardConfigurator.Default.SetDashboardStorage(dataBaseDashboardStorage);

            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
            DashboardObjectDataSource objDataSource = new DashboardObjectDataSource("Object Data Source", typeof(SalesPersonData));
            objDataSource.DataMember = "GetSalesData";
            dataSourceStorage.RegisterDataSource("objectDataSource", objDataSource.SaveToXml());

            DashboardConfigurator.Default.SetDataSourceStorage(dataSourceStorage);

        }
    }
}