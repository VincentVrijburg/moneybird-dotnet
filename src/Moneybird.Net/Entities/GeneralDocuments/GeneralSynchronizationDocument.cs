using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.GeneralDocuments
{
    public class GeneralSynchronizationDocument
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}