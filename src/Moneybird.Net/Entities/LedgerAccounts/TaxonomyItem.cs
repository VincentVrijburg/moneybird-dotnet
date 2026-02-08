using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.LedgerAccounts
{
    public class TaxonomyItem
    {
        [JsonPropertyName("taxonomy_version")]
        public string TaxonomyVersion { get; set; }
        
        [JsonPropertyName("code")]
        public string Code { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("name_english")]
        public string NameEnglish { get; set; }
        
        [JsonPropertyName("reference")]
        public string Reference { get; set; }
    }
}