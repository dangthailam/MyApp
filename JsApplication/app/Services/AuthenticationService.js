myApp.service('AuthenticationService', ['ServiceBase', 'config', function (ServiceBase, config) {
    this.Login = function (loginInfo, scope) {
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
}]);