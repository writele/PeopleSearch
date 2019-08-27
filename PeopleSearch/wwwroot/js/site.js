var app = angular.module('app', []);
app.controller('ctrl', function ($scope, $window, $http) {

    $scope.data = $window.data;

    $scope.search = function (event) {

        $(".person-search-container").hide();
        $(".lds-spinner").show();

        setTimeout(function () {
            $http({
                method: 'GET',
                url: '/api/person',
                params: { query: $scope.query }
            })
                .then(
                    function (response) {
                        $scope.data = response.data;
                        $(".lds-spinner").hide();
                        $(".person-search-container").show();
                    });
        }, 3000);

    };

    $scope.search(null);
});