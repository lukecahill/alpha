﻿app.controller('addonsController', ['$scope', '$http', '$route', 'GetAll', 'PostItem', function ($scope, $http, $route, GetAll, PostItem) {

    $scope.loading = true;
    $scope.showAddNew = false;

    $scope.showAddNewAddon = function () {
        $scope.showAddNew = true;
    };

    GetAll.all(addonApi, function (response) {
        $scope.addons = response;
        $scope.loading = false;
    });

    var PostData = function () {
        var config = {
            Name: $scope.title,
            GameId: $scope.gameId,
            ReleaseDate: $scope.releaseDate,
            Description: $scope.description,
            Price: $scope.price
        };

        PostItem.post(addonApi, config, function () {
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

app.controller('addonIdController', ['$scope', '$http', '$routeParams', '$route', '$location', 'GetAll', 'DeleteItem', '$uibModal', '$log', 'UpdateItem', function ($scope, $http, $routeParams, $route, $location, GetAll, DeleteItem, $uibModal, $log, UpdateItem) {

    var addonId = $routeParams.addonId;
    var items;
    $scope.loading = true;

    GetAll.all(addonApi + addonId, function (response) {
        $scope.addon = response;
        $scope.loading = false;
        items = response;
    });

    $scope.updateAddon = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '../app/modals/editAddon.html',
            controller: 'editAddonController',
            resolve: {
                items: function () {
                    return items;
                }
            }
        });

        modalInstance.result.then(function (result) {
            var config = {
                AddonId: addonId,
                Name: result.Name,
                ReleaseDate: result.ReleaseDate,
                Description: result.Description,
                GameId: result.GameId,
                Price: result.Price
            };

            UpdateItem.put(addonApi + addonId, config, function (response) {
                $route.reload();
            });

        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.delete = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '../app/modals/deleteAddonConfirmation.html',
            controller: 'deleteAddonController'
        });

        modalInstance.result.then(function (response) {
            DeleteItem.deleteItem(addonIdApi, $routeParams.addonId, function (response) {
                $location.path('#/addons');
            });

        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };
}]);

app.controller('editAddonController', ['$scope', '$uibModalInstance', 'items', 'GetAll', function ($scope, $uibModalInstance, items, GetAll) {
    $scope.addon = items;

    GetAll.all(gameApi, function (response) {
        $scope.games = response;
    });

    $scope.ok = function () {
        $uibModalInstance.close({
            Name: $scope.addon.AddonName,
            ReleaseDate: $scope.addon.ReleaseDate,
            Description: $scope.addon.Description,
            GameId: $scope.gameId,
            Price: $scope.addon.Price
        });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);

app.controller('deleteAddonController', ['$scope', '$uibModalInstance', function ($scope, $uibModalInstance) {
    $scope.ok = function () {
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);