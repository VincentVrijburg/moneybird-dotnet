using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.LedgerAccounts;
using Moneybird.Net.Entities.Payments;

namespace Moneybird.Net.Entities.FinancialMutations
{
    public class FinancialMutation : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("amount")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double Amount { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("contra_account_name")]
        public string ContraAccountName { get; set; }

        [JsonPropertyName("contra_account_number")]
        public string ContraAccountNumber { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("amount_open")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double AmountOpen { get; set; }

        [JsonPropertyName("sepa_fields")]
        public Sepa SepaFields { get; set; }

        [JsonPropertyName("batch_reference")]
        public string BatchReference { get; set; }

        [JsonPropertyName("financial_account_id")]
        public string FinancialAccountId { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("original_amount")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double? OriginalAmount { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("financial_statement_id")]
        public string FinancialStatementId { get; set; }

        [JsonPropertyName("processed_at")]
        public DateTime? ProcessedAt { get; set; }

        [JsonPropertyName("account_servicer_transaction_id")]
        public string AccountServicerTransactionId { get; set; }
        
        [JsonPropertyName("payments")]
        public IReadOnlyList<Payment> Payments { get; set; }
        
        [JsonPropertyName("ledger_account_bookings")]
        public IReadOnlyList<LedgerAccountBooking> LedgerAccountBookings { get; set; }
    }
}