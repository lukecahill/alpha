app.controller('accessoriesController', ['$scope', '$http', '$route', 'GetAll', 'PostItem', function ($scope, $http, $route, GetAll, PostItem) {

    var accessoryApi = 'http://localhost:57369/api/accessories';

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
            GameId: $scope.gameId
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

    GetAll.all('http://localhost:57369/api/games', function (response) {
        $scope.games = response;
    });
}]);

app.controller('accessoryIdController', ['$scope', '$http', '$routeParams', '$route', '$location', 'GetAll', 'DeleteItem', '$uibModal', '$log', function ($scope, $http, $routeParams, $route, $location, GetAll, DeleteItem, $uibModal, $log) {

    var accessoryIdApi = 'http://localhost:57369/api/accessories/';
    var accessoryId = $routeParams.accessoryId;
    var items;
    $scope.loading = true;

    GetAll.all(accessoryIdApi + accessoryId, function (response) {
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

        modalInstance.result.then(function (result) {
            var config = {
                AccessoryId: accessoryId,
                Name: response.Name,
                Type: response.Type,
                Description: response.Description,
                GameId: response.gameId
            };

            UpdateItem.put(accessoryIdApi + accessoryId, config, function (response) {
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

app.controller('editAccessoryController', ['$scope', '$uibModalInstance', 'items', function ($scope, $uibModalInstance, items) {
    $scope.accessory = items;

    $scope.ok = function () {
        $uibModalInstance.close({
            Name: $scope.name,
            Type: $scope.type,
            Description: $scope.description,
            GameId: $scope.gameId
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