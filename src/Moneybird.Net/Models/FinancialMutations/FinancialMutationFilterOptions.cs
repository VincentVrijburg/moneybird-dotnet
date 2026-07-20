using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.FinancialMutations
{
    public class FinancialMutationFilterOptions : IMoneybirdFilterOptions
    {
        public string Period { get; set; }

        public string State { get; set; }

        public string MutationType { get; set; }

        public string FinancialAccountId { get; set; }

        public double? AmountFrom { get; set; }

        public double? AmountTo { get; set; }
    }
}
