(function () {
    'use strict';

    angular.module('myApp').controller('profileController', ['$scope', 'localStorageService', 'oidcManager', '$http', function ($scope, localStorageService, oidcManager, $http) {
        console.log(localStorageService.get('authorizationData'));

        $http
    }]);
})();