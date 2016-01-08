'use strict';
app.factory('donationsService', ['$http', function ($http) {

    var donationsServiceFactory = {};

    var _getDonations = function () {

        return $http.get(serviceBase + 'api/Donation').then(function (results) {
            debugger;
            return results;
        });
    };

    var _deleteDonation = function (id) {

        return $http.delete(serviceBase + 'api/Donation/' + id).then(function (results) {
            debugger;
            return results;
        });
    };
    var _saveDonation = function (donation) {
        return $http.post(serviceBase + 'api/Donation', donation).then(function (response) {
            return response;
        });

    };
    var _getNeedys = function () {

        return $http.get(serviceBase + 'api/Needy').then(function (results) {
            debugger;
            return results;
        });
    };
    var _getProjects = function () {

        return $http.get(serviceBase + 'api/Project').then(function (results) {
            debugger;
            return results;
        });
    };
    debugger;
    donationsServiceFactory.getDonations = _getDonations;
    donationsServiceFactory.deleteDonation = _deleteDonation;
    donationsServiceFactory.saveDonation = _saveDonation;
    donationsServiceFactory.getNeedys = _getNeedys;
    donationsServiceFactory.getProjects = _getProjects;
    return donationsServiceFactory;

}])