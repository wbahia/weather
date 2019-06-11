WeatherApp.controller('cidadeController', ['$scope', 'weatherService', 'rootUrl', function ($scope, weatherService) {
    
    $scope.initCidade = function () {
        $scope.cidades = {};
        $scope.loading = false;
        getCidades($scope, weatherService, $scope.rootUrl);
    }

}]);

function getCidades($scope, weatherService) {
    $scope.loading = true;
    weatherService.request('/Cidade/ObterCidades', 'Get', null).then(function (result) {

        if (result != null) {
            $scope.cidades = result.Lista;
        }

        console.log(result.Lista);
        $scope.loading = false;

    }, function (data) {
        console.log = "Erro ao carregar Eventos";
        $scope.loading = false;
    })
}

