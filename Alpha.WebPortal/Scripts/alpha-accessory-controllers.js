app.controller('accessoriesController', function ($scope, $http, $route, GetAll) {

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

        $http({
            method: "POST",
            url: accessoryApi,
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

    GetAll.all('http://localhost:57369/api/addons', function (response) {
        $scope.games = response;
    });
});

app.controller('accessoryIdController', function ($scope, $http, $routeParams, $route, $location, GetAll) {

    var accessoryIdApi = 'http://localhost:57369/api/accessories/';

    GetAll.all(accessoryIdApi + $routeParams.accessoryId, function (response) {
        $scope.accessory = response;
    });

    $scope.delete = function () {
        DeleteItem.deleteItem(accessoryIdApi, $routeParams.accessoryId, function (response) {
            $location.path('#/accessories');
            console.log(response);
        });
    };
});