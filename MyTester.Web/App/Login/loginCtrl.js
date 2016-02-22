var app = angular.module('app');

app.controller('loginCtrl', function ($scope, $http, clientSettings) {

    $scope.person = {};

    $scope.exam = {};


    $scope.startExam = function() {
        if ($scope.person.Surname == undefined || $scope.person.Firstname == undefined || $scope.person.Patronomyc == undefined) {
            alert("заполните все поля...");
        } else {
            
            //запросить вопросы с сервера

            //начать показывать вопросы по одному , добавляя отвты на эти вопросы в массив

            //отправить ФИО персона и все вопросы с ответами пользователя на сервер (вопрос + коллекция выбранных ответов)
            
        }
    }

}); 