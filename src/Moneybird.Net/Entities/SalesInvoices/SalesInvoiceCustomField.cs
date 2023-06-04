using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.SalesInvoices
{
    public class SalesInvoiceCustomField
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
