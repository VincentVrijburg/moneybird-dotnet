using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.Contacts.Models
{
    public class ContactCreateOptions
    {
        [JsonPropertyName("contact")]
        public ContactCreateItem Contact { get; set; }
    }
}