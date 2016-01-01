'use strict';
app.controller('projectsController', ['$scope', 'projectsService', function ($scope, projectsService) {

    $scope.projects = [];
    $scope.savedSuccessfully = false;
    $scope.message = "";
    $scope.addproject = {
        Name: "",
        Description: "",
    };
    projectsService.getProjects().then(function (results) {
        debugger;
        $scope.projects = results.data;

    }, function (error) {

    });
    $scope.AddProject = function () {

        projectsService.saveProject($scope.addproject).then(function (response) {
            $scope.savedSuccessfully = true;
            $scope.message = "Project has been added successfully";      
        },
         function (response) {
         
             $scope.message = "Failed to register user due to some technical problem";
         });
    };
    $scope.deleteproject = function (idx, index,event) {
        debugger;
        projectsService.deleteProject(idx).then(function (result) {           
            $scope.projects.splice(index, 1);                      
        }, function (error) {
        });
        event.preventDefault();
    };
    $scope.editproject = function (idx,event) {
        alert("ufff");
        event.preventDefault();
    };

}]);