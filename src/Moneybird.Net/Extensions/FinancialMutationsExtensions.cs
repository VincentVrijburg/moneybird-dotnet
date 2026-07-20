using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Moneybird.Net.Models.FinancialMutations;

namespace Moneybird.Net.Extensions
{
    internal static class FinancialMutationsExtensions
    {
        public static string GetFilterString(this FinancialMutationFilterOptions options)
        {
            var filterValues = new List<string>();

            if (!string.IsNullOrEmpty(options.Period))
            {
                filterValues.Add($"period:{options.Period}");
            }

            if (!string.IsNullOrEmpty(options.State))
            {
                filterValues.Add($"state:{options.State}");
            }

            if (!string.IsNullOrEmpty(options.MutationType))
            {
                filterValues.Add($"mutation_type:{options.MutationType}");
            }

            if (!string.IsNullOrEmpty(options.FinancialAccountId))
            {
                filterValues.Add($"financial_account_id:{options.FinancialAccountId}");
            }

            if (options.AmountFrom.HasValue)
            {
                filterValues.Add($"amount_from:{options.AmountFrom.Value.ToString(CultureInfo.InvariantCulture)}");
            }

            if (options.AmountTo.HasValue)
            {
                filterValues.Add($"amount_to:{options.AmountTo.Value.ToString(CultureInfo.InvariantCulture)}");
            }

            return filterValues.Any()
                ? $"filter={string.Join(",", filterValues)}"
                : string.Empty;
        }
    }
}
