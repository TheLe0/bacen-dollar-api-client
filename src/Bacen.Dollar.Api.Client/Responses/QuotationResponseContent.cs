using System;
using System.Text.Json.Serialization;

namespace Bacen.Dollar.Api.Client.Responses
{
    internal class QuotationResponseContent
    {
        [JsonPropertyName("cotacaoCompra")]
        internal decimal PurchaseQuote { get; set; }
        [JsonPropertyName("cotacaoVenda")]
        internal decimal WithdrawQuote { get; set; }
        [JsonPropertyName("dataHoraCotacao")]
        internal DateTime QuotationDateTime { get; set; }
    }
}
