<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />

    <title>Projects Management - Demo Application</title>

    <base href="/" />

    <!-- bootstrap -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" 
          1integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">

    <!-- site style -->
    @Styles.Render("~/styles")

</head>
<body ng-app="app">
    <header>
        <nav class="navbar navbar-expand-lg navbar-dark bd-navbar">
            <a class="navbar-brand" href="/">
                Projects Management
            </a>

            <button type="button" class="navbar-toggler" ng-click="isNavCollapsed = !isNavCollapsed">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse justify-content-end" uib-collapse="isNavCollapsed">
                <ul class="nav navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" ui-sref="index" ng-class="{active: activeTab === 'index'}">All Projects</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" ui-sref="add" ng-class="{active: activeTab === 'new'}">Create Project</a>
                    </li>
                </ul>
            </div>
        </nav>
    </header>

    <main ui-view class="container">

    </main>

    <footer>
        <div class="container">
            <p>
                Demo application developed by <a href="https://www.linkedin.com/in/ovidiueremia/" target="_blank">Ovidiu Eremia</a>.
            </p>
            <p>
                All source code is available on <a href="https://github.com/ovider/Projects-Demo" target="_blank">GitHub</a>.
            </p>
        </div>
    </footer>

    <!-- angular -->
    <script src="//unpkg.com/angular@1.7.9/angular.min.js"></script>
    <script src="//unpkg.com/%40uirouter/angularjs@1.0.5/release/angular-ui-router.min.js"></script>
    <script src="//unpkg.com/angular-animate@1.7.9/angular-animate.min.js"></script>
    <script src="//unpkg.com/angular-touch@1.7.9/angular-touch.min.js"></script>
    
    <!-- vendor -->
    @Scripts.Render("~/scripts/vendor")

    <!-- app -->
    @Scripts.Render("~/scripts/app")
</body>
</html>
