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
    
    private const string GetVerificationResponsePath = "./Responses/Endpoints/Verifications/getVerification.json";
    private const string GetVerificationAllPendingResponsePath = "./Responses/Endpoints/Verifications/getVerificationAllPending.json";
    private const string GetVerificationBankPendingResponsePath = "./Responses/Endpoints/Verifications/getVerificationBankPending.json";
    private const string GetVerificationCommercePendingResponsePath = "./Responses/Endpoints/Verifications/getVerificationCommercePending.json";
    private const string GetVerificationEmailPendingResponsePath = "./Responses/Endpoints/Verifications/getVerificationEmailPending.json";
    private const string GetVerificationTaxPendingResponsePath = "./Responses/Endpoints/Verifications/getVerificationTaxPending.json";

    public VerificationEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _verificationEndpoint = new VerificationEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async Task GetVerificationAsync_ByAccessToken_Returns_Verification()
    {
        var verificationJson = await File.ReadAllTextAsync(GetVerificationResponsePath);
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(verificationJson);
        
        var verification = JsonSerializer.Deserialize<Verification>(verificationJson, _config.SerializerOptions);
        Assert.NotNull(verification);
        
        var actualVerification = await _verificationEndpoint.GetVerificationAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualVerification);
        
        verification.Should().BeEquivalentTo(actualVerification);
        
        // All properties should be filled
        Assert.NotNull(actualVerification.BankAccountNumbers);
        Assert.NotEmpty(actualVerification.BankAccountNumbers);
        Assert.NotNull(actualVerification.ChamberOfCommerceNumber);
        Assert.NotNull(actualVerification.Emails);
        Assert.NotEmpty(actualVerification.Emails);
        Assert.NotNull(actualVerification.TaxNumber);
    }
    
    [Fact]
    public async Task GetVerificationAsync_ByAccessToken_Returns_VerificationAllPending()
    {
        var verificationJson = await File.ReadAllTextAsync(GetVerificationAllPendingResponsePath);
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(verificationJson);
        
        var verification = JsonSerializer.Deserialize<Verification>(verificationJson, _config.SerializerOptions);
        Assert.NotNull(verification);
        
        var actualVerification = await _verificationEndpoint.GetVerificationAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualVerification);
        
        verification.Should().BeEquivalentTo(actualVerification);
        
        // All properties should not be filled
        Assert.Null(actualVerification.BankAccountNumbers);
        Assert.Null(actualVerification.ChamberOfCommerceNumber);
        Assert.Null(actualVerification.Emails);
        Assert.Null(actualVerification.TaxNumber);
    }
    
    [Fact]
    public async Task GetVerificationAsync_ByAccessToken_Returns_VerificationBankPending()
    {
        var verificationJson = await File.ReadAllTextAsync(GetVerificationBankPendingResponsePath);
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(verificationJson);
        
        var verification = JsonSerializer.Deserialize<Verification>(verificationJson, _config.SerializerOptions);
        Assert.NotNull(verification);
        
        var actualVerification = await _verificationEndpoint.GetVerificationAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualVerification);
        
        verification.Should().BeEquivalentTo(actualVerification);
        
        // All properties except bank account numbers should be filled
        Assert.Null(actualVerification.BankAccountNumbers);
        Assert.NotNull(actualVerification.ChamberOfCommerceNumber);
        Assert.NotNull(actualVerification.Emails);
        Assert.NotEmpty(actualVerification.Emails);
        Assert.NotNull(actualVerification.TaxNumber);
    }
    
    [Fact]
    public async Task GetVerificationAsync_ByAccessToken_Returns_VerificationCommercePending()
    {
        var verificationJson = await File.ReadAllTextAsync(GetVerificationCommercePendingResponsePath);
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(verificationJson);
        
        var verification = JsonSerializer.Deserialize<Verification>(verificationJson, _config.SerializerOptions);
        Assert.NotNull(verification);
        
        var actualVerification = await _verificationEndpoint.GetVerificationAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualVerification);
        
        verification.Should().BeEquivalentTo(actualVerification);
        
        // All properties except chamber of commerce number should be filled
        Assert.NotNull(actualVerification.BankAccountNumbers);
        Assert.NotEmpty(actualVerification.BankAccountNumbers);
        Assert.Null(actualVerification.ChamberOfCommerceNumber);
        Assert.NotNull(actualVerification.Emails);
        Assert.NotEmpty(actualVerification.Emails);
        Assert.NotNull(actualVerification.TaxNumber);
    }
    
    [Fact]
    public async Task GetVerificationAsync_ByAccessToken_Returns_VerificationEmailPending()
    {
        var verificationJson = await File.ReadAllTextAsync(GetVerificationEmailPendingResponsePath);
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(verificationJson);
        
        var verification = JsonSerializer.Deserialize<Verification>(verificationJson, _config.SerializerOptions);
        Assert.NotNull(verification);
        
        var actualVerification = await _verificationEndpoint.GetVerificationAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualVerification);
        
        verification.Should().BeEquivalentTo(actualVerification);
        
        // All properties except emails should be filled
        Assert.NotNull(actualVerification.BankAccountNumbers);
        Assert.NotEmpty(actualVerification.BankAccountNumbers);
        Assert.NotNull(actualVerification.ChamberOfCommerceNumber);
        Assert.Null(actualVerification.Emails);
        Assert.NotNull(actualVerification.TaxNumber);
    }
    
    [Fact]
    public async Task GetVerificationAsync_ByAccessToken_Returns_VerificationTaxPending()
    {
        var verificationJson = await File.ReadAllTextAsync(GetVerificationTaxPendingResponsePath);
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(verificationJson);
        
        var verification = JsonSerializer.Deserialize<Verification>(verificationJson, _config.SerializerOptions);
        Assert.NotNull(verification);
        
        var actualVerification = await _verificationEndpoint.GetVerificationAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualVerification);
        
        verification.Should().BeEquivalentTo(actualVerification);
        
        // All properties except tax number should be filled
        Assert.NotNull(actualVerification.BankAccountNumbers);
        Assert.NotEmpty(actualVerification.BankAccountNumbers);
        Assert.NotNull(actualVerification.ChamberOfCommerceNumber);
        Assert.NotNull(actualVerification.Emails);
        Assert.NotEmpty(actualVerification.Emails);
        Assert.Null(actualVerification.TaxNumber);
    }
}