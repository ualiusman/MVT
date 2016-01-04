'use strict';
app.controller('projectsController', ['$scope', 'projectsService', function ($scope, projectsService) {

    $scope.projects = [];
    $scope.savedSuccessfully = false;
    $scope.isEdit = false;
    $scope.editId = 0;
    $scope.editIndex = 0;
    $scope.message = "";
    $scope.addproject = {
        name: "",
        description: "",
        id: 0,
        reset: function () {
            this.name= "";
            this.description= "";
            this.id = 0;
        }
    };
    projectsService.getProjects().then(function (results) {
        debugger;
        $scope.projects = results.data;

    }, function (error) {

    });
    $scope.saveProject = function (isValid) {
        if (isValid.$valid) {
            if ($scope.isEdit)
                update();
            else
                save();
        }
    };
    $scope.deleteproject = function (idx, index,event) {
        debugger;
        projectsService.deleteProject(idx).then(function (result) {           
            $scope.projects.splice(index, 1);                      
        }, function (error) {
        });
        event.preventDefault();
    };
    $scope.editproject = function (idx, index, event) {
        debugger;
        projectsService.getProject(idx).then(function (result) {
            debugger;
            $scope.addproject.name = result.data.name;
            $scope.addproject.description = result.data.description;
            $scope.isEdit = true;
            $scope.editId = idx;
            $scope.editIndex = index;
        }, function (error) {

        });
        event.preventDefault();

    };


    var save = function () {
        projectsService.saveProject($scope.addproject).then(function (response) {
            $scope.savedSuccessfully = true;
            $scope.message = "Project has been added successfully";
            $scope.addproject.reset();
            $scope.projects.push(response.data);
        },
             function (response) {

                 $scope.message = "Error! Try Again";
             });
    };

    var update = function () {
        debugger;
        $scope.addproject.id = $scope.editId;
        projectsService.updateProject($scope.editId, $scope.addproject).then(function (response) {
            $scope.savedSuccessfully = true;
            $scope.isEdit = false;
            $scope.projects[$scope.editIndex].description = $scope.addproject.description;
            $scope.projects[$scope.editIndex].name = $scope.addproject.name;
            $scope.addproject.reset();
            $scope.message = "Project has been updated successfully";
        },
             function (response) {

                 $scope.message = "Error! Try Again";
             });
    };

}]);