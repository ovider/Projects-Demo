Imports Unity
Imports Unity.Lifetime

Public NotInheritable Class DataConfig

    ''' <summary>
    ''' Register the implementations in the unity container
    ''' </summary>
    Public Shared Sub Initialize(container As IUnityContainer)

        container.RegisterType(Of IProjectsRepository, ProjectsRepository)(New PerResolveLifetimeManager())

    End Sub
End Class
