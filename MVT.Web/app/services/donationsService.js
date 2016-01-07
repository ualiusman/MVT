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

    debugger;
    donationsServiceFactory.getDonations = _getDonations;
    donationsServiceFactory.deleteDonation = _deleteDonation;
    donationsServiceFactory.saveDonation = _saveDonation;
    return donationsServiceFactory;

}])