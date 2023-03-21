# Bacen Dolar .NET Rest API Client

[![Test CI](https://github.com/TheLe0/LawBook/actions/workflows/pull_request.yml/badge.svg)](https://github.com/TheLe0/LawBook/actions/workflows/pull_request.yml)

This is a REST API client for the .NET plataform that gives you information about the dollar quotation for all business days for both withdraw and purchase. 

## Packages

   | Package | Version | Downloads | Workflow | 
   |---------|---------|-----------|----------| 
   | Bacen.Dollar.Api.Client | [![NuGet Version](https://img.shields.io/nuget/v/Bacen.Dollar.Api.Client.svg)](https://www.nuget.org/packages/Bacen.Dollar.Api.Client/ "NuGet Version")| [![NuGet Downloads](https://img.shields.io/nuget/dt/Bacen.Dollar.Api.Client.svg)](https://www.nuget.org/packages/Bacen.Dollar.Api.Client/ "NuGet Downloads") | [![Deploy](https://github.com/TheLe0/bacen-dollar-api-client/actions/workflows/deploy_nuget_api_client.yml/badge.svg)](https://github.com/TheLe0/bacen-dollar-api-client/actions/workflows/deploy_nuget_api_client.yml) |
   | Bacen.Dollar.Api.Client.DependencyInjection | ![NuGet Version](https://img.shields.io/nuget/v/Bacen.Dollar.Api.Client.DependencyInjection.svg) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Bacen.Dollar.Api.Client.DependencyInjection.svg)](https://www.nuget.org/packages/Bacen.Dollar.Api.Client.DependencyInjection/ "NuGet Downloads") | [![Deploy](https://github.com/TheLe0/bacen-dollar-api-client/actions/workflows/deploy_nuget_api_client_di.yml/badge.svg)](https://github.com/TheLe0/bacen-dollar-api-client/actions/workflows/deploy_nuget_api_client_di.yml) | 

## Endpoints

1. [DailyDollarQuotationAsync](https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/aplicacao#!/recursos/CotacaoDolarDia#eyJmb3JtdWxhcmlvIjp7IiRmb3JtYXQiOiJqc29uIiwiJHRvcCI6MTAwfX0=): Gets the dollar quotation for a specific date;

```csharp
var dollarQuotation = await client.DailyDollarQuotationAsync(
    new DateTime(2023, 3, 17)
);
```

2. [PeriodicDollarQuotationAsync](https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/aplicacao#!/recursos/CotacaoDolarPeriodo#eyJmb3JtdWxhcmlvIjp7IiRmb3JtYXQiOiJqc29uIiwiJHRvcCI6MTAwLCJkYXRhSW5pY2lhbCI6IjAzLTAxLTIwMjMiLCJkYXRhRmluYWxDb3RhY2FvIjoiMDMtMTgtMjAyMyJ9LCJwZXNxdWlzYWRvIjp0cnVlLCJhY3RpdmVUYWIiOiJ0YWJsZSIsImdyaWRTdGF0ZSI6ewMwAzpbewNCAyIEMAQiLANBA30sewNCAyIEMQQiLANBA30sewNCAyIEMgQiLANBA31dLAMxAzp7fSwDMgM6W10sAzMDOnt9LAM0Azp7fSwDNQM6e319LCJwaXZvdE9wdGlvbnMiOnsDYQM6e30sA2IDOltdLANjAzo1MDAsA2QDOltdLANlAzpbXSwDZgM6W10sA2cDOiJrZXlfYV90b196IiwDaAM6ImtleV9hX3RvX3oiLANpAzp7fSwDagM6e30sA2sDOjg1LANsAzpmYWxzZSwDbQM6e30sA24DOnt9LANvAzoiQ29udGFnZW0iLANwAzoiVGFibGUifX0=): Gets the dollar quotation for an specific date interval.

```csharp
var dollarQuotation = await client.PeriodicDollarQuotationAsync(
     new DateTime(2023, 3, 1),
    new DateTime(2023, 3, 17)
);
```

## Configuration

This Api integration is ver simple, there is no authentication/authorization requirements, you can use it with almost no configurations.

You can instanciate this client in three different ways:

1. Using default configs: This uses the default [baseUrl](https://github.com/TheLe0/bacen-dollar-api-client/blob/4ff15805206d95600da34365d8b4248e3ba8120e/src/Bacen.Dollar.Api.Client/Resources/Routes.resx#L121), [timeout](https://github.com/TheLe0/bacen-dollar-api-client/blob/4ff15805206d95600da34365d8b4248e3ba8120e/src/Bacen.Dollar.Api.Client/Configurations/BacenDollarClientConfiguration.cs#L27) and [Throw on any error flag](https://github.com/TheLe0/bacen-dollar-api-client/blob/4ff15805206d95600da34365d8b4248e3ba8120e/src/Bacen.Dollar.Api.Client/Configurations/BacenDollarClientConfiguration.cs#L28).

```csharp
var client = new BacenDollarClient();
```

2. Only configurating the API base url:

```csharp
var client = new BacenDollarClient(baseUrl);
```

3. And setup manually all configurations with your preferences:

```csharp
var configs = new BacenDollarClientConfiguration
{
    BaseUrl = baseUrl,
    MaxTimeout = 10000,
    ThrowOnAnyError = false
};

var client = new BacenDollarClient(configs);
```

