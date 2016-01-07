'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function (isValid) {
        if (isValid.$valid) {
            authService.login($scope.loginData).then(function (response) {

                var role = JSON.parse(response.roles)[0];
                if(role ==="Admin")
                    $location.path('/users');
                else
                    $location.path('/projectlist');

            },
             function (err) {
                 $scope.message = err.error_description;
             });
        }
    };

}]);