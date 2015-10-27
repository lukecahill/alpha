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

app.controller('accessoryIdController', ['$scope', '$http', '$routeParams', '$route', '$location', 'GetAll', 'DeleteItem', function ($scope, $http, $routeParams, $route, $location, GetAll, DeleteItem) {

    var accessoryIdApi = 'http://localhost:57369/api/accessories/';
    var accessoryId = $routeParams.accessoryId;
    $scope.loading = true;

    GetAll.all(accessoryIdApi + accessoryId, function (response) {
        $scope.accessory = response;
        $scope.loading = false;
    });

    $scope.updateAccessory = function () {

        var config = {
            AccessoryId: accessoryId,
            Name: $scope.Name,
            Type: $scope.Type,
            Description: $scope.Description
        };

        UpdateItem.put(accessoryIdApi + accessoryId, config, function (response) {
            console.log(response);
        });

        console.log("Nothing currently");
    }

    $scope.delete = function () {
        DeleteItem.deleteItem(accessoryIdApi, accessoryId, function (response) {
            $location.path('#/accessories');
            console.log(response);
        });
    };
}]);