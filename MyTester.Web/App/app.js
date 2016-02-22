var app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider) {

    $routeProvider.when('/Login',  
    {
        templateUrl: 'Login/Index.html',
        controller: ''
    });

    $routeProvider.otherwise({ redirectTo: '/Login' }); 
});