myApp.factory('AuthenticationService', ['$http', 'config', 'localStorageService', '$q', function ($http, config, localStorageService, $q) {

    var AuthenticationService = {};

    var _authentication = {
        isAuth: false,
        userName: "",
        useRefreshTokens: false
    };

    var _login = function (loginInfo, scope) {
        var user = { grant_type: 'password', username: loginInfo.Email, password: loginInfo.Password, scope: scope };

        var deferred = $q.defer();

        var urlEncodedUrl = {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': "Basic " + btoa(config._settings.client_id + ":" + config._settings.client_secret)
        };

        $http({
            url: config._settings.metadata.token_endpoint,
            method: "POST",
            headers: urlEncodedUrl,
            data: user,
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            }
        }).success(function (response) {
            //if (loginData.useRefreshTokens) {
            //    localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: response.refresh_token, useRefreshTokens: true });
            //}
            //else {
            //    localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: "", useRefreshTokens: false });
            //}

            localStorageService.set('authorizationData', { token: response.access_token, userName: loginInfo.Email, refreshToken: "", useRefreshTokens: false });
            _authentication.isAuth = true;
            _authentication.userName = loginInfo.Email;
            deferred.resolve(response);
        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;
    };

    var _logout = function () {
        localStorageService.remove('authorizationData');
        _authentication.isAuth = false;
        _authentication.userName = "";
        _authentication.useRefreshTokens = false;
    };

    var _fillAuthData = function () {
        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
            _authentication.useRefreshTokens = authData.useRefreshTokens;
        }
    };

    AuthenticationService.Login = _login;
    AuthenticationService.Logout = _logout;
    AuthenticationService.FillAuthData = _fillAuthData;
    AuthenticationService.Authentication = _authentication;

    return AuthenticationService;
}]);