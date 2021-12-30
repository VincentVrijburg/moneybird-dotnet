using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Contacts
{
    public class ContactCustomFieldsAttribute
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}