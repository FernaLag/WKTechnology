# WKTechnology Teste

Esse projeto utiliza Migrations para criação das tabelas no MySQL.
Siga o passo a passo a seguir para criar o banco de dados.

1. Clone o projeto para o Visual Studio;
2. Certifique-se de ter o MySQL Instalado em sua máquina;
3. Coloque seu "User e Password" do MySQL na ConnectionString dentro do "appsettings.json" no projeto WKTechnology.API
4. No Visual Studio, acesse o Package Manager Console na aba "View > Other Windows >";
5. Executa o comando "update-database"

-----------------------------

Após ter feito o passo anterior você deve executar os projetos API e Application.
Para pode fazer isso da seguinte maneira:
1. Clique com o botão direito na Solution ou em qualquer projeto dentro da Solution;
2. Selecione "Configure Startup Projects...";
3. Selecione "Multiple startup projects";
4. Coloque "Start" ou "Start without debbuging" nos dois projetos (API e Application);

------------------------------

Feito isso você pode clicar em "Start" e testar a Aplicação no seu navegador.

------------------------------

Para executar os testes de unidade:

1. Clique com o botão direito no Projeto "WKTechnology.Core.UnitTests"
2. Clique em Run Tests