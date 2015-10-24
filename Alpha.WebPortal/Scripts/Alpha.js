// create the controller and inject Angular's $scope
app.controller('mainController', function ($scope, $http) {
    $scope.message = "Welcome to Alpha game store!";
});

app.controller('gameIdController', function ($scope, $http, $routeParams, $location) {

    var gameIdApiUrl = 'http://localhost:57369/api/games';

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
        var id = $routeParams.gameId;
        console.log(id)
        $http({
            method: 'DELETE',
            url: gameIdApiUrl + id
        })
        .success(function (response) {
            $location.path('/#/games');
            console.log(response);
            // change this to redirect to the games summary - currently goes home
        })
        .error(function (error) {
            console.log(error);
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

app.controller('addonIdController', function ($scope, $http, $routeParams, $route, $location, GetAll) {

    var addonIdApi = 'http://localhost:57369/api/addons/'

    GetAll.all(addonIdApi + $routeParams.addonId, function (response) {
        $scope.addon = response;
    });

    $scope.delete = function () {
        var id = $routeParams.addonId;
        $http({
            method: "DELETE",
            url: addonIdApi + id
        })
        .success(function (response) {
            // $location.location.href('/#/addons');
        })
        .error(function (error) {
            console.log(error);
        });
    };
});

app.controller('accessoryIdController', function ($scope, $http, $routeParams, $route, $location, GetAll) {

    var accessoryIdApi = 'http://localhost:57369/api/accessories/';

    GetAll.all(accessoryIdApi + $routeParams.accessoryId, function (response) {
        $scope.accessory = response;
    });

    $scope.delete = function () {
        var id = $routeParams.accessoryId;

        $http({
            method: "DELETE",
            url: accessoryIdApi + id
        })
        .success(function (response) {
            //$location.href('/#/accessories');
        })
        .error(function (error) {
            console.log(error);
        });
    };
});

app.controller('aboutController', function ($scope) {
    $scope.message = 'This is an about page.';
});

app.controller('contactController', function ($scope) {
    $scope.message = 'Contact us! JK. This is just a demo.';
});