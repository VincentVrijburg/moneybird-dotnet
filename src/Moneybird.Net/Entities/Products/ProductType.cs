using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Products
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ProductType
    {
        [JsonPropertyName("digital_service")]
        DigitalService,

        [JsonPropertyName("service")]
        Service
    }
}
