using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.Subscriptions;

public class SubscriptionUpdateOptions : IMoneybirdUpdateOptions
{
    [JsonPropertyName("subscription")]
    public SubscriptionUpdate Subscription { get; set; }
}
