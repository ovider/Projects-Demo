Imports Unity

''' <summary>
''' Dependency Resolver unsing unity container
''' </summary>
Class UnityResolver
    Implements IDependencyResolver

    Private ReadOnly container As IUnityContainer

    Public Sub New(container As IUnityContainer)
        Me.container = container
    End Sub

    Public Function GetService(serviceType As Type) As Object Implements IDependencyResolver.GetService
        Try
            Return container.Resolve(serviceType)
        Catch ex As ResolutionFailedException
            Return Nothing
        End Try
    End Function

    Public Function GetServices(serviceType As Type) As IEnumerable(Of Object) Implements IDependencyResolver.GetServices
        Try
            Return container.ResolveAll(serviceType)
        Catch ex As ResolutionFailedException
            Return New List(Of Object)
        End Try
    End Function


End Class
