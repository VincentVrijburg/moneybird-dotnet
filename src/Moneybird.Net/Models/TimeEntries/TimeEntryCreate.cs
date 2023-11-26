using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.TimeEntries
{
    public class TimeEntryCreate
    {
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }
        
        [JsonPropertyName("started_at")]
        public string StartedAt { get; set; }

        [JsonPropertyName("ended_at")]
        public string EndedAt { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("contact_id")]
        public long ContactId { get; set; }

        [JsonPropertyName("project_id")]
        public long ProjectId { get; set; }

        [JsonPropertyName("detail_id")]
        public long DetailId { get; set; }

        [JsonPropertyName("billable")]
        public bool Billable { get; set; }
        
        [JsonPropertyName("paused_duration")]
        public int PausedDuration { get; set; }
    }
}