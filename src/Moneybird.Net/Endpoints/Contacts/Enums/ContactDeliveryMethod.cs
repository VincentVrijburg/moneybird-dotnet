using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.Contacts.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContactDeliveryMethod
    {
        Email,
        Simplerinvoicing,
        Post,
        Manual
    }
}