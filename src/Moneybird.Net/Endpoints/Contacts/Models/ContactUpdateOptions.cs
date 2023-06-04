using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Models;

namespace Moneybird.Net.Endpoints.Contacts.Models
{
    public class ContactUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("contact")]
        public ContactUpdateItem Contact { get; set; }
    }
}