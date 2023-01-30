using System.Text.Json.Serialization;

namespace Moneybird.Net.Misc
{
    /// <summary>
    /// Custom field sources.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum Source
    {
        [JsonPropertyName("sales_invoices")]
        SalesInvoices,
        [JsonPropertyName("contact")]
        Contact,
        [JsonPropertyName("identity")]
        Identity
    }
}