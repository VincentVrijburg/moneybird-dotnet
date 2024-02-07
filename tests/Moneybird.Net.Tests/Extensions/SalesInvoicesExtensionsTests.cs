using System;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Extensions;
using Moneybird.Net.Models.SalesInvoices;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class SalesInvoicesExtensionsTests
{
    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_StateOnly_Returns_CorrectString()
    {
        const SalesInvoiceState state = SalesInvoiceState.Reminded;
            
        var options = new SalesInvoiceFilterOptions
        {
            State = state
        };

        const string expectedString = "filter=state:reminded";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_PeriodOnly_Returns_CorrectString()
    {
        const string period = "this_month";
            
        var options = new SalesInvoiceFilterOptions
        {
            Period = period
        };

        const string expectedString = "filter=period:this_month";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_ReferenceOnly_Returns_CorrectString()
    {
        const string reference = "test";
            
        var options = new SalesInvoiceFilterOptions
        {
            Reference = reference
        };

        const string expectedString = "filter=reference:test";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_ContactIdOnly_Returns_CorrectString()
    {
        const string contactId = "381666401394414610";
            
        var options = new SalesInvoiceFilterOptions
        {
            ContactId = contactId
        };

        const string expectedString = "filter=contact_id:381666401394414610";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_RecurringSalesInvoiceIdOnly_Returns_CorrectString()
    {
        const string recurringSalesInvoiceId = "395773954254439850";
            
        var options = new SalesInvoiceFilterOptions
        {
            RecurringSalesInvoiceId = recurringSalesInvoiceId
        };

        const string expectedString = "filter=recurring_sales_invoice_id:395773954254439850";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_WorkflowIdOnly_Returns_CorrectString()
    {
        const string workflowId = "395773789247375285";
            
        var options = new SalesInvoiceFilterOptions
        {
            WorkflowId = workflowId
        };

        const string expectedString = $"filter=workflow_id:395773789247375285";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_CreatedOnly_Returns_CorrectString()
    {
        var createdAfter = DateTime.UtcNow;
            
        var options = new SalesInvoiceFilterOptions
        {
            CreatedAfter = createdAfter
        };

        var expectedString = $"filter=created_after:{createdAfter:O}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_UpdatedOnly_Returns_CorrectString()
    {
        var updatedAfter = DateTime.UtcNow;
            
        var options = new SalesInvoiceFilterOptions
        {
            UpdatedAfter = updatedAfter
        };

        var expectedString = $"filter=updated_after:{updatedAfter:O}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_All_Returns_CorrectString()
    {
        const SalesInvoiceState state = SalesInvoiceState.PendingPayment;
        const string period = "this_year";
        const string reference = "test";
        const string contactId = "381666401394414610";
        const string recurringSalesInvoiceId = "395773954254439850";
        const string workflowId = "395773789247375285";
        var createdAfter = DateTime.UtcNow;
        var updatedAfter = DateTime.UtcNow;
            
        var options = new SalesInvoiceFilterOptions
        {
            State = state,
            Period = period,
            Reference = reference,
            ContactId = contactId,
            RecurringSalesInvoiceId = recurringSalesInvoiceId,
            WorkflowId = workflowId,
            CreatedAfter = createdAfter,
            UpdatedAfter = updatedAfter
        };

        var expectedString = $"filter=state:pending_payment," +
                             $"period:this_year," +
                             $"reference:test," +
                             $"contact_id:381666401394414610," +
                             $"recurring_sales_invoice_id:395773954254439850," +
                             $"workflow_id:395773789247375285," +
                             $"created_after:{createdAfter:O}," +
                             $"updated_after:{updatedAfter:O}";

        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
}
