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



        for (var i = 0; i < selectedAnswers.length; i++) {
            var PersonsAnswer = {
                PersonId: $rootScope.person.Id,
                QueryId: $scope.currentQuery.Id,
                VariantAnsverId: selectedAnswers[i].Id,
            }
            $scope.PersonsAnswers.push(PersonsAnswer);
        }

    }

    $scope.examFinish = function () {
        addAnswer();

        $rootScope.person.PersonsAnswers = $scope.PersonsAnswers;

        $http.post("/Person/SavePersonsExam", $rootScope.person)
        .success(function (response) {
        });
    }
});