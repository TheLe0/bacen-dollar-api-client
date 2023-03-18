using Bacen.Dollar.Api.Client.Configurations;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bacen.Dollar.Api.Client.Common
{
    public class BacenDollarHttpClient : IBacenDollarHttpClient
    {
        private readonly RestClient _client;
        private readonly BacenDollarClientConfiguration _configuration;

        public BacenDollarHttpClient(BacenDollarClientConfiguration configuration)
        {
            _configuration = configuration;
            _client = new RestClient(GetConfigurations());
        }

        public BacenDollarHttpClient(string baseUrl)
        {
            _configuration = new BacenDollarClientConfiguration(baseUrl);
            _client = new RestClient(GetConfigurations());
        }

        public BacenDollarHttpClient()
        {
            _configuration = new BacenDollarClientConfiguration();
            _client = new RestClient(GetConfigurations());
        }

        public string GetBaseUrl()
        {
            return _configuration.BaseUrl;
        }

        public Task<T> GetAsync<T>(string parameters)
        {
            var fullEndpoint = _configuration.BaseUrl
                + parameters
                + "&$format=json";

            return _client.GetJsonAsync<T>(fullEndpoint);
        }

        private RestClientOptions GetConfigurations()
        {
            return new RestClientOptions(_configuration.BaseUrl)
            {
                ThrowOnAnyError = _configuration.ThrowOnAnyError,
                MaxTimeout = _configuration.MaxTimeout
            };
        }
    }
}
