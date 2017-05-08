(function () {
    'use strict';
    
    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',
        'ui.select',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');

            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in Pannexus.PsNutracNavigationProvider
                    });
                $urlRouterProvider.otherwise('/users');
            }

            if (abp.auth.hasPermission('Pages.Admin')) {
                $stateProvider
                    .state('banks', {
                        url: '/banks',
                        templateUrl: '/App/Main/views/administration/banks/index.cshtml',
                        menu: 'Banks' //Matches to name of 'Users' menu in SampleDemoNavigationProvider
                    })
                    .state('crops', {
                        url: '/crops',
                        templateUrl: '/App/Main/views/administration/crops/index.cshtml',
                        menu: 'Crops'
                    })
                    .state('paymentPeriods', {
                        url: '/payment-periods',
                        templateUrl: '/App/Main/views/administration/payments/paymentPeriods.cshtml',
                        menu: 'PaymentPeriods' //Matches to name of 'Users' menu in SampleDemoNavigationProvider
                    })
                    .state('tenors', {
                        url: '/tenors',
                        templateUrl: '/App/Main/views/administration/tenors/index.cshtml',
                        menu: 'Tenors' //Matches to name of 'Users' menu in SampleDemoNavigationProvider
                    })
                    .state('schemes', {
                        url: '/schemes',
                        templateUrl: '/App/Main/views/administration/schemes/index.cshtml',
                        menu: 'Schemes' //Matches to name of 'Users' menu in SampleDemoNavigationProvider
                    })
                    .state('newScheme', {
                        url: '/schemes/newScheme',
                        templateUrl: '/App/Main/views/administration/schemes/newScheme.cshtml',
                        menu: 'Schemes' //Matches to name of 'Users' menu in SampleDemoNavigationProvider
                    })

                $urlRouterProvider.otherwise('/');
            }

            if (abp.auth.hasPermission('Pages.Tenants')) {
                $stateProvider
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in Pannexus.PsNutracNavigationProvider
                    });
                $urlRouterProvider.otherwise('/tenants');
            }

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in Pannexus.PsNutracNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in Pannexus.PsNutracNavigationProvider
                });
        }
    ]);
})();