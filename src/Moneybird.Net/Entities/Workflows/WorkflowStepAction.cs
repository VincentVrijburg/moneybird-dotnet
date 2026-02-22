using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Workflows
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WorkflowStepAction
    {
        [JsonStringEnumMemberName("suspend_moneybird_account")]
        SuspendMoneybirdAccount,
        
        [JsonStringEnumMemberName("reactivate_moneybird_account")]
        ReactivateMoneybirdAccount,
        
        [JsonStringEnumMemberName("warn_moneybird_account")]
        WarnMoneybirdAccount,
        
        [JsonStringEnumMemberName("cancel_subscription")]
        CancelSubscription
    }
}