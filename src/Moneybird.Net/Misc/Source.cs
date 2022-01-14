using System.Text.Json.Serialization;

namespace Moneybird.Net.Misc
{
    /// <summary>
    /// Custom field sources.
    /// </summary>
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