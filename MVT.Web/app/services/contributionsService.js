'use strict';
app.factory('contributionsService', ['$http', function ($http) {

    var contributionsServiceFactory = {};

    var _getContributions = function () {

        return $http.get(serviceBase + 'api/Contribution').then(function (results) {
            debugger;
            return results;
        });
    };

    var _deleteContribution = function (id) {

        return $http.delete(serviceBase + 'api/Contribution/' + id).then(function (results) {
            debugger;
            return results;
        });
    };

    debugger;
    contributionsServiceFactory.getContributions = _getContributions;
    contributionsServiceFactory.deleteContribution = _deleteContribution;
    return contributionsServiceFactory;

}])