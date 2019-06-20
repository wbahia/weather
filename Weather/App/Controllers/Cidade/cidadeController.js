WeatherApp.controller('cidadeController', ['$scope', '$http', '$window', 'weatherService', function ($scope, $http, $window, weatherService) {

    $scope.initCidade = function () {
        
        $scope.cidades = {};
        $scope.loading = false;
        getCidades($scope, weatherService, $scope.rootUrl);
        
    }

    $scope.redirecionarFormCadastro = function () {

        window.location.pathname = 'Cidade/RedirecionarCadastro'
    }

    $scope.cadastrarCidade = function () {

        if (typeof ($scope.Cidade) == "undefined" || $scope.Cidade == "") {
            $window.alert("Por favor informe o nome da cidade!");
            return;
        }

        var data = {
            nomeCidade: $scope.Cidade
        };

        $http
            .post('/Cidade/CadastrarCidade/', data)
            .success(function (data, status, headers, config) {
                successFn();
            })
            .errors(function (data, status, headers, config) {
                errorFn();
            });
    }

    function successFn() {
        alert("success");
    };

    function errorFn() {
        alert("error");
    };

}]);

function getCidades($scope, weatherService) {
    
    $scope.loading = true;
    weatherService.request('/Cidade/ObterCidades', 'Get', null).then(function (result) {
        
        if (result != null) {
            $scope.cidades = result.Lista;
        }
       
        $scope.loading = false;

    }, function (data) {
        console.log = "Erro ao carregar Cidades";
        $scope.loading = false;
    })
}




