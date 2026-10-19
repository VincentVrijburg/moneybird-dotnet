using Moneybird.Net.Entities.GeneralDocuments;
using Moneybird.Net.Extensions;
using Moneybird.Net.Models.GeneralDocuments;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class GeneralDocumentsExtensionsTests
{
    [Fact]
    public void GetFilterString_FromGeneralDocumentFilterOptions_All_Returns_CorrectString()
    {
        var options = new GeneralDocumentFilterOptions
        {
            Period = "this_year",
            State = new[] { GeneralDocumentState.Open, GeneralDocumentState.Paid },
            Recurring = new[] { GeneralDocumentRecurringFilter.Enabled },
            Attachment = new[] { GeneralDocumentAttachmentFilter.With, GeneralDocumentAttachmentFilter.Without },
            Reference = "Contract",
            ContactId = "501141414111872361",
            LedgerAccountId = "381666401394414610",
            UpdatedAfter = "2026-10-16T10:15:17.279Z"
        };

        const string expectedString = "filter=period:this_year," +
                                      "state:open|paid," +
                                      "recurring:enabled," +
                                      "attachment:with|without," +
                                      "reference:Contract," +
                                      "contact_id:501141414111872361," +
                                      "ledger_account_id:381666401394414610," +
                                      "updated_after:2026-10-16T10:15:17.279Z";

        Assert.Equal(expectedString, options.GetFilterString());
    }

    [Fact]
    public void GetFilterString_FromGeneralDocumentFilterOptions_Empty_Returns_EmptyString()
    {
        var options = new GeneralDocumentFilterOptions();

        Assert.Equal(string.Empty, options.GetFilterString());
    }
}
