using System;

namespace Moneybird.Net.Endpoints.Contacts.Models
{
    public class ContactFilterOptions
    {
        public DateTime? CreatedAfter { get; set; }

        public DateTime? UpdatedAfter { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}