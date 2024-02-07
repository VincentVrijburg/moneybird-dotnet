using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.Products
{
    public class ProductUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("product")]
        public ProductUpdate Product { get; set; }
    }
}
