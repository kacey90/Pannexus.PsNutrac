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
                //bidOpenDate: '08/05/2017',
                //bidCloseDate: '2017/05/31',
                //schemeStartDate: '08/05/2017',
                bidOpenDate: '',
                bidCloseDate: '',
                schemeStartDate: '',
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


            $scope.today = function () {
                $scope.dt = new Date();
            };
            $scope.today();

            $scope.clear = function () {
                $scope.dt = null;
            };

            $scope.inlineOptions = {
                customClass: getDayClass,
                minDate: new Date(),
                showWeeks: true
            };

            $scope.dateOptions = {
                //dateDisabled: disabled,
                formatYear: 'yy',
                maxDate: new Date(2020, 5, 22),
                minDate: new Date(),
                startingDay: 1
            };

            // Disable weekend selection
            //function disabled(data) {
            //    var date = data.date,
            //      mode = data.mode;
            //    return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
            //}

            $scope.toggleMin = function () {
                $scope.inlineOptions.minDate = $scope.inlineOptions.minDate ? null : new Date();
                $scope.dateOptions.minDate = $scope.inlineOptions.minDate;
            };

            $scope.toggleMin();

            $scope.open1 = function () {
                $scope.popup1.opened = true;
            };

            $scope.open2 = function () {
                $scope.popup2.opened = true;
            };

            $scope.open3 = function () {
                $scope.popup3.opened = true;
            };

            $scope.open4 = function () {
                $scope.popup4.opened = true;
            };

            $scope.setDate = function (year, month, day) {
                $scope.dt = new Date(year, month, day);
            };

            $scope.formats = ['MM/dd/yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
            $scope.format = $scope.formats[0];
            $scope.altInputFormats = ['M!/d!/yyyy'];

            $scope.popup1 = {
                opened: false
            };

            $scope.popup2 = {
                opened: false
            };

            $scope.popup3 = {
                opened: false
            };

            $scope.popup4 = {
                opened: false
            };

            var tomorrow = new Date();
            tomorrow.setDate(tomorrow.getDate() + 1);
            var afterTomorrow = new Date();
            afterTomorrow.setDate(tomorrow.getDate() + 1);
            $scope.events = [
              {
                  date: tomorrow,
                  status: 'full'
              },
              {
                  date: afterTomorrow,
                  status: 'partially'
              }
            ];

            function getDayClass(data) {
                var date = data.date,
                  mode = data.mode;
                if (mode === 'day') {
                    var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

                    for (var i = 0; i < $scope.events.length; i++) {
                        var currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                        if (dayToCheck === currentDay) {
                            return $scope.events[i].status;
                        }
                    }
                }

                return '';
            }
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
    })
    .directive('currencyInput', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ctrl) {

                return ctrl.$parsers.push(function (inputValue) {
                    var inputVal = element.val();

                    //clearing left side zeros
                    while (inputVal.charAt(0) == '0') {
                        inputVal = inputVal.substr(1);
                    }

                    inputVal = inputVal.replace(/[^\d.\',']/g, '');

                    var point = inputVal.indexOf(".");
                    if (point >= 0) {
                        inputVal = inputVal.slice(0, point + 3);
                    }

                    var decimalSplit = inputVal.split(".");
                    var intPart = decimalSplit[0];
                    var decPart = decimalSplit[1];

                    intPart = intPart.replace(/[^\d]/g, '');
                    if (intPart.length > 3) {
                        var intDiv = Math.floor(intPart.length / 3);
                        while (intDiv > 0) {
                            var lastComma = intPart.indexOf(",");
                            if (lastComma < 0) {
                                lastComma = intPart.length;
                            }

                            if (lastComma - 3 > 0) {
                                intPart = intPart.slice(0, lastComma - 3) + "," + intPart.slice(lastComma - 3);
                            }
                            intDiv--;
                        }
                    }

                    if (decPart === undefined) {
                        decPart = "";
                    }
                    else {
                        decPart = "." + decPart;
                    }
                    var res = intPart + decPart;

                    if (res !== inputValue) {
                        ctrl.$setViewValue(res);
                        ctrl.$render();
                    }
                    return inputVal.replace(/,/g, '');

                });

            }
        };
    })
    .directive('datepickerLocaldate', ['$parse', function ($parse) {
        var directive = {
            restrict: 'A',
            require: ['ngModel'],
            link: link
        };
        return directive;

        function link(scope, element, attr, ctrls) {
            var ngModelController = ctrls[0];

            // called with a JavaScript Date object when picked from the datepicker
            ngModelController.$parsers.push(function (viewValue) {
                if (!viewValue) {
                    return undefined;
                }
                // undo the timezone adjustment we did during the formatting
                viewValue.setMinutes(viewValue.getMinutes() - viewValue.getTimezoneOffset());
                // we want date in Unix timestamp
                return Math.round(new Date(viewValue).getTime() / 1000.0);
            });

            // called with a Unix timestamp to format
            ngModelController.$formatters.push(function (modelValue) {
                if (!modelValue) {
                    return undefined;
                }
                // date constructor will apply timezone deviations from UTC (i.e. if locale is behind UTC 'dt' will be one day behind)
                var dt = new Date(modelValue * 1000);
                // 'undo' the timezone offset again (so we end up on the original date again)
                dt.setMinutes(dt.getMinutes() + dt.getTimezoneOffset());
                return dt;
            });
        }
    }]);
})();
