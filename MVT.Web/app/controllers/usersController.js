'use strict';
app.controller('usersController', ['$scope', 'usersService', function ($scope, usersService) {

    $scope.users = [];
    debugger;
    usersService.getUsers().then(function (results) {
        debugger;
        $scope.users = results.data;

    }, function (error) {
        
    });

}]);