﻿// create the controller and inject Angular's $scope
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
            url: 'http://localhost:57369/api/games/' + id,
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

app.controller('gamesController', function ($scope, $http, $modal, $log, $route) {
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

    $scope.submitForm = function (isValid) {
        if (isValid) {
            PostData();
        }
    };

    // Get the full list of games - this happens as soon as the page is loaded.
    $http.get("http://localhost:57369/api/games")
    .success(function (response) {
        $scope.games = response;
        $scope.show_table = true;
        $scope.totalGames = response.length;
        $scope.loading = false;
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

app.controller('publisherController', function ($scope, $http, $route) {
    $scope.sortType = 'Name'; // set the default sort type
    $scope.sortReverse = false;  // set the default sort order
    $scope.searchPublishers = '';     // set the default search/filter term
    $scope.loading = true;
    $scope.showAddNew = false;

    $scope.showAddNewGame = function () {
        $scope.showAddNew = true;
    };

    $http.get("http://localhost:57369/api/publishers")
    .success(function (response) {
        $scope.publishers = response;
        $scope.loading = false;
    })
    .error(function (error) {
        console.log(error);
    });

    var PostData = function () {
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

app.controller('publisherIdController', function ($rootScope, $scope, $routeParams, $route, $http) {
    console.log($routeParams.publisherId)
    $http.get("http://localhost:57369/api/publishers/" + $routeParams.publisherId)
    .success(function (response) {
        $scope.publisher = response;
        console.log(response);
        $scope.PublisherId = $routeParams.publisherId;
        var i = $routeParams.publisherId;
        console.log(i)
    })
    .error(function (error) {
        console.log(error);
    });

    $scope.delete = function () {
        var id = $routeParams.publisherId;
        $http({
            method: "DELETE",
            url: "http://localhost:57369/api/publishers/" + id
        })
        .success(function (response) {
            $location.path('#/publishers');
        })
        .error(function (error) {
            console.log(error);
        });
    };
});

app.controller('addonsController', function ($scope, $http, $route) {
    $scope.loading = true;
    $scope.showAddNew = false;

    $scope.showAddNewAddon = function () {
        $scope.showAddNew = true;
    };

    $http.get("http://localhost:57369/api/addons")
       .success(function (response) {
           $scope.addons = response;
           $scope.loading = false;
       })
       .error(function (error) {
           console.log(error);
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
            url: "http://localhost:57369/api/addons",
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

    $http.get("http://localhost:57369/api/games")
    .success(function (response) {
        $scope.games = response;
    })
    .error(function (error) {
        console.log(error);
    });
});

app.controller('accessoriesController', function ($scope, $http, $route) {
    $scope.loading = true;
    $scope.showAddNew = false;

    $scope.showAddNewAccessory = function () {
        $scope.showAddNew = true;
    };

    $http.get("http://localhost:57369/api/accessories")
       .success(function (response) {
           $scope.accessories = response;
           $scope.loading = false;
       })
       .error(function (error) {
           console.log(error);
       });

    var PostData = function () {
        var config = {
            Name: $scope.name,
            Type: $scope.type,
            Description: $scope.description,
            GameId: $scope.gameId
        };

        $http({
            method: "POST",
            url: "http://localhost:57369/api/accessories",
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

    $http.get("http://localhost:57369/api/games")
    .success(function (response) {
        $scope.games = response;
    })
    .error(function (error) {
        console.log(error);
    });
});

app.controller('addonIdController', function ($scope, $http, $routeParams, $route, $location) {
    $http.get('http://localhost:57369/api/addons/' + $routeParams.addonId)
       .success(function (response) {
           $scope.addon = response;
       })
       .error(function (error) {
           console.log(error);
       });

    $scope.delete = function () {
        var id = $routeParams.addonId;
        $http({
            method: "DELETE",
            url: "http://localhost:57369/api/addons/" + id
        })
        .success(function (response) {
           // $location.location.href('/#/addons');
        })
        .error(function (error) {
            console.log(error);
        });
    };
});

app.controller('accessoryIdController', function ($scope, $http, $routeParams, $route, $location) {
    $http.get('http://localhost:57369/api/accessories/' + $routeParams.accessoryId)
       .success(function (response) {
           $scope.accessory = response;
       })
       .error(function (error) {
           console.log(error);
       });

    $scope.delete = function () {
        var id = $routeParams.accessoryId;

        $http({
            method: "DELETE",
            url: "http://localhost:57369/api/accessories/" + id
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

//function PostData(url, config) {
//    $http({
//        method: "POST",
//        url: url,
//        data: config,
//        contentType: "application/json"
//    })
//    .success(function () {
//        $route.reload();
//    })
//    .error(function (error) {
//        console.log(error);
//    });
//};

//function DeleteItem(url, id) {
//    $http({
//        method: 'DELETE',
//        url: url + id
//    })
//    .success(function (response) {
//    })
//    .error(function (error) {
//        console.log(error)
//    });
//};