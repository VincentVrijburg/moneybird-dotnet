using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.FinancialMutations
{
    public class FinancialMutationUnlinkBookingOptions
    {
        [JsonPropertyName("booking_type")]
        public FinancialMutationUnlinkBookingType BookingType { get; set; }

        [JsonPropertyName("booking_id")]
        public string BookingId { get; set; }
    }
}
