using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.RecurringSalesInvoices
{
    public class SynchronizationRecurringSalesInvoice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}
