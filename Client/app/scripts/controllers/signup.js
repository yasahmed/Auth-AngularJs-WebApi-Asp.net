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
//   .controller('SignupCtrl', function ($scope) {
//     $scope.awesomeThings = [
//       'HTML5 Boilerplate',
//       'AngularJS',
//       'Karma'
//     ];
//   });


'use strict';
angular.module('authJsApp')
.controller('SignupCtrl', ['$scope', '$location', '$timeout', 'authService','dashboardService', function ($scope, $location, $timeout, authService,dashboardService) {


	
    $scope.savedSuccessfully = false;
	$scope.showLoader = false;
    $scope.message = "";

    $scope.registration = {
        userName: "",
        password: "",
		email: "",
        confirmPassword: "",
		response : ""
    };

    $scope.signUp = function () {
	$scope.registration.response = $scope.gRecaptchaResponse;
	
   //  console.log($scope.gRecaptchaResponse)
       $scope.showLoader = true;
       authService.saveRegistration($scope.registration).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
			$scope.showLoader = false;
            startTimer();

        },
         function (response) {
		 $scope.showLoader = false;
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

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/signin');
        }, 2000);
    }

}]);
