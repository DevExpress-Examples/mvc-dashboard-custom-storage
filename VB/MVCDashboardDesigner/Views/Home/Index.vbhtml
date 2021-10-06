@Code
    ViewBag.Title = "Home Page"
End Code

@Html.DevExpress().Dashboard(
                Sub(settings)
                    settings.Name = "Dashboard"
                    settings.ControllerName = "DefaultDashboard"
                    settings.Height = Unit.Percentage(100)
                End Sub).GetHtml()