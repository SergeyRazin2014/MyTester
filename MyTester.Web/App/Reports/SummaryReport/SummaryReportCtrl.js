var app = angular.module('app');

app.controller('SummaryReportCtrl', function ($scope, $http, $rootScope) {

    //получить всех пользователей с ответами на вопросы
    $http.get("/Person/GetAll")
                    .success(function (response) {
                        $scope.persons = response;
                    });
});