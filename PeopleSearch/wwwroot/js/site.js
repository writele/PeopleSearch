var app = angular.module('app', []);
app.controller('ctrl', function ($scope, $window, $http) {

    $scope.data = $window.data;

    $scope.search = function (event) {

        setTimeout(function () {
            $http({
                method: 'GET',
                url: '/api/person',
                params: { query: $scope.query }
            })
                .then(
                    function (response) {
                        $scope.data = response.data;
                    });
        }, 3000);

    };

    $scope.search(null);
});