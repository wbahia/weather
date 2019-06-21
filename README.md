# weather
Aplicativo de Previsão do tempo Weather que usa a API do OpenWeather para exibir um Forecast de 5 dias 
Funcionalidades:
1) Cadastro de Cidades:
O aplicativo cadastra as cidades que ainda não estejam cadastradas e que estejam disponíveis na API
2) Forecast
Com a cidade cadastrada, o app busca o forecast na API para os 5 dias seguintes (incluindo o próprio)

Obs.: Nesta versão não está sendo tratado o caso de cidades HOMONIMAS (próxima versão ??).

Tecnologia:
Para desenvolver foi usado ASP.NET MVC com C# e angularJS no front-end com HTML5 e bootstrap
Para o front-end (minhas habilidades de front pra design são restritas :)) tomei como base o código descrito em: https://sceendy.com/blog/2017/09-27-weather-widget-tutorial/

Código:
A arquitetura está dividida em camadas, tal como os diretórios da solução:
BLL => Negócio
DAL => Acesso a dados
DOMAIN => Domínio
SERVICES => Serviço (consome a API do OpenWeather)
UI => User Interface

O código está limpo, na medida do possível, com segragação das interfaces e utilização de boas práticas de codificação.

Utilizei alguns padrões de desenvolvimento como UnitofWork, proposto por mim em minha atual empresa.
Optei por não utilizar o arquivo de configuração para carregar os dados da API client (URL e chave), sem nenhum objetivo específico além de gosto próprio.

Na DAL, estão as migrations, o requisito inicial do projeto era de utilizar code first.

Testes:
Criei um projeto de teste dentro da camada de serviço apenas, utiizando testes unitários para acesso a API.

Dúvidas e sugestões: wbahia@gmail.com ;-)

