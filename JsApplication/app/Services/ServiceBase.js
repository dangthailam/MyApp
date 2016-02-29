myApp.service('ServiceBase', ['$http', '$q',
    function ($http, $q) {
        this.ExecuteAjax = function (url, method, data, transformRequest, headers, params, async) {
            var request = $http({
                url: url, method: method, data: data, params: params, transformRequest: transformRequest, async: async, headers: headers
            });

            return (request.then(handleSuccess, handleError));
        }

        // I transform the successful response, unwrapping the application data
        // from the API response payload.
        function handleSuccess(response) {
            return (response.data);
        }

        // ---
        // PRIVATE METHODS.
        // ---
        // I transform the error response, unwrapping the application dta from
        // the API response payload.
        function handleError(response) {

            var deferred = $q.defer();
            // The API response from the server should be returned in a
            // nomralized format. However, if the request was not handled by the
            // server (or what not handles properly - ex. server error), then we
            // may have to normalize it on our end, as best we can.

            if (response.data && response.data.Errors) {
                response.data.Errors.formErrors = {};
                response.data.Errors.pageError = "";

                if (response.data.Errors) {
                    for (var i = 0; i < response.data.Errors.length; i++) {
                        response.data.Errors.formErrors[response.data.Errors[i].Key] = response.data.Errors[i].Message;
                    }
                }
                return ($q.reject(response.data.Errors));
            }

            if (!angular.isObject(response.data) || !response.data.Messages) {
                return ($q.reject("An unknown error occurred."));
            }

            return ($q.reject("An unknown error occurred."));
        }
    }
]);