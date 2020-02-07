(function () {
    'use strict';

    angular
        .module('app')
        .controller('Projects.DetailsController', ['ProjectsService', '$stateParams', Controller]);

    function Controller(ProjectsService, $stateParams) {
        var vm = this;

        vm.loading = false;
        vm.errorMessage = '';
        vm.id = $stateParams._id;

        // if redirected from add page, check if there is a success message to show
        vm.successMessage = $stateParams.successMessage;

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