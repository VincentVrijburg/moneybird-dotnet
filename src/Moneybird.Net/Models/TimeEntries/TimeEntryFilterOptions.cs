using System;
using System.Collections.Generic;
using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.TimeEntries;

namespace Moneybird.Net.Models.TimeEntries
{
    public class TimeEntryFilterOptions : IMoneybirdFilterOptions
    {
        public IReadOnlyCollection<TimeEntryState> State { get; set; }
        
        public string Period { get; set; }
        
        public string ContactId { get; set; }
        
        public bool? IncludeNilContacts { get; set; }
        
        public bool? IncludeActive { get; set; }
        
        public string ProjectId { get; set; }
        
        public string UserId { get; set; }
        
        public DateTime Day { get; set; }
    }
}