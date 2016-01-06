'use strict';
app.factory('needysService', ['$http', function ($http) {

    var needysServiceFactory = {};

    var _getNeedys = function () {

        return $http.get(serviceBase + 'api/Needy').then(function (results) {
            debugger;
            return results;
        });
    };

    var _getNeedy = function (id) {
        return $http.get(serviceBase + 'api/Needy/' + id).then(function (results) {
            debugger;
            return results;
        });
    };

    var _deleteNeedy = function (ID) {

        return $http.delete(serviceBase + 'api/Needy/' + ID).then(function (results) {
            debugger;
            return results;
        });
    };
    var _saveNeedy = function (project) {
        return $http.post(serviceBase + 'api/Needy', project).then(function (response) {
            return response;
        });

    };

    var _updateNeedy = function (id, project) {
        return $http.put(serviceBase + 'api/Needy/' + id, project).then(function (response) {
            return response;
        });
    };
    debugger;
    needysServiceFactory.getNeedys = _getNeedys;
    needysServiceFactory.getNeedy = _getNeedy;
    needysServiceFactory.deleteNeedy = _deleteNeedy;
    needysServiceFactory.saveNeedy = _saveNeedy;
    needysServiceFactory.updateNeedy = _updateNeedy;
    return needysServiceFactory;

}])