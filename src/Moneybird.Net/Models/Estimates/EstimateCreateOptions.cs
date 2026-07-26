using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.Estimates
{
    public class EstimateCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("estimate")]
        public EstimateCreate Estimate { get; set; }
    }
}
