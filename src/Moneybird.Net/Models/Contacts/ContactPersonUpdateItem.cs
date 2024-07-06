using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Contacts
{
    public class ContactPersonUpdateItem
    {
        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }
        
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }
        
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("department")]
        public string Department { get; set; }
    }
}