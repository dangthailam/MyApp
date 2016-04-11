'use strict';
myApp.config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {

    $urlRouterProvider.otherwise("/");

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
        })
        .state('profile', {
            url: "/profile",
            templateUrl: "Views/Profile/Profile.html",
            controller: "profileController"
        });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: true
    }).hashPrefix("!");
}]);