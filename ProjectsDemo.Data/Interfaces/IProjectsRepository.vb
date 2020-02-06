Imports AutoMapper

Public Interface IProjectsRepository
    Function Find(Of TModel)(config As IConfigurationProvider, Optional filter As String = Nothing) As IList(Of TModel)

    Function GetById(Of TModel)(config As IConfigurationProvider, id As Integer) As TModel

    Function CreateAsync(entity As Model.Project) As Task

End Interface