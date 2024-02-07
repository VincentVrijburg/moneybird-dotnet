using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Contacts
{
    public class ContactPersonUpdateOptions
    {
        [JsonPropertyName("contact_person")]
        public ContactPersonUpdateItem ContactPerson { get; set; }
    }
}