using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.FinancialStatements
{
    public class FinancialStatementUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("financial_statement")]
        public FinancialStatementUpdate FinancialStatement { get; set; }
    }
}