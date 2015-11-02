﻿app.controller('addonsController', ['$scope', '$http', '$route', 'GetAll', 'PostItem', function ($scope, $http, $route, GetAll, PostItem) {

    var addonApi = 'http://localhost:57369/api/addons/';

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
            Description: $scope.description
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

    GetAll.all('http://localhost:57369/api/games', function (response) {
        $scope.games = response;
    });
}]);

app.controller('addonIdController', ['$scope', '$http', '$routeParams', '$route', '$location', 'GetAll', 'DeleteItem', '$uibModal', '$log', function ($scope, $http, $routeParams, $route, $location, GetAll, DeleteItem, $uibModal, $log) {

    var addonIdApi = 'http://localhost:57369/api/addons/'
    var addonId = $routeParams.addonId;
    var items;
    $scope.loading = true;

    GetAll.all(addonIdApi + addonId, function (response) {
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
                GameId: result.GameId
            };

            UpdateItem.put(addonIdApi + addonId, config, function (response) {
                $route.reload();
            });

        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.delete = function () {
        DeleteItem.deleteItem(addonIdApi, $routeParams.addonId, function (response) {
            $location.path('#/addons');
        });
    };
}]);

app.controller('editAddonController', ['$scope', '$uibModalInstance', 'items', function ($scope, $uibModalInstance, items) {
   $scope.addon = items;

    $scope.ok = function () {
        $uibModalInstance.close({
            Name: $scope.name,
            ReleaseDate: $scope.releaseDate,
            Description: $scope.description,
            GameId: $scope.gameId
        });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);