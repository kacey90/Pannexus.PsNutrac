(function () {
    'use strict';

    angular.module('app').controller('app.views.schemes.newBid', [
        '$scope', '$state', '$stateParams', 'abp.services.app.scheme', 'abp.services.app.crop', 'abp.services.app.tenor', 'abp.services.app.payment',
        function ($scope, $state, $stateParams, schemeService, cropService, tenorService, paymentService) {
            var vm = this;

            vm.scheme = '',

            function loadScheme() {
                abp.ui.setBusy();
                schemeService.getAsync({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.scheme = result;
                }).finally(function () {
                    abp.ui.clearBusy();
                });
            }

            loadScheme();

            vm.save = function () {
                investmentService
                    .createAsync(vm.investment)
                    .success(function () {
                        abp.notify.success("Successfully saved.");
                        $uibModalInstance.close();
                    });
            };


        }
    ]);
})();
