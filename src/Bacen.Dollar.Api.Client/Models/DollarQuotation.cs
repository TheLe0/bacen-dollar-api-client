using Bacen.Dollar.Api.Client.Responses;
using System;

namespace Bacen.Dollar.Api.Client.Models
{
    public class DollarQuotation
    {
        public decimal WithdrawQuote { get; set; }
        public decimal PurchaseQuote { get; set; }
        public DateTime QuoteDate { get; set; }
    }
}
