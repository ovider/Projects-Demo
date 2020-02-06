(function () {
    'use strict';

    angular
        .module('app')
        .controller('Projects.AddController', Controller);

    function Controller() {
        var vm = this;

        vm.loading = true;
        
        initController();

        function initController() {

        }
    }
})();