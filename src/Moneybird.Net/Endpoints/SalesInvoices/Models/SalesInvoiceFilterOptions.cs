using System;
using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.SalesInvoices;

namespace Moneybird.Net.Endpoints.SalesInvoices.Models
{
    public class SalesInvoiceFilterOptions : IMoneybirdFilterOptions
    {
        public SalesInvoiceState? State { get; set; }
        
        public SalesInvoicePeriod? Period { get; set; }
        
        public string Reference { get; set; }

        public int? ContactId { get; set; }
        
        public int? RecurringSalesInvoiceId { get; set; }
        
        public int? WorkflowId { get; set; }
        
        public DateTime? CreatedAfter { get; set; }
        
        public DateTime? UpdatedAfter { get; set; }
    }
}