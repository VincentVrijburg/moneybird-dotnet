using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Contacts
{
    public class ContactPersonCreateOptions
    {
        [JsonPropertyName("contact_person")]
        public ContactPersonCreateItem ContactPerson { get; set; }
    }
}