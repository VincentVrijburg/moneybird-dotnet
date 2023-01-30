using System.Text.Json.Serialization;

namespace Moneybird.Net.Misc
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum WorkflowType
    {
        [JsonPropertyName("InvoiceWorkflow")]
        InvoiceWorkflow,
        [JsonPropertyName("EstimateWorkflow")]
        EstimateWorkflow
    }
}