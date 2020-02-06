Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        '' define the default route. 
        '' We have a Single page application, so there Is one page - Home.
        '' use use html5 mode in angular (which is url without #!), 
        '' so we any url will be routed to the home page and let angular to the routing

        routes.MapRoute(
            name:="Home",
            url:="{*anything}",
            defaults:=New With {.controller = "Home", .action = "Index"}
        )
    End Sub
End Module