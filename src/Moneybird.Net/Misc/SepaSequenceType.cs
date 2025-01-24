using System.Text.Json.Serialization;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Moneybird.Net.Misc
{
    /// <summary>
    /// Sepa sequence types.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SepaSequenceType
    {
        [JsonStringEnumMemberName("RCUR")]
        RCUR,
        [JsonStringEnumMemberName("FRST")]
        FRST,
        [JsonStringEnumMemberName("OOFF")]
        OOFF,
        [JsonStringEnumMemberName("FNAL")]
        FNAL
    }
}