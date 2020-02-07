Imports Unity
Imports Unity.Lifetime

Public NotInheritable Class DataConfig

    ''' <summary>
    ''' Register the implementations in the unity container
    ''' </summary>
    Public Shared Sub Initialize(container As IUnityContainer)

        ''Application Data Context is registered with the HierarchicalLifetimeManager 
        '' so that the same instance of the object is returned within the same request, but create a new instance for a new request
        container.RegisterType(Of ApplicationDataContext)(New HierarchicalLifetimeManager())

        container.RegisterType(Of IProjectsRepository, ProjectsRepository)(New PerResolveLifetimeManager())

    End Sub
End Class
