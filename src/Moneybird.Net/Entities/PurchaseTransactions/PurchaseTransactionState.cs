using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.PurchaseTransactions
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PurchaseTransactionState
    {
        [JsonStringEnumMemberName("all")]
        All,

        [JsonStringEnumMemberName("open")]
        Open,

        [JsonStringEnumMemberName("cancelled")]
        Cancelled,

        [JsonStringEnumMemberName("paid")]
        Paid,

        [JsonStringEnumMemberName("pending_payment")]
        PendingPayment,

        [JsonStringEnumMemberName("error")]
        Error,

        [JsonStringEnumMemberName("awaiting_authorization")]
        AwaitingAuthorization,

        [JsonStringEnumMemberName("preparing")]
        Preparing
    }
}
