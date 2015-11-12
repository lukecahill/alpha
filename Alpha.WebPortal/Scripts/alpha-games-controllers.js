app.controller('gamesController', ['$scope', '$http', '$log', '$route', 'GetAll', 'PostItem', function ($scope, $http, $log, $route, GetAll, PostItem) {

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
            PublisherId: $scope.Publisher,
            Title: $scope.Name,
            ReleaseDate: $scope.ReleaseDate,
            Price: $scope.Price,
            Picture: $scope.Picture
        };

        PostItem.post(gameApi, config, function () {
            $route.reload();
        });
    };

    $scope.submitForm = function (isValid) {
        if (isValid) {
            PostData();
        }
    };

    GetAll.all(gameApi, function (response) {
        $scope.games = response;
        $scope.loading = false;
        $scope.totalGames = $scope.games.length;
    });

    GetAll.all(publisherApi, function (response) {
        $scope.publishers = response;
    });
}]);

app.controller('gameIdController', ['$scope', '$http', '$routeParams', '$location', 'PostItem', 'DeleteItem', 'GetAll', '$route', '$uibModal', '$log', 'UpdateItem', function ($scope, $http, $routeParams, $location, PostItem, DeleteItem, GetAll, $route, $uibModal, $log, UpdateItem) {

    var gameId = $routeParams.gameId;
    var items;
    $scope.loading = true;

    GetAll.all(gameApi + gameId, function (response) {
        $scope.game = response;
        $scope.loading = false;
        items = response;
    });

    $scope.delete = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '../app/modals/deleteGameConfirmation.html',
            controller: 'deleteGameController'
        });

        modalInstance.result.then(function (response) {
            DeleteItem.deleteItem(gameApi, gameId, function (response) {
                console.log(response.Title + ' removed!');
            });

        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
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
                PublisherId: result.Publisher,
                ReleaseDate: result.ReleaseDate
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

    GetAll.all(publisherApi, function (response) {
        $scope.publishers = response;
    });

    $scope.ok = function () {
        $uibModalInstance.close({
            Title: $scope.game.Title,
            Publisher: $scope.publisher,
            ReleaseDate: $scope.game.ReleaseDate
        });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);

app.controller('deleteGameController', ['$scope', '$uibModalInstance', function ($scope, $uibModalInstance) {
    $scope.ok = function () {
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);