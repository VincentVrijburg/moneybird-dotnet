using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Endpoints.Products.Models
{
    public class ProductCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("product")]
        public ProductCreate Product { get; set; }
    }
}
