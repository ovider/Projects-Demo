(function () {
    'use strict';

    angular
        .module('app')
        .controller('Projects.AddController', Controller);

    function Controller(ProjectsService, $state, $location) {
        var vm = this;

        vm.loading = false;
        vm.errorMessage = '';

        vm.project = {
            name: '',
            price: null,
            scheduledDate: null
        };

        vm.submit = submit;
        vm.cancel = cancel;
        vm.closeAlert = closeAlert;

        function cancel() {
            vm.errorMessage = '';
            $location.url("/");
        }

        function submit() {
            vm.errorMessage = '';
            vm.loading = true;

            ProjectsService.Create(vm.project)
                .then(
                    function (result) {
                        vm.loading = false;

                        $state.go("details", { _id: result.id }, { location: true });
                    },
                    function (errorMessage) {

                        vm.errorMessage = errorMessage || 'Something went wrong!';
                        vm.loading = false;
                    });
        }

        function closeAlert() {
            vm.errorMessage = '';
        }
    }
})();