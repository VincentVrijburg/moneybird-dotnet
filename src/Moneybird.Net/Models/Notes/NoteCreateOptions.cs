using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Notes
{
    public class NoteCreateOptions
    {
        [JsonPropertyName("note")]
        public NoteCreateItem Note { get; set; }
    }
}