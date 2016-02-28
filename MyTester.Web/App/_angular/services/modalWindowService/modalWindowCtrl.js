angular.module('app').controller('modalWindowCtrl', function ($scope, $modalInstance, $log, $rootScope, text) {
    $scope.text = text;

    $scope.ok = function () {
        $modalInstance.close("ok");
    };

    $scope.no = function () {
        $modalInstance.close("no");
    };

    $scope.cancel = function () {
        $modalInstance.close("cancel");
    };
});