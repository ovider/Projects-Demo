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
                controllerAs: 'vm',
                data: { tab: 'index' }
            })
            .state('add', {
                url: '/new',
                templateUrl: 'app/views/add.view.html',
                controller: 'Projects.AddController',
                controllerAs: 'vm',
                data: { tab: 'new' }
            })
            .state('details', {
                url: '/project/:_id',
                templateUrl: 'app/views/details.view.html',
                controller: 'Projects.DetailsController',
                controllerAs: 'vm',
                data: { tab: 'index' }
            });

        $locationProvider.html5Mode(true);
    }
    function run($rootScope) {
        // callback for module run

        // update active tab on state change
        $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
            $rootScope.activeTab = toState.data.tab;
        });
    }
})();