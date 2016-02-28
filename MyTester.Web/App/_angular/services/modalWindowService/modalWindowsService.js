var app = angular.module('app');

app.service('modalWindowsService', function ($modal) {
    //модальное окно да-нет
    this.showYesNoCancel = function (text, okCallBack, noCallBack, cancelCallback) {
        // показать модальное окно
        var modalInstance = $modal.open({
            templateUrl: "_angular/services/modalWindowService/yesNoCancelModalWindow.html",
            controller: "modalWindowCtrl",
            resolve: {
                text: function () {
                    return text;
                }
            }
        }
        );

        modalInstance.result.then(
               function (data) {
                   if (data === "ok") {
                       okCallBack();
                   }
                   else if (data === "no") {
                       noCallBack();
                   } else {
                       cancelCallback();
                   }
               }, function (data) { });
    };
});