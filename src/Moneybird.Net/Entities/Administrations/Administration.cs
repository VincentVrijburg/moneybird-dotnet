using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Administrations
{
    public class Administration : IMoneybirdEntity
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
        
        /// <summary>
        /// Gets or sets the access value.
        /// </summary>
        [JsonPropertyName("access")]
        public AdministrationAccess Access { get; set; }
        
        /// <summary>
        /// Gets or sets the suspended value.
        /// </summary>
        [JsonPropertyName("suspended")]
        public bool Suspended { get; set; }
        
        /// <summary>
        /// Gets or sets the period locked until value.
        /// </summary>
        [JsonPropertyName("period_locked_until")]
        public DateTime? PeriodLockedUntil { get; set; }
    }
}
