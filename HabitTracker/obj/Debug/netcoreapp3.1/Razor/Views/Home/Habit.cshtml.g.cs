#pragma checksum "C:\Users\Dinora\Desktop\HabitTracker\HabitTracker\Views\Home\Habit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0fef7e5cadd9ef17ec3af16270d780533b767d1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Habit), @"mvc.1.0.view", @"/Views/Home/Habit.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Dinora\Desktop\HabitTracker\HabitTracker\Views\_ViewImports.cshtml"
using HabitTracker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dinora\Desktop\HabitTracker\HabitTracker\Views\_ViewImports.cshtml"
using HabitTracker.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fef7e5cadd9ef17ec3af16270d780533b767d1e", @"/Views/Home/Habit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9577b22d0b85afd32558d0852a18eb91c61e11ef", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Habit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div ng-app=""WAD"">
    <div ng-view></div>
</div>
<script type=""text/javascript"" src=""https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js""></script>
<script type=""text/javascript"" src=""https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular-route.min.js""></script>
<script type=""text/javascript"">

    var baseURL = 'https://localhost:47547/api/'
    angular
        .module('WAD', ['ngRoute'])
        .config(function ($routeProvider) {
            $routeProvider
                .when('/',
                    {
                        templateUrl: 'pages/habit/index.html',
                        controller: 'IndexController'
                    })
                .when('/create',
                    {
                        templateUrl: 'pages/habit/create.html',
                        controller: 'CreateController'
                    })
                .when('/details/:habitId',
                    {
                        templateUrl: 'pages/habit/details.ht");
            WriteLiteral(@"ml',
                        controller: 'DetailsController'
                    })

                .when('/edit/:habitId',
                    {
                        templateUrl: 'pages/habit/edit.html',
                        controller: 'EditDeleteController'
                    })
                .otherwise({
                    redirectTo: '/'
                });

        })


        .controller('IndexController', ['$scope', '$http', '$filter', function ($scope, $http, $filter) {
            $scope.habits = [];
            $http.get('http://localhost:47547/api/Habit/')
                .then(function (res) {
                    $scope.habits = res.data;

                    for (var i = 0; i < $scope.habits.length; i++) {
                        $scope.habits[i].startDate = $filter('date')($scope.habits[i].startDate, ""mediumDate"");
                    }
                })

        }])


        .controller('CreateController', ['$scope', '$http', '$location', '$filter', ");
            WriteLiteral(@"function ($scope, $http, $location, $filter) {
            $scope.create =
            {
                name: '',
                frequency: '',
                repeat: '',
                startDate: ''
            };
            $scope.create.frequency = parseInt($scope.create.frequency);
            $scope.repeatTypes = ['Daily', 'Weekly', 'Monthly'];

            $scope.Save = function () {
                switch ($scope.create.repeat) {
                    case 'Daily':
                        $scope.create.repeat = 0;
                        break;
                    case 'Weekly':
                        $scope.create.repeat = 1;
                        break;
                    case 'Monthly':
                        $scope.create.repeat = 2;
                        break;
                }

                $http.post('http://localhost:47547/api/Habit/', $scope.create)
                    .then(function (res) {
                        $location.path('/');
                 ");
            WriteLiteral(@"   });
            }
        }])


        .controller('DetailsController', ['$scope', '$http', '$routeParams', '$filter', function ($scope, $http, $routeParams, $filter) {
            $scope.details = [];

            $http.get('http://localhost:47547/api/Habit/' + $routeParams.habitId)
                .then(function (res) {
                    $scope.details = res.data;
                    $scope.details.startDate = $filter('date')($scope.details.startDate, ""mediumDate"");

                });
        }])


        .controller('EditDeleteController', ['$scope', '$http', '$location', '$routeParams', '$filter', function ($scope, $http, $location, $routeParams) {

            $scope.repeatTypes = ['Daily', 'Weekly', 'Monthly'];
            $scope.edit = [];

            $http.get('http://localhost:47547/api/Habit/' + $routeParams.habitId)
                .then(function (res) {
                    $scope.edit = res.data;
                    $scope.edit.repeat = $scope.repeatTypes[$scope.");
            WriteLiteral(@"edit.repeat];
                    $scope.edit.startDate = new Date($scope.edit.startDate);

                });

            $scope.Edit = function () {
                $scope.edit.frequency = parseInt($scope.edit.frequency);
                switch ($scope.edit.repeat) {
                    case 'Daily':
                        $scope.edit.repeat = 0;
                        break;
                    case 'Weekly':
                        $scope.edit.repeat = 1;
                        break;
                    case 'Monthly':
                        $scope.edit.repeat = 2;
                        break;
                }
                $http.put('http://localhost:47547/api/Habit/' + $routeParams.habitId, $scope.edit)
                    .then(function (res) {
                        $location.path('/');
                    });
            };
            $scope.Delete = function () {
                $http.delete('http://localhost:47547/api/Habit/' + $routeParams.habitId, null)
    ");
            WriteLiteral(@"                .then(function (res) {
                        $location.path('/');
                    });
            };
        }])
        .filter('repeatType', function () {
            return function (input) {
                switch (input) {
                    case 0:
                        return 'Daily';
                    case 1:
                        return 'Weekly';
                    case 2:
                        return 'Monthly';
                }
            };
        });
</script>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
