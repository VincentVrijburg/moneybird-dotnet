using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.Contacts.Models
{
    public class Event
    {
        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("link_entity_id")]
        public object LinkEntityId { get; set; }

        [JsonPropertyName("link_entity_type")]
        public object LinkEntityType { get; set; }

        // TODO: Check documentation to understand what this data field is meant for.
        [JsonIgnore]
        [JsonPropertyName("data")]
        public object Data { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}