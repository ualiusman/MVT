'use strict';
app.factory('profileService', ['$http', 'localStorageService', function ($http, localStorageService) {
    var profileServiceFactory = {};

    var _getProfileData = function () {
        debugger;
        var data = localStorageService.get('authorizationData');
        var userName = "";
        if (data != null)
            userName = data.userName;
        return $http.get(serviceBase + 'api/account/profile/' + userName).then(function (results) {
            debugger;
            return results;
        });

    };


    profileServiceFactory.getProfileData = _getProfileData;
    return profileServiceFactory;
}])