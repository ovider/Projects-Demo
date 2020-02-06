Imports System.Web.Http
Imports Unity
Imports Unity.WebApi

''' <summary>
''' Specifies the Unity configuration for the main container.
''' </summary>
NotInheritable Class UnityConfig

    Shared Sub RegisterComponents()
        Dim container = New UnityContainer()

        '' register all your components with the container here
        Data.DataConfig.Initialize(container)

        MappingConfig.RegisterMaps(container)

        GlobalConfiguration.Configuration.DependencyResolver = New UnityDependencyResolver(container)
    End Sub
End Class
