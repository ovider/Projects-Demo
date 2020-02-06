<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>Projects - Demo Application</title>
    <base href="/" />

    @Styles.Render("~/styles")

</head>
<body ng-app="app">
    <header>
        <h1>
            Projects - Demo Application
        </h1>
        <nav>
            <a ui-sref="index" ui-sref-active="active">All Projects</a>
            <a ui-sref="add" ui-sref-active="active">Create Project</a>
        </nav>
    </header>


    <main ui-view>

    </main>

    <footer>
        <p>Developed by <a href="https://www.linkedin.com/in/ovidiueremia/" target="_blank">Ovidiu Eremia</a>.</p>
        <p>All source code is available on <a href="https://github.com/ovider/Projects-Demo" target="_blank">GitHub</a>.</p>
    </footer>

    <!-- angular -->
    <script src="//unpkg.com/angular@1.7.9/angular.js"></script>
    <script src="//unpkg.com/%40uirouter/angularjs@1.0.5/release/angular-ui-router.js"></script>

    <!-- app -->
    @Scripts.Render("~/scripts/app")
</body>
</html>
