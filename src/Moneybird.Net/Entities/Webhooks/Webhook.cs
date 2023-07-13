using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Webhooks
{
    public class Webhook : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("events")]
        public List<WebhookEvent> Events { get; set; }

        [JsonPropertyName("last_http_status")]
        public int? LastHttpStatus { get; set; }

        [JsonPropertyName("last_http_body")]
        public object LastHttpBody { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
