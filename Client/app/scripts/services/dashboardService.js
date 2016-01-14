'use strict';
angular.module('authJsApp').factory('dashboardService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:55602/';
    var dashboardServiceFactory = {};

    var _getdashboard = function () {

        return $http.post(serviceBase + 'api/account/home').then(function (results) {
            return results;
        });
    };

    dashboardServiceFactory.isAuth = _getdashboard;


    return dashboardServiceFactory;

}]);