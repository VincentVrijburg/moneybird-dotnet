using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Models;

namespace Moneybird.Net.Endpoints.Contacts.Models
{
    public class ContactCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("contact")]
        public ContactCreateItem Contact { get; set; }
    }
}