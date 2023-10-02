using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.FinancialMutations
{
    public class Sepa
    {
        [JsonPropertyName("sref")]
        public string Sref { get; set; }

        [JsonPropertyName("isdt")]
        public string Isdt { get; set; }

        [JsonPropertyName("ordp")]
        public SepaDebtor Ordp { get; set; }

        [JsonPropertyName("eref")]
        public string Eref { get; set; }

        [JsonPropertyName("crdb")]
        public string Crdb { get; set; }

        [JsonPropertyName("remi")]
        public string Remi { get; set; }
    }
}