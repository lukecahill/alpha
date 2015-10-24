app.factory('GetAll', ['$http', function ($http) {

    return {
        all: function (url, callback) {
            $http.get(url)
                .success(callback)
                .error(function (error) {
                    console.log(error);
            });
        }
    };

    return {
        post: function (url, config, callback) {
            $http({
                method: 'POST',
                url: url,
                data: config,
                contentType: 'application/json'
            })
                .success(callback)
                .error(function (error) {
                    console.log(error);
            });
        }
    };
}]);