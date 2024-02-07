using System;
using System.Collections.Generic;
using Moneybird.Net.Entities.TaxRates;
using Moneybird.Net.Extensions;
using Moneybird.Net.Models.TaxRates;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class TaxRatesExtensionsTests
{
    [Fact]
    public void GetFilterString_FromTaxRateFilterOptions_NameOnly_Returns_CorrectString()
    {
        const string name = "Money Bird";
        
        var options = new TaxRateFilterOptions
        {
            Name = name
        };

        const string expectedString = $"filter=name:{name}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTaxRateFilterOptions_PartialNameOnly_Returns_CorrectString()
    {
        const string partialName = "Bird";
            
        var options = new TaxRateFilterOptions
        {
            PartialName = partialName
        };

        const string expectedString = $"filter=partial_name:{partialName}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromTaxRateFilterOptions_PercentageOnly_Returns_CorrectString()
    {
        const int percentage = 21;
            
        var options = new TaxRateFilterOptions
        {
            Percentage = percentage
        };

        var expectedString = $"filter=percentage:{percentage}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTaxRateFilterOptions_TaxRateTypeOnly_Returns_CorrectString()
    {
        const TaxRateType taxRateType = TaxRateType.GeneralJournalDocument;
            
        var options = new TaxRateFilterOptions
        {
            TaxRateType = taxRateType
        };

        const string expectedString = "filter=tax_rate_type:general_journal_document";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTaxRateFilterOptions_StateOnly_Returns_CorrectString()
    {
        var taxRateType = new List<TaxRateType> { TaxRateType.PurchaseInvoice, TaxRateType.SalesInvoice };
            
        var options = new TaxRateFilterOptions
        {
            State = taxRateType
        };

        const string expectedString = "filter=state:purchase_invoice|sales_invoice";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTaxRateFilterOptions_CountryOnly_Returns_CorrectString()
    {
        const string country = "NL";
            
        var options = new TaxRateFilterOptions
        {
            Country = country
        };

        const string expectedString = "filter=country:NL";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTaxRateFilterOptions_ShowTaxOnly_Returns_CorrectString()
    {
        const bool showTax = true;
            
        var options = new TaxRateFilterOptions
        {
            ShowTax = showTax
        };

        const string expectedString = "filter=show_tax:true";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTaxRateFilterOptions_ActiveOnly_Returns_CorrectString()
    {
        const bool active = true;
            
        var options = new TaxRateFilterOptions
        {
            Active = active
        };

        const string expectedString = "filter=active:true";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTaxRateFilterOptions_CreatedOnly_Returns_CorrectString()
    {
        var createdAfter = DateTime.UtcNow;
            
        var options = new TaxRateFilterOptions
        {
            CreatedAfter = createdAfter
        };

        var expectedString = $"filter=created_after:{createdAfter:O}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTaxRateFilterOptions_UpdatedOnly_Returns_CorrectString()
    {
        var updatedAfter = DateTime.UtcNow;
            
        var options = new TaxRateFilterOptions
        {
            UpdatedAfter = updatedAfter
        };

        var expectedString = $"filter=updated_after:{updatedAfter:O}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTaxRateFilterOptions_All_Returns_CorrectString()
    {
        const string name = "Money Bird";
        const string partialName = "Bird";
        const int percentage = 21;
        const TaxRateType taxRateType = TaxRateType.All;
        var state = new List<TaxRateType> { TaxRateType.PurchaseInvoice, TaxRateType.SalesInvoice };
        const string country = "NL";
        const bool showTax = true;
        const bool active = true;
        var createdAfter = DateTime.UtcNow - TimeSpan.FromDays(1);
        var updatedAfter = DateTime.UtcNow;
            
        var options = new TaxRateFilterOptions()
        {
            Name = name,
            PartialName = partialName,
            Percentage = percentage,
            TaxRateType = taxRateType,
            State = state,
            Country = country,
            ShowTax = showTax,
            Active = active,
            CreatedAfter = createdAfter,
            UpdatedAfter = updatedAfter
        };

        var expectedString = $"filter=name:Money Bird," +
                             $"partial_name:Bird," +
                             $"percentage:21," +
                             $"tax_rate_type:all," +
                             $"state:purchase_invoice|sales_invoice," +
                             $"country:NL," +
                             $"show_tax:true," +
                             $"active:true," +
                             $"created_after:{createdAfter:O}," +
                             $"updated_after:{updatedAfter:O}";
            
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
}
