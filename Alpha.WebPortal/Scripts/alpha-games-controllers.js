app.controller('gameIdController', function ($scope, $http, $routeParams, $location, PostItem, DeleteItem, GetAll) {

    var gameIdApiUrl = 'http://localhost:57369/api/games/';

    $http.get(gameIdApiUrl + $routeParams.gameId)
	.success(function (response) {
	    $scope.game = response;
	    $scope.GameId = $routeParams.gameId;
	    console.log(response);
	})
	.error(function (error) {
	    console.log(error);
	});

    $scope.delete = function () {
        DeleteItem.deleteItem(gameIdApiUrl, $routeParams.gameId, function (response) {
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
            console.log(response);
        })
        .error(function (error) {
            console.log(error);
        });
    };
});

app.controller('gamesController', function ($scope, $http, $modal, $log, $route, GetAll) {

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

        $http({
            method: 'POST',
            url: gameApiUrl,
            data: config,
            contentType: 'application/json'
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

    GetAll.all(gameApiUrl, function (response) {
        $scope.games = response;
        $scope.loading = false;
        $scope.totalGames = $scope.games.length;
    });

    GetAll.all('http://localhost:57369/api/publishers', function (response) {
        $scope.publishers = response;
    })
});