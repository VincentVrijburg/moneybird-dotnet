using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;
using Moneybird.Net.Entities.TaxRates;
using Moneybird.Net.Entities.TimeEntries;
using Moneybird.Net.Extensions;
using Moneybird.Net.Models.TimeEntries;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class TimeEntriesExtensionsTests
{
    [Fact]
    public void GetFilterString_FromTimeEntryFilterOptions_NoFilters_Returns_EmptyString()
    {
        var options = new TimeEntryFilterOptions();

        const string expectedString = "";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTimeEntryFilterOptions_StateOnly_Returns_CorrectString()
    {
        var state = new List<TimeEntryState> { TimeEntryState.Open };
        
        var options = new TimeEntryFilterOptions
        {
            State = state
        };

        const string expectedString = "filter=state:open";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTimeEntryFilterOptions_PeriodOnly_Returns_CorrectString()
    {
        const string period = "this_year";
        
        var options = new TimeEntryFilterOptions
        {
            Period = period
        };

        const string expectedString = "filter=period:this_year";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTimeEntryFilterOptions_ContactIdOnly_Returns_CorrectString()
    {
        const string contactId = "381666401394414610";
        
        var options = new TimeEntryFilterOptions
        {
            ContactId = contactId
        };

        const string expectedString = "filter=contact_id:381666401394414610";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTimeEntryFilterOptions_IncludeNilContactsOnly_Returns_CorrectString()
    {
        const bool includeNilContacts = false;
        
        var options = new TimeEntryFilterOptions
        {
            IncludeNilContacts = includeNilContacts
        };

        const string expectedString = "filter=include_nil_contacts:false";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTimeEntryFilterOptions_IncludeActiveOnly_Returns_CorrectString()
    {
        const bool includeActive = true;
        
        var options = new TimeEntryFilterOptions
        {
            IncludeActive = includeActive
        };

        const string expectedString = "filter=include_active:true";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTimeEntryFilterOptions_ProjectIdOnly_Returns_CorrectString()
    {
        const string projectId = "386844401331200766";
        
        var options = new TimeEntryFilterOptions
        {
            ProjectId = projectId
        };

        const string expectedString = "filter=project_id:386844401331200766";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTimeEntryFilterOptions_UserIdOnly_Returns_CorrectString()
    {
        const string userId = "252969831744742910";
        
        var options = new TimeEntryFilterOptions
        {
            UserId = userId
        };

        const string expectedString = "filter=user_id:252969831744742910";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTimeEntryFilterOptions_DayOnly_Returns_CorrectString()
    {
        var day = DateTime.Parse("2023-11-05");
        
        var options = new TimeEntryFilterOptions
        {
            Day = day
        };

        const string expectedString = "filter=day:2023-11-05";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
    
    [Fact]
    public void GetFilterString_FromTaxRateFilterOptions_All_Returns_CorrectString()
    {
        var state = new List<TimeEntryState> { TimeEntryState.All };
        const string period = "this_month";
        const string contactId = "381666401394414610";
        const bool includeNilContacts = true;
        const bool includeActive = false;
        const string projectId = "386844401331200766";
        const string userId = "252969831744742910";
        var day = DateTime.Parse("2023-11-10");
        
        var options = new TimeEntryFilterOptions
        {
            State = state,
            Period = period,
            ContactId = contactId,
            IncludeNilContacts = includeNilContacts,
            IncludeActive = includeActive,
            ProjectId = projectId,
            UserId = userId,
            Day = day
        };

        const string expectedString = $"filter=state:all," +
                                      $"period:this_month," +
                                      $"contact_id:381666401394414610," +
                                      $"include_nil_contacts:true," +
                                      $"include_active:false," +
                                      $"project_id:386844401331200766," +
                                      $"user_id:252969831744742910," +
                                      $"day:2023-11-10";
        
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
}
