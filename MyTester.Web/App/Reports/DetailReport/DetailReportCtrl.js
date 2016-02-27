var app = angular.module('app');

app.controller('DetailReportCtrl', function ($scope, $http, $rootScope) {
    $http.get("/Query/GetDetailReport")
                    .success(function (response) {

                        $scope.detailReport = response;


                        $scope.averageSumm = getAverageSumm($scope.detailReport);


                    });


    function getAverageSumm(detailReport) {
        //для всех Row выбрать AveragePoitByQuery и сложить



        //var res = _.map(detailReport.Row, function(a, b) {
        //    return a.AveragePointByQuery + b.AveragePointByQuery 

        //});

        var averagePointByQueryList = _.pluck(detailReport.Row, "AveragePointByQuery");
        var sum = _.reduce(averagePointByQueryList, function (memo, num) { return memo + num; }, 0);

        return sum;

    }
});