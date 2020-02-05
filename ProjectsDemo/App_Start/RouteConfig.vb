Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute(
            name:="Home",
            url:="",
            defaults:=New With {.controller = "Home", .action = "Index"}
        )
    End Sub
End Module