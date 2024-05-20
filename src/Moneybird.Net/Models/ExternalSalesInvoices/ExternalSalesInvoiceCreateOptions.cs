using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.ExternalSalesInvoices
{
    public class ExternalSalesInvoiceCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("external_sales_invoice")]
        public ExternalSalesInvoiceCreate ExternalInvoice { get; set; }

        [JsonPropertyName("user_agent")]
        public string UserAgent { get; set; }
    }
}
