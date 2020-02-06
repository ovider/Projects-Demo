Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class CreatedProjectEntity
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Projects",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String(nullable := False),
                        .ScheduledDate = c.DateTime(nullable := False),
                        .Price = c.Decimal(nullable := False, precision := 16, scale := 2)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Projects")
        End Sub
    End Class
End Namespace
