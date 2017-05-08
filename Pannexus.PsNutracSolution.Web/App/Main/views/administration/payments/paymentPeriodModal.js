(function () {
    'use strict';

    angular.module('app').controller('app.views.paymentPeriod.modal', [
        '$scope', '$uibModalInstance', 'abp.services.app.payment',
        function ($scope, $uibModalInstance, paymentService) {
            var vm = this;

            vm.paymentPeriod = {
                periodInDays: 2
            };

            vm.save = function () {
                abp.ui.setBusy();
                paymentService.createPaymentPeriodAsync(vm.paymentPeriod)
                    .success(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        abp.ui.clearBusy();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };
        }
    ]);

})();
