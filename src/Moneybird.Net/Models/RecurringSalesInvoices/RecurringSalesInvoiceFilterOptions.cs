using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Misc;

namespace Moneybird.Net.Models.RecurringSalesInvoices
{
    public class RecurringSalesInvoiceFilterOptions : IMoneybirdFilterOptions
    {
        public string State { get; set; }
        
        public FrequencyType? Frequency { get; set; }
        
        public bool? AutoSend { get; set; }
        
        public string ContactId { get; set; }
        
        public string WorkflowId { get; set; }
    }
}
