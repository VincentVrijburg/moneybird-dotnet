using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.RecurringSalesInvoices
{
    public class RecurringSalesInvoiceListOptions
    {
        [JsonPropertyName("ids")]
        public string[] Ids { get; set; }
    }
}
