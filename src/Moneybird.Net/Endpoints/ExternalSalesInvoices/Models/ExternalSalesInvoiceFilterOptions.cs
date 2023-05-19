using Moneybird.Net.Entities.SalesInvoices;

namespace Moneybird.Net.Endpoints.ExternalSalesInvoices.Models
{
    public class ExternalSalesInvoiceFilterOptions
    {
        public ExternalSalesInvoiceState? State { get; set; }
        
        public SalesInvoicePeriod? Period { get; set; }
        
        public int? ContactId { get; set; }
    }
}
