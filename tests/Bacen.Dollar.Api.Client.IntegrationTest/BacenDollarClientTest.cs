using Bacen.Dollar.Api.Client.Configurations;
using System;
using System.Text.Json;

namespace Bacen.Dollar.Api.Client.IntegrationTest
{
    public class BacenDollarClientTest
    {
        [Fact]
        public async void DailyDollarQuotationAsync_Success()
        {
            var client = new BacenDollarClient();

            var dollarQuotation = await client.DailyDollarQuotationAsync(
                new DateTime(2023, 3, 17)
            );

            Assert.NotNull(dollarQuotation);
            Assert.True(dollarQuotation.PurchaseQuote > 0);
            Assert.True(dollarQuotation.WithdrawQuote > 0);
            Assert.True(dollarQuotation.QuoteDate < DateTime.Now);
        }

        [Fact]
        public async void PeriodicDollarQuotationAsync_Success()
        {
            var client = new BacenDollarClient();

            var dollarQuotation = await client.PeriodicDollarQuotationAsync(
                 new DateTime(2023, 3, 1),
                new DateTime(2023, 3, 17)
            );

            Assert.NotNull(dollarQuotation);
            Assert.True(dollarQuotation.Count > 1);
        }

        [InlineData("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/")]
        [Theory]
        public async void DailyDollarQuotationAsync_WithBaseUrl_Success(string baseUrl)
        {
            var client = new BacenDollarClient(baseUrl);

            var dollarQuotation = await client.DailyDollarQuotationAsync(
                new DateTime(2023, 3, 17)
            );

            Assert.NotNull(dollarQuotation);
            Assert.True(dollarQuotation.PurchaseQuote > 0);
            Assert.True(dollarQuotation.WithdrawQuote > 0);
            Assert.True(dollarQuotation.QuoteDate < DateTime.Now);
        }

        [InlineData("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/")]
        [Theory]
        public async void PeriodicDollarQuotationAsync_WithBaseUrl_Success(string baseUrl)
        {
            var client = new BacenDollarClient(baseUrl);

            var dollarQuotation = await client.PeriodicDollarQuotationAsync(
                 new DateTime(2023, 3, 1),
                new DateTime(2023, 3, 17)
            );

            Assert.NotNull(dollarQuotation);
            Assert.True(dollarQuotation.Count > 1);
        }

        [InlineData("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/")]
        [Theory]
        public async void DailyDollarQuotationAsync_WithConfigs_Success(string baseUrl)
        {
            var configs = new BacenDollarClientConfiguration
            {
                BaseUrl = baseUrl,
                MaxTimeout = 1000,
                ThrowOnAnyError = false
            };

            var client = new BacenDollarClient(configs);

            var dollarQuotation = await client.DailyDollarQuotationAsync(
                new DateTime(2023, 3, 17)
            );

            Assert.NotNull(dollarQuotation);
            Assert.True(dollarQuotation.PurchaseQuote > 0);
            Assert.True(dollarQuotation.WithdrawQuote > 0);
            Assert.True(dollarQuotation.QuoteDate < DateTime.Now);
        }

        [InlineData("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/")]
        [Theory]
        public async void PeriodicDollarQuotationAsync_WithConfigs_Success(string baseUrl)
        {
            var configs = new BacenDollarClientConfiguration
            {
                BaseUrl = baseUrl,
                MaxTimeout = 1000,
                ThrowOnAnyError = false
            };

            var client = new BacenDollarClient(configs);

            var dollarQuotation = await client.PeriodicDollarQuotationAsync(
                 new DateTime(2023, 3, 1),
                new DateTime(2023, 3, 17)
            );

            Assert.NotNull(dollarQuotation);
            Assert.True(dollarQuotation.Count > 1);
        }

        [InlineData("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/")]
        [Theory]
        public async void PeriodicDollarQuotationAsync_WithConfigs_Fail_Timeout(string baseUrl)
        {
            var configs = new BacenDollarClientConfiguration
            {
                BaseUrl = baseUrl,
                MaxTimeout = 1,
                ThrowOnAnyError = true
            };

            var client = new BacenDollarClient(configs);

            Func<Task> act = () => client.PeriodicDollarQuotationAsync(
                 new DateTime(2023, 3, 1),
                new DateTime(2023, 3, 17)
            );

            await Assert.ThrowsAsync<TimeoutException>(act);
        }

        [InlineData("https://leotosin.com.br/")]
        [Theory]
        public async void PeriodicDollarQuotationAsync_WithConfigs_Fail_InvalidBaseUrl_Throws(string baseUrl)
        {
            var configs = new BacenDollarClientConfiguration
            {
                BaseUrl = baseUrl,
                MaxTimeout = 1000,
                ThrowOnAnyError = true
            };

            var client = new BacenDollarClient(configs);

            Func<Task> act = () => client.PeriodicDollarQuotationAsync(
                 new DateTime(2023, 3, 1),
                new DateTime(2023, 3, 17)
            );

            await Assert.ThrowsAsync<JsonException>(act);
        }
    }
}