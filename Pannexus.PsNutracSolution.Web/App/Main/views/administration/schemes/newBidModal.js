(function () {
    'use strict';

    angular.module('app').controller('app.views.investments.createDialog', [
        '$scope', '$uibModalInstance', '$stateParams', 'abp.services.app.investment', 'abp.services.app.scheme', 'schemeId',
        function ($scope, $stateParams, $uibModalInstance, investmentService, schemeService, schemeId) {
            var vm = this;

            vm.investment = {
                userId: abp.session.userId,
                schemeId: schemeId,
                investmentUnit: 1000,
                investmentDate: moment().format('YYYY-MM-DD'),
                isActive: false
            }

            vm.scheme = '';

            function loadScheme() {
                schemeService.getAsync({
                    id: schemeId
                }).success(function (result) {
                    vm.scheme = result;
                })
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

            vm.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };
        }
    ])
    .directive('format', function ($filter) {
        'use strict';

        return {
            require: '?ngModel',
            link: function (scope, elem, attrs, ctrl) {
                if (!ctrl) {
                    return;
                }

                ctrl.$formatters.unshift(function () {
                    return $filter('number')(ctrl.$modelValue);
                });

                ctrl.$parsers.unshift(function (viewValue) {
                    var plainNumber = viewValue.replace(/[\,\.]/g, ''),
                        b = $filter('number')(plainNumber);

                    elem.val(b);

                    return plainNumber;
                });
            }
        };
    });
})();
