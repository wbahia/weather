﻿WeatherApp.controller('previsaoController', ['$scope', '$location', '$http', '$window', 'weatherService', function ($scope, $location, $http, $window, weatherService) {

    $scope.initPrevisao = function () {

        $scope.cidades = {};
        $scope.loading = false;
        getPrevisao($scope, $location, weatherService);

    }

}]);

function getPrevisao($scope, $location, weatherService) {

    $scope.loading = true;
    weatherService.request('/Previsao/ObterPrevisao?idAPI=' + $location.search().idAPI, 'Get', null).then(function (result) {

        if (result != null) {
            $scope.cidades = result.Lista;
            renderData($scope.cidades.Items);
        }

        $scope.loading = false;

    }, function (data) {
        console.log = "Erro ao carregar a previsão";
        $scope.loading = false;
    })
}

renderData = (forecast) => {

    const CURRENT_LOCATION = document.getElementsByClassName('weather-content__overview')[0];
    const CURRENT_TEMP = document.getElementsByClassName('weather-content__temp')[0];
    const FORECAST = document.getElementsByClassName('component__forecast-box')[0];

    const currentWeather = forecast[0];
    const widgetHeader =
        `<h1>${currentWeather.City}</h1><small>${currentWeather.Description}</small>`;

    CURRENT_TEMP.innerHTML =
        `<i class="wi ${currentWeather.Icon}"></i>
  ${Math.round(currentWeather.Temp)} <i class="wi wi-degrees"></i>`;

    CURRENT_LOCATION.innerHTML = widgetHeader;

    // dia-a-dia da previsao
    forecast.forEach(day => {
        let date = new Date(day.DateUnixFormat * 1000);
        console.log(date);
        let days = ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'];
        let name = days[date.getDay()];
        let dayBlock = document.createElement("div");
        dayBlock.className = 'forecast__item';
        dayBlock.innerHTML =
            `<div class="forecast-item__heading">${name}</div>
      <div class="forecast-item__info">
      <i class="wi ${day.Icon}"></i>
      <span class="degrees">${Math.round(day.Temp)}
      <i class="wi wi-degrees"></i></span></div>`;
        FORECAST.appendChild(dayBlock);
    });
}



