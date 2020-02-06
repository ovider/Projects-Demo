<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />

    <title>Projects Management - Demo Application</title>

    <base href="/" />

    @*site style*@
    @Styles.Render("~/styles")

</head>
<body ng-app="app">
    <header>
        <nav class="navbar navbar-expand-lg navbar-dark bd-navbar">
            <h1 class="navbar-brand">
                Projects Management
            </h1>

            <button type="button" class="navbar-toggler" ng-click="isNavCollapsed = !isNavCollapsed">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse justify-content-end" uib-collapse="isNavCollapsed">
                <ul class="nav navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" ui-sref="index({page: 1})" ng-class="{active: activeTab === 'index'}">All Projects</a>
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

    <!-- core -->
    @Scripts.Render("~/scripts/core")
    <!-- app -->
    @Scripts.Render("~/scripts/app")
</body>
</html>
