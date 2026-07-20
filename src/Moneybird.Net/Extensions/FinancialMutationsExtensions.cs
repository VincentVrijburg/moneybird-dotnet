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

            if (options.State != null && options.State.Any())
            {
                filterValues.Add($"state:{string.Join("|", options.State.Select(s => s.ToString().ToSnakeCase()))}");
            }

            if (options.MutationType != null && options.MutationType.Any())
            {
                filterValues.Add($"mutation_type:{string.Join("|", options.MutationType.Select(s => s.ToString().ToSnakeCase()))}");
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
