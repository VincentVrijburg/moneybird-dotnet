using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.Estimates
{
    public class EstimateUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("estimate")]
        public EstimateUpdate Estimate { get; set; }
    }
}
