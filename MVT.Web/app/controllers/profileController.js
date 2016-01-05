'use strict';
app.controller('profileController', ['$scope', 'profileService', function ($scope, profileService) {
    $scope.profile = {};
    $scope.isEdit = false;
    $scope.ishide = true;
    $scope.message = "";
    $scope.savedSuccessfully = false;


    $scope.edit = function () {
        $scope.ishide = false;
        $scope.isEdit = true;
      
    };

    $scope.cancel = function () {
        $scope.isEdit = false;
        $scope.ishide = true;
        $scope.message = '';
    };

    $scope.save = function (isValid) {
        if (isValid.$valid){
            profileService.updateProfile($scope.profile).then(function (response) {
                $scope.message = 'Profile Updated..';
                $scope.savedSuccessfully = true;
            }, function (error) {
                $scope.message = 'Profile Not Updated!!';
            });
        }
    };

    profileService.getProfileData().then(function (results) {
        $scope.profile = results.data;
    }, function (error) {

    });

}]);