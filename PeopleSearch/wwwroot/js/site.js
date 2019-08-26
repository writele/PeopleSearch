var app = angular.module('app', []);
app.controller('ctrl', function ($scope, $window, $http) {

    $scope.data = $window.data;

    $scope.search = function (event) {
        console.log($scope.query);
        $http({
            method: 'GET',
            url: '/api/person',
            data: $scope.query
        })
        .then(
            function (response) {
                $scope.data = response.data;
         });
    };

    $scope.search(null);
});