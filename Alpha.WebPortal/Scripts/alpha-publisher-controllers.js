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

app.controller('publisherIdController', ['$rootScope', '$scope', '$routeParams', '$location', '$route', '$http', 'GetAll', 'DeleteItem', 'UpdateItem', function ($rootScope, $scope, $routeParams, $route, $location, $http, GetAll, DeleteItem, UpdateItem) {

    var publisherIdApi = 'http://localhost:57369/api/publishers/';
    var publisherId;

    GetAll.all(publisherIdApi + $routeParams.publisherId, function (response) {
        $scope.publisher = response;
        publisherId = $routeParams.publisherId;
        $scope.PublisherId = publisherId
    });

    $scope.updatePublisher = function () {
        var config = {
            PublisherId: publisherId,
            Name: 'test-change',
            Location: 'UK'
        };

        UpdateItem.put(publisherIdApi + publisherId, config, function (response) {
            console.log(response);

        });
    };

    $scope.delete = function () {
        DeleteItem.deleteItem(publisherIdApi, publisherId, function (response) {
            console.log(response);
            $location.href.path('#/publishers');
        });
    };
}]);