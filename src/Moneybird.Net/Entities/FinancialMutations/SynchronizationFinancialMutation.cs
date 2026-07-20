using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.FinancialMutations
{
    public class SynchronizationFinancialMutation
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}
