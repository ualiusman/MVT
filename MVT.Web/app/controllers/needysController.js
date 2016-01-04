'use strict';
app.controller('needysController', ['$scope', 'needysService', function ($scope, needysService) {

    $scope.needys = [];
    $scope.savedSuccessfully = false;
    $scope.isEdit = false;
    $scope.editId = 0;
    $scope.editIndex = 0;
    $scope.message = "";
    $scope.addneedy = {
        name: "",
        location: "",
        phoneNumber:"",
        id: 0,
        reset: function () {
            this.name = "";
            this.location = "";
            this.phoneNumber = "";
            this.id = 0;
        }
    };
    needysService.getNeedys().then(function (results) {
        debugger;
        $scope.needys = results.data;

    }, function (error) {

    });
    $scope.saveNeedy = function (isValid) {
        if (isValid.$valid) {
            if ($scope.isEdit)
                update();
            else
                save();
        }
    };
    $scope.deleteneedy = function (idx, index, event) {
        debugger;
        needysService.deleteNeedy(idx).then(function (result) {
            $scope.needys.splice(index, 1);
        }, function (error) {
        });
        event.preventDefault();
    };
    $scope.editneedy = function (idx, index, event) {
        debugger;
        needysService.getNeedy(idx).then(function (result) {
            debugger;
            $scope.addneedy.name = result.data.name;
            $scope.addneedy.location = result.data.location;
            $scope.addneedy.phoneNumber = result.data.phoneNumber;
            $scope.isEdit = true;
            $scope.editId = idx;
            $scope.editIndex = index;
        }, function (error) {

        });
        event.preventDefault();

    };


    var save = function () {
        needysService.saveNeedy($scope.addneedy).then(function (response) {
            $scope.savedSuccessfully = true;
            $scope.message = "Project has been added successfully";
            $scope.addneedy.reset();
            $scope.needys.push(response.data);
        },
             function (response) {

                 $scope.message = "Error! Try Again";
             });
    };

    var update = function () {
        debugger;
        $scope.addneedy.id = $scope.editId;
        needysService.updateNeedy($scope.editId, $scope.addneedy).then(function (response) {
            $scope.savedSuccessfully = true;
            $scope.isEdit = false;
            $scope.needys[$scope.editIndex].description = $scope.addneedy.description;
            $scope.needys[$scope.editIndex].name = $scope.addneedy.name;
            $scope.needys[$scope.editIndex].phoneNumber = $scope.addneedy.phoneNumber;
            $scope.addneedy.reset();
            $scope.message = "Project has been updated successfully";
        },
             function (response) {

                 $scope.message = "Error! Try Again";
             });
    };

}]);