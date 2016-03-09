myApp.controller('loginController', ['$scope', '$http', 'config', 'localStorageService', 'AuthenticationService',
    function ($scope, $http, config, localStorageService, AuthenticationService) {
        $scope.UserLogin = {
            Email: "",
            Password: "",
            RememberMe: false
        };

        $scope.login = function () {
            AuthenticationService.Login($scope.UserLogin, "openid profile email api").then(function (data) {
                localStorageService.set('authorizationData', { token: data.access_token, userName: $scope.UserLogin.Email, refreshToken: "", useRefreshTokens: false });
                $scope.$emit('onAuthenticated');
            });
        };
    }
]);