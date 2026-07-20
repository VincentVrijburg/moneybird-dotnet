using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.PurchaseTransactions
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PurchaseTransactionBatchState
    {
        [JsonStringEnumMemberName("cancelled")]
        Cancelled,

        [JsonStringEnumMemberName("open")]
        Open
    }
}
