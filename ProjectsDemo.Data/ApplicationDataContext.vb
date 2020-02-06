Imports System.Data.Entity

Class ApplicationDataContext
    Inherits DbContext

    Public Sub New()
        Me.New("DefaultConnection")
    End Sub

    Private Sub New(connectionString As String)
        MyBase.New(connectionString)

        Me.Configuration.LazyLoadingEnabled = True

        Me.Database.Log = Sub(query) Debug.WriteLine(query)
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)

        '' add all entity type configurations found in the current assembly

        Dim dataAssembly = Me.GetType().Assembly

        modelBuilder.Configurations.AddFromAssembly(dataAssembly)
    End Sub
End Class
