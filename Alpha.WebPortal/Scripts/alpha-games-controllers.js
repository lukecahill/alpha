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

app.controller('gameIdController', ['$scope', '$http', '$routeParams', '$location', 'PostItem', 'DeleteItem', 'GetAll', '$route', '$uibModal', '$log', function ($scope, $http, $routeParams, $location, PostItem, DeleteItem, GetAll, $route, $uibModal, $log) {

    var gameIdApiUrl = 'http://localhost:57369/api/games/';
    var gameId = $routeParams.gameId;
    var items;
    $scope.loading = true;

    GetAll.all(gameIdApiUrl + gameId, function (response) {
        $scope.game = response;
        $scope.loading = false;
        items = response;
    });

    $scope.delete = function () {
        DeleteItem.deleteItem(gameIdApiUrl, gameId, function (response) {
            console.log(response);
        });
    };

    $scope.updateGame = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '../app/modals/editGame.html',
            controller: 'editGameController',
            resolve: {
                items: function () {
                    return items;
                }
            }
        });

        modalInstance.result.then(function (result) {
            var config = {
                GameId: gameId,
                Title: result.Title,
                PublisherId: result.PublisherId,
                ReleaseDate: result.releaseDate
            };

            UpdateItem.put(gameIdApiUrl + gameId, config, function (response) {
                $route.reload();
            });

        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };
}]);

app.controller('editGameController', ['$scope', '$uibModalInstance', 'GetAll', 'items', function ($scope, $uibModalInstance, GetAll, items) {
    $scope.game = items;

    GetAll.all('http://localhost:57369/api/publishers/', function (response) {
        $scope.publishers = response;
        console.log(response)
    });

    $scope.ok = function () {
        $uibModalInstance.close({
            Title: $scope.title,
            Publisher: $scope.publisher,
            ReleaseDate: $scope.releaseDate
        });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);