using Moneybird.Net.Extensions;
using Moneybird.Net.Misc;
using Moneybird.Net.Models.RecurringSalesInvoices;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class RecurringSalesInvoicesExtensionsTests
{
    [Fact]
    public void GetFilterString_FromRecurringSalesInvoiceFilterOptions_NoFilters_Returns_EmptyString()
    {
        var options = new RecurringSalesInvoiceFilterOptions();

        const string expectedString = "";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromRecurringSalesInvoiceFilterOptions_StateOnly_Returns_CorrectString()
    {
        var options = new RecurringSalesInvoiceFilterOptions
        {
            State = "active"
        };

        const string expectedString = "filter=state:active";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromRecurringSalesInvoiceFilterOptions_FrequencyOnly_Returns_CorrectString()
    {
        var options = new RecurringSalesInvoiceFilterOptions
        {
            Frequency = FrequencyType.Month
        };

        const string expectedString = "filter=frequency:month";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromRecurringSalesInvoiceFilterOptions_FrequencyAll_Returns_CorrectString()
    {
        var options = new RecurringSalesInvoiceFilterOptions
        {
            Frequency = FrequencyType.All
        };

        const string expectedString = "filter=frequency:all";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromRecurringSalesInvoiceFilterOptions_AutoSendOnly_Returns_CorrectString()
    {
        var options = new RecurringSalesInvoiceFilterOptions
        {
            AutoSend = false
        };

        const string expectedString = "filter=auto_send:false";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromRecurringSalesInvoiceFilterOptions_ContactIdOnly_Returns_CorrectString()
    {
        var options = new RecurringSalesInvoiceFilterOptions
        {
            ContactId = "492734981118887600"
        };

        const string expectedString = "filter=contact_id:492734981118887600";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromRecurringSalesInvoiceFilterOptions_WorkflowIdOnly_Returns_CorrectString()
    {
        var options = new RecurringSalesInvoiceFilterOptions
        {
            WorkflowId = "492734879064130703"
        };

        const string expectedString = "filter=workflow_id:492734879064130703";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromRecurringSalesInvoiceFilterOptions_All_Returns_CorrectString()
    {
        var options = new RecurringSalesInvoiceFilterOptions
        {
            State = "active",
            Frequency = FrequencyType.Month,
            AutoSend = false,
            ContactId = "492734981118887600",
            WorkflowId = "492734879064130703"
        };

        const string expectedString = "filter=state:active," +
                                      "frequency:month," +
                                      "auto_send:false," +
                                      "contact_id:492734981118887600," +
                                      "workflow_id:492734879064130703";
        
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
}
