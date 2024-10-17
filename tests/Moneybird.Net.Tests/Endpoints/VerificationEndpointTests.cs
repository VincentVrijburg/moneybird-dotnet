using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.Verifications;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class VerificationEndpointTests : CommonTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly VerificationEndpoint _verificationEndpoint;
    
    private const string GetVerificationsResponsePath = "./Responses/Endpoints/Verifications/getVerification.json";
    private const string GetVerificationsAllPendingResponsePath = "./Responses/Endpoints/Verifications/getVerificationAllPending.json";
    private const string GetVerificationsBankPendingResponsePath = "./Responses/Endpoints/Verifications/getVerificationBankPending.json";
    private const string GetVerificationsCommercePendingResponsePath = "./Responses/Endpoints/Verifications/getVerificationCommercePending.json";
    private const string GetVerificationsEmailPendingResponsePath = "./Responses/Endpoints/Verifications/getVerificationEmailPending.json";
    private const string GetVerificationsTaxPendingResponsePath = "./Responses/Endpoints/Verifications/getVerificationTaxPending.json";

    public VerificationEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _verificationEndpoint = new VerificationEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async Task GetAsync_ByAccessToken_Returns_Verifications()
    {
        var verificationsJson = await File.ReadAllTextAsync(GetVerificationsResponsePath);
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(verificationsJson);
        
        var verifications = JsonSerializer.Deserialize<Verification>(verificationsJson, _config.SerializerOptions);
        Assert.NotNull(verifications);
        
        var actualVerifications = await _verificationEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualVerifications);
        
        verifications.Should().BeEquivalentTo(actualVerifications);
        
        // All properties should be filled
        Assert.NotNull(actualVerifications.BankAccountNumbers);
        Assert.NotEmpty(actualVerifications.BankAccountNumbers);
        Assert.NotNull(actualVerifications.ChamberOfCommerceNumber);
        Assert.NotNull(actualVerifications.Emails);
        Assert.NotEmpty(actualVerifications.Emails);
        Assert.NotNull(actualVerifications.TaxNumber);
    }
    
    [Fact]
    public async Task GetAsync_ByAccessToken_Returns_VerificationsAllPending()
    {
        var verificationsJson = await File.ReadAllTextAsync(GetVerificationsAllPendingResponsePath);
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(verificationsJson);
        
        var verifications = JsonSerializer.Deserialize<Verification>(verificationsJson, _config.SerializerOptions);
        Assert.NotNull(verifications);
        
        var actualVerifications = await _verificationEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualVerifications);
        
        verifications.Should().BeEquivalentTo(actualVerifications);
        
        // All properties should not be filled
        Assert.Null(actualVerifications.BankAccountNumbers);
        Assert.Null(actualVerifications.ChamberOfCommerceNumber);
        Assert.Null(actualVerifications.Emails);
        Assert.Null(actualVerifications.TaxNumber);
    }
    
    [Fact]
    public async Task GetAsync_ByAccessToken_Returns_VerificationsBankPending()
    {
        var verificationsJson = await File.ReadAllTextAsync(GetVerificationsBankPendingResponsePath);
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(verificationsJson);
        
        var verifications = JsonSerializer.Deserialize<Verification>(verificationsJson, _config.SerializerOptions);
        Assert.NotNull(verifications);
        
        var actualVerifications = await _verificationEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualVerifications);
        
        verifications.Should().BeEquivalentTo(actualVerifications);
        
        // All properties except bank account numbers should be filled
        Assert.Null(actualVerifications.BankAccountNumbers);
        Assert.NotNull(actualVerifications.ChamberOfCommerceNumber);
        Assert.NotNull(actualVerifications.Emails);
        Assert.NotEmpty(actualVerifications.Emails);
        Assert.NotNull(actualVerifications.TaxNumber);
    }
    
    [Fact]
    public async Task GetVerificationAsync_ByAccessToken_Returns_VerificationCommercePending()
    {
        var verificationsJson = await File.ReadAllTextAsync(GetVerificationsCommercePendingResponsePath);
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(verificationsJson);
        
        var verifications = JsonSerializer.Deserialize<Verification>(verificationsJson, _config.SerializerOptions);
        Assert.NotNull(verifications);
        
        var actualVerifications = await _verificationEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualVerifications);
        
        verifications.Should().BeEquivalentTo(actualVerifications);
        
        // All properties except chamber of commerce number should be filled
        Assert.NotNull(actualVerifications.BankAccountNumbers);
        Assert.NotEmpty(actualVerifications.BankAccountNumbers);
        Assert.Null(actualVerifications.ChamberOfCommerceNumber);
        Assert.NotNull(actualVerifications.Emails);
        Assert.NotEmpty(actualVerifications.Emails);
        Assert.NotNull(actualVerifications.TaxNumber);
    }
    
    [Fact]
    public async Task GetAsync_ByAccessToken_Returns_VerificationsEmailPending()
    {
        var verificationsJson = await File.ReadAllTextAsync(GetVerificationsEmailPendingResponsePath);
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(verificationsJson);
        
        var verifications = JsonSerializer.Deserialize<Verification>(verificationsJson, _config.SerializerOptions);
        Assert.NotNull(verifications);
        
        var actualVerifications = await _verificationEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualVerifications);
        
        verifications.Should().BeEquivalentTo(actualVerifications);
        
        // All properties except emails should be filled
        Assert.NotNull(actualVerifications.BankAccountNumbers);
        Assert.NotEmpty(actualVerifications.BankAccountNumbers);
        Assert.NotNull(actualVerifications.ChamberOfCommerceNumber);
        Assert.Null(actualVerifications.Emails);
        Assert.NotNull(actualVerifications.TaxNumber);
    }
    
    [Fact]
    public async Task GetAsync_ByAccessToken_Returns_VerificationsTaxPending()
    {
        var verificationsJson = await File.ReadAllTextAsync(GetVerificationsTaxPendingResponsePath);
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(verificationsJson);
        
        var verifications = JsonSerializer.Deserialize<Verification>(verificationsJson, _config.SerializerOptions);
        Assert.NotNull(verifications);
        
        var actualVerifications = await _verificationEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualVerifications);
        
        verifications.Should().BeEquivalentTo(actualVerifications);
        
        // All properties except tax number should be filled
        Assert.NotNull(actualVerifications.BankAccountNumbers);
        Assert.NotEmpty(actualVerifications.BankAccountNumbers);
        Assert.NotNull(actualVerifications.ChamberOfCommerceNumber);
        Assert.NotNull(actualVerifications.Emails);
        Assert.NotEmpty(actualVerifications.Emails);
        Assert.Null(actualVerifications.TaxNumber);
    }
}