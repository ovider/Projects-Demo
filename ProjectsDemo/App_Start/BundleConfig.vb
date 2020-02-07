Imports System.Web
Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)
        Dim stylesBundle As StyleBundle = CreateStylesBundle()
        Dim appScriptsBundle As ScriptBundle = CreateAppScriptsBundle()

        bundles.Add(stylesBundle)
        bundles.Add(appScriptsBundle)
    End Sub


    ''' <summary>
    ''' Creates a bundle with all the javascript files which compose the angular application
    ''' </summary>
    Private Function CreateAppScriptsBundle() As ScriptBundle
        Dim bundle = New ScriptBundle("~/scripts/app") With {
            .Orderer = New NonOrderingBundleOrderer()
        }

        ' includes the app.js file 
        ' and all the javascript files from the subfolders of /app/ folder: 
        ' * controllers
        ' * directives
        ' * services

        bundle.Include(
                    "~/app/app.js",
                    "~/app/controllers/*.js",
                    "~/app/directives/*.js",
                    "~/app/services/*.js")

        Return bundle
    End Function

    ''' <summary>
    ''' Creates a bundle with all the styles required by the application
    ''' </summary>
    Private Function CreateStylesBundle() As StyleBundle
        '' Create a bundle with all the styles to be included in the razor view
        '' we use a non ordering bundle orderer so that the order the files are included in the bundle is respected.
        Dim bundle = New StyleBundle("~/styles") With {
            .Orderer = New NonOrderingBundleOrderer()
        }

        bundle.Include(
            "~/_dist/style.css",
            "~/_dist/responsive.css")

        Return bundle
    End Function

    ''' <summary>
    ''' A simple bundle orderer which does not order the files composing the bundle, 
    ''' i.e bundling in the order the files were specified. 
    ''' </summary>
    Private Class NonOrderingBundleOrderer
        Implements IBundleOrderer

        Public Function OrderFiles(context As BundleContext,
                                   files As IEnumerable(Of BundleFile)) As IEnumerable(Of BundleFile) Implements IBundleOrderer.OrderFiles

            Return files
        End Function
    End Class
End Module

