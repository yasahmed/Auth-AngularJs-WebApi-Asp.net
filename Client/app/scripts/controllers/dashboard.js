'use strict';

/**
 * @ngdoc function
 * @name authJsApp.controller:AboutCtrl
 * @description
 * # AboutCtrl
 * Controller of the authJsApp
 */


  'use strict';
  angular.module('authJsApp')
  .controller('DashboardCtrl', ['$scope', '$location','authService', 'dashboardService', function ($scope, $location,authService,dashboardService) {



      $scope.logout =  function()
      {
        authService.logOut();
        $location.path('/signin');
      }

     $scope.orders = [];

    dashboardService.isAuth().then(function (results) {

;
		$scope.username = authService.getUsername();
		
		

    }, function (error) {
        //alert(error.data.message);
    });

  }]);
