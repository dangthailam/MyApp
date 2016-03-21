myApp.controller('rootController', ['$scope', '$state', '$window', '$log', 'localStorageService', 'AuthenticationService', function ($scope, $state, $window, $log, localStorageService, AuthenticationService) {
    var identityServerUrl = 'https://localhost:44300/';

    $scope.authentication = AuthenticationService.Authentication;

    $scope.logout = function () {
        AuthenticationService.Logout();
    };

    $scope.message = "AuthorizedController created";

    // TO force check always
    localStorageService.set("authorizationData", "");
    //localStorageService.get("authorizationData");
    //localStorageService.set("authStateControl", "");
    //localStorageService.get("authStateControl");
    debugger;
    if (localStorageService.get("authorizationData") !== "") {
        $scope.message = "AuthorizedController created logged on";
        // console.log(authorizationData);
        $state.go("home");
    } else {
        if ($window.location.hash) {
            $scope.message = "AuthorizedController created with a code";

            var hash = window.location.hash.substr(1);

            var result = hash.split('&').reduce(function (result, item) {
                var parts = item.split('=');
                result[parts[0]] = parts[1];
                return result;
            }, {});

            var token = "";
            if (!result.error) {
                if (result.state !== localStorageService.get("authStateControl")) {
                    console.log("AuthorizedController created. no myautostate");
                } else {
                    localStorageService.set("authStateControl", "");
                    console.log("AuthorizedController created. returning access token");
                    token = result.access_token;
                }
            }

            localStorageService.set("authorizationData", token);

            $state.go("home");

        }
    }


    $scope.login = function () {
        var authorizationUrl = identityServerUrl + 'core/connect/authorize';
        var client_id = 'js';
        var redirect_uri = 'http://localhost:55505/index.html';
        var response_type = "token";
        var scope = "api";
        var state = Date.now() + "" + Math.random();

        //localStorageService.set("authStateControl", state);
        //console.log("AuthorizedController created. adding myautostate: " + localStorageService.get("authStateControl"));

        var url =
            authorizationUrl + "?" +
            "client_id=" + encodeURI(client_id) + "&" +
            "redirect_uri=" + encodeURI(redirect_uri) + "&" +
            "response_type=" + encodeURI(response_type) + "&" +
            "scope=" + encodeURI(scope) + "&" +
            "state=" + encodeURI(state);

        $window.location = url;
    };
}]);