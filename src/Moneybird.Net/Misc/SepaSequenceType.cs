using System.Text.Json.Serialization;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Moneybird.Net.Misc
{
    /// <summary>
    /// Sepa sequence types.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum SepaSequenceType
    {
        [JsonPropertyName("RCUR")]
        RCUR,
        [JsonPropertyName("FRST")]
        FRST,
        [JsonPropertyName("OOFF")]
        OOFF,
        [JsonPropertyName("FNAL")]
        FNAL
    }
}