using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Models.PurchaseTransactions;

namespace Moneybird.Net.Extensions
{
    internal static class PurchaseTransactionsExtensions
    {
        public static string GetFilterString(this PurchaseTransactionFilterOptions options)
        {
            var filterValues = new List<string>();

            if (options.State != null && options.State.Any())
            {
                filterValues.Add($"state:{string.Join("|", options.State.Select(s => s.ToString().ToSnakeCase()))}");
            }

            if (!string.IsNullOrEmpty(options.Period))
            {
                filterValues.Add($"period:{options.Period}");
            }

            if (options.Unbatched.HasValue)
            {
                filterValues.Add($"unbatched:{options.Unbatched.Value.ToString().ToLowerInvariant()}");
            }

            if (options.SignableByUser.HasValue)
            {
                filterValues.Add($"signable_by_user:{options.SignableByUser.Value.ToString().ToLowerInvariant()}");
            }

            return filterValues.Any()
                ? $"filter={string.Join(",", filterValues)}"
                : string.Empty;
        }
    }
}
