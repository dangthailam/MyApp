'use strict';
myApp.config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {
    //
    // For any unmatched url, redirect to /state1
    $urlRouterProvider.otherwise("/");
    //
    // Now set up the states
    $stateProvider
        .state('home', {
            url: "/",
            templateUrl: "Views/Home/Home.html",
            controller: "homeController"
        })
        .state('login', {
            url: "/login",
            templateUrl: "Views/Login/LoginPage.html",
            controller: "loginController"
        })
        .state('register', {
            url: "/register",
            templateUrl: "Views/Register/RegisterPage.html",
            controller: "registerController"
        });

    $locationProvider.html5Mode(true);
    //.state('state2', {
    //    url: "/state2",
    //    templateUrl: "partials/state2.html"
    //})
    //.state('state2.list', {
    //    url: "/list",
    //    templateUrl: "partials/state2.list.html",
    //    controller: function ($scope) {
    //        $scope.things = ["A", "Set", "Of", "Things"];
    //    }
    //});
}]);