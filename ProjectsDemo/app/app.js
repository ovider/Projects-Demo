(function () {
    'use strict';

    angular
        .module('app', ['ui.router', 'ui.bootstrap'])
        .config(['$stateProvider', '$urlRouterProvider', '$locationProvider', config])
        .run(['$rootScope', '$transitions', run]);

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
                params: {
                    successMessage: null
                },
                data: { tab: 'index' }
            });

        $locationProvider.html5Mode(true);
    }
    function run($rootScope, $transitions) {
        // callback for module run

        // set isNavCollapsed = true
        $rootScope.isNavCollapsed = true;

        // update active tab on transiton success
        $transitions.onSuccess({}, function (transition) {
            $rootScope.activeTab = transition.to().data.tab;
        });
    }
})();