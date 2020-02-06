Namespace Models
    Public Class PagedResultSet(Of TModel)
        Public Property Total As Integer
        Public Property Page As Integer
        Public Property PageSize As Integer

        Public Property Results As List(Of TModel)
    End Class
End Namespace
