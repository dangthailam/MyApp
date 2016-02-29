myApp.controller('rootController', ['$scope', function ($scope) {
    $scope.authenticated = false;

    $scope.$on('onAuthenticated', function (event) {
        $scope.authenticated = true;
    });
}]);