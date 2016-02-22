var app = angular.module('app');

app.controller('loginCtrl', function ($scope, $http, clientSettings) {

    $scope.person = {};

    $scope.exam = {};

    $scope.isNotFullName = function() {
        return $scope.person.Surname == undefined || $scope.person.Firstname == undefined || $scope.person.Patronomyc == undefined;
    };

    $scope.startExam = function() {
           
            //запросить вопросы с сервера
            $http.get("/Query/GetAll").success(function(response) {
                $scope.querys = response;
            });

            //начать показывать вопросы по одному , добавляя отвты на эти вопросы в массив

            //отправить ФИО персона и все вопросы с ответами пользователя на сервер (вопрос + коллекция выбранных ответов)

        
    }

}); 