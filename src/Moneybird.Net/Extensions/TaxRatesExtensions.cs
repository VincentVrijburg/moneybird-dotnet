using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Endpoints.TaxRates.Models;

namespace Moneybird.Net.Extensions
{
    internal static class TaxRatesExtensions
    {
        public static string GetFilterString(this TaxRateFilterOptions options)
        {
            var filterValues = new List<string>();

            if (!string.IsNullOrEmpty(options.Name))
            {
                filterValues.Add($"name:{options.Name}");
            }
            
            if (!string.IsNullOrEmpty(options.PartialName))
            {
                filterValues.Add($"partial_name:{options.PartialName}");
            }
            
            if (options.Percentage.HasValue)
            {
                filterValues.Add($"percentage:{options.Percentage.Value}");
            }
            
            if (options.TaxRateType.HasValue)
            {
                filterValues.Add($"tax_rate_type:{options.TaxRateType.Value}");
            }
            
            if (options.State != null && options.State.Any())
            {
                filterValues.Add($"state:{string.Join("|", options.State)}");
            }
            
            if (!string.IsNullOrEmpty(options.Country))
            {
                filterValues.Add($"country:{options.Country}");
            }
            
            if (options.ShowTax.HasValue)
            {
                filterValues.Add($"show_tax:{options.ShowTax.Value}");
            }
            
            if (options.Active.HasValue)
            {
                filterValues.Add($"active:{options.Active.Value}");
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
