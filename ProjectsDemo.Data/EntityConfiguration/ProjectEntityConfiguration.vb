Imports System.Data.Entity.ModelConfiguration

''' <summary>
''' Configures how the Project Entity is mapped to a table in the database
''' </summary>
Class ProjectEntityConfiguration
    Inherits EntityTypeConfiguration(Of Model.Project)

    Public Sub New()
        HasKey(Function(t) t.Id)

        [Property](Function(t) t.Name).IsRequired()

        [Property](Function(t) t.Price).HasPrecision(16, 2)

    End Sub
End Class
