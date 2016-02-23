var app = angular.module('app');

app.controller('SummaryReportCtrl', function ($scope, $http, $rootScope) {




    //получить всех пользователей с ответами на вопросы
    $http.get("/Person/GetAll")
                    .success(function (response) {
                        $scope.persons = response;

                        //$scope.PersonsAnswers = [];

                        //for (var i = 0; i < $scope.persons.length; i++) {
                        //    for (var j = 0; j < $scope.persons.PersonsAnswers.length; j++) {
                        //        $scope.PersonsAnswers.push($scope.persons[i].PersonsAnswers[j]);
                        //    }
                        //}

            //получить все правильно отвеченные вопросы


        });




});