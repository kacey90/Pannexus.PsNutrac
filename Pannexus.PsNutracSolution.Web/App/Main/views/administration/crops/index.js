(function () {
    'use strict';

    angular.module('app').controller('app.views.crops.index', [
            '$scope', '$uibModal', 'abp.services.app.crop',
            function ($scope, $uibModal, cropService) {
                var vm = this;

                vm.crops = [];

                function getCrops() {
                    abp.ui.setBusy(null,
                        cropService.getAllCropsPaged({}).success(function (data) {
                            vm.crops = data.items;
                        })
                    );
                }

                vm.openNewCropModal = function () {
                    var modalInstance = $uibModal.open({
                        templateUrl: '/App/Main/views/administration/crops/createModal.cshtml',
                        controller: 'app.views.crops.createModal as vm',
                        backdrop: 'true'
                    });

                    modalInstance.result.then(function () {
                        getCrops();
                    });
                };

                getCrops();
            }
    ]);
})();
