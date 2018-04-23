Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports DevExpress.DashboardWeb.Mvc

Namespace MVCDashboardDesigner
	Public Class RouteConfig
		Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
			routes.IgnoreRoute("{resource}.ashx/{*pathInfo}")
			routes.MapDashboardRoute()

			routes.MapRoute(name:= "Default", url:= "{controller}/{action}/{id}", defaults:= New With {Key .controller = "Home", Key .action = "Index", Key .id = UrlParameter.Optional})
		End Sub
	End Class
End Namespace