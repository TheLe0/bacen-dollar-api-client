using Bacen.Dollar.Api.Client;
using Bacen.Dollar.Api.Client.Configurations;
using Bacen.Dollar.Api.Client.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var baseUrl = "https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/";
var configs = new BacenDollarClientConfiguration
{
    BaseUrl = baseUrl,
    ThrowOnAnyError = false,
    MaxTimeout = 50000
};

// builder.Services.AddBacenDollarApiClient();
// builder.Services.AddBacenDollarApiClient(baseUrl);
builder.Services.AddBacenDollarApiClient(configs);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/dollar/quotes/today", (IBacenDollarClient client) =>
{
    return client.DailyDollarQuotationAsync(DateTime.Today);
})
.WithName("TodayDollarQuotation")
.WithOpenApi();

app.MapGet("/dollar/quotes/daily/{date}", (IBacenDollarClient client, DateTime date) =>
{
    return client.DailyDollarQuotationAsync(date);
})
.WithName("DailyDollarQuotation")
.WithOpenApi();

app.MapGet("/dollar/quotes/periodic/{from}/{to}", (IBacenDollarClient client, DateTime from, DateTime
     to) =>
{
    return client.PeriodicDollarQuotationAsync(from, to);
})
.WithName("PeriodicDollarQuotation")
.WithOpenApi();

app.Run();