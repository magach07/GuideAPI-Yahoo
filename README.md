* LINK YAHOO FINANCE UTILIZADO PARA ACESSAR OS DADOS *

https://query1.finance.yahoo.com/v8/finance/chart/ABEV3.SA?symbol=ABEV3.SA&period1=1676289600&period2=9999999999&interval=1d
- Período inicial: 13/02/2023
- Período final: 13/03/2023
- Intervalo: 1 dia (abertura)

* O padrão de arquitetura utilizado foi o CQRS, que utiliza microsserviços para maximizar o desempenho, a escabilidade e a segurança da aplicação.

* COMANDOS BANCO DE DADOS SQL SERVER *

USE [master]
GO

* Criando base da dados *
CREATE DATABASE [YAHOO_FINANCE]
GO

USE [YAHOO_FINANCE]
GO

* Criando tabela para armazenar os dados *
CREATE TABLE [TB_DATA_ANALITCS]
(
    [ID] INT PRIMARY KEY IDENTITY(1,1),
    [CL_DATE] DATETIME NOT NULL,
    [CL_VALUE] FLOAT NOT NULL,
    [CL_VARIATION_PREVIOUS_DATE] FLOAT NOT NULL,
    [CL_VARIATION_FIRST_DATE] FLOAT NOT NULL,
)
GO

* DOCUMENTAÇÃO DAS API's

(GET) '/YahooFinance/ABEV3/GetInformations/' - API que consume os dados do Yahoo Finance, nos retornando o JSON que será usado para inserir as informações na base de dados.
(POST) '/YahooFinance/ABEV3/InsertInformations/' - Insere as informações retornadas pelo JSON na base de dados.
(GET) '/YahooFinance/ABEV3/GetHistorico30Dias/' - API que busca os dados no banco de dados e nos retorna as informações sobre as variações do ABEV3 dos útlimos 30 dias de modo formatado.

- Id: Identity, auto-incremental pelo banco de dados.
- Date: Data analisada.
- Value: Valor (em BRL) da ação no dia.
- VariationPreviousDate: Variação (em %) do valor da ação em relação ao dia anterior (D-1).
- VariationFirstDate: Variação (em %) do valor da ação em relação a primeira data analisada (03/02/2023).


* COMO UTILIZAR AS API'S *

Para utilizar as API's deverá ser utilizado alguma ferramente para requisições de API's. Como por exemplo Postman, ou a extensão do VSCode Thunder Client.
Após executar o programa com o comando 'dotnet run', uma porta local será apresentada a você.
Concatene essa porta local ao caminho da API e assim os dados serão retornados.

Exemplo: https://localhost:7078/YahooFinance/abev3/Historic30Days/

- Na raiz do projeto existe um arquivo chamado 'Historico30Dias', e nele está um modelo de retorno da api '/YahooFinance/ABEV3/GetHistorico30Dias/', com os dados manipulados conforme solicitado no escopo projeto.
