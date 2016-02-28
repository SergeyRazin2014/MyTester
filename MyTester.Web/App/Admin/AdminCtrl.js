var app = angular.module('app');

app.controller('AdminCtrl', function ($scope, $http, $rootScope, modalWindowsService) {

    






    $scope.clearResult = function () {



        function okCallback() {
            $http.post("/Person/ClearResult");
        }

        function noCallback() {
            //..
        }

        function cancellCallback() {
            //..
        }

        modalWindowsService.showYesNoCancel("Очистить результаты тестирования?", okCallback, noCallback, cancellCallback);
    }



    
});