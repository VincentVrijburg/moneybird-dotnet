using System.Text.Json;
using Moneybird.Net.Extensions;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class JsonElementExtensionsTests
{
    [Fact]
    public void GetErrorMessage_FromStringErrorJsonElement_Returns_CorrectString()
    {
        const string json = "{\"error\":\"Contact is required\",\"symbolic\":{\"contact\":\"required\"}}";
        var jsonElement = JsonDocument.Parse(json);
        var actualValue = jsonElement.RootElement.GetErrorMessage();
        
        Assert.Equal("Contact is required", actualValue);
    }
    
    [Fact]
    public void GetErrorMessage_FromObjectErrorJsonElement_Returns_CorrectString()
    {
        const string json = "{\"error\":{\"delivery_method\":[\"The sender address must contain an email address\"]}}";
        var jsonElement = JsonDocument.Parse(json);
        var actualValue = jsonElement.RootElement.GetErrorMessage();
        
        Assert.Equal("delivery_method: The sender address must contain an email address", actualValue);
    }
    
    [Fact]
    public void GetErrorMessage_FromObjectsErrorJsonElement_Returns_CorrectString()
    {
        const string json = "{\"error\":{\"firstname\":[\"is required\"],\"lastname\":[\"is required\"],\"company_name\":[\"is required\"]}}";
        var jsonElement = JsonDocument.Parse(json);
        var actualValue = jsonElement.RootElement.GetErrorMessage();
        
        Assert.Equal("firstname: is required, lastname: is required, company_name: is required", actualValue);
    }
    
    [Fact]
    public void GetErrorMessage_FromObjectMultipleErrorsJsonElement_Returns_CorrectString()
    {
        const string json = "{\"error\":{\"delivery_method\":[\"The delivery method is required\",\"The sender address must contain an email address\"]}}";
        var jsonElement = JsonDocument.Parse(json);
        var actualValue = jsonElement.RootElement.GetErrorMessage();
        
        Assert.Equal("delivery_method: The delivery method is required, delivery_method: The sender address must contain an email address", actualValue);
    }
}