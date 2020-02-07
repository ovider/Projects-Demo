Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of ApplicationDataContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
        End Sub

        Protected Overrides Sub Seed(context As ApplicationDataContext)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method
            '  to avoid creating duplicate seed data.

            SetupDefaultProjects(context)
        End Sub

        Private Sub SetupDefaultProjects(context As ApplicationDataContext)
            Dim greekLetters As String() = {"Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lambda", "Mu", "Nu", "Xi", "Omicron", "Pi", "Rho", "Sigma", "Tau", "Upsilon", "Phi", "Chi", "Psi", "Omega"}
            Dim random = New Random()


            For i As Integer = 0 To greekLetters.Length - 1
                Dim project = New Model.Project() With {
                        .Id = i + 1,
                        .Name = String.Format("Project {0}", greekLetters(i)),
                        .Price = random.Next(1, 10000000) / 100.0,
                        .ScheduledDate = DateTime.Now.Date.AddDays(random.Next(0, 356))
                    }

                context.Set(Of Model.Project).AddOrUpdate(project)
            Next

        End Sub
    End Class

End Namespace
