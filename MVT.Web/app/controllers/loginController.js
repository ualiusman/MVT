'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function (isValid) {
        debugger;
        if (isValid.$valid) {
            authService.login($scope.loginData).then(function (response) {

                $location.path('/users');

            },
             function (err) {
                 $scope.message = err.error_description;
             });
        }
    };

}]);