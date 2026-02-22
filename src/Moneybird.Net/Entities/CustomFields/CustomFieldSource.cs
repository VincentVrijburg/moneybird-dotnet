using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.CustomFields
{
    /// <summary>
    /// Custom field sources.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CustomFieldSource
    {
        [JsonStringEnumMemberName("sales_invoice")]
        SalesInvoice,
        [JsonStringEnumMemberName("estimate")]
        Estimate,
        [JsonStringEnumMemberName("contact")]
        Contact,
        [JsonStringEnumMemberName("identity")]
        Identity
    }
}
