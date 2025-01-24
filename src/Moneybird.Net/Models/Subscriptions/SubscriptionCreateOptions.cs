using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Models.Projects;

namespace Moneybird.Net.Models.Subscriptions
{
    public class SubscriptionCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("subscription")]
        public SubscriptionCreate Subscription { get; set; }
    }
}