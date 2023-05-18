using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.ExternalSalesInvoices.Models
{
    public class ExternalSalesInvoiceCreateOptions
    {
        [JsonPropertyName("external_sales_invoice")]
        public ExternalSalesInvoiceCreate ExternalInvoice { get; set; }

        [JsonPropertyName("user_agent")]
        public string UserAgent { get; set; }
    }
}
