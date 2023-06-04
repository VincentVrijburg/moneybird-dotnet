using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.ExternalSalesInvoices
{
    public class ExternalSalesInvoiceCustomField
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
