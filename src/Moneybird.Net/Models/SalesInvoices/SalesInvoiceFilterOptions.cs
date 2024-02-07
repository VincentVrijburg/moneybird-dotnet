using System;
using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.SalesInvoices;

namespace Moneybird.Net.Models.SalesInvoices
{
    public class SalesInvoiceFilterOptions : IMoneybirdFilterOptions
    {
        public SalesInvoiceState? State { get; set; }
        
        public string Period { get; set; }
        
        public string Reference { get; set; }

        public string ContactId { get; set; }
        
        public string RecurringSalesInvoiceId { get; set; }
        
        public string WorkflowId { get; set; }
        
        public DateTime? CreatedAfter { get; set; }
        
        public DateTime? UpdatedAfter { get; set; }
    }
}