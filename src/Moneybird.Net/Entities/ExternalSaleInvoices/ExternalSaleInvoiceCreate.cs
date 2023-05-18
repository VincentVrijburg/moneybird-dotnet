using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.SaleInvoices;

namespace Moneybird.Net.Entities.ExternalSaleInvoices
{
    public class ExternalSaleInvoiceCreate
    {
        /// <summary>
        /// Should be a valid contact id.
        /// </summary>
        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        [JsonPropertyName("due_date")]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// ISO three-character currency code, e.g. EUR or USD.
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("prices_are_incl_tax")]
        public bool? PricesAreInclTax { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("source_url")]
        public string SourceUrl { get; set; }

        [JsonPropertyName("details_attributes")]
        public IReadOnlyList<ExternalSaleInvoiceCreateDetail> DetailsAttributes { get; set; }
    }
}
