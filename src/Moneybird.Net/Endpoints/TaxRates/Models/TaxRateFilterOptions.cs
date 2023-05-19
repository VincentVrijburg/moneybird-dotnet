using System;
using System.Collections.Generic;
using Moneybird.Net.Entities.TaxRates;

namespace Moneybird.Net.Endpoints.TaxRates.Models
{
    public class TaxRateFilterOptions
    {
        public string Name { get; set; }
        
        public string PartialName { get; set; }
        
        public int? Percentage { get; set; }
        
        public TaxRateType? TaxRateType { get; set; }
        
        public IReadOnlyCollection<TaxRateType> State { get; set; }

        public string Country { get; set; }
        
        public bool? ShowTax { get; set; }
        
        public bool? Active { get; set; }

        public DateTime? CreatedAfter { get; set; }

        public DateTime? UpdatedAfter { get; set; }
    }
}
