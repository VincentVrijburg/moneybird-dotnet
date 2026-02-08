using Moneybird.Net.Entities.ExternalSalesInvoices;
using Moneybird.Net.Extensions;
using Moneybird.Net.Models.ExternalSalesInvoices;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class ExternalSalesInvoicesExtensionsTests
{
    [Fact]
    public void GetFilterString_FromExternalSalesInvoiceFilterOptions_StateOnly_Returns_CorrectString()
    {
        const ExternalSalesInvoiceState state = ExternalSalesInvoiceState.All;
            
        var options = new ExternalSalesInvoiceFilterOptions
        {
            State = state
        };

        const string expectedString = "filter=state:all";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromExternalSalesInvoiceFilterOptions_PeriodOnly_Returns_CorrectString()
    {
        const string period = "this_year";
            
        var options = new ExternalSalesInvoiceFilterOptions
        {
            Period = period
        };

        const string expectedString = "filter=period:this_year";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromExternalSalesInvoiceFilterOptions_ContactIdOnly_Returns_CorrectString()
    {
        const string contactId = "381666401394414610";
            
        var options = new ExternalSalesInvoiceFilterOptions
        {
            ContactId = contactId
        };

        const string expectedString = "filter=contact_id:381666401394414610";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromExternalSalesInvoiceFilterOptions_All_Returns_CorrectString()
    {
        const ExternalSalesInvoiceState state = ExternalSalesInvoiceState.Late;
        const string period = "this_month";
        const string contactId = "381666401394414610";
            
        var options = new ExternalSalesInvoiceFilterOptions
        {
            State = state,
            Period = period,
            ContactId = contactId
        };

        const string expectedString = $"filter=state:late," +
                                      $"period:this_month," +
                                      $"contact_id:381666401394414610";
            
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
}
