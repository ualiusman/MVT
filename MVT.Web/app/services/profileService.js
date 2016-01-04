'use strict';
app.factory('profileService', ['$http', 'localStorageService', function ($http, localStorageService) {
    var profileServiceFactory = {};

    var _getProfileData = function () {
        var data = localStorageService.get('authorizationData');
        var userName = "fake";
        if (data != null)
            userName = data.userName;
        return $http.get(serviceBase + 'api/account/profile/' + userName).then(function (results) {
            return results;
        });

    };

    var _updateProfile = function (profile) {
        debugger;
        return $http.post(serviceBase + 'api/account/profile', profile).then(function (response) {
            return response;
        });
    };


    profileServiceFactory.getProfileData = _getProfileData;
    profileServiceFactory.updateProfile = _updateProfile;
    return profileServiceFactory;
}])