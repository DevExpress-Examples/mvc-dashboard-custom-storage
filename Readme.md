<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128579375/20.1.10%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T400693)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Dashboard for MVC - How to Load and Save Dashboards from/to a Database

This example shows how to create a custom dashboard storage to load and save dashboards in a database.

## Example Overview
The example uses the [System.Data.SqlClient](https://msdn.microsoft.com/en-us/library/system.data.sqlclient(v=vs.110).aspx) members to connect and manage an MS SQL server database.

A custom dashboard storage should implement one of the following interfaces: [IDashboardStorage](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDashboardStorage) or [IEditableDashboardStorage](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IEditableDashboardStorage).

The following API used in the example:

- [LoadDashboard](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDashboardStorage.LoadDashboard(System.String)) 

    Loads a dashboard with the specified ID in XDocument format from storage.
- [GetAvailableDashboardsInfo](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDashboardStorage.GetAvailableDashboardsInfo) 

    Returns a list of IDs and Captions of dashboards available in the data storage.
- [SaveDashboard](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDashboardStorage.SaveDashboard(System.String-System.Xml.Linq.XDocument)) 

    Saves the specified dashboard with new settings to the dashboard storage.
- [AddDashboard](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IEditableDashboardStorage.AddDashboard(System.Xml.Linq.XDocument-System.String)) 

    Saves a dashboard definition and its caption to the data storage and returns the ID of the new saved dashboard.
  
Additionally, this example contains an SQL file ([SavedDashboards.sql](./CS/MVCDashboardDesigner/SavedDashboards.sql)) that can be used to recreate a database used in this example. Update the connection string in the **Web.config** file to make it valid in your environment.

## Files to Look At

* [DataBaseEditaleDashboardStorage.cs](./CS/MVCDashboardDesigner/DataBaseEditaleDashboardStorage.cs) (VB: [DataBaseEditaleDashboardStorage.vb](./VB/MVCDashboardDesigner/DataBaseEditaleDashboardStorage.vb))
* [Global.asax.cs](./CS/MVCDashboardDesigner/Global.asax.cs) (VB: [Global.asax.vb](./VB/MVCDashboardDesigner/Global.asax.vb))

## Documentation
  
* [Prepare Dashboard Storage](https://docs.devexpress.com/Dashboard/16979/web-dashboard/dashboard-backend/prepare-dashboard-storage)
* [Manage Multi-Tenancy](https://docs.devexpress.com/Dashboard/402924/web-dashboard/dashboard-backend/manage-multi-tenancy)

## More Examples
  
- [Dashboard for Web Forms - How to save dashboards created in ASPxDashboard to a DataSet](https://github.com/DevExpress-Examples/aspxdashboard-how-to-save-dashboards-created-by-end-users-to-a-dataset-t392813)
- [Dashboard for Web Forms - How to load and save dashboards from/to a database](https://github.com/DevExpress-Examples/aspxdashboard-how-to-load-and-save-dashboards-from-to-a-database-t386418)
- [Dashboard for MVC - How to implement multi-tenant Dashboard architecture](https://github.com/DevExpress-Examples/DashboardUserBasedMVC)
