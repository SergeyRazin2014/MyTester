var app = angular.module('app');

app.controller('loginCtrl', function ($scope, $http) {

    $scope.person = {};

    $scope.isNotFullName = function() {
        return $scope.person.Surname == undefined || $scope.person.Firstname == undefined || $scope.person.Patronomyc == undefined;
    };
}); 