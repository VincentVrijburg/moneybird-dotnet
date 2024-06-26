using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.ExternalSalesInvoices
{
    public class ExternalSalesInvoiceUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("external_sales_invoice")]
        public ExternalSalesInvoiceUpdate ExternalInvoice { get; set; }

        [JsonPropertyName("user_agent")]
        public string UserAgent { get; set; }
    }
}
