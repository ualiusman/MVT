'use strict';
app.factory('projectsService', ['$http', function ($http) {

    var projectsServiceFactory = {};
   
    var _getProjects = function () {

        return $http.get(serviceBase + 'api/Project').then(function (results) {
            debugger;
            return results;
        });
    };

    var _getProject = function (id) {
        return $http.get(serviceBase + 'api/Project/' + id).then(function (results) {
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

    var _updateProject = function (id,project) {
        return $http.put(serviceBase + 'api/Project/' + id, project).then(function (response) {
            return response;
        });
    };
    debugger;
    projectsServiceFactory.getProjects = _getProjects;
    projectsServiceFactory.getProject = _getProject;
    projectsServiceFactory.deleteProject = _deleteProject;
    projectsServiceFactory.saveProject = _saveProject;
    projectsServiceFactory.updateProject = _updateProject;
    return projectsServiceFactory;

}])