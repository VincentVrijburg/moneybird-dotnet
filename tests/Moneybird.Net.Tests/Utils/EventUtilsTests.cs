using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Utils;
using Xunit;

namespace Moneybird.Net.Tests.Utils;

public class EventUtilsTests : CommonTestBase
{
    private const string ContactCreatedEventResponsePath = "./Responses/Events/contactCreatedEvent.json";
    
    [Fact]
    public async Task ParseEvent_ValidJson_ReturnsEvent()
    {
        var eventJson = await File.ReadAllTextAsync(ContactCreatedEventResponsePath);
        
        var actualEvent = EventUtils.ParseEvent(eventJson);
        Assert.NotNull(actualEvent);
    }
    
    [Fact]
    public async Task ParseEvent_InvalidJson_ThrowsException()
    {
        var eventJson = await File.ReadAllTextAsync(ContactCreatedEventResponsePath);
        eventJson = eventJson.Replace("}", "");
        
        Assert.Throws<JsonException>(() => EventUtils.ParseEvent(eventJson));
    }
    
    [Fact]
    public void ParseEvent_NullJson_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => EventUtils.ParseEvent(null));
    }
    
    [Fact]
    public void ParseEvent_EmptyJson_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => EventUtils.ParseEvent(string.Empty));
    }
    
    [Fact]
    public async Task ConstructEvent_ValidJson_ReturnsEvent()
    {
        var eventJson = await File.ReadAllTextAsync(ContactCreatedEventResponsePath);
        
        var actualEvent = EventUtils.ConstructEvent(eventJson, SecretWebhookToken);
        Assert.NotNull(actualEvent);
    }
    
    [Fact]
    public async Task ConstructEvent_InvalidJson_ThrowsException()
    {
        var eventJson = await File.ReadAllTextAsync(ContactCreatedEventResponsePath);
        eventJson = eventJson.Replace("}", "");
        
        Assert.Throws<JsonException>(() => EventUtils.ConstructEvent(eventJson, SecretWebhookToken));
    }
    
    [Fact]
    public async Task ConstructEvent_InvalidToken_ThrowsException()
    {
        var eventJson = await File.ReadAllTextAsync(ContactCreatedEventResponsePath);
        
        Assert.Throws<MoneybirdException>(() => EventUtils.ConstructEvent(eventJson, "invalid-token"));
    }
    
    [Fact]
    public void ConstructEvent_NullJson_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => EventUtils.ConstructEvent(null, SecretWebhookToken));
    }
    
    [Fact]
    public void ConstructEvent_EmptyJson_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => EventUtils.ConstructEvent(string.Empty, SecretWebhookToken));
    }
    
    [Fact]
    public void ConstructEvent_NullToken_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => EventUtils.ConstructEvent("{}", null));
    }
    
    [Fact]
    public void ConstructEvent_EmptyToken_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => EventUtils.ConstructEvent("{}", string.Empty));
    }
}
