using System.Text.Json.Serialization;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Moneybird.Net.Endpoints.Contacts.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContactSepaSequenceType
    {
        RCUR,
        FRST,
        OOFF,
        FNAL
    }
}