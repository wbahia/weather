WeatherApp.controller('cidadeController', ['$scope', '$http', '$window', 'weatherService', function ($scope, $http, $window, weatherService) {

    $scope.initCidade = function () {

        $scope.cidades = {};
        $scope.loading = false;
        getCidades($scope, weatherService);

    }

    $scope.redirecionarFormCadastro = function () {
        window.location.pathname = 'Cidade/Cadastro'
    }

    $scope.redirecionarPrevisao = function (idAPI) {
        window.location.href = "/Cidade/Previsao?idAPI=" + idAPI;
    }

    $scope.cadastrarCidade = function () {

        if (typeof ($scope.Cidade) == "undefined" || $scope.Cidade == "") {
            $window.alert("Por favor informe o nome da cidade!");
            return;
        }

        var data = {
            nomeCidade: $scope.Cidade
        };


        return $http.post('/Cidade/CadastrarCidade/', data).then(function (result) {

            var retorno = JSON.parse(result.data);

            if (!retorno.Sucesso) {
                $window.alert(retorno.Mensagem);
            }
            else {
                $window.alert('Cadastro realizado com sucesso!');
                window.location.pathname = 'Home/Index'
            }
        });
    }

}]);

function getCidades($scope, weatherService) {

    $scope.loading = true;
    weatherService.request('/Cidade/ObterCidades', 'Get', null).then(function (result) {

        if (result != null) {
            $scope.cidades = result.Lista;
            console.log(result.Lista);
        }

        $scope.loading = false;

    }, function (data) {
        console.log = "Erro ao carregar Cidades";
        $scope.loading = false;
    })
}




