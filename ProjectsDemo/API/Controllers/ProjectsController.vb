Imports System.Threading.Tasks
Imports System.Web.Http
Imports Unity

<RoutePrefix("api/projects")>
Public Class ProjectsController
    Inherits ApiController

    ' GET api/projects
    <HttpGet>
    <Route("")>
    Public Function GetProjects(Optional q As String = Nothing) As IHttpActionResult

        Dim result = Repository.Find(Of ProjectModel)(MapperConfiguration, q)

        Return Ok(result)

    End Function

    ' GET api/projects/:id
    <HttpGet>
    <Route("{id:int}", Name:="project-details")>
    Public Function GetProject(id As Integer) As IHttpActionResult
        If id <= 0 Then _
            Return BadRequest("id must be a positive number!")

        Dim result = Repository.GetById(Of ProjectModel)(MapperConfiguration, id)

        If result Is Nothing Then _
            Return NotFound()

        Return Ok(result)

    End Function

    ' POST api/projects
    <HttpPost>
    <Route("")>
    Public Async Function Create(model As ProjectModel) As Task(Of IHttpActionResult)
        If Not ModelState.IsValid Then _
            Return BadRequest(ModelState)

        Dim entity = Mapper.Map(Of Model.Project)(model)

        Await Repository.CreateAsync(entity)

        model.Id = entity.Id

        Return Created(Url.Route("project-details", New With {.id = model.Id}), model)
    End Function

    <Dependency>
    Public Property Repository As Data.IProjectsRepository

    <Dependency>
    Public Property MapperConfiguration As AutoMapper.IConfigurationProvider

    <Dependency>
    Public Property Mapper As AutoMapper.IMapper

End Class
