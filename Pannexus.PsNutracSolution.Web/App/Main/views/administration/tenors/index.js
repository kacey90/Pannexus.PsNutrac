(function () {
    'use strict';

    angular.module('app').controller('app.views.tenors.index', [
        '$scope', '$uibModal', 'abp.services.app.tenor',
        function ($scope, $uibModal, tenorService) {
            var vm = this;

            vm.tenors = [];

            function getTenors() {
                abp.ui.setBusy(null,
                    tenorService.getAllTenorsAsync({}).success(function (data) {
                        vm.tenors = data.items;
                    })
                );
            }

            vm.openNewTenorModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/administration/tenors/createModal.cshtml',
                    controller: 'app.views.tenors.createModal as vm',
                    backdrop: 'true'
                });

                modalInstance.result.then(function () {
                    getTenors();
                });
            };

            getTenors();
        }
    ]);
})();
