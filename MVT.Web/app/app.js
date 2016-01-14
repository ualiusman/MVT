var serviceBase = 'http://localhost:60384/';

var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'ngAnimate', 'highcharts-ng']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "app/views/signup.html"
    });

    $routeProvider.when("/users", {
        controller: "usersController",
        templateUrl: "/app/views/users.html"
    });
    $routeProvider.when("/projects", {
        controller: "projectsController",
        templateUrl: "/app/views/projects.html"
    });

    $routeProvider.when("/profile", {
        controller: "profileController",
        templateUrl: "/app/views/profile.html"
    });
    $routeProvider.when("/needys", {
        controller: "needysController",
        templateUrl: "/app/views/needys.html"
    });
    $routeProvider.when("/projectlist", {
        controller: "projectlistController",
        templateUrl: "/app/views/projectlist.html"
    });
    $routeProvider.when("/contributions", {
        controller: "contributionsController",
        templateUrl: "/app/views/contributions.html"
    });
    $routeProvider.when("/donations", {
        controller: "donationsController",
        templateUrl: "/app/views/donations.html"
    });

    $routeProvider.when("/donations", {
        controller: "donationsController",
        templateUrl: "/app/views/donations.html"
    });

    $routeProvider.when("/project/:projectId", {
        controller: "projectDetailController",
        templateUrl: "/app/views/project-detail.html"
    });
    $routeProvider.otherwise({ redirectTo: "/home" });
});


app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});
app.constant('serviceBase', 'http://localhost:60384/');
app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

app.controller('folderCtrl', function ($scope, $http) {
    $scope.images = ['../../Asset/Images/images (1).jpg', '../../Asset/Images/helping-others.jpg', '../../Asset/Images/ngo_mysore.jpg', '../../Asset/Images/ngo.jpg', '../../Asset/Images/M_Id_307360_NGO.jpg'];
});

