using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Notes
{
    public class Note
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("entity_id")]
        public string EntityId { get; set; }

        [JsonPropertyName("entity_type")]
        public string EntityType { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("assignee_id")]
        public string AssigneeId { get; set; }

        [JsonPropertyName("todo")]
        public bool Todo { get; set; }

        [JsonPropertyName("note")]
        public string Value { get; set; }

        [JsonPropertyName("completed_at")]
        public DateTime CompletedAt { get; set; }

        [JsonPropertyName("completed_by_id")]
        public string CompletedById { get; set; }

        [JsonPropertyName("todo_type")]
        public object TodoType { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}