using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.Contacts.Models
{
    public class ContactUpdateOptions
    {
        [JsonPropertyName("contact")]
        public ContactUpdateItem Contact { get; set; }
    }
}