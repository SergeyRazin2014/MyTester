var app = angular.module('app');

app.controller('ExamCtrl', function ($scope, $http, $rootScope) {

    $scope.isNextVisible = true;
    $scope.ansversList = [];

    //запросить вопросы с сервера
    $http.get("/Query/GetAll")
        .success(function (response) {
            $scope.querys = response;

            $scope.currentQuery = _.first($scope.querys);
            $scope.currentQueryIndex = 0;
        });

    $scope.next = function () {

        addAnswer();


        //если это последний вопрос
        if ($scope.currentQueryIndex == $scope.querys.length - 2) {
            $scope.isNextVisible = false;
        }

        $scope.currentQueryIndex += 1;
        $scope.currentQuery = $scope.querys[$scope.currentQueryIndex];
    }

    
    function addAnswer() {

        //выбранные ответы пользователем для текущего вопроса
        var selectedAnswers = _.filter($scope.currentQuery.VariantsAnsver, function (variantAnsver) { return variantAnsver.IsSelected === true; });

        //добавить выбранный ответ в массив ответов
        var ansver = {
            Text: $scope.currentQuery.Text,
            VariantsAnsver: selectedAnswers
        }

        $scope.ansversList.push(ansver);
    }

    $scope.examFinish = function () {

        addAnswer();

        $rootScope.person.Answers = $scope.ansversList;

        $http.post("/Person/SavePersonsExam", $rootScope.person)
        .success(function (response) {

        });
    }

    var person = $rootScope.person;
});