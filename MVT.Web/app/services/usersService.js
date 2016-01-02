'use strict';
app.factory('usersService', ['$http', function ($http) {

    var usersServiceFactory = {};

    var _getUsers = function () {

        return $http.get(serviceBase + 'api/users').then(function (results) {
            debugger;
            return results;
        });
    };
    debugger;
    usersServiceFactory.getUsers = _getUsers;

    return usersServiceFactory;

}])