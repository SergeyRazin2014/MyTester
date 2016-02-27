var app = angular.module('app');

app.controller('SummaryReportCtrl', function ($scope, $http, $rootScope) {
    $http.get("/Query/GetSummaryReportInfo")
                    .success(function (response) {
                        $scope.summaryReportInfo = response;
                    });
});