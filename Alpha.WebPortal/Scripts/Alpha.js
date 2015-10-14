// create the controller and inject Angular's $scope
app.controller('mainController', function ($scope, $http) {
    $scope.message = "Welcome to Alpha game store!";
});

app.controller('gameIdController', function ($scope, $http, $routeParams, $location) {
    $http.get('http://localhost:57369/api/games/' + $routeParams.gameId)
	.success(function (response) {
	    $scope.game = response;
	    $scope.GameId = $routeParams.gameId;
	    console.log(response);
	})
	.error(function (error) {
	    console.log(error);
	});

    $scope.delete = function () {
        var id = $routeParams.gameId;
        console.log(id)
        $http({
            method: "DELETE",
            url: "http://localhost:57369/api/games/" + id
        })
        .success(function (response) {
            $location.path('/#/games');
            // change this to redirect to the games summary - currently goes home
        })
        .error(function (error) {
            console.log(error);
        });
    };
});


app.controller('gamesController', function ($scope, $http, $modal, $log, $route) {
    $scope.sortType = 'Title'; // set the default sort type
    $scope.sortReverse = false;  // set the default sort order
    $scope.searchGame = '';     // set the default search/filter term

    $scope.items = ['item1', 'item2', 'item3'];

    $scope.animationsEnabled = true;

    $scope.open = function (size) {

        var modalInstance = $modal.open({
            animation: $scope.animationsEnabled,
            templateUrl: '/app/components/Modals/AddNewGame.html',
            controller: 'newGameController',
            size: size,
            resolve: {
                items: function () {
                    return $scope.items;
                }
            }
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.toggleAnimation = function () {
        $scope.animationsEnabled = !$scope.animationsEnabled;
    };

    $scope.postData = function () {
        var config = {
            "PublisherId": $scope.Publisher,
            "Title": $scope.Name,
            "ReleaseDate": $scope.ReleaseDate
        };

        $http({
            method: "POST",
            url: "http://localhost:57369/api/games",
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

    // Get the full list of games - this happens as soon as the page is loaded.
    $http.get("http://localhost:57369/api/games")
    .success(function (response) {
        $scope.games = response;
        $scope.show_table = true;
        $scope.totalGames = response.length;
    })
    .error(function (error) {
        console.log(error);
    });

    $http.get("http://localhost:57369/api/publishers")
    .success(function (response) {
        $scope.publishers = response;
    })
    .error(function (error) {
        console.log(error);
    });
});

app.controller('newGameController', function ($scope, $modalInstance, items) {
    $scope.items = items;
    $scope.selected = {
        item: $scope.items[0]
    };

    $scope.ok = function () {
        $modalInstance.close($scope.selected.item);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});

app.controller('publisherController', function ($scope, $http) {
    $scope.show_table = false;

    $scope.sortType = 'Name'; // set the default sort type
    $scope.sortReverse = false;  // set the default sort order
    $scope.searchPublishers = '';     // set the default search/filter term

    $scope.GetPublishers = function () {
        $http.get("http://localhost:57369/api/publishers")
        .success(function (response) {
            $scope.publishers = response;
            $scope.show_table = true;
        })
        .error(function (error) {
            console.log(error);
        })
    };

    $scope.postData = function () {
        var config = {
            "Name": $scope.Name,
            "Location": $scope.Location
        };

        $http({
            method: "POST",
            url: "http://localhost:57369/api/publishers",
            data: config,
            contentType: "application/json"
        })
        .success(function () {
            $scope.GetPublishers();
        })
        .error(function (error) {
            console.log(error);
        });
    };
});

app.controller('contactController', function ($scope) {
    $scope.message = 'Contact us! JK. This is just a demo.';
});


app.controller('publisherIdController', function ($rootScope, $scope, $routeParams, $route, $http) {
    console.log($routeParams.publisherId);
    $http.get("http://localhost:57369/api/publishers/" + $routeParams.publisherId)
    .success(function (response) {
        $scope.publisher = response;
    })
    .error(function (error) {
        console.log(error);
    });
});

app.controller('aboutController', function ($scope) {
    $scope.message = 'This is an about page.';
});

app.controller('addonsController', function ($scope, $http) {
    $http.get("http://localhost:57369/api/addons")
       .success(function (response) {
           $scope.addons = response;
       })
       .error(function (error) {
           console.log(error);
       })
});

app.controller('accessoriesController', function ($scope, $http) {
    $http.get("http://localhost:57369/api/accessories")
       .success(function (response) {
           $scope.accessories = response;
       })
       .error(function (error) {
           console.log(error);
       })
});