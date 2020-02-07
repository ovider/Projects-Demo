Imports System.Web.Http
Imports Unity.AspNet.WebApi

<Assembly: WebActivatorEx.PreApplicationStartMethod(GetType(UnityWebApiActivator), NameOf(UnityWebApiActivator.Start))>
<Assembly: WebActivatorEx.ApplicationShutdownMethod(GetType(UnityWebApiActivator), NameOf(UnityWebApiActivator.ShutDown))>
Public Class UnityWebApiActivator

    ''' <summary>
    ''' Integrates Unity when the application starts.
    ''' </summary>
    Public Shared Sub Start()
        Dim container = UnityConfig.Container.Value

        '' we use a UnityHierarchicalDependencyResolver to have a new child container for each IHttpController resolution
        '' in other words to use the same instance of the DataContext in a single controller action

        GlobalConfiguration.Configuration.DependencyResolver = New UnityHierarchicalDependencyResolver(container)
    End Sub

    ''' <summary>
    ''' Disposes the Unity container when the application is shut down.
    ''' </summary>
    Public Shared Sub ShutDown()

        UnityConfig.Container.Value.Dispose()
    End Sub
End Class
