using Bacen.Dollar.Api.Client.Models;
using Bacen.Dollar.Api.Client.Responses;
using System;
using System.Collections.Generic;

namespace Bacen.Dollar.Api.Client.Extensions
{
    internal static class QuotationResponseContentExtension
    {
        internal static IList<DollarQuotation> ToDollarQuotationList(this IList<QuotationResponseContent> responseContent)
        {
            var dolarQuotationList = new List<DollarQuotation>();

            foreach (var content in responseContent)
            {
                dolarQuotationList.Add(
                    content.ToDollarQuotation());
            }

            return dolarQuotationList;
        }

        internal static DollarQuotation ToDollarQuotation(this QuotationResponseContent content)
        {
            return new DollarQuotation
            {
                WithdrawQuote = content.WithdrawQuote,
                PurchaseQuote = content.PurchaseQuote,
                QuoteDate = DateTime.Parse(content.QuotationDateTime)
            };
        }
    }
}
