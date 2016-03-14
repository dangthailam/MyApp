myApp.controller('rootController', ['$scope', 'AuthenticationService', function ($scope, AuthenticationService) {
    $scope.authentication = AuthenticationService.Authentication;

    $scope.logout = function () {
        AuthenticationService.Logout();
    };
}]);