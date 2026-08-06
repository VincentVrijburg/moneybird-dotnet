using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.Subscriptions;

public class SubscriptionCreateOptions : IMoneybirdCreateOptions
{
    [JsonPropertyName("subscription")]
    public SubscriptionCreate Subscription { get; set; }
}
