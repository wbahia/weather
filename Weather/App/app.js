var WeatherApp = angular.module("WeatherApp", [], function ($locationProvider) {
    $locationProvider.html5Mode(true);
});

WeatherApp.config(["$provide", function ($provide) {
    var rootUrl = $("#linkRoot").attr("href");
    $provide.constant("rootUrl", $("#linkRoot").attr("href"));
}
]);