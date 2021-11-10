<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128579375/20.1.10%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T400693)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Dashboard for MVC - How to Load and Save Dashboards from/to a Database

This example shows how to create a custom dashboard storage that allows storing dashboards in a database. 

<!-- default file list -->
## Files to Look At

* [DataBaseEditaleDashboardStorage.cs](./CS/MVCDashboardDesigner/DataBaseEditaleDashboardStorage.cs) (VB: [DataBaseEditaleDashboardStorage.vb](./VB/MVCDashboardDesigner/DataBaseEditaleDashboardStorage.vb))
* [Global.asax.cs](./CS/MVCDashboardDesigner/Global.asax.cs) (VB: [Global.asax.vb](./VB/MVCDashboardDesigner/Global.asax.vb))
<!-- default file list end -->

## Example Overview
The example uses the [System.Data.SqlClient](https://msdn.microsoft.com/en-us/library/system.data.sqlclient(v=vs.110).aspx) members to connect and operate an MS SQL server database.

A custom dashboard storage should implement one of the following interfaces: [IDashboardStorage](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDashboardStorage) or [IEditableDashboardStorage](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IEditableDashboardStorage).

The following API used in the example:

- [IEditableDashboardStorage](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IEditableDashboardStorage) provides functionality to open and edit dashboards available in the storage. 
- [LoadDashboard](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDashboardStorage.LoadDashboard(System.String)) - returns a dashboard by its ID in the XDocument format, which describes an object model of the dashboard.
- [GetAvailableDashboardsInfo](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDashboardStorage.GetAvailableDashboardsInfo) - returns a list of IDs and Captions of dashboards available in the data storage.
- [SaveDashboard](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDashboardStorage.SaveDashboard(System.String-System.Xml.Linq.XDocument)) - updates the dashboard with new settings by its id.
- [AddDashboard](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IEditableDashboardStorage.AddDashboard(System.Xml.Linq.XDocument-System.String))  - takes a dashboard definition with its caption, saves it to the data storage, and returns the ID of a new saved dashboard.
  
Additionally, this example contains an SQL file ([SavedDashboards.sql](./CS/MVCDashboardDesigner/SavedDashboards.sql)), which can be used to recreate a database used in this example on your side. Do no forget to update the connection string in the **Web.config** file to make it valid in your environment.

## Documentation
  
* [Prepare Dashboard Storage](https://docs.devexpress.com/Dashboard/16979/web-dashboard/dashboard-backend/prepare-dashboard-storage)
* [Manage Multi-Tenancy](https://docs.devexpress.com/Dashboard/402924/web-dashboard/dashboard-backend/manage-multi-tenancy)

## More Examples
  
- [Dashboard for Web Forms - How to save dashboards created in ASPxDashboard to a DataSet](https://github.com/DevExpress-Examples/aspxdashboard-how-to-save-dashboards-created-by-end-users-to-a-dataset-t392813)
- [Dashboard for Web Forms - How to load and save dashboards from/to a database](https://github.com/DevExpress-Examples/aspxdashboard-how-to-load-and-save-dashboards-from-to-a-database-t386418)
- [Dashboard for MVC - How to implement multi-tenant Dashboard architecture](https://github.com/DevExpress-Examples/DashboardUserBasedMVC)
