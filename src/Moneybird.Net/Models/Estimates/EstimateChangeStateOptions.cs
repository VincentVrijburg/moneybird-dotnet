using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Estimates
{
    public class EstimateChangeStateOptions
    {
        [JsonPropertyName("state")]
        public EstimateChangeState State { get; set; }
    }
}
