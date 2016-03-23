(function () {
    'use strict';

    angular.module('myApp').controller('rootController', ['$scope', '$state', '$window', '$log', 'localStorageService', '$http', 'oidcManager',
    function ($scope, $state, $window, $log, localStorageService, $http, oidcManager) {
        $scope.authInfo = localStorageService.get('authorizationData');

        function handleCallback(hash) {
            oidcManager.processTokenCallbackAsync().then(function () {
                var result = hash.split('&').reduce(function (result, item) {
                    var parts = item.split('=');
                    result[parts[0]] = parts[1];
                    return result;
                }, {});

                localStorageService.set("authorizationData", {
                    token: result.access_token,
                    userName: oidcManager.profile.preferred_username
                });

                $scope.authInfo = localStorageService.get('authorizationData');
                $scope.$apply();
            });
        }

        $scope.login = function () {
            oidcManager.redirectForToken();
        };

        $scope.logout = function () {
            localStorageService.remove("authorizationData");
            oidcManager.redirectForLogout();
        };

        if ($window.location.hash) {
            handleCallback($window.location.hash.substr(1));
        }
    }]);
})();