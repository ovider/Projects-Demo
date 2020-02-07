Imports AutoMapper
Imports AutoMapper.QueryableExtensions
Imports ProjectsDemo.Data.Models
Imports ProjectsDemo.Model
Imports Unity

Class ProjectsRepository
    Implements IProjectsRepository

    Public Async Function CreateAsync(entity As Project) As Task Implements IProjectsRepository.CreateAsync
        Context.Set(Of Project).Add(entity)

        Await Context.SaveChangesAsync()
    End Function

    Public Function GetPage(Of TModel)(config As IConfigurationProvider,
                                       Optional page As Integer = 1,
                                       Optional pageSize As Integer = 10,
                                       Optional filter As String = Nothing) As PagedResultSet(Of TModel) Implements IProjectsRepository.GetPage

        Dim resultSet = New PagedResultSet(Of TModel) With {
                .Page = page,
                .PageSize = pageSize
            }


        Dim query As IQueryable(Of Model.Project) = Context.Set(Of Model.Project).AsQueryable()

        '' apply the filter, if any
        If Not String.IsNullOrEmpty(filter) Then _
            query = query _
                .Where(Function(p) p.Name.Contains(filter))

        '' calculate the total count
        resultSet.Total = query.Count()

        '' page the result
        query = query _
            .OrderBy(Function(p) p.Name) _
            .Skip((page - 1) * pageSize) _
            .Take(pageSize)

        resultSet.Results = query _
            .ProjectTo(Of TModel)(config) _
            .ToList()

        Return resultSet
    End Function

    Public Function GetById(Of TModel)(config As IConfigurationProvider, id As Integer) As TModel Implements IProjectsRepository.GetById
        Dim query = Context.Set(Of Model.Project).Where(Function(p) p.Id = id)

        Return query _
            .ProjectTo(Of TModel)(config) _
            .FirstOrDefault()
    End Function

    <Dependency>
    Public Context As ApplicationDataContext
End Class
