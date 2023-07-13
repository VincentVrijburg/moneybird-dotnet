using System.Text.Json.Serialization;
using Moneybird.Net.Entities.Webhooks;

namespace Moneybird.Net.Models
{
    public class Event
    {
        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("webhook_id")]
        public string WebhookId { get; set; }

        [JsonPropertyName("webhook_token")]
        public string WebhookToken { get; set; }

        [JsonPropertyName("entity_type")]
        public string EntityType { get; set; }

        [JsonPropertyName("entity_id")]
        public string EntityId { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("action")]
        public WebhookEvent Action { get; set; }

        [JsonPropertyName("entity")]
        public object Entity { get; set; }
    }
}
