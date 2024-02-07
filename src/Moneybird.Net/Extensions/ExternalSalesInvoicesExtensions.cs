using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Models.ExternalSalesInvoices;

namespace Moneybird.Net.Extensions
{
    internal static class ExternalSalesInvoicesExtensions
    {
        public static string GetFilterString(this ExternalSalesInvoiceFilterOptions options)
        {
            var filterValues = new List<string>();

            if (options.State.HasValue)
            {
                filterValues.Add($"state:{options.State.Value.ToString().ToSnakeCase()}");
            }
            
            if (!string.IsNullOrEmpty(options.Period))
            {
                filterValues.Add($"period:{options.Period}");
            }
            
            if (!string.IsNullOrEmpty(options.ContactId))
            {
                filterValues.Add($"contact_id:{options.ContactId}");
            }

            return filterValues.Any()
                ? $"filter={string.Join(",", filterValues)}"
                : string.Empty;
        }
    }
}
