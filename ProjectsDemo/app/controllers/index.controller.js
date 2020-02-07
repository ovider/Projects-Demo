(function () {
    'use strict';

    angular
        .module('app')
        .controller('Projects.IndexController', Controller);

    function Controller(ProjectsService, $location, $timeout) {
        var vm = this;

        vm.loading = true;
        vm.searchQuery = '';
        vm.page = 1;
        vm.pageSize = 10;
        vm.total = 0;
        vm.first = 1;
        vm.last = 1;
        vm.errorMessage = '';
        vm.projects = [];

        vm.closeAlert = closeAlert;
        vm.loadData = loadData;
        vm.search = search;

        initController();

        function initController() {
            loadData();
        }

        var lastQueriedPage;
        var lastQueriedSearchQuery;

        function loadData() {
            if (vm.page === lastQueriedPage && vm.searchQuery === lastQueriedSearchQuery) {
                // we already have queried data for the current page and search query 
                // we can return

                return;
            }

            lastQueriedPage = vm.page;
            lastQueriedSearchQuery = vm.searchQuery;

            vm.loading = true;

            ProjectsService
                .GetPage(vm.page, vm.searchQuery)
                .then(
                    function (result) {
                        vm.total = result.total;
                        vm.page = result.page;
                        vm.pageSize = result.pageSize;
                        vm.projects = result.results;

                        vm.first = (vm.page - 1) * vm.pageSize + 1;
                        vm.last = vm.first + vm.pageSize - 1 > vm.total ? vm.total : vm.first + vm.pageSize - 1;

                        if (vm.projects.length === 0 && vm.page > 1) {
                            // the user has requested a page greather then last page
                            // then redirect to last page.

                            vm.page = Math.ceil(vm.total * 1.0 / vm.pageSize);
                            loadData();
                        }


                        vm.loading = false;
                    },
                    function (errorMessage) {
                        vm.errorMessage = errorMessage || 'Something went wrong!';
                        vm.total = 0;
                        vm.projects = [];

                        vm.loading = false;
                    });

        }

        function search() {
            // wait some time to reduce the number of search queries
            // i.e. do not query after each letter change, but leave a bit more time to the user to type his query
            $timeout(function () {
                vm.page = 1;
                loadData();
            }, 400);
        }

        function closeAlert() {
            vm.errorMessage = '';
            $location.href("/");
        }
    }
})();