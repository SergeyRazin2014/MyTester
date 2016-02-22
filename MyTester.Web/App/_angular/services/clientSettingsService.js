var app = angular.module('app');

app.service('clientSettings', function () {
    this.getServerInstance = function () {
        return "/Tnt";
    };
});
