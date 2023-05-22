using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.LegderAccounts;
using Moneybird.Net.Endpoints.Users;
using Moneybird.Net.Entities.LedgerAccounts;
using Moneybird.Net.Entities.Users;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.Users;

public class LedgerAccountEndpointTest : CommonTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly LedgerAccountEndpoint _ledgerAccountEndpoint;
    
    private const string ResponsePath = "./Responses/Endpoints/LedgerAccounts/getLedgerAccounts.json";

    public LedgerAccountEndpointTest()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _ledgerAccountEndpoint = new LedgerAccountEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async void GetLedgerAccountsAsync_ByAccessToken_Returns_LedgerAccounts()
    {
        var ledgerAccountListJson = await File.ReadAllTextAsync(ResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(ledgerAccountListJson);

        var ledgerAccountList = JsonSerializer.Deserialize<List<LedgerAccount>>(ledgerAccountListJson, _config.SerializerOptions);
        Assert.NotNull(ledgerAccountList);

        var actualLedgerAccountList = await _ledgerAccountEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualLedgerAccountList);

        var actualLedgerAccounts = actualLedgerAccountList.ToList();
        Assert.Equal(ledgerAccountList.Count, actualLedgerAccounts.Count);
        foreach (var actualLedgerAccount in actualLedgerAccounts)
        {
            var ledgerAccount = ledgerAccountList.FirstOrDefault(w => w.Id == actualLedgerAccount.Id);
            Assert.NotNull(ledgerAccount);

            ledgerAccount.Should().BeEquivalentTo(actualLedgerAccount);
        }
    }
}
