app.controller('loginController', ['$scope', '$http', function ($scope, $http) {

    $scope.login = function () {
        var data = {
            UserName: $scope.username,
            Password: $scope.password
        };

        console.log(data)

        $http({
            method: 'POST',
            url: loginApi,
            data: data,
            contentType: 'application/x-www-form-urlencoded'
        }).success(function (repsonse) {
            // if successful
            console.log(repsonse);
        }).error(function (error) {
            // if there is an error
            console.log(error);
        });
    }
}]);