using Bacen.Dollar.Api.Client.Configurations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Bacen.Dollar.Api.Client.Common
{
    public abstract class BacenDollarBaseClient
    {
        private readonly IBacenDollarHttpClient httpClient;

        protected BacenDollarBaseClient(IBacenDollarHttpClient restApiClient)
        {
            httpClient = restApiClient;
        }

        protected BacenDollarBaseClient(BacenDollarClientConfiguration configuration)
        {
            httpClient = new BacenDollarHttpClient(configuration);
        }

        protected BacenDollarBaseClient()
        {
            httpClient = new BacenDollarHttpClient();
        }

        protected BacenDollarBaseClient(string baseUrl)
        {
            httpClient = new BacenDollarHttpClient(baseUrl);
        }
    }
}
