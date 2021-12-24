using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.Contacts.Models
{
    public class ContactPerson
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }
        
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
        
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}