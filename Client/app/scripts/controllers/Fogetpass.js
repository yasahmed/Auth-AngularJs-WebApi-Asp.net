'use strict';

/**
 * @ngdoc function
 * @name authJsApp.controller:AboutCtrl
 * @description
 * # AboutCtrl
 * Controller of the authJsApp
 */
angular.module('authJsApp')
  .controller('FogetpassCtrl', 'authService',function ($scope,authService) {
    
	
    $scope.sentSuccessfully = false;
    $scope.message = "";

    $scope.recover = {
        email:""
    };
	
	
	   $scope.signUp = function () {
	$scope.registration.response = $scope.gRecaptchaResponse;
	
       authService.recovermypassword($scope.recover).then(function (response) {

            $scope.sentSuccessfully = true;
            $scope.message = "Checl ur inbox";
           

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
			 
			 if(response.data.modelState === undefined)$scope.message = response.data.message;
			 else
             $scope.message = "Failed to register user due to:" + errors.join(' ');
         });
    };

	
  });
