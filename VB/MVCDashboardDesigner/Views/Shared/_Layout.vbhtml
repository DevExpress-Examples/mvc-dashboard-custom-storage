<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8" />
    <title>DevExpress ASP.NET project</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />

    @Html.DevExpress().GetStyleSheets(
                New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
                New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
                New StyleSheet With {.ExtensionSuite = ExtensionSuite.Dashboard}
                )
    @Html.DevExpress().GetScripts(
                        New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
                        New Script With {.ExtensionSuite = ExtensionSuite.Editors},
                        New Script With {.ExtensionSuite = ExtensionSuite.Dashboard}
                )

    <style type="text/css">
        html, body, form {
            height: 100%;
            margin: 0;
            padding: 0;
            overflow: hidden;
        }
    </style>
</head>

<body>
    @RenderBody()
</body>
</html>