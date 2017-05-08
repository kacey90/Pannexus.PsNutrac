(function () {
    'use strict';

    angular.module('app').controller('app.views.banks.index', [
        '$scope', '$uibModal', 'abp.services.app.bank',
        function ($scope, $uibModal, bankService) {
            var vm = this;

            vm.banks = [];

            function getBanks() {
                abp.ui.setBusy(null,
                    bankService.getAllBanksPaged({}).success(function (data) {
                        vm.banks = data.items;
                    })
                );
            }

            vm.openNewBankModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/administration/banks/createModal.cshtml',
                    controller: 'app.views.banks.createModal as vm',
                    backdrop: 'true'
                });

                modalInstance.result.then(function () {
                    getBanks();
                });
            };

            getBanks();
        }
    ]);
})();
