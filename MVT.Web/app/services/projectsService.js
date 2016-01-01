'use strict';
app.factory('projectsService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:60384/';
    var projectsServiceFactory = {};
   
    var _getProjects = function () {

        return $http.get(serviceBase + 'api/Project').then(function (results) {
            debugger;
            return results;
        });
    };

    var _deleteProject = function (ID) {

        return $http.delete(serviceBase + 'api/Project/'+ID).then(function (results) {
            debugger;
            return results;
        });
    };
    var _saveProject = function (project) {
        return $http.post(serviceBase + 'api/Project', project).then(function (response) {
            return response;
        });

    };
    debugger;
    projectsServiceFactory.getProjects = _getProjects;
    projectsServiceFactory.deleteProject = _deleteProject;
    projectsServiceFactory.saveProject = _saveProject;
    return projectsServiceFactory;

}])