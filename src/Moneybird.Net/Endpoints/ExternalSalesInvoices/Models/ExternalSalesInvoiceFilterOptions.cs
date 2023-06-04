using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.ExternalSalesInvoices;
using Moneybird.Net.Entities.SalesInvoices;

namespace Moneybird.Net.Endpoints.ExternalSalesInvoices.Models
{
    public class ExternalSalesInvoiceFilterOptions : IMoneybirdFilterOptions
    {
        public ExternalSalesInvoiceState? State { get; set; }
        
        public SalesInvoicePeriod? Period { get; set; }
        
        public int? ContactId { get; set; }
    }
}
