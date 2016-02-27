var app = angular.module('app');

app.controller('PersonAverageReportCtrl', function($scope, $http, $rootScope) {
    $http.get("/Query/GetPersonAverageReport")
                    .success(function (response) {
                        $scope.personAverages = response;
                    });
});