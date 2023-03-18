using Bacen.Dollar.Api.Client.Common;
using Bacen.Dollar.Api.Client.Configurations;
using Bacen.Dollar.Api.Client.Extensions;
using Bacen.Dollar.Api.Client.Models;
using Bacen.Dollar.Api.Client.Resources;
using Bacen.Dollar.Api.Client.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bacen.Dollar.Api.Client
{
    public class BacenDollarClient : BacenDollarBaseClient, IBacenDollarClient
    {

        public BacenDollarClient() :base() { }
        public BacenDollarClient(string baseUrl) : base(baseUrl) { }
        public BacenDollarClient(BacenDollarClientConfiguration configuration) : base(configuration) { }
        public BacenDollarClient(IBacenDollarHttpClient restApiClient) : base(restApiClient) { }

        public async Task<DollarQuotation> DailyDollarQuotationAsync(DateTime date)
        {
            var parameters = Routes.DailyDollarQuotation;

            parameters += "?@dataCotacao='" + 
                date.FormatToBacenDollarApi() +
                "'";

            var response = await GetAsync<DollarQuotationResponse>(parameters)
                    .ConfigureAwait(false);

            if (response == null) return null;
            if (response.QuotationContent == null) return null;

            return response.QuotationContent
                .SingleOrDefault()
                .ToDollarQuotation();
        }

        public async Task<IList<DollarQuotation>> PeriodicDollarQuotationAsync(DateTime fromDate, DateTime toDate)
        {
            var parameters = Routes.PeriodicDollarQuotation;

            parameters += "?@dataInicial='" +
                fromDate.FormatToBacenDollarApi() +
                "'";
            parameters += "&@dataFinalCotacao='" +
                toDate.FormatToBacenDollarApi() +
                "'";

            var response = await GetAsync<DollarQuotationResponse>(parameters)
                    .ConfigureAwait(false);

            if (response == null) return null;
            if (response.QuotationContent == null) return null;

            return response.QuotationContent
                .ToDollarQuotationList();

        }
    }
}
