Imports System.Web
Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New StyleBundle("~/styles").Include(
                    "~/_dist/style.css"))

        bundles.Add(New ScriptBundle("~/scripts/AngularJS").Include(
                    "~/Scripts/angular.min.js",
                    "~/Scripts/angular-route.min.js"))
    End Sub
End Module