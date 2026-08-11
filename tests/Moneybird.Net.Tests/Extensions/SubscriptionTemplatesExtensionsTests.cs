using System;
using Moneybird.Net.Extensions;
using Moneybird.Net.Models.SubscriptionTemplates;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class SubscriptionTemplatesExtensionsTests
{
    [Fact]
    public void GetQueryParameters_FromNullOptions_Returns_Null()
    {
        SubscriptionTemplateSalesLinkOptions options = null;

        var actualParameters = options.GetQueryParameters();

        Assert.Null(actualParameters);
    }

    [Fact]
    public void GetQueryParameters_FromEmptyOptions_Returns_Null()
    {
        var options = new SubscriptionTemplateSalesLinkOptions();

        var actualParameters = options.GetQueryParameters();

        Assert.Null(actualParameters);
    }

    [Fact]
    public void GetQueryParameters_FromAllOptions_Returns_CorrectValues()
    {
        var options = new SubscriptionTemplateSalesLinkOptions
        {
            ContactId = "123 456",
            StartDate = new DateTime(2026, 8, 15),
            ProductId = "789"
        };

        var actualParameters = options.GetQueryParameters();

        Assert.Equal(3, actualParameters.Count);
        Assert.Equal("contact_id=123 456", actualParameters[0]);
        Assert.Equal("start_date=2026-08-15", actualParameters[1]);
        Assert.Equal("product_id=789", actualParameters[2]);
    }
}
