using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Estimates
{
    public class SynchronizationEstimate
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}
