using System;
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
        
        [Obsolete("Use EnabledEvents instead as this attribute has been removed from the API.", true)]
        [JsonIgnore]
        public List<WebhookEvent> Events { get; set; }
        
        [JsonPropertyName("enabled_events")]
        public List<WebhookEvent> EnabledEvents { get; set; }
    }
}
