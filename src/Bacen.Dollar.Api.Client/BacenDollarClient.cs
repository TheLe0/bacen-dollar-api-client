using Bacen.Dollar.Api.Client.Common;
using Bacen.Dollar.Api.Client.Configurations;
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

        public async Task<DollarQuotation> DailyDollarQuotation(DateTime date)
        {
            var parameters = Routes.DailyDollarQuotation;

            parameters += "?@dataCotacao=" + date.ToString();

            var response = await GetAsync<DollarQuotationResponse>(parameters)
                    .ConfigureAwait(false);

            if (response == null || 
                !response.QuotationContent.Any()) return null;

            var responseContent = response.QuotationContent.SingleOrDefault();

            return new DollarQuotation
            {
                WithdrawQuote = responseContent.WithdrawQuote,
                PurchaseQuote = responseContent.PurchaseQuote,
                QuoteDate = responseContent.QuotationDateTime
            };
        }

        public async Task<IList<DollarQuotation>> PeriodicDollarQuotation(DateTime fromDate, DateTime toDate)
        {
            var dolarQuotationList = new List<DollarQuotation>();
            var parameters = Routes.PeriodicDollarQuotation;

            parameters += "?@dataInicial=" + fromDate.ToString();
            parameters += "&@dataFinalCotacao=" + toDate.ToString();

            var response = await GetAsync<DollarQuotationResponse>(parameters)
                    .ConfigureAwait(false);

            if (response == null ||
                !response.QuotationContent.Any()) return null;

            var responseContent = response.QuotationContent;

            foreach (var content in responseContent)
            {
                dolarQuotationList.Add(new DollarQuotation
                {
                    WithdrawQuote = content.WithdrawQuote,
                    PurchaseQuote = content.PurchaseQuote,
                    QuoteDate = content.QuotationDateTime

                });
            }

            return dolarQuotationList;
        }
    }
}
