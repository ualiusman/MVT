var serviceBase = 'http://localhost:60384/';

var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

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
    $routeProvider.otherwise({ redirectTo: "/home" });
});


app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});
app.constant('serviceBase', 'http://localhost:60384/');
app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

