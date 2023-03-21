using Bacen.Dollar.Api.Client;
using Bacen.Dollar.Api.Client.Configurations;

var baseUrl = "https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/";
var configs = new BacenDollarClientConfiguration
{
    BaseUrl = baseUrl,
    ThrowOnAnyError = false,
    MaxTimeout = 50000
};

var client = new BacenDollarClient(configs);

var dollarQuotation = await client.DailyDollarQuotationAsync(DateTime.Today)
    .ConfigureAwait(false);

Console.WriteLine(dollarQuotation);