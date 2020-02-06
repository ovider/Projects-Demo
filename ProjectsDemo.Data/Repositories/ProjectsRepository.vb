Imports AutoMapper
Imports AutoMapper.QueryableExtensions
Imports ProjectsDemo.Model

Class ProjectsRepository
    Implements IProjectsRepository

    Public Async Function CreateAsync(entity As Project) As Task Implements IProjectsRepository.CreateAsync
        Using context As New ApplicationDataContext()

            context.Set(Of Project).Add(entity)

            Await context.SaveChangesAsync()

        End Using
    End Function

    Public Function Find(Of TModel)(config As IConfigurationProvider, Optional filter As String = Nothing) As IList(Of TModel) Implements IProjectsRepository.Find
        Using context As New ApplicationDataContext()
            Dim query = context.Set(Of Model.Project)

            If Not String.IsNullOrEmpty(filter) Then _
                query = query.Where(Function(p) p.Name.StartsWith(filter))

            Return query _
                .OrderBy(Function(p) p.ScheduledDate) _
                .ProjectTo(Of TModel)(config) _
                .ToList()

        End Using
    End Function

    Public Function GetById(Of TModel)(config As IConfigurationProvider, id As Integer) As TModel Implements IProjectsRepository.GetById
        Using context As New ApplicationDataContext()
            Dim query = context.Set(Of Model.Project).Where(Function(p) p.Id = id)

            Return query _
                .ProjectTo(Of TModel)(config) _
                .FirstOrDefault()

        End Using
    End Function
End Class
