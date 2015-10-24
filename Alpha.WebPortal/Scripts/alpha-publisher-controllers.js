app.controller('publisherController', function ($scope, $http, $route, GetAll) {

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

        $http({
            method: "POST",
            url: publisherApi,
            data: config,
            contentType: "application/json"
        })
        .success(function () {
            $route.reload();
        })
        .error(function (error) {
            console.log(error);
        });
    };

    $scope.submitForm = function (isValid) {
        if (isValid) {
            PostData();
        }
    };
});

app.controller('publisherIdController', function ($rootScope, $scope, $routeParams, $route, $http, GetAll) {

    var publisherIdApi = 'http://localhost:57369/api/publishers/';

    GetAll.all(publisherIdApi + $routeParams.publisherId, function (response) {
        $scope.publisher = response;
        $scope.PublisherId = $routeParams.publisherId;
        var i = $routeParams.publisherId;
    })

    $scope.delete = function () {
        var id = $routeParams.publisherId;
        $http({
            method: "DELETE",
            url: publisherIdApi + id
        })
        .success(function (response) {
            $location.path('#/publishers');
        })
        .error(function (error) {
            console.log(error);
        });
    };
});