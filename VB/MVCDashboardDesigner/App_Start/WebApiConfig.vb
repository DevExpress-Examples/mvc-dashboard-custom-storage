Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Namespace MVCDashboardDesigner
	Public NotInheritable Class WebApiConfig

		Private Sub New()
		End Sub

		Public Shared Sub Register(ByVal config As HttpConfiguration)
			config.Routes.MapHttpRoute(name:= "DefaultApi", routeTemplate:= "api/{controller}/{id}", defaults:= New With {Key .id = RouteParameter.Optional})
		End Sub
	End Class
End Namespace