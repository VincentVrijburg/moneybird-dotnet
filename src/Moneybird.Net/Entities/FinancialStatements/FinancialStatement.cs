using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.FinancialMutations;

namespace Moneybird.Net.Entities.FinancialStatements
{
    public class FinancialStatement : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }
        
        [JsonPropertyName("financial_account_id")]
        public string FinancialAccountId { get; set; }
        
        [JsonPropertyName("reference")]
        public string Reference { get; set; }
        
        [JsonPropertyName("official_date")]
        public DateTime? OfficialDate { get; set; }
        
        [JsonPropertyName("official_balance")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double? OfficialBalance { get; set; }
        
        [JsonPropertyName("importer_service")]
        public string ImporterService { get; set; }
        
        [JsonPropertyName("financial_mutations")]
        public IReadOnlyList<FinancialMutation> FinancialMutations { get; set; }
    }
}