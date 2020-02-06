Imports System.ComponentModel.DataAnnotations

''' <summary>
''' The model class used by the Projects Controller
''' </summary>
Public Class ProjectModel

    Public Property Id As Integer

    <Required>
    Public Property Name As String

    Public Property ScheduledDate As DateTime

    <Range(0, Double.MaxValue)>
    Public Property Price As Decimal
End Class

Class ProjectsMapperProfile
    Inherits AutoMapper.Profile

    Sub New()
        CreateMap(Of Model.Project, ProjectModel) _
            .ReverseMap()


    End Sub

End Class