using Bacen.Dollar.Api.Client.Common;
using Bacen.Dollar.Api.Client.Configurations;
using System;

namespace Bacen.Dollar.Api.Client
{
    public class BacenDollarClient : BacenDollarBaseClient, IBacenDollarClient
    {

        public BacenDollarClient() :base() { }
        public BacenDollarClient(string baseUrl) : base(baseUrl) { }
        public BacenDollarClient(BacenDollarClientConfiguration configuration) : base(configuration) { }
        public BacenDollarClient(IBacenDollarHttpClient restApiClient) : base(restApiClient) { }
    }
}
