'use strict';
app.controller('contributionsController', ['$scope', 'contributionsService', function ($scope, contributionsService) {

    $scope.contributions = [];

    contributionsService.getContributions().then(function (results) {
        debugger;
        $scope.contributions = results.data;

    }, function (error) {

    });

    $scope.deleteContribution = function (idx, index, event) {
        debugger;
        contributionsService.deleteContribution(idx).then(function (result) {
            $scope.contributions.splice(index, 1);
        }, function (error) {
        });
        event.preventDefault();
    };

}]);