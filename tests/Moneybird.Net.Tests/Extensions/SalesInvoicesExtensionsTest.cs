using System;
using Moneybird.Net.Endpoints.SalesInvoices.Models;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Extensions;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class SalesInvoicesExtensionsTest
{
    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_StateOnly_Returns_CorrectString()
    {
        const SalesInvoiceState state = SalesInvoiceState.All;
            
        var options = new SalesInvoiceFilterOptions
        {
            State = state
        };

        var expectedString = $"filter=state:{state}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_PeriodOnly_Returns_CorrectString()
    {
        const string period = "ThisYear";
            
        var options = new SalesInvoiceFilterOptions
        {
            Period = period
        };

        var expectedString = $"filter=period:{period}";
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

        var expectedString = $"filter=reference:{reference}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_ContactIdOnly_Returns_CorrectString()
    {
        const int contactId = 10;
            
        var options = new SalesInvoiceFilterOptions
        {
            ContactId = contactId
        };

        var expectedString = $"filter=contact_id:{contactId}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_RecurringSalesInvoiceIdOnly_Returns_CorrectString()
    {
        const int recurringSalesInvoiceId = 100;
            
        var options = new SalesInvoiceFilterOptions
        {
            RecurringSalesInvoiceId = recurringSalesInvoiceId
        };

        var expectedString = $"filter=recurring_sales_invoice_id:{recurringSalesInvoiceId}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromSalesInvoiceFilterOptions_WorkflowIdOnly_Returns_CorrectString()
    {
        const int workflowId = 1;
            
        var options = new SalesInvoiceFilterOptions
        {
            WorkflowId = workflowId
        };

        var expectedString = $"filter=workflow_id:{workflowId}";
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
        const SalesInvoiceState state = SalesInvoiceState.All;
        const string period = "ThisYear";
        const string reference = "test";
        const int contactId = 10;
        const int recurringSalesInvoiceId = 100;
        const int workflowId = 1;
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

        var expectedString = $"filter=state:{state}," +
                             $"period:{period}," +
                             $"reference:{reference}," +
                             $"contact_id:{contactId}," +
                             $"recurring_sales_invoice_id:{recurringSalesInvoiceId}," +
                             $"workflow_id:{workflowId}," +
                             $"created_after:{createdAfter:O}," +
                             $"updated_after:{updatedAfter:O}";

        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
}
