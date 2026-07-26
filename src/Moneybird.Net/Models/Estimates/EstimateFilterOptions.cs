using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.Estimates;

namespace Moneybird.Net.Models.Estimates
{
    public class EstimateFilterOptions : IMoneybirdFilterOptions
    {
        public EstimateState? State { get; set; }
        
        public string Period { get; set; }
        
        public string ContactId { get; set; }
        
        public string WorkflowId { get; set; }
    }
}
