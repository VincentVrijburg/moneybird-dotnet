using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.ExternalSalesInvoices;

namespace Moneybird.Net.Models.ExternalSalesInvoices
{
    public class ExternalSalesInvoiceFilterOptions : IMoneybirdFilterOptions
    {
        public ExternalSalesInvoiceState? State { get; set; }
        
        public string Period { get; set; }
        
        public string ContactId { get; set; }
    }
}
