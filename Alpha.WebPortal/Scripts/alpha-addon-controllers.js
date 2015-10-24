app.controller('addonsController', function ($scope, $http, $route, GetAll) {

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

        $http({
            method: "POST",
            url: addonApi,
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

    GetAll.all('http://localhost:57369/api/games', function (response) {
        $scope.games = response;
    });
});

app.controller('addonIdController', function ($scope, $http, $routeParams, $route, $location, GetAll) {

    var addonIdApi = 'http://localhost:57369/api/addons/'

    GetAll.all(addonIdApi + $routeParams.addonId, function (response) {
        $scope.addon = response;
    });

    $scope.delete = function () {
        DeleteItem.deleteItem(addonIdApi, $routeParams.addonId, function (response) {
            $location.path('#/addons');
            console.log(response);
        });
    };
});