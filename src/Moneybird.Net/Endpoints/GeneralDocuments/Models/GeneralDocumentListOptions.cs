using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.GeneralDocuments.Models
{
    public class GeneralDocumentListOptions
    {
        [JsonPropertyName("ids")]
        public List<string> Ids { get; set; }
    }
}