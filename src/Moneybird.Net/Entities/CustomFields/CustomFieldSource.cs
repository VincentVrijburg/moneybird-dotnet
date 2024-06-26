using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.CustomFields
{
    /// <summary>
    /// Custom field sources.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CustomFieldSource
    {
        [JsonPropertyName("sales_invoice")]
        SalesInvoice,
        [JsonPropertyName("contact")]
        Contact,
        [JsonPropertyName("identity")]
        Identity
    }
}
