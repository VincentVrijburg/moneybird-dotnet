using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.TaxTotals;

public class TaxTotal
{
    [JsonPropertyName("tax_rate_id")]
    public string TaxRateId { get; set; }

    [JsonPropertyName("taxable_amount")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public double? TaxableAmount { get; set; }

    [JsonPropertyName("taxable_amount_base")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public double? TaxableAmountBase { get; set; }

    [JsonPropertyName("tax_amount")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public double? TaxAmount { get; set; }

    [JsonPropertyName("tax_amount_base")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public double? TaxAmountBase { get; set; }
}
