app.controller('addonsController', ['$scope', '$http', '$route', 'GetAll', 'PostItem', function ($scope, $http, $route, GetAll, PostItem) {

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

app.controller('addonIdController', ['$scope', '$http', '$routeParams', '$route', '$location', 'GetAll', 'DeleteItem', function ($scope, $http, $routeParams, $route, $location, GetAll, DeleteItem) {

    var addonIdApi = 'http://localhost:57369/api/addons/'
    var addonId = $routeParams.addonId;
    $scope.loading = true;

    GetAll.all(addonIdApi + addonId, function (response) {
        $scope.addon = response;
        $scope.loading = false;
    });

    $scope.updateAddon = function () {

        var config = {
            AddonId: addonId,
            Name: $scope.Name,
            ReleaseDate: $scope.ReleaseDate,
            Description: $scope.Description,
            GameId: $scope.GameId
        };

        UpdateItem.put(addonIdApi + addonId, config, function (response) {
            console.log(response);

        });

        console.log("Nothing currently");
    };

    $scope.delete = function () {
        DeleteItem.deleteItem(addonIdApi, $routeParams.addonId, function (response) {
            $location.path('#/addons');
            console.log(response);
        });
    };
}]);