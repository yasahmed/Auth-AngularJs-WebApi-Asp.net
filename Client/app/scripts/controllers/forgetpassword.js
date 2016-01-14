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
angular.module('authJsApp').controller('ForgetPasswordCtrl', ['$scope', 'authService', function ($scope, authService) {


    $scope.sentSuccessfully = false;
	$scope.showLoader = false;
    $scope.message = "";

    $scope.recover = {
        email:""
    };
	
	
	   $scope.getbackmypass = function () {
	
	   $scope.showLoader = true;
       authService.recovermypassword($scope.recover).then(function (response) {

            $scope.sentSuccessfully = true;
            $scope.message = "Votre mot de passe est envoyé à votre adresse email avec succée";
			$scope.showLoader = false;
           

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

}]);
