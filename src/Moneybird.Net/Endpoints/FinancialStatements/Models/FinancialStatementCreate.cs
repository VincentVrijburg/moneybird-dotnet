using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.FinancialMutations;

namespace Moneybird.Net.Endpoints.FinancialStatements.Models
{
    public class FinancialStatementCreate
    {
        [JsonPropertyName("financial_statement")]
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
        
        [JsonPropertyName("financial_mutations_attributes")]
        public IReadOnlyList<FinancialMutationAttribute> FinancialMutationAttributes { get; set; }
    }
}