using System.Text.Json.Serialization;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Moneybird.Net.Misc
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SepaSequenceType
    {
        RCUR,
        FRST,
        OOFF,
        FNAL
    }
}