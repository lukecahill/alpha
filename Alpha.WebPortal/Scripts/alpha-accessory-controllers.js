app.controller('accessoriesController', ['$scope', '$http', '$route', 'GetAll', 'PostItem', function ($scope, $http, $route, GetAll, PostItem) {
    
    $scope.loading = true;
    $scope.showAddNew = false;

    $scope.showAddNewAccessory = function () {
        $scope.showAddNew = true;
    };

    GetAll.all(accessoryApi, function (response) {
        $scope.accessories = response;
        $scope.loading = false;
    })

    var PostData = function () {
        var config = {
            Name: $scope.name,
            Type: $scope.type,
            Description: $scope.description,
            GameId: $scope.gameId,
            Price: $scope.price
        };

        PostItem.post(accessoryApi, config, function () {
            $route.reload();
        });
    };

    $scope.submitForm = function (isValid) {
        if (isValid) {
            PostData();
        }
    };

    GetAll.all(gameApi, function (response) {
        $scope.games = response;
    });
}]);

app.controller('accessoryIdController', ['$scope', '$http', '$routeParams', '$route', '$location', 'GetAll', 'DeleteItem', '$uibModal', '$log', 'UpdateItem', function ($scope, $http, $routeParams, $route, $location, GetAll, DeleteItem, $uibModal, $log, UpdateItem) {

    var accessoryId = $routeParams.accessoryId;
    var items;
    $scope.loading = true;

    GetAll.all(accessoryApi + accessoryId, function (response) {
        $scope.accessory = response;
        $scope.loading = false;
        items = response;
    });

    $scope.updateAccessory = function () {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: '../app/modals/editAccessory.html',
            controller: 'editAccessoryController',
            resolve: {
                items: function() {
                    return items;
                }
            }
        });

        modalInstance.result.then(function (response) {
            var config = {
                AccessoryId: accessoryId,
                Name: response.Name,
                Type: response.Type,
                Description: response.Description,
                GameId: response.GameId,
                Price: response.Price
            };

            UpdateItem.put(accessoryApi + accessoryId, config, function (response) {
                $route.reload();
            });

        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.delete = function () {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: '../app/modals/deleteAccessoryConfirmation.html',
            controller: 'deleteAccessoryController'
        });

        modalInstance.result.then(function (result) {
            DeleteItem.deleteItem(accessoryIdApi, accessoryId, function (response) {
                $location.path('#/accessories');
            });

        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };
}]);

app.controller('editAccessoryController', ['$scope', '$uibModalInstance', 'items', 'GetAll', function ($scope, $uibModalInstance, items, GetAll) {

    $scope.accessory = items;
    var items;

    GetAll.all(gameApi, function (response) {
        $scope.games = response;
    });

    $scope.ok = function () {
        $uibModalInstance.close({
            Name: $scope.accessory.Name,
            Type: $scope.accessory.Type,
            Description: $scope.accessory.Description,
            GameId: $scope.gameId,
            Price: $scope.accessory.Price
        });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);

app.controller('deleteAccessoryController', ['$scope', '$uibModalInstance', function ($scope, $uibModalInstance) {
    $scope.ok = function () {
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);