(function () {
    'use strict';

    angular
        .module('app')
        .controller('Projects.DetailsController', Controller);

    function Controller(ProjectsService, $stateParams, $location) {
        var vm = this;

        vm.loading = false;
        vm.errorMessage = '';
        vm.id = $stateParams._id;

        vm.project = {
            name: '',
            price: null,
            scheduledDate: null
        };

        loadData();

        function loadData() {
            vm.loading = true;

            ProjectsService
                .GetById(vm.id).then(
                    function (result) {
                        vm.loading = false;
                        vm.project = result;
                    },
                    function (errorMessage) {
                        vm.loading = false;
                        vm.errorMessage = errorMessage;
                    });
        }
    }
})();