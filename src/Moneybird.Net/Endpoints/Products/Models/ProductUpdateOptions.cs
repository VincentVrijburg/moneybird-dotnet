using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Endpoints.Products.Models
{
    public class ProductUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("product")]
        public ProductUpdate Product { get; set; }
    }
}
