using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.Webhooks;
using Moneybird.Net.Http;
using Moneybird.Net.Models.Webhooks;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class WebhookEndpointTests : WebhookEndpointTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly WebhookEndpoint _webhookEndpoint;
        
    private const string GetWebhooksResponsePath = "./Responses/Endpoints/Webhooks/getWebhooks.json";
    private const string WebhookCreateOptionsPath = "./Responses/Endpoints/Webhooks/webhookCreateOptions.json";
    private const string PostWebhookResponsePath = "./Responses/Endpoints/Webhooks/postWebhook.json";
        
    public WebhookEndpointTests()
    {  
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _webhookEndpoint = new WebhookEndpoint(_config, _requester.Object);
    }
        
    [Fact]
    public async void GetWebhooksAsync_ByAccessToken_Returns_WebhookList()
    {
        var webhookListJson = await File.ReadAllTextAsync(GetWebhooksResponsePath);
            
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(webhookListJson);
            
        var webhookList = JsonSerializer.Deserialize<List<Webhook>>(webhookListJson, _config.SerializerOptions);
        Assert.NotNull(webhookList);

        var actualWebhookList = await _webhookEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualWebhookList);
        
        var actualWebhooks = actualWebhookList.ToList();
        Assert.Equal(webhookList.Count, actualWebhooks.Count);
        foreach (var actualWebhook in actualWebhooks)
        {
            var webhook = webhookList.FirstOrDefault(w => w.Id == actualWebhook.Id);
            Assert.NotNull(webhook);

            webhook.Should().BeEquivalentTo(actualWebhook);
        }
    }
    
    [Fact]
    public async void CreateWebhookAsync_ByAccessToken_Returns_NewWebhook()
    {
        var options = new WebhookCreateOptions
        {
            Url = "http://www.mocky.io/v2/5185415ba171ea3a00704eed",
            EnabledEvents = new List<WebhookEvent>
            {
                WebhookEvent.ContactCreated
            }
        };
        
        var serializedOptions = JsonSerializer.Serialize(options, _config.SerializerOptions);
        var actualSerializedOptions = await File.ReadAllTextAsync(WebhookCreateOptionsPath);
        Assert.Equal(serializedOptions, actualSerializedOptions);
        
        var createResponse = await File.ReadAllTextAsync(PostWebhookResponsePath);

        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<string>>()))
            .ReturnsAsync(createResponse);

        var expectedWebhook = JsonSerializer.Deserialize<Webhook>(createResponse, _config.SerializerOptions);
        Assert.NotNull(expectedWebhook);

        var actualWebhook = await _webhookEndpoint.CreateAsync(AdministrationId, options, AccessToken);
        Assert.NotNull(actualWebhook);

        actualWebhook.Should().BeEquivalentTo(expectedWebhook);
    }
    
    [Fact]
    public async void DeleteWebhookAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var actualWebhook = await _webhookEndpoint.DeleteByIdAsync(AdministrationId, WebhookId, AccessToken);
        Assert.True(actualWebhook);
    }
}
