using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.ExternalSaleInvoices
{
    public class ExternalSaleInvoiceCreateOptions
    {
        [JsonPropertyName("external_sales_invoice")]
        public ExternalSaleInvoiceCreate ExternalInvoice { get; set; }

        [JsonPropertyName("user_agent")]
        public string UserAgent { get; set; }
    }
}
