(function () {
    'use strict';

    angular.module('app').controller('app.views.paymentPeriod.index', [
        '$scope', '$uibModal', 'abp.services.app.payment',
        function ($scope, $uibModal, paymentService) {
            var vm = this;

            vm.paymentPeriods = [];

            function getPaymentPeriods() {
                abp.ui.setBusy(null,
                    paymentService.getAllPaymentPeriodsAsync({}).success(function (data) {
                        vm.paymentPeriods = data.items;
                    })
                );
            }

            vm.openNewPaymetPeriodModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/administration/payments/paymentPeriodModal.cshtml',
                    controller: 'app.views.paymentPeriod.modal as vm',
                    backdrop: 'true'
                });

                modalInstance.result.then(function () {
                    getPaymentPeriods();
                });
            };

            getPaymentPeriods();
        }
    ]);

})();
