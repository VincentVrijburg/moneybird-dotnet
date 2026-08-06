using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Subscriptions;

public class SubscriptionCancel
{
    [JsonPropertyName("end_date")]
    public DateTime? EndDate { get; set; }
}
