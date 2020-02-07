Imports System.Transactions
Imports Moq
Imports NUnit.Framework
Imports ProjectsDemo.Data
Imports Unity

Namespace ProjectsDemo.DataTest

    Public Class DataIntegrationTest

        Private scope As TransactionScope

        <SetUp>
        Public Sub Setup()
            '' transaction scope is used to prevent persisting any data resulting from running the tests
            scope = New TransactionScope()
        End Sub

        ''' <summary>
        ''' Tests if connection string is correct 
        ''' and data context is setup correctly
        ''' </summary>
        <Test>
        Public Sub TestDbConnection()
            Using ctx = New ApplicationDataContext()
                Dim result = ctx.Database.SqlQuery(Of Object)("SELECT 1").Count()

                Assert.AreEqual(1, result)
            End Using
        End Sub

        ''' <summary>
        ''' Tests if Projects Repository is registered correctly in the unity container
        ''' </summary>
        <Test>
        Public Sub TestProjectsRepositoryDependencyResolution()
            Dim container = New UnityContainer()

            DataConfig.Initialize(container)

            Dim repository = container.Resolve(Of IProjectsRepository)

            Assert.IsInstanceOf(Of ProjectsRepository)(repository)

            Dim typedRepository = CType(repository, ProjectsRepository)

            Assert.IsNotNull(typedRepository.Context)
        End Sub

        ''' <summary>
        ''' Tests the create project method
        ''' </summary>
        <Test>
        Public Async Function TestCreateProject() As Task

            Using context = New ApplicationDataContext()
                Dim repository = New ProjectsRepository With {.Context = context}

                Dim entity = New Model.Project() With {
                    .Name = "A",
                    .Price = 1,
                    .ScheduledDate = New Date(2020, 2, 20)
                }

                Await repository.CreateAsync(entity)

                Assert.Positive(entity.Id)

                Dim storedEntity = context.Set(Of Model.Project).Find(entity.Id)

                Assert.AreEqual(entity.Name, storedEntity.Name)
                Assert.AreEqual(entity.Price, storedEntity.Price)
                Assert.AreEqual(entity.ScheduledDate, storedEntity.ScheduledDate)

            End Using
        End Function


        <TearDown>
        Public Sub TearDown()
            scope.Dispose()
        End Sub
    End Class

End Namespace