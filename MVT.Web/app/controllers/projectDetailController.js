'use strict';
app.controller('projectDetailController', ['$scope', '$routeParams', 'projectsService', 'contributionsService', 'projectlistService', 'donationsService', '$filter', function ($scope, $routeParams, projectsService, contributionsService, projectlistService, donationsService, $filter) {
    $scope.projects = [];
    $scope.showModal = false;
    $scope.pId = $routeParams.projectId;
    $scope.project = {
        name: "",
        description: "",
        id: 0
    };

    $scope.Contributor = {

        contributor: "",
        projectId: 0,
        ammount: 0

    };

    $scope.series = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    $scope.seriesDonation = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    //var projectId = $routeParams.projectId;
    projectsService.getProject($routeParams.projectId).then(function (results) {
        $scope.project = results.data;
    }, function (error) {

    });
    contributionsService.getMonthlyContribution($routeParams.projectId).then(function (results) {
        debugger;
        angular.forEach(results.data, function (value, index) {

            debugger;
            $scope.series[index] = parseFloat(value);
        });
    }, function (error) {

    });
    donationsService.getMonthlyDonation($routeParams.projectId).then(function (results) {
        debugger;
        angular.forEach(results.data, function (value, index) {
            debugger;
            $scope.seriesDonation[index] = parseFloat(value);
        });
    }, function (error) {

    });


   



    projectsService.getProjects().then(function (results) {
        debugger;
        $scope.projects = results.data;

    }, function (error) {

    });
    $scope.highchartsNG = {
    
        chart: {
            type: 'spline'
        },
        title: {
            text: 'Monthy contributions and Donations 2016',

        },

        xAxis: {

            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
       'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],

            title: {
                text: 'Name of Months'
            }
        },
        yAxis: {
            title: {
                text: 'Total ammount in month (Rs.)'
            },
            min: 0
        },

        plotOptions: {
            spline: {
                marker: {
                    enabled: true
                }
            }

        },
        tooltip: {
            formatter: function () {

                //var  time = new Date(this.key);
                //var month=time.getMonth()+1;
                alert('asdasd');
                return 'Month:' + this.key + '   Total Contribution Amount:' + this.y + ' (Rs.)';
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle',
            borderWidth: 0
        },
        series: [{ name: 'Contribution', data: $scope.series, showInLegend: true },
                 { name: 'Donation', data: $scope.seriesDonation, showInLegend: true }],
        credits: {
            enabled: false
        }
    }



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
        $scope.contributor.ammount = '';
    };

}]);

