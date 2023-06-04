using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Workflows
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
