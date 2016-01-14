'use strict';

/**
 * @ngdoc overview
 * @name authJsApp
 * @description
 * # authJsApp
 *
 * Main module of the application.
 */
angular
  .module('authJsApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch',
    'LocalStorageModule',
    'noCAPTCHA'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/signup', {
        templateUrl: 'views/signup.html',
        controller: 'SignupCtrl'
      })
      .when('/signin', {
        templateUrl: 'views/signin.html',
        controller: 'SignInCtrl'
      })

      .when('/dashboard', {
        templateUrl: 'views/dashboard.html',
        controller: 'DashboardCtrl'
      })

      .when('/fogetpass', {
        templateUrl: 'views/fogetpass.html',
        controller: 'ForgetPasswordCtrl'
      })

      .otherwise({
        redirectTo: '/signin'
      });
  })
  .config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
})

  .config(['noCAPTCHAProvider', function (noCaptchaProvider) {
    noCaptchaProvider.setSiteKey('6LcsShUTAAAAAM-Pb8SZiuy1a-i2vfnzQ-Cn_8pw');
    noCaptchaProvider.setTheme('dark');
  }
]);
