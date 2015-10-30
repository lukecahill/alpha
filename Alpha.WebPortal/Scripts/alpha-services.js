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

app.factory('UpdateItem', ['$http', function ($http) {
    return {
        put: function (url, config, callback) {
            $http({
                method: 'PUT',
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

app.factory('OpenModal', ['$uibModal', '$scope', '$log', '$scope', function ($uibModal, $scope, $log, $scope) {
    return {
        openModal: function (items, templateUrl, controller) {
            $scope.animationsEnabled = true;

            $scope.items = items;

            $scope.open = function () {

                var modalInstance = $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: templateUrl,
                    controller: controller,
                    resolve: {
                        items: function () {
                            return $scope.items;
                        }
                    }
                });

                modalInstance.result.then(function (success) {
                    console.log(success);
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };
        }
    };
}]);