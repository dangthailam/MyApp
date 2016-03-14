myApp.controller('loginController', ['$scope', '$http', 'localStorageService', 'AuthenticationService', '$state',
    function ($scope, $http, localStorageService, AuthenticationService, $state) {
        $scope.UserLogin = {
            Email: "hello",
            Password: "123456",
            RememberMe: false
        };

        $scope.login = function () {
            AuthenticationService.Login($scope.UserLogin, "openid profile email api").then(function(){
                $state.go('home');
            });
        };
    }
]);