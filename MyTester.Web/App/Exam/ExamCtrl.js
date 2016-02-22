var app = angular.module('app');

app.controller('ExamCtrl', function ($scope, $http) {



    //запросить вопросы с сервера
    $http.get("/Query/GetAll")
        .success(function (response) {
            $scope.querys = response;

            $scope.currentQuery = _.first($scope.querys);
            $scope.currentQueryIndex = 0;

        });

    $scope.next = function () {
        $scope.currentQueryIndex += 1;
        $scope.currentQuery = $scope.querys[$scope.currentQueryIndex];

    }


    //отправить ФИО персона и все вопросы с ответами пользователя на сервер (вопрос + коллекция выбранных ответов)

});