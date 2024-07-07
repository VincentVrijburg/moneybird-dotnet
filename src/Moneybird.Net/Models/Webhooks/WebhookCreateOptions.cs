using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.Webhooks;

namespace Moneybird.Net.Models.Webhooks
{
    public class WebhookCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
        
        [JsonPropertyName("events")]
        public List<WebhookEvent> Events { get; set; }
    }
}
