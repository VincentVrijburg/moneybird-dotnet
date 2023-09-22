using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.FinancialAccounts;
using Moneybird.Net.Entities.FinancialAccounts;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.FinancialAccounts;

public class FinancialAccountEndpointTests : CommonTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly FinancialAccountEndpoint _financialAccountEndpoint;
    
    private const string GetFinancialAccountsResponsePath = "./Responses/Endpoints/FinancialAccounts/getFinancialAccounts.json";

    public FinancialAccountEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _financialAccountEndpoint = new FinancialAccountEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async void GetFinancialAccountsAsync_ByAccessToken_Returns_FinancialAccounts()
    {
        var financialAccountsList = await File.ReadAllTextAsync(GetFinancialAccountsResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(financialAccountsList);

        var financialAccounts = JsonSerializer.Deserialize<List<FinancialAccount>>(financialAccountsList, _config.SerializerOptions);
        Assert.NotNull(financialAccounts);

        var actualFinancialAccounts = await _financialAccountEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualFinancialAccounts);
        
        var actualFinancialAccountsList = actualFinancialAccounts.ToList();
        Assert.Equal(financialAccounts.Count, actualFinancialAccountsList.Count);
        
        foreach (var actualFinancialAccount in actualFinancialAccountsList)
        {
            var financialAccount = financialAccounts.FirstOrDefault(fa => fa.Id == actualFinancialAccount.Id);
            Assert.NotNull(financialAccount);

            financialAccount.Should().BeEquivalentTo(actualFinancialAccount);
        }
    }
}