using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.FinancialStatements
{
    public class FinancialStatementCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("financial_statement")]
        public FinancialStatementCreate FinancialStatement { get; set; }
    }
}