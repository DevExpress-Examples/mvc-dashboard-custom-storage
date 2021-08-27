<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128579375/16.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T400693)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DashboardDesigner.cs](./CS/MVCDashboardDesigner/App_Start/DashboardDesigner.cs) (VB: [DashboardDesigner.vb](./VB/MVCDashboardDesigner/App_Start/DashboardDesigner.vb))
* [FilterConfig.cs](./CS/MVCDashboardDesigner/App_Start/FilterConfig.cs) (VB: [FilterConfig.vb](./VB/MVCDashboardDesigner/App_Start/FilterConfig.vb))
* [RouteConfig.cs](./CS/MVCDashboardDesigner/App_Start/RouteConfig.cs) (VB: [RouteConfig.vb](./VB/MVCDashboardDesigner/App_Start/RouteConfig.vb))
* [WebApiConfig.cs](./CS/MVCDashboardDesigner/App_Start/WebApiConfig.cs) (VB: [WebApiConfig.vb](./VB/MVCDashboardDesigner/App_Start/WebApiConfig.vb))
* [HomeController.cs](./CS/MVCDashboardDesigner/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/MVCDashboardDesigner/Controllers/HomeController.vb))
* [DataBaseEditaleDashboardStorage.cs](./CS/MVCDashboardDesigner/DataBaseEditaleDashboardStorage.cs) (VB: [DataBaseEditaleDashboardStorage.vb](./VB/MVCDashboardDesigner/DataBaseEditaleDashboardStorage.vb))
* [Global.asax](./CS/MVCDashboardDesigner/Global.asax) (VB: [Global.asax](./VB/MVCDashboardDesigner/Global.asax))
* [Global.asax.cs](./CS/MVCDashboardDesigner/Global.asax.cs) (VB: [Global.asax.vb](./VB/MVCDashboardDesigner/Global.asax.vb))
* [AjaxLogin.js](./CS/MVCDashboardDesigner/Scripts/AjaxLogin.js) (VB: [AjaxLogin.js](./VB/MVCDashboardDesigner/Scripts/AjaxLogin.js))
* [cldr.event.js](./CS/MVCDashboardDesigner/Scripts/cldr.event.js) (VB: [cldr.event.js](./VB/MVCDashboardDesigner/Scripts/cldr.event.js))
* [cldr.js](./CS/MVCDashboardDesigner/Scripts/cldr.js) (VB: [cldr.js](./VB/MVCDashboardDesigner/Scripts/cldr.js))
* [cldr.supplemental.js](./CS/MVCDashboardDesigner/Scripts/cldr.supplemental.js) (VB: [cldr.supplemental.js](./VB/MVCDashboardDesigner/Scripts/cldr.supplemental.js))
* [cldr.unresolved.js](./CS/MVCDashboardDesigner/Scripts/cldr.unresolved.js) (VB: [cldr.unresolved.js](./VB/MVCDashboardDesigner/Scripts/cldr.unresolved.js))
* [globalize.currency.js](./CS/MVCDashboardDesigner/Scripts/globalize.currency.js) (VB: [globalize.currency.js](./VB/MVCDashboardDesigner/Scripts/globalize.currency.js))
* [globalize.date.js](./CS/MVCDashboardDesigner/Scripts/globalize.date.js) (VB: [globalize.date.js](./VB/MVCDashboardDesigner/Scripts/globalize.date.js))
* [globalize.message.js](./CS/MVCDashboardDesigner/Scripts/globalize.message.js) (VB: [globalize.message.js](./VB/MVCDashboardDesigner/Scripts/globalize.message.js))
* [globalize.number.js](./CS/MVCDashboardDesigner/Scripts/globalize.number.js) (VB: [globalize.number.js](./VB/MVCDashboardDesigner/Scripts/globalize.number.js))
<!-- default file list end -->
# MVC Dashboard - How to save dashboards to a database


This example shows how to create a custom dashboard storage that allows storing dashboards in a data base. It uses the <a href="https://msdn.microsoft.com/en-us/library/system.data.sqlclient(v=vs.110).aspx">System.Data.SqlClient</a> members to connect and operate an MS SQL server data base. <br><br>A custom dashboard storage should implement one of the following interfaces:<strong> IDashboardStorage</strong> or <strong>IEditableDashboardStorage</strong>.<br><br>IDashboardStorage provides functionality to open and edit dashboards available in the storage. <br><strong>XDocument LoadDashboard(string dashboardID) </strong>- returns a dashboard by its ID in the XDocument format, which describes an object model of the dashboard.<br><strong>IEnumerable<DashboardInfo> GetAvailableDashboardsInfo()</strong> - returns a list of IDs and Captions of dashboards available in the data storage.<br><strong>void SaveDashboard(string dashboardID, XDocument dashboard)</strong> - updates the dashboard with new settings by its id.<br><br>IEditableDashboardStorage inherits the IDashboardStorage interface and contains one additional method that allows adding new dashboards to the storage.<br><strong>string AddDashboard(XDocument dashboard, string dashboardName)</strong> - takes a dashboard definition with its caption, saves it to the data storage, and returns the ID of a new saved dashboard.<br><br>Additionally, this example contains an SQL query and data base backup file,  which can be used to recreate a data base used in this example on your side.<br><br>See also: <a href="https://www.devexpress.com/Support/Center/p/T386418"> ASPxDashboard- How to save dashboards to a data base</a>

<br/>


