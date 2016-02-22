var app = angular.module('app');

app.controller('loginCtrl', function ($scope, $http, $rootScope) {

    $scope.person = {};

    $scope.isNotFullName = function() {
        return $scope.person.Surname == undefined || $scope.person.Firstname == undefined || $scope.person.Patronymic == undefined;
    };

    $scope.saveFullName = function() {
        $rootScope.person = $scope.person;
    };
    
}); 