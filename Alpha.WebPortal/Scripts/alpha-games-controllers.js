app.controller('gamesController', ['$scope', '$http', '$modal', '$log', '$route', 'GetAll', function ($scope, $http, $modal, $log, $route, GetAll) {

    var gameApiUrl = 'http://localhost:57369/api/games';

    $scope.sortType = 'Title'; // set the default sort type
    $scope.sortReverse = false;  // set the default sort order
    $scope.searchGame = '';     // set the default search/filter term
    $scope.loading = true;
    $scope.showAddNew = false;

    $scope.showAddNewGame = function () {
        $scope.showAddNew = true;
    };

    var PostData = function () {
        var config = {
            "PublisherId": $scope.Publisher,
            "Title": $scope.Name,
            "ReleaseDate": $scope.ReleaseDate
        };

        PostItem.post(gameApiUrl, config, function () {
            $route.reload();
        });
    };

    $scope.submitForm = function (isValid) {
        if (isValid) {
            PostData();
        }
    };

    GetAll.all(gameApiUrl, function (response) {
        $scope.games = response;
        $scope.loading = false;
        $scope.totalGames = $scope.games.length;
    });

    GetAll.all('http://localhost:57369/api/publishers', function (response) {
        $scope.publishers = response;
    });
}]);

app.controller('gameIdController', ['$scope', '$http', '$routeParams', '$location', 'PostItem', 'DeleteItem', 'GetAll', '$route', function ($scope, $http, $routeParams, $location, PostItem, DeleteItem, GetAll, $route) {

    var gameIdApiUrl = 'http://localhost:57369/api/games/';
    var gameId = $routeParams.gameId;


    GetAll.all(gameIdApiUrl + gameId, function (response) {
        $scope.game = response;
        $scope.GameId = gameId;
    });

    $scope.delete = function () {
        DeleteItem.deleteItem(gameIdApiUrl, gameId, function (response) {
            console.log(response);
        });
    };

    $scope.updateGame = function () {
        var id = $routeParams.gameId;

        var data = {
            GameId: $scope.deleteId,
            PublisherId: $routeParams.publisherId,
            Title: $scope.title
        };
        console.log(data);
        $http({
            method: 'PUT',
            url: gameIdApiUrl + id,
            data: data
        })
        .success(function (response) {
            $route.reload();
            console.log(response);
        })
        .error(function (error) {
            console.log(error);
        });
    };
}]);