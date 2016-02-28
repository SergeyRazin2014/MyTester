angular.module('app').controller('modalWindowCtrl', function ($scope, $uibModalInstance, $log, $rootScope, text) {
    $scope.text = text;

    $scope.ok = function () {
        $uibModalInstance.close("ok");
    };

    $scope.no = function () {
        $uibModalInstance.close("no");
    };

    
});