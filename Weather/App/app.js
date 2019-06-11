var WeatherApp = angular.module("WeatherApp", [], function ($locationProvider) {
    $locationProvider.html5Mode(true);
});


WeatherApp.factory('httpAuthInterceptor', function ($q, $interval) {
    return {

        request: function (config) { return config; },
        response: function (response) {
            if (typeof response.data === "string" && response.data.indexOf("Log in") > -1) {
                swal({
                    title: "Sessão Expirou!",
                    text: "Sua sessão expirou, por favor, faço um novo Log In!",
                    type: "warning",
                    showCancelButton: false,
                    confirmButtonClass: "btn-warning",
                    closeOnConfirm: true
                });
                var stop = $interval(function () {
                    location.reload();
                    console.log(response);
                }, 5000);

            }
            return response;
        }
    };
})

WeatherApp.config(["$provide", function ($provide) {
    var rootUrl = $("#linkRoot").attr("href");
    $provide.constant("rootUrl", $("#linkRoot").attr("href"));
}
]);