using System;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Endpoints.Contacts.Models
{
    public class ContactFilterOptions : IMoneybirdFilterOptions
    {
        public DateTime? CreatedAfter { get; set; }

        public DateTime? UpdatedAfter { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}