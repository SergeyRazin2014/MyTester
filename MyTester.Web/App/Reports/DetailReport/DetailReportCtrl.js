var app = angular.module('app');

app.controller('DetailReportCtrl', function ($scope, $http, $rootScope) {
    $http.get("/Query/GetDetailReport")
                    .success(function (response) {

                        $scope.detailReport = response;

                        var test = $scope.detailReport.AllPerson;

                    });
});