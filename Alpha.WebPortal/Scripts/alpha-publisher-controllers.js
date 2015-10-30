﻿app.controller('publisherController', ['$scope', '$http', '$route', 'GetAll', 'PostItem', function ($scope, $http, $route, GetAll, PostItem) {

    var publisherApi = 'http://localhost:57369/api/publishers/';

    $scope.sortType = 'Name'; // set the default sort type
    $scope.sortReverse = false;  // set the default sort order
    $scope.searchPublishers = '';     // set the default search/filter term
    $scope.loading = true;
    $scope.showAddNew = false;

    $scope.showAddNewGame = function () {
        $scope.showAddNew = true;
    };

    GetAll.all(publisherApi, function (response) {
        $scope.publishers = response;
        $scope.loading = false;
    })

    var PostData = function () {
        var config = {
            "Name": $scope.Name,
            "Location": $scope.Location
        };

        PostItem.post(publisherApi, config, function () {
            $route.reload();
        });
    };

    $scope.submitForm = function (isValid) {
        if (isValid) {
            PostData();
        }
    };
}]);

app.controller('publisherIdController', ['$rootScope', '$scope', '$routeParams', '$location', '$route', '$http', 'GetAll', 'DeleteItem', 'UpdateItem', '$uibModal', '$log', function ($rootScope, $scope, $routeParams, $location, $route, $http, GetAll, DeleteItem, UpdateItem, $uibModal, $log) {

    $scope.animationsEnabled = true;
    var name, location;

    $scope.updatePublisher = function () {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: '../app/modals/editPublisher.html',
            controller: 'newPublisherController'
        });

        modalInstance.result.then(function (result) {
            // Find a better way to do this!
            if (result.Name == undefined) {
                result.Name = name
            }

            if (result.Location == undefined) {
                result.Location = location
            }

            var config = {
                PublisherId: $routeParams.publisherId,
                Name: result.Name,
                Location: result.Location
            };

            UpdateItem.put(publisherIdApi + publisherId, config, function (response) {
                $route.reload();
            });

        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.toggleAnimation = function () {
        $scope.animationsEnabled = !$scope.animationsEnabled;
    };

    var publisherIdApi = 'http://localhost:57369/api/publishers/';
    var publisherId;
    $scope.loading = true;

    GetAll.all(publisherIdApi + $routeParams.publisherId, function (response) {
        $scope.publisher = response;
        publisherId = $routeParams.publisherId;
        $scope.PublisherId = publisherId
        $scope.loading = false;

        name = response.Name;
        location = response.Location;
    });

    $scope.delete = function () {
        DeleteItem.deleteItem(publisherIdApi, publisherId, function (response) {
            console.log(response);
            $location.href.path('#/publishers');
        });
    };
}]);

app.controller('newPublisherController', ['$scope', '$uibModalInstance', function ($scope, $uibModalInstance) {
    $scope.ok = function () {
        $uibModalInstance.close({ Name: $scope.name, Location: $scope.location });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);