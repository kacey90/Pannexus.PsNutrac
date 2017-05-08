(function () {
    'use strict';

    angular.module('app').controller('app.views.tenors.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.tenor',
        function ($scope, $uibModalInstance, tenorService) {
            var vm = this;

            vm.tenor = {
                tenorInDays: 2,
                isActive: true
            };

            vm.save = function () {
                abp.ui.setBusy();
                tenorService.createAsync(vm.tenor)
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
