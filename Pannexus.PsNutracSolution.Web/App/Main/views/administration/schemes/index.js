﻿(function () {
    'use strict';

    angular.module('app').controller('app.views.schemes.index', [
        '$scope', 'abp.services.app.scheme',
        function ($scope, schemeService) {
            var vm = this;

            vm.schemes = [];
            vm.currentDate = abp.clock.now;

            function getSchemes() {
                abp.ui.setBusy(null,
                    schemeService.getSchemesPagedList({}).success(function (data) {
                        vm.schemes = data.items;
                    })
                );
            }

            vm.isBiddingOn = function (scheme) {
                return (abp.clock.now >= scheme.bidOpenDate && abp.clock.now <= scheme.bidCloseDate)
            }

            getSchemes();
        }
    ]);
})();