using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Notes
{
    public class NoteCreateItem
    {
        [JsonPropertyName("note")]
        public string Note { get; set; }
        
        [JsonPropertyName("todo")]
        public bool? Todo { get; set; }
        
        [JsonPropertyName("assignee_id")]
        public string AssigneeId { get; set; }
    }
}