(function () {
    'use strict';

    angular
        .module('app')
        .controller('Projects.IndexController', Controller);

    function Controller(ProjectsService, $stateParams, $state) {
        var vm = this;

        vm.loading = true;
        vm.searchQuery = $stateParams.q;
        vm.page = parseInt($stateParams.page);
        vm.pageSize = 10;
        vm.total = 0;
        vm.first = 1;
        vm.last = 1;
        vm.errorMessage = '';
        vm.projects = [];

        vm.goToPage = goToPage;
        vm.closeAlert = closeAlert;

        initController();

        function initController() {
            loadData();
        }

        function loadData() {
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
                            goToPage();
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

        function goToPage() {
            $state.go('index',
                {
                    page: vm.page,
                    q: vm.searchQuery
                },
                { location: true });
        }

        function closeAlert() {
            vm.errorMessage = '';
            vm.page = 1;
            vm.searchQuery = '';

            goToPage();
        }
    }
})();