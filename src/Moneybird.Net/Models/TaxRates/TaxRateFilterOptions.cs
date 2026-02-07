using System;
using System.Collections.Generic;
using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.TaxRates;

namespace Moneybird.Net.Models.TaxRates
{
    public class TaxRateFilterOptions : IMoneybirdFilterOptions
    {
        public string Name { get; set; }
        
        public string PartialName { get; set; }
        
        public int? Percentage { get; set; }
        
        public TaxRateType? TaxRateType { get; set; }
        
        public IList<TaxRateType> State { get; set; }

        public string Country { get; set; }
        
        public bool? ShowTax { get; set; }
        
        public bool? Active { get; set; }

        public DateTime? CreatedAfter { get; set; }

        public DateTime? UpdatedAfter { get; set; }
    }
}
