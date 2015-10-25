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
}]);

app.factory('PostItem', ['$http', function ($http) {
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

app.factory('DeleteItem', ['$http', function ($http) {
    return {
        deleteItem: function (url, id, callback) {
            $http({
                method: 'DELETE',
                url: url + id
            })
                .success(callback)
                .error(function (error) {
                    console.log(error);
            });
        }
    };
}]);