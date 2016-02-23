var app = angular.module('app');

app.controller('ExamCtrl', function ($scope, $http, $rootScope) {

    $scope.isNextVisible = true;
    $scope.ansversList = [];

    $scope.PersonsAnswers = [];

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

        //добавить выбранный ответ в массив ответов (ЭТО ТОТ ЖЕ ВОПРОС ТОЛЬКО С МЕНЬШИМ КОЛИЧЕСТВОМ ВАРИАНТОВ ОТВЕТОВ)
        //var ansver = {
        //    Id:$scope.currentQuery.Id,
        //    Text: $scope.currentQuery.Text,
        //    VariantsAnsver: selectedAnswers
        //}


        
        for (var i = 0; i < selectedAnswers.length; i++) {
            var PersonsAnswer = {
                PerosnId: $rootScope.person.Id,
                //Person: $rootScope.person,
                QueryId: $scope.currentQuery.Id,
                //Query: $scope.currentQuery,
                VariantAnsverId: selectedAnswers[i].Id,
                //VariantAnsver: selectedAnswers[i]

            }
            $scope.PersonsAnswers.push(PersonsAnswer);
        }

        //$scope.ansversList.push(ansver);
    }

    $scope.examFinish = function () {

        addAnswer();

        //$rootScope.person.Answers = $scope.ansversList;

        //------------------------------работает через вспомогательный класс
        //var PersonsQuerysAnswer = {
        //    Person: $rootScope.person,
        //    PersonsAnswers: $scope.ansversList
        //}

        //------------------ не работает пока пользователь с ответами
        //$http.post("/Person/SavePersonsExam", PersonsQuerysAnswer)
        //.success(function (response) {

        //});

        //------------------коллекция ответов пользователя

        //$http.post("/Person/SavePersonsExam", $scope.ansversList)
        //.success(function (response) {

        //});

        //------------------соединительная таблица PersonAnswers
        $rootScope.person.PersonsAnswers = $scope.PersonsAnswers;

        $http.post("/Person/SavePersonsExam", $rootScope.person)
        .success(function (response) {

        });
    }

    var person = $rootScope.person;
});