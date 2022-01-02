using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.Contacts.Models
{
    public class ContactPersonUpdateOptions
    {
        [JsonPropertyName("contact_person")]
        public ContactPersonUpdateItem ContactPerson { get; set; }
    }
}