using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Users
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum UserPermission
    {
        [JsonPropertyName("sales_invoices")]
        SalesInvoices,
        [JsonPropertyName("documents")]
        Documents,
        [JsonPropertyName("estimates")]
        Estimates,
        [JsonPropertyName("bank")]
        Bank,
        [JsonPropertyName("settings")]
        Settings,
        [JsonPropertyName("ownership")]
        Ownership,
        [JsonPropertyName("time_entries")]
        TimeEntries,
    }
}
