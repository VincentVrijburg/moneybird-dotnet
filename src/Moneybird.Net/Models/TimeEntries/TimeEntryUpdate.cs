using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.TimeEntries
{
    public class TimeEntryUpdate
    {
        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        [JsonPropertyName("ended_at")]
        public DateTime EndedAt { get; set; }

        [JsonPropertyName("paused_duration")]
        public int PausedDuration { get; set; }
        
        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }
        
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("billable")]
        public bool Billable { get; set; }
    }
}