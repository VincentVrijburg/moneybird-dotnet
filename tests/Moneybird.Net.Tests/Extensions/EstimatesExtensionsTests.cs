using Moneybird.Net.Entities.Estimates;
using Moneybird.Net.Extensions;
using Moneybird.Net.Models.Estimates;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class EstimatesExtensionsTests
{
    [Fact]
    public void GetFilterString_FromEstimateFilterOptions_NoFilters_Returns_EmptyString()
    {
        var options = new EstimateFilterOptions();

        var actualString = options.GetFilterString();

        Assert.Equal(string.Empty, actualString);
    }

    [Fact]
    public void GetFilterString_FromEstimateFilterOptions_StateOnly_Returns_CorrectString()
    {
        var options = new EstimateFilterOptions
        {
            State = EstimateState.Open
        };

        const string expectedString = "filter=state:open";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromEstimateFilterOptions_PeriodOnly_Returns_CorrectString()
    {
        var options = new EstimateFilterOptions
        {
            Period = "this_month"
        };

        const string expectedString = "filter=period:this_month";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromEstimateFilterOptions_ContactIdOnly_Returns_CorrectString()
    {
        var options = new EstimateFilterOptions
        {
            ContactId = "493530535844382136"
        };

        const string expectedString = "filter=contact_id:493530535844382136";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromEstimateFilterOptions_WorkflowIdOnly_Returns_CorrectString()
    {
        var options = new EstimateFilterOptions
        {
            WorkflowId = "493530504057848981"
        };

        const string expectedString = "filter=workflow_id:493530504057848981";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromEstimateFilterOptions_All_Returns_CorrectString()
    {
        var options = new EstimateFilterOptions
        {
            State = EstimateState.Open,
            Period = "this_month",
            ContactId = "493530535844382136",
            WorkflowId = "493530504057848981"
        };

        const string expectedString =
            "filter=state:open," +
            "period:this_month," +
            "contact_id:493530535844382136," +
            "workflow_id:493530504057848981";

        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }
}
