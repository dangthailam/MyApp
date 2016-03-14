'use strict';

var settings = {
    authority: "https://localhost:44300/core/",
    client_id: "js",
    client_secret: "secret",
    redirect_uri: window.location.protocol + "//" + window.location.host + "/index.html",
    post_logout_redirect_uri: window.location.protocol + "//" + window.location.host + "/index.html",

    // these two will be done dynamically from the buttons clicked, but are
    // needed if you want to use the silent_renew
    response_type: "id_token token",
    scope: "openid profile email api",

    // silent renew will get a new access_token via an iframe 
    // just prior to the old access_token expiring (60 seconds prior)
    silent_redirect_uri: window.location.protocol + "//" + window.location.host + "/silent_renew.html",

    // this will allow all the OIDC protocol claims to vbe visible in the window. normally a client app 
    // wouldn't care about them or want them taking up space
    filter_protocol_claims: false,

    // use session storage
    store: window.sessionStorage
};

var manager = new OidcTokenManager(settings);

manager.oidcClient.loadMetadataAsync();

myApp.value('config', manager);

myApp.factory('httpInterceptor', ['$q', '$rootScope', '$log', '$timeout', 'localStorageService',
            function ($q, $rootScope, $log, $timeout, localStorageService) {
                return {
                    request: function (config) {
                        config.headers = config.headers || {};

                        var authData = localStorageService.get('authorizationData');

                        if (authData) {
                            config.headers.Authorization = 'Bearer ' + authData.token;
                        }
                        return config;
                    },
                    response: function (response) {
                        if (response.status === 401) {
                            // handle the case where the user is not authenticated
                        }
                        return response || $q.when(response);
                    },
                    responseError: function (response) {
                        if (rejection.status === 401) {
                            var authService = $injector.get('authService');
                            var authData = localStorageService.get('authorizationData');

                            if (authData) {
                                if (authData.useRefreshTokens) {
                                    $location.path('/refresh');
                                    return $q.reject(rejection);
                                }
                            }
                            authService.logOut();
                            $location.path('/login');
                        }
                        return $q.reject(rejection);
                    }
                };
            }]);

myApp.config(["$httpProvider", function ($httpProvider) {
    $httpProvider.interceptors.push('httpInterceptor');
}]);

myApp.run(['AuthenticationService', function (AuthenticationService) {
    AuthenticationService.FillAuthData();
}]);