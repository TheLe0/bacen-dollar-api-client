using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bacen.Dollar.Api.Client.Responses
{
    public class DollarQuotationResponse
    {
        [JsonPropertyName("@odata.context")]
        public string Context { get; set; }
        [JsonPropertyName("value")]
        public IList<QuotationResponseContent> QuotationContent { get; set; }
    }
}
