'use strict';
app.factory('projectlistService', ['$http','localStorageService', function ($http,localStorageService) {

    var projectlistServiceFactory = {};

    var _getProjects = function () {

        return $http.get(serviceBase + 'api/Project').then(function (results) {
            debugger;
            return results;
        });
    };
    var _userName = function () {
        var data = localStorageService.get('authorizationData');
        var uname = "fake";
        if (data != null)
            uname = data.userName;
        return uname;
    };
    var _saveDonation = function (contribution) {
        return $http.post(serviceBase + 'api/Contribution', contribution).then(function (response) {
            return response;
        });

    };
    debugger;
    projectlistServiceFactory.getProjects = _getProjects;
    projectlistServiceFactory.userName = _userName;
    projectlistServiceFactory.saveDonation = _saveDonation;
    return projectlistServiceFactory;

}])