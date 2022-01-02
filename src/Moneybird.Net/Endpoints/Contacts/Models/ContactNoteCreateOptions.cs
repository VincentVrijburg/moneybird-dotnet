using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.Contacts.Models
{
    public class ContactNoteCreateOptions
    {
        [JsonPropertyName("note")]
        public ContactNoteCreateItem Note { get; set; }
    }
}