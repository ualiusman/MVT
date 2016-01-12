'use strict';
app.controller('projectDetailController', ['$scope', '$routeParams', 'projectsService', function ($scope, $routeParams, projectsService) {

    $scope.project = {};
    debugger;
    //var projectId = $routeParams.projectId;

    projectsService.getProject(1).then(function (results) {
        debugger;
        $scope.project = results.data;

    }, function (error) {

    });
    


}]);