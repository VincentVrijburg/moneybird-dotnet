using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.PurchaseTransactions;

namespace Moneybird.Net.Models.PurchaseTransactions
{
    public class PurchaseTransactionFilterOptions : IMoneybirdFilterOptions
    {
        public PurchaseTransactionState[] State { get; set; }

        public string Period { get; set; }

        public bool? Unbatched { get; set; }

        public bool? SignableByUser { get; set; }
    }
}
