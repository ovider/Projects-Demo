Imports System.Web
Imports System.Web.Mvc

Public Module FilterConfig
    Public Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        '' When Custom Errors Mode is ON in web.config, 
        '' any serverside error occuring during a controller action will result in the action returning the error view.
        '' i.e. this will prevent the end user from seeing error details and debug information, but show him instead a friendly message.

        filters.Add(New HandleErrorAttribute())
    End Sub
End Module