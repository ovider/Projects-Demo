(function () {
    'use strict';

    angular
        .module('app')
        .factory('ProjectsService', Service);

    function Service($http, $q) {
        var service = {};

        service.GetPage = GetPage;
        service.GetById = GetById;
        service.Create = Create;

        const endpoint = '/api/projects';

        function GetPage(page, q) {
            var url = endpoint;

            if (page)
                url = url + '/page/' + page.toString();

            if (q)
                url = url + '?q=' + q;

            return $http.get(url)
                .then(handleSuccess, handleError);
        }

        function GetById(id) {
            var url = endpoint + '/' + id;
            return $http.get(url)
                .then(handleSuccess, handleError);
        }

        function Create(entity) {
            // format date - strip time & timezone

            var data = {
                name: entity.name,
                scheduledDate: moment(entity.scheduledDate).format("YYYY-MM-DD"),
                price: entity.price
            };

            return $http
                .post(endpoint, data)
                .then(handleSuccess, handleError);
        }

        return service;

        // private functions

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(res) {
            return $q.reject(res.data && res.data.Message);
        }
    }


})();
