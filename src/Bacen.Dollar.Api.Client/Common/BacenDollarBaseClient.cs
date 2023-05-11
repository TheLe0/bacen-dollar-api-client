using Bacen.Dollar.Api.Client.Configurations;
using Flurl;
using RestSharp;
using System.Threading.Tasks;

namespace Bacen.Dollar.Api.Client.Common
{
    public abstract class BacenDollarBaseClient
    {
        private readonly IBacenDollarHttpClient httpClient;
        protected readonly Url Endpoint;

        protected BacenDollarBaseClient(IBacenDollarHttpClient restApiClient)
        {
            httpClient = restApiClient;
            Endpoint = httpClient.GetBaseUrl();
            ConfigBaseEndpoint();
        }

        protected BacenDollarBaseClient(BacenDollarClientConfiguration configuration)
        {
            httpClient = new BacenDollarHttpClient(configuration);
            Endpoint = httpClient.GetBaseUrl();
            ConfigBaseEndpoint();
        }

        protected BacenDollarBaseClient()
        {
            httpClient = new BacenDollarHttpClient();
            Endpoint = httpClient.GetBaseUrl();
            ConfigBaseEndpoint();
        }

        protected BacenDollarBaseClient(string baseUrl)
        {
            httpClient = new BacenDollarHttpClient(baseUrl);
            Endpoint = httpClient.GetBaseUrl();
            ConfigBaseEndpoint();
        }

        protected Task<T> GetAsync<T>()
        {
            var restRequest = new RestRequest(Endpoint.ToString());
            RefreshEndpoint();

            return httpClient.GetAsync<T>(restRequest);
        }

        private void ConfigBaseEndpoint()
        {
            Endpoint.SetQueryParam("$format", "json");
        }

        private void RefreshEndpoint()
        {
            Endpoint.Reset();
            ConfigBaseEndpoint();
        }
    }
}
