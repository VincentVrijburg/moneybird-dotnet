using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Products
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProductType
    {
        [JsonStringEnumMemberName("digital_service")]
        DigitalService,

        [JsonStringEnumMemberName("service")]
        Service
    }
}
