WeatherApp.service('weatherService', ['$http', function ($http) {

    this.request = function (URL, typeRequest, mapDados) {

        httpInfo = {
            method: typeRequest,
            url: URL
        }
        if (typeRequest.toLowerCase() == 'post')
            httpInfo.data = mapDados;
        else
            httpInfo.paramns = mapDados;

        var promise = $http(
            httpInfo
        ).then(function (response) {
            console.log(response);
            return response.data;
        });
        return promise;
    }


}]);

