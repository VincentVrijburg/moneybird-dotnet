using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.FinancialMutations;

namespace Moneybird.Net.Models.FinancialMutations
{
    public class FinancialMutationFilterOptions : IMoneybirdFilterOptions
    {
        public string Period { get; set; }

        public FinancialMutationState[] State { get; set; }

        public FinancialMutationType[] MutationType { get; set; }

        public string FinancialAccountId { get; set; }

        public double? AmountFrom { get; set; }

        public double? AmountTo { get; set; }
    }
}
