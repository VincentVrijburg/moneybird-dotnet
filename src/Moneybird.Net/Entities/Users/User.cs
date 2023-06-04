using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Users
{
    public class User : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("email_validated")]
        public bool EmailValidated { get; set; }
        
        [JsonPropertyName("language")]
        public string Language { get; set; }
        
        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }
        
        [JsonPropertyName("permissions")]
        public UserPermission[] Permissions { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
