using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bacen.Dollar.Api.Client.Responses
{
    internal class DollarQuotationResponse
    {
        [JsonPropertyName("@odata.context")]
        internal string Context { get; set; }
        [JsonPropertyName("value")]
        internal IList<QuotationResponseContent> QuotationContent { get; set; }
    }
}
