myApp.controller('registerController', ['$scope', '$http', function ($scope, $http) {
    $scope.UserRegister = {
        Email: "",
        Password: "",
        ConfirmPassword: ""
    };

    var registerUrl = "http://localhost:58392/private/api/user/register";

    $scope.register = function () {
        $http.post(registerUrl, $scope.UserRegister).then(function (result) {
            console.log(result);
        });
    };
}]);