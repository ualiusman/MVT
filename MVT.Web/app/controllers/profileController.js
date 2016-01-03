'use strict';
app.controller('profileController', ['$scope', 'profileService', function ($scope, profileService) {
    $scope.profile = {};

    profileService.getProfileData().then(function (results) {
        debugger;
        $scope.profile = results.data;

    }, function (error) {

    });

}]);