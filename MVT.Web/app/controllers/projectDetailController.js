'use strict';
app.controller('projectDetailController', ['$scope', '$routeParams', 'projectsService', 'donationsService', '$filter', function ($scope, $routeParams, projectsService, donationsService, $filter) {
    $scope.projects = [];
    $scope.project = {
        name: "",
        description: "",
        id: 0
    };
    $scope.series = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    //var projectId = $routeParams.projectId;
    projectsService.getProject($routeParams.projectId).then(function (results) {
        $scope.project = results.data;
    }, function (error) {

    });
    donationsService.getDonations().then(function (results) {
        debugger;
       // $scope.donations = results.data;
            angular.forEach(results.data, function (value, index)
            {
                //var dateString = "", month = "", day = "", year = "", jsondatetime = "";
                //dateString = value.Date.slice(6);
                debugger;
               
                var dati = $filter('date')(value.date, 'M');
                //var current = new Date(value.Date);
                //var tempArray = new Array();
                $scope.series[dati - 1] = parseFloat(value.ammount);
            });
    }, function (error) {

    });
    //projectsService.getProjects().then(function (results) {
    //    angular.forEach(results.data, function (value, index)
    //    {
    //        var dateString = "", month = "", day = "", year = "", jsondatetime = "";
    //        dateString = value.Date.substr(6);
    //        current = new Date(parseInt(dateString));
    //        var tempArray = new Array();
    //        series[current.getMonth()] = parseFloat(row.Ammount);
    //    });

    //}, function (error) {

    //});
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
            text: 'Monthy Amounts for the year 2016',

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
                text: 'Total Price ($)'
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
                return 'Month:' + this.key + '   Total Donate Amount:' + this.y + ' ($)';
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle',
            borderWidth: 0
        },
        series: [{ data: $scope.series, showInLegend: false }],
        credits: {
            enabled: false
        }
    }

}]);
