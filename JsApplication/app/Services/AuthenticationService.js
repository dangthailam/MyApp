myApp.factory('AuthenticationService', ['$http', 'config', 'localStorageService', function ($http, config, localStorageService) {

    var AuthenticationService = {};

    var _authentication = {
        isAuth: false,
        userName: "",
        useRefreshTokens: false
    };

    var _login = function (loginInfo, scope) {
        var user = { grant_type: 'password', username: loginInfo.Email, password: loginInfo.Password, scope: scope };

        var urlEncodedUrl = {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': "Basic " + btoa(config._settings.client_id + ":" + config._settings.client_secret)
        };

        var transformRequestFnc = function (obj) {
            var str = [];
            for (var p in obj)
                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
            return str.join("&");
        };

        return ServiceBase.ExecuteAjax(
            config._settings.metadata.token_endpoint,
            'POST',
            user,
            transformRequestFnc,
            urlEncodedUrl
        );
    }

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
            _authentication.useRefreshTokens = authData.useRefreshTokens;
        }
    };

    AuthenticationService.Login = _login;
    AuthenticationService.FillAuthData = _fillAuthData;

    return AuthenticationService;
}]);