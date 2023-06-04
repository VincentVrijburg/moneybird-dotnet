using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Endpoints.ExternalSalesInvoices.Models;

namespace Moneybird.Net.Extensions
{
    internal static class ExternalSalesInvoicesExtensions
    {
        public static string GetFilterString(this ExternalSalesInvoiceFilterOptions options)
        {
            var filterValues = new List<string>();

            if (options.State.HasValue)
            {
                filterValues.Add($"state:{options.State.Value}");
            }
            
            if (!string.IsNullOrEmpty(options.Period))
            {
                filterValues.Add($"period:{options.Period}");
            }
            
            if (options.ContactId.HasValue)
            {
                filterValues.Add($"contact_id:{options.ContactId.Value}");
            }

            return filterValues.Any()
                ? $"filter={string.Join(",", filterValues)}"
                : string.Empty;
        }
    }
}
