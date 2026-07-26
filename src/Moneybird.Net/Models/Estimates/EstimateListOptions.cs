using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Estimates
{
    public class EstimateListOptions
    {
        [JsonPropertyName("ids")]
        public string[] Ids { get; set; }
    }
}
