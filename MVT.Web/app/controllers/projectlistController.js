'use strict';
app.controller('projectlistController', ['$scope', '$location', 'projectlistService', function ($scope,$location, projectlistService) {

    $scope.projects = [];
    $scope.showModal = false;
    $scope.projectname = '';
    $scope.description = '';
   
    $scope.Contributor = {
       
        contributor: "",
        projectId: 0,
        ammount:0
        
    };
    $scope.toggleModal = function (id, name, description) {
        $scope.Contributor.projectId = id;
        var username = projectlistService.userName(function (results) {
        return results;
        });
        if (username == "fake") {
            $location.path('/login');
            return;
        }
        $scope.Contributor.contributor = username;
        $scope.projectname = name;
        $scope.description = description;
        $scope.reset();
        $scope.showModal = !$scope.showModal;
        };
        projectlistService.getProjects().then(function (results) {
        $scope.projects = results.data;
    }, function (error) {
    });
    $scope.success = false;
  


   


    $scope.Adddonation = function (user) {
        debugger;
        projectlistService.saveDonation(user).then(function (response) {
            $scope.success = true; $scope.showModal = !$scope.showModal;
        },
            function (response) {

                $scope.message = "Error! Try Again";
            });
    };

    $scope.reset = function () {
        $scope.Contributor.ammount = '';     
    };



   

}]);
app.directive('modal', function () {
    return {
        template: '<div class="modal fade">' +
            '<div class="modal-dialog">' +
              '<div class="modal-content">' +
                '<div class="modal-header">' +
                  '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                  '<h4 class="modal-title">{{ title }}</h4>' +
                '</div>' +
                '<div class="modal-body" ng-transclude></div>' +
              '</div>' +
            '</div>' +
          '</div>',
        restrict: 'E',
        transclude: true,
        replace: true,
        scope: true,
        link: function postLink(scope, element, attrs) {
            scope.title = attrs.title;

            scope.$watch(attrs.visible, function (value) {
                if (value == true) {
                    $(element).modal('show');                   
                }
                else {
                    $(element).modal('hide');
                }
            });

            $(element).on('shown.bs.modal', function () {
                scope.$apply(function () {
                    scope.$parent[attrs.visible] = true;
                });
            });

            $(element).on('hidden.bs.modal', function () {
                scope.$apply(function () {
                    scope.$parent[attrs.visible] = false;
                });
            });
        }
    };
});