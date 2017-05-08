(function () {
    'use strict';

    angular.module('app').controller('app.views.crops.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.crop',
        function ($scope, $uibModalInstance, cropService) {
            var vm = this;

            vm.crop = {
                code: '',
                name: '',
                description: ''
            };

            vm.save = function () {
                abp.ui.setBusy();
                cropService.createAsync(vm.crop)
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
