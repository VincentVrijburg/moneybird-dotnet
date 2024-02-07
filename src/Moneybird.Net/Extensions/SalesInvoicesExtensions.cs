using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Models.SalesInvoices;

namespace Moneybird.Net.Extensions
{
    public static class SalesInvoicesExtensions
    {
        public static string GetFilterString(this SalesInvoiceFilterOptions options)
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
            
            if (!string.IsNullOrEmpty(options.Reference))
            {
                filterValues.Add($"reference:{options.Reference}");
            }
            
            if (!string.IsNullOrEmpty(options.ContactId))
            {
                filterValues.Add($"contact_id:{options.ContactId}");
            }
            
            if (!string.IsNullOrEmpty(options.RecurringSalesInvoiceId))
            {
                filterValues.Add($"recurring_sales_invoice_id:{options.RecurringSalesInvoiceId}");
            }
            
            if (!string.IsNullOrEmpty(options.WorkflowId))
            {
                filterValues.Add($"workflow_id:{options.WorkflowId}");
            }
            
            if (options.CreatedAfter.HasValue)
            {
                filterValues.Add($"created_after:{options.CreatedAfter.Value:O}");
            }

            if (options.UpdatedAfter.HasValue)
            {
                filterValues.Add($"updated_after:{options.UpdatedAfter.Value:O}");
            }

            return filterValues.Any()
                ? $"filter={string.Join(",", filterValues)}"
                : string.Empty;
        }
    }
}