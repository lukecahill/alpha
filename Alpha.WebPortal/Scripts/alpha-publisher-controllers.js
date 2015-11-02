app.controller('publisherController', ['$scope', '$http', '$route', 'GetAll', 'PostItem', function ($scope, $http, $route, GetAll, PostItem) {

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

    var name, location;
    var publisherId = $routeParams.publisherId;
    var publisherIdApi = 'http://localhost:57369/api/publishers/';
    var items;
    $scope.loading = true;

    $scope.updatePublisher = function () {

        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '../app/modals/editPublisher.html',
            controller: 'editPublisherController',
            resolve: {
                items: function () {
                    return items;
                }
            }
        });

        modalInstance.result.then(function (result) {
            var config = {
                PublisherId: publisherId,
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

    GetAll.all(publisherIdApi + publisherId, function (response) {
        $scope.publisher = response;
        publisherId = publisherId;
        $scope.PublisherId = publisherId
        $scope.loading = false;
        items = response;

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

app.controller('editPublisherController', ['$scope', '$uibModalInstance', 'items', function ($scope, $uibModalInstance, items) {
    $scope.publisher = items;

    $scope.ok = function () {
        $uibModalInstance.close({ Name: publisher.Name, Location: publisher.Location });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);