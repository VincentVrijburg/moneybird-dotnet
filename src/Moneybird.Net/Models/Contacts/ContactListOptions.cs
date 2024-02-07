using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Contacts
{
    public class ContactListOptions
    {
        [JsonPropertyName("ids")]
        public List<string> Ids { get; set; }
    }
}