(function () {
    'use strict';

    angular.module('app').controller('app.views.schemes.newScheme', [
        '$scope', '$location', '$state', '$stateParams', 'abp.services.app.scheme', 'abp.services.app.crop', 'abp.services.app.tenor', 'abp.services.app.payment',
        function ($scope, $location, $state, $stateParams, schemeService, cropService, tenorService, paymentService) {
            var vm = this;

            vm.scheme = {
                schemeCode: '',
                schemeName: '',
                cropId: '',
                cropName: 'CropName',
                totalSchemeUnits: '',
                valuePerUnit: '',
                floorInvestUnit: '',
                ceilingInvestUnit: '',
                returnRate: '',
                tenorId: '',
                tenorInDays: '364',
                bidOpenDate: '08/05/2017',
                bidCloseDate: '2017/05/31',
                schemeStartDate: '08/05/2017',
                paymentPeriodId: '',
                paymentPeriodInDays: '91',
                isActive: true
            };

            vm.crops = [];
            function getCrops() {
                cropService.getAllCropsPaged({}).success(function (data) {
                    vm.crops = data.items
                });
            }

            vm.tenors = [];
            function getTenors() {
                tenorService.getAllTenorsAsync({}).success(function (data) {
                    vm.tenors = data.items
                });
            }

            vm.paymentPeriods = [];
            function getPaymentPeriods() {
                paymentService.getAllPaymentPeriodsAsync({}).success(function (data) {
                    vm.paymentPeriods = data.items
                });
            }

            getCrops();
            getTenors();
            getPaymentPeriods();

            vm.save = function () {
                abp.ui.setBusy();
                schemeService.createAsync(vm.scheme).success(function () {
                    abp.notify.success('Scheme added successfully!');
                    $location.path('/schemes');
                }).finally(function () {
                    abp.ui.clearBusy();
                })
            };

            vm.cancel = function () {
                $state.go('schemes');
            }
        }
    ]);
})();
