using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.FinancialMutations
{
    public class SepaDebtor
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}