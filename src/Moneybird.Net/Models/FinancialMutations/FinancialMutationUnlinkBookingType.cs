using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.FinancialMutations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FinancialMutationUnlinkBookingType
    {
        [JsonStringEnumMemberName("Payment")]
        Payment,
        [JsonStringEnumMemberName("LedgerAccountBooking")]
        LedgerAccountBooking
    }
}
