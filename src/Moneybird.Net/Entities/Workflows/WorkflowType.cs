using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Workflows
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WorkflowType
    {
        [JsonStringEnumMemberName("InvoiceWorkflow")]
        InvoiceWorkflow,
        [JsonStringEnumMemberName("EstimateWorkflow")]
        EstimateWorkflow
    }
}
