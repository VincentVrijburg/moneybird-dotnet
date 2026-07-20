using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.FinancialMutations
{
    public class FinancialMutationListOptions
    {
        [JsonPropertyName("ids")]
        public string[] Ids { get; set; }
    }
}
