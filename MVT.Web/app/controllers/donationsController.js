'use strict';
app.controller('donationsController', ['$scope', 'donationsService', function ($scope, donationsService) {

    $scope.donations = [];
    $scope.needys = [];
    $scope.projects = [];
    $scope.savedSuccessfully = false;
    $scope.message = "";
    $scope.addDonation = {
        projectId: 0,
        needyId :0,
        ammount: 0,
        reset: function () {
            this.name = "";
            this.description = "";
            this.ammount = 0;
            $scope.ddlneedies=undefined;
            $scope.ddlprojects=undefined;
        }
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
        debugger;
        var needyId = $scope.ddlneedies;
       
        var projetId = $scope.ddlprojects;
       
        $scope.addDonation.projectId = projetId;
        $scope.addDonation.needyId=needyId;
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
    donationsService.getNeedys().then(function (results) {
        debugger;
        $scope.needys = results.data;

    }, function (error) {

    });
    donationsService.getProjects().then(function (results) {
        debugger;
        $scope.projects = results.data;

    }, function (error) {

    });
}]);