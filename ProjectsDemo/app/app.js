(function () {
    'use strict';

    angular
        .module('app', ['ui.router', 'ui.bootstrap'])
        .config(config)
        .run(run);

    function config($stateProvider, $urlRouterProvider, $locationProvider) {
        //default route
        $urlRouterProvider.otherwise("/");

        // define the routes
        $stateProvider
            .state('index', {
                url: '/',
                templateUrl: 'app/views/index.view.html',
                controller: 'Projects.IndexController',
                controllerAs: 'vm'
            })
            .state('add', {
                url: '/new',
                templateUrl: 'app/views/add.view.html',
                controller: 'Projects.AddController',
                controllerAs: 'vm'
            })
            .state('details', {
                url: '/:_id',
                templateUrl: 'app/views/details.view.html',
                controller: 'Projects.DetailsController',
                controllerAs: 'vm'
            });

        $locationProvider.html5Mode(true);
    }
    function run() {
        // callback for module run
    }
})();