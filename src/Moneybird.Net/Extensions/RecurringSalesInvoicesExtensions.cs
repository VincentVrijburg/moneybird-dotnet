using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Models.RecurringSalesInvoices;

namespace Moneybird.Net.Extensions
{
    internal static class RecurringSalesInvoicesExtensions
    {
        public static string GetFilterString(this RecurringSalesInvoiceFilterOptions options)
        {
            var filterValues = new List<string>();

            if (!string.IsNullOrEmpty(options.State))
            {
                filterValues.Add($"state:{options.State}");
            }
            
            if (options.Frequency.HasValue)
            {
                filterValues.Add($"frequency:{options.Frequency.Value.ToString().ToSnakeCase()}");
            }
            
            if (options.AutoSend.HasValue)
            {
                filterValues.Add($"auto_send:{options.AutoSend.Value.ToString().ToLowerInvariant()}");
            }
            
            if (!string.IsNullOrEmpty(options.ContactId))
            {
                filterValues.Add($"contact_id:{options.ContactId}");
            }
            
            if (!string.IsNullOrEmpty(options.WorkflowId))
            {
                filterValues.Add($"workflow_id:{options.WorkflowId}");
            }

            return filterValues.Any()
                ? $"filter={string.Join(",", filterValues)}"
                : string.Empty;
        }
    }
}
