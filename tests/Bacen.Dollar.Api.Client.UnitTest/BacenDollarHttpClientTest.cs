using Bacen.Dollar.Api.Client.Common;
using Bacen.Dollar.Api.Client.Configurations;

namespace Bacen.Dollar.Api.Client.UnitTest
{
    public class BacenDollarHttpClientTest
    {
        [Fact]
        public void InstanciateWithDefaultConfigs()
        {
            var client = new BacenDollarHttpClient();

            Assert.Equal("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/", 
                client.GetBaseUrl());
        }

        [InlineData("https://leotosin.com.br/")]
        [InlineData("https://localhost/")]
        [InlineData("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/")]
        [Theory]
        public void InstanciateWithBaseUrlParameter(string baseUrl)
        {
            var client = new BacenDollarHttpClient(baseUrl);

            Assert.Equal(baseUrl, client.GetBaseUrl());
        }

        [Fact]
        public void InstanciateWithConfigurationDefault()
        {
            var configs = new BacenDollarClientConfiguration();
            var client = new BacenDollarHttpClient(configs);

            Assert.Equal("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/",
                client.GetBaseUrl());
        }

        [InlineData("https://leotosin.com.br/")]
        [InlineData("https://localhost/")]
        [InlineData("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/")]
        [Theory]
        public void InstanciateWithConfigurationBaseUrlParameter(string baseUrl)
        {
            var configs = new BacenDollarClientConfiguration(baseUrl);
            var client = new BacenDollarHttpClient(configs);

            Assert.Equal(baseUrl, client.GetBaseUrl());
        }

        [InlineData("https://leotosin.com.br/")]
        [InlineData("https://localhost/")]
        [InlineData("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/")]
        [Theory]
        public void InstanciateWithConfiguration(string baseUrl)
        {
            var configs = new BacenDollarClientConfiguration
            {
                BaseUrl = baseUrl,
                ThrowOnAnyError = false,
                MaxTimeout = 100
            };

            var client = new BacenDollarHttpClient(configs);

            Assert.Equal(baseUrl, client.GetBaseUrl());
        }
    }
}