using System;
using System.Text.Json.Serialization;

namespace Bacen.Dollar.Api.Client.Responses
{
    public class QuotationResponseContent
    {
        [JsonPropertyName("cotacaoCompra")]
        public decimal PurchaseQuote { get; set; }
        [JsonPropertyName("cotacaoVenda")]
        public decimal WithdrawQuote { get; set; }
        [JsonPropertyName("dataHoraCotacao")]
        public string QuotationDateTime { get; set; }
    }
}
