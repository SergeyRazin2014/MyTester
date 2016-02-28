var app = angular.module('app', ['ngRoute', 'ui.bootstrap', 'ngAnimate', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider
        .when('/Login', { templateUrl: 'Login/Index.html', controller: '' })
        .when('/Exam', { templateUrl: 'Exam/Index.html', controller: '' })
        .when('/SummaryReport', { templateUrl: 'Reports/SummaryReport/Index.html', controller: '' })
        .when('/PersonAverageReport', { templateUrl: 'Reports/PersonAverageReport/Index.html', controller: '' })
        .when('/DetailReport', { templateUrl: 'Reports/DetailReport/Index.html', controller: '' })
        .when('/Admin', { templateUrl: 'Admin/Index.html', controller: '' })

    $routeProvider.otherwise({ redirectTo: '/Login' });
});