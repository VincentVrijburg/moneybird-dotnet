using Moneybird.Net.Endpoints.ExternalSalesInvoices.Models;
using Moneybird.Net.Entities.ExternalSalesInvoices;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Extensions;
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

        var expectedString = $"filter=state:{state}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromExternalSalesInvoiceFilterOptions_PeriodOnly_Returns_CorrectString()
    {
        const string period = "ThisYear";
            
        var options = new ExternalSalesInvoiceFilterOptions
        {
            Period = period
        };

        var expectedString = $"filter=period:{period}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromExternalSalesInvoiceFilterOptions_ContactIdOnly_Returns_CorrectString()
    {
        const int contactId = 10;
            
        var options = new ExternalSalesInvoiceFilterOptions
        {
            ContactId = contactId
        };

        var expectedString = $"filter=contact_id:{contactId}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromExternalSalesInvoiceFilterOptions_All_Returns_CorrectString()
    {
        const ExternalSalesInvoiceState state = ExternalSalesInvoiceState.All;
        const string period = "ThisYear";
        const int contactId = 10;
            
        var options = new ExternalSalesInvoiceFilterOptions
        {
            State = state,
            Period = period,
            ContactId = contactId
        };

        var expectedString = $"filter=state:{state}," +
                             $"period:{period}," +
                             $"contact_id:{contactId}";
            
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
}
