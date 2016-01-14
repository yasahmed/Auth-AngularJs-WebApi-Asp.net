// 'use strict';
//
// /**
//  * @ngdoc function
//  * @name authJsApp.controller:AboutCtrl
//  * @description
//  * # AboutCtrl
//  * Controller of the authJsApp
//  */
// angular.module('authJsApp')
//   .controller('SigninCtrl', function ($scope) {
//     $scope.awesomeThings = [
//       'HTML5 Boilerplate',
//       'AngularJS',
//       'Karma'
//     ];
//   });

'use strict';
angular.module('authJsApp').controller('SignInCtrl', ['$scope', '$location', 'authService','dashboardService', function ($scope, $location, authService,dashboardService) {


    dashboardService.isAuth().then(function (results) {
	$location.path('/dashboard');
    }, function (error) { 
    });

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";
	$scope.showLoader = false;

    $scope.login = function () {
	
        $scope.showLoader = true;
        authService.login($scope.loginData).then(function (response) {

            $location.path('/dashboard');
			

        },
         function (err) {
		     $scope.showLoader = false;
             $scope.message = err.error_description;
         });
    };

}]);
