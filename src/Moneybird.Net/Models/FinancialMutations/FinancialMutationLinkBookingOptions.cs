using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.FinancialMutations
{
    public class FinancialMutationLinkBookingOptions
    {
        [JsonPropertyName("booking_type")]
        public FinancialMutationLinkBookingType BookingType { get; set; }

        [JsonPropertyName("booking_id")]
        public string BookingId { get; set; }

        [JsonPropertyName("price_base")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double? PriceBase { get; set; }

        [JsonPropertyName("price")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double? Price { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("payment_batch_identifier")]
        public string PaymentBatchIdentifier { get; set; }

        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("mark_open_sepa_transaction_as_paid")]
        public bool? MarkOpenSepaTransactionAsPaid { get; set; }
    }
}
