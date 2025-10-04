using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Users
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserPermission
    {
        [JsonStringEnumMemberName("sales_invoices")]
        SalesInvoices,
        [JsonStringEnumMemberName("documents")]
        Documents,
        [JsonStringEnumMemberName("estimates")]
        Estimates,
        [JsonStringEnumMemberName("bank")]
        Bank,
        [JsonStringEnumMemberName("settings")]
        Settings,
        [JsonStringEnumMemberName("ownership")]
        Ownership,
        [JsonStringEnumMemberName("time_entries")]
        TimeEntries,
    }
}
