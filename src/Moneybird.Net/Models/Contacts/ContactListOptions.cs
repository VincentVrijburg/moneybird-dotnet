using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Contacts
{
    public class ContactListOptions
    {
        [JsonPropertyName("ids")]
        public string[] Ids { get; set; }
    }
}