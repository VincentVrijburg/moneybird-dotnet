using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.Contacts.Models
{
    public class ContactPersonCreateOptions
    {
        [JsonPropertyName("contact_person")]
        public ContactPersonCreateItem ContactPerson { get; set; }
    }
}