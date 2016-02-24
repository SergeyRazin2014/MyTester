var app = angular.module('app');

app.controller('SummaryReportCtrl', function ($scope, $http, $rootScope) {




    //получить всех пользователей с ответами на вопросы
    $http.get("/Query/GetSummaryReportInfo")
                    .success(function (response) {
                        $scope.summaryReportInfo = response;

                       


        });




});