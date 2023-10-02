using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.LedgerAccounts
{
    public class LedgerAccountBooking : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }
        
        [JsonPropertyName("financial_mutation_id")]
        public string FinancialMutationId { get; set; }
        
        [JsonPropertyName("ledger_account_id")]
        public string LedgerAccountId { get; set; }
        
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("price")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double Price { get; set; }
        
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}