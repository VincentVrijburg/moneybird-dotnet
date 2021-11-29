using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.Administrations.Models
{
    public class AdministrationList
    {
        /// <summary>
        /// Gets or sets the administration collection.
        /// </summary>
        [JsonPropertyName("administrations")]
        public List<Administration> Administrations { get; set; }
    }
}