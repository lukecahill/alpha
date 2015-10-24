// create the controller and inject Angular's $scope
app.controller('mainController', function ($scope, $http) {
    $scope.message = "Welcome to Alpha game store!";
});

app.controller('aboutController', function ($scope) {
    $scope.message = 'This is an about page.';
});

app.controller('contactController', function ($scope) {
    $scope.message = 'Contact us! JK. This is just a demo.';
});