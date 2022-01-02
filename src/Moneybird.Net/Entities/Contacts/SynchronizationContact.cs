using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Contacts
{
    public class SynchronizationContact
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}