using System;

namespace Bacen.Dollar.Api.Client.Responses
{
    public class DollarQuotation
    {
        public decimal WithdrawQuote { get; set; }
        public decimal PurchaseQuote { get; set; }
        public DateTime QuoteDate { get; set; }
    }
}
