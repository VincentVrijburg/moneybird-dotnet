using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.GeneralDocuments;

namespace Moneybird.Net.Models.GeneralDocuments;

public class GeneralDocumentFilterOptions : IMoneybirdFilterOptions
{
    public string Period { get; set; }

    public GeneralDocumentState[] State { get; set; }

    public GeneralDocumentRecurringFilter[] Recurring { get; set; }

    public GeneralDocumentAttachmentFilter[] Attachment { get; set; }

    public string Reference { get; set; }

    public string ContactId { get; set; }

    public string LedgerAccountId { get; set; }

    public string UpdatedAfter { get; set; }
}
