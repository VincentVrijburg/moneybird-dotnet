using System;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.Contacts;

namespace Moneybird.Net.Entities.PurchaseTransactions
{
    public class PurchaseTransaction : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("financial_account_id")]
        public string FinancialAccountId { get; set; }

        [JsonPropertyName("payment_instrument_id")]
        public string PaymentInstrumentId { get; set; }

        [JsonPropertyName("state")]
        public PurchaseTransactionState State { get; set; }

        [JsonPropertyName("sepa_iban")]
        public string SepaIban { get; set; }

        [JsonPropertyName("sepa_iban_account_name")]
        public string SepaIbanAccountName { get; set; }

        [JsonPropertyName("sepa_bic")]
        public string SepaBic { get; set; }

        [JsonPropertyName("source_sepa_iban")]
        public string SourceSepaIban { get; set; }

        [JsonPropertyName("source_sepa_iban_account_name")]
        public string SourceSepaIbanAccountName { get; set; }

        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("end_to_end_id")]
        public string EndToEndId { get; set; }

        [JsonPropertyName("contact")]
        public Contact Contact { get; set; }

        [JsonPropertyName("amount")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double Amount { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("payable_type")]
        public string PayableType { get; set; }

        [JsonPropertyName("payable_id")]
        public string PayableId { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }
    }
}
