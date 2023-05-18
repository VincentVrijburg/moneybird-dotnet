using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.SaleInvoices
{
    public class SaleInvoiceCustomField
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
