#pragma checksum "C:\Users\Dinora\Desktop\HabitTracker\HabitTracker\Views\Home\Progress.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa4b90594f12db9490ab90e6066a1b0e7e3ab838"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Progress), @"mvc.1.0.view", @"/Views/Home/Progress.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa4b90594f12db9490ab90e6066a1b0e7e3ab838", @"/Views/Home/Progress.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9577b22d0b85afd32558d0852a18eb91c61e11ef", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Progress : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
                        templateUrl: 'pages/progress/index.html',
                        controller: 'IndexController'
                    })
                .when('/create',
                    {
                        templateUrl: 'pages/progress/create.html',
                        controller: 'CreateController'
                    })
                .when('/details/:progressId',
                    {
                        templateUrl: 'pages/progres");
            WriteLiteral(@"s/details.html',
                        controller: 'DetailsController'
                    })

                .when('/edit/:progressId',
                    {
                        templateUrl: 'pages/progress/edit.html',
                        controller: 'EditDeleteController'
                    })
                .otherwise({
                    redirectTo: '/'
                });
        })


        .controller('IndexController', ['$scope', '$http', '$filter', function ($scope, $http, $filter) {
            $scope.progresses = [];
            $http.get('http://localhost:47547/api/Progress/')
                .then(function (res) {
                    $scope.progresses = res.data;

                    for (var i = 0; i < $scope.progresses.length; i++) {
                        $scope.progresses[i].endDate = $filter('date')($scope.progresses[i].endDate, ""mediumDate"");
                    }
                })
        }])


        .controller('CreateController', ['$scope', ");
            WriteLiteral(@"'$http', '$location', '$routeParams', '$filter', function ($scope, $http, $location, $routeParams, $filter) {
            $scope.create = []
            $scope.create = {
                habitProgress: '',
                isCompleted: false,
                note: '',
                endDate: ''
            };
            
            $scope.names = []

            $http.get('http://localhost:47547/api/Habit/')
                .then(function (res) {
                    $scope.habits = res.data;
                    for (var i = 0; i < $scope.habits.length; i++) {
                        $scope.names[i] = $scope.habits[i].name;
                    }
                });

            $scope.Save = function () {

                for (var i = 0; i < $scope.habits.length; i++) {
                    if ($scope.habitName == $scope.habits[i].name) {
                        $scope.habitId = $scope.habits[i].id;
                    }
                }
                

                $http.get");
            WriteLiteral(@"('http://localhost:47547/api/Habit/' + $scope.habitId)
                    .then(function (res) {
                        $scope.create.habit = res.data;

                        $http.post('http://localhost:47547/api/Progress/', $scope.create)
                            .then(function (res) {
                                console.log(res.data.habit);
                                console.log(res.data.isCompleted);
                                $location.path('/');
                            });
                        
                    });
            };
        }])



        .controller('DetailsController', ['$scope', '$http', '$routeParams', '$filter', function ($scope, $http, $routeParams, $filter) {
            $scope.details = [];

            $http.get('http://localhost:47547/api/Progress/' + $routeParams.progressId)
                .then(function (res) {
                    $scope.details = res.data;
                    $scope.details.endDate = $filter('date')($scope");
            WriteLiteral(@".details.endDate, ""mediumDate"");

                });
        }])


        .controller('EditDeleteController', ['$scope', '$http', '$location', '$routeParams', '$filter', function ($scope, $http, $location, $routeParams) {
            $scope.edit = [];

            $http.get('http://localhost:47547/api/Progress/' + $routeParams.progressId)
                .then(function (res) {
                    $scope.edit = res.data;
                    $scope.edit.habitProgress = parseInt($scope.edit.habitProgress);
                    $scope.edit.endDate = new Date($scope.edit.endDate);

                });

            $scope.Edit = function () {
                $scope.edit.habitProgress = parseInt($scope.edit.habitProgress);
                $http.put('http://localhost:47547/api/Progress/' + $routeParams.progressId, $scope.edit)
                    .then(function (res) {
                        $location.path('/');
                    });
            };
            $scope.Delete = function () {");
            WriteLiteral(@"
                $http.delete('http://localhost:47547/api/Progress/' + $routeParams.progressId, null)
                    .then(function (res) {
                        $location.path('/');
                    });
            };
        }])
        .filter('yesNo', function () {
            return function (input) {
                return input ? 'Yes' : 'No';
            }
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
