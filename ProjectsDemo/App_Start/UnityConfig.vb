Imports System.Web.Http
Imports Unity
Imports Unity.AspNet.WebApi
Imports Unity.WebApi

''' <summary>
''' Specifies the Unity configuration for the main container.
''' </summary>
NotInheritable Class UnityConfig

    Public Shared Container As Lazy(Of IUnityContainer) = New Lazy(Of IUnityContainer)(Function() GetConfiguredContainer())

    Private Shared Function GetConfiguredContainer()

        Dim container = New UnityContainer()

        '' register all your components with the container here
        Data.DataConfig.Initialize(container)

        MappingConfig.RegisterMaps(container)

        Return container


    End Function
End Class
