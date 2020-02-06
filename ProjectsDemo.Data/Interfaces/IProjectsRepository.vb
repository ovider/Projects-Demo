Imports AutoMapper

Public Interface IProjectsRepository
    Function GetPage(Of TModel)(config As IConfigurationProvider,
                                Optional page As Integer = 1,
                                Optional pageSize As Integer = 10,
                                Optional filter As String = Nothing) As Models.PagedResultSet(Of TModel)

    Function GetById(Of TModel)(config As IConfigurationProvider, id As Integer) As TModel

    Function CreateAsync(entity As Model.Project) As Task

End Interface