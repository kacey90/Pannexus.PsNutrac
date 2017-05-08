(function () {
    'use strict';

    angular.module('app').controller('app.views.banks.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.bank',
        function ($scope, $uibModalInstance, bankService) {
            var vm = this;

            vm.bank = {
                bankCode: '',
                bankName: ''
            };

            vm.save = function () {
                abp.ui.setBusy();
                bankService.createAsync(vm.bank)
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
