using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.PurchaseTransactions
{
    public class PurchaseTransactionBatch : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("financial_account_id")]
        public string FinancialAccountId { get; set; }

        [JsonPropertyName("state")]
        public PurchaseTransactionBatchState State { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
