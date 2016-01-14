'use strict';

/**
 * @ngdoc function
 * @name authJsApp.controller:AboutCtrl
 * @description
 * # AboutCtrl
 * Controller of the authJsApp
 */
angular.module('authJsApp')
  .controller('AboutCtrl', function ($scope) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  });
