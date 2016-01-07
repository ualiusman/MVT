'use strict';
app.controller('donationsController', ['$scope', 'donationsService', function ($scope, donationsService) {

    $scope.donations = [];
    $scope.savedSuccessfully = false;
    $scope.message = "";
    $scope.addDonation = {
        projectId: 0,
        needyId :0,
        ammount: 0,
    };
    donationsService.getDonations().then(function (results) {
        debugger;
        $scope.donations = results.data;

    }, function (error) {

    });
    $scope.saveDonation = function (isValid) {
        if (isValid.$valid) {
                save();
        }
    };
    $scope.deleteDonation = function (idx, index, event) {
        debugger;
        donationsService.deleteDonation(idx).then(function (result) {
            $scope.donations.splice(index, 1);
        }, function (error) {
        });
        event.preventDefault();
    };



    var save = function () {
        donationsService.saveDonation($scope.addDonation).then(function (response) {
            $scope.savedSuccessfully = true;
            $scope.message = "Donation has been added successfully";
            $scope.addDonation.reset();
            $scope.donations.push(response.data);
        },
             function (response) {

                 $scope.message = "Error! Try Again";
             });
    };

}]);