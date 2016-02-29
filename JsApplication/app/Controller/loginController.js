myApp.controller('loginController', ['$scope', '$http', 'config', 'localStorageService', 'AuthenticationService',
    function ($scope, $http, config, localStorageService, AuthenticationService) {
        $scope.UserLogin = {
            Email: "",
            Password: "",
            RememberMe: false
        };

        console.log(config);

        $scope.login = function () {
            console.log($scope.UserLogin);

            AuthenticationService.Login($scope.UserLogin, "openid profile email api").then(function (data) {
                console.log(data.access_token);
                localStorageService.set('bearerToken', data.access_token);
                $scope.$emit('onAuthenticated');
            });
        };


    }
]);