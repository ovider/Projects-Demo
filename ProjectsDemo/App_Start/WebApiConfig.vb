Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http
Imports Newtonsoft.Json.Serialization
Imports Unity

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services

        ' set camel case as defulat naming stragegy for serializing json
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = New DefaultContractResolver() With {
            .NamingStrategy = New CamelCaseNamingStrategy()
        }

        ' Web API routes
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )
    End Sub
End Module
