using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.Administrations.Models
{
    public class Administration
    {
        /// <summary>
        /// Gets or sets the id value.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Gets or sets the name value.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the language value.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }
        
        /// <summary>
        /// Gets or sets the currency value.
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        
        /// <summary>
        /// Gets or sets the country value.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }
        
        /// <summary>
        /// Gets or sets the time zone value.
        /// </summary>
        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }
    }
}