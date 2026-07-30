using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Subscriptions;

public class SubscriptionCancelOptions
{
    [JsonPropertyName("subscription")]
    public SubscriptionCancel Subscription { get; set; }
}
