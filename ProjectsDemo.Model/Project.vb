''' <summary>
''' Entity class for a project
''' </summary>
Public Class Project

    ''' <summary>
    ''' The id of the project
    ''' </summary>
    Public Property Id As Integer

    ''' <summary>
    ''' The name of the project
    ''' </summary>
    Public Property Name As String

    ''' <summary>
    ''' The date the project is scheduled to start
    ''' </summary>
    Public Property ScheduledDate As DateTime

    ''' <summary>
    ''' The price of the proejct
    ''' </summary>
    Public Property Price As Decimal
End Class
