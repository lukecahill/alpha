app.controller('registerController', ['$scope', '$http', function ($scope, $http) {

    $scope.register = function () {
        var data = {
            UserName: $scope.username,
            Password: $scope.password,
            ComparePassword: $scope.confirm
        };
        console.log(data)

        $http({
            method: 'POST',
            url: registerApi,
            data: data,
            contentType: 'application/x-www-form-urlencoded'
        }).success(function (response) {
            // if successful
            console.log(response);
        }).error(function (error) {
            // on error
            console.log(error);
        });
    }
}]);