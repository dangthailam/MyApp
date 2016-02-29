'use strict';

var settings = {
    authority: "https://localhost:44300/",
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

myApp.value('config', manager);

myApp.factory('httpInterceptor', ['$q', '$rootScope', '$log', '$timeout', 'localStorageService',
            function ($q, $rootScope, $log, $timeout, localStorageService) {
                return {
                    request: function (config) {
                        console.log('bearer : ');
                        console.log(localStorageService.get('bearerToken'));
                        config.headers = config.headers || {};
                        if (localStorageService.get('bearerToken')) {
                            config.headers.Authorization = 'Bearer ' + localStorageService.get('bearerToken');
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
                        return $q.reject(response);
                    }
                };
            }]);

myApp.config(["$httpProvider", function ($httpProvider) {
    $httpProvider.interceptors.push('httpInterceptor');
}]);