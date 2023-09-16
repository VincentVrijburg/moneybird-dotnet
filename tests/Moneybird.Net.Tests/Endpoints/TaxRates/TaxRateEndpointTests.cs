using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.TaxRates;
using Moneybird.Net.Endpoints.TaxRates.Models;
using Moneybird.Net.Entities.TaxRates;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.TaxRates;

public class TaxRateEndpointTests : CommonTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly TaxRateEndpoint _taxRateEndpoint;
    
    private const string ResponsePath = "./Responses/Endpoints/TaxRates/getTaxRates.json";

    public TaxRateEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _taxRateEndpoint = new TaxRateEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async void GetTaxRatesAsync_ByAccessToken_Returns_TaxRates()
    {
        var taxRatesList = await File.ReadAllTextAsync(ResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(taxRatesList);

        var taxRates = JsonSerializer.Deserialize<List<TaxRate>>(taxRatesList, _config.SerializerOptions);
        Assert.NotNull(taxRates);

        var actualTaxRates = await _taxRateEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualTaxRates);
        
        var actualTaxRateList = actualTaxRates.ToList();
        Assert.Equal(taxRates.Count, actualTaxRateList.Count);
        
        foreach (var actualTaxRate in actualTaxRateList)
        {
            var user = taxRates.FirstOrDefault(w => w.Id == actualTaxRate.Id);
            Assert.NotNull(user);

            user.Should().BeEquivalentTo(actualTaxRate);
        }
    }
    
    [Fact]
    public async void GetTaxRatesAsync_UsingFilterOptions_ByAccessToken_Returns_TaxRates()
    {
        var taxRatesList = await File.ReadAllTextAsync(ResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(taxRatesList);

        var taxRates = JsonSerializer.Deserialize<List<TaxRate>>(taxRatesList, _config.SerializerOptions);
        Assert.NotNull(taxRates);
        
        var filterOptions = new TaxRateFilterOptions
        {
            Active = true,
            ShowTax = true
        };

        var actualTaxRates = await _taxRateEndpoint.GetAsync(AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualTaxRates);
        
        var actualTaxRateList = actualTaxRates.ToList();
        Assert.Equal(taxRates.Count, actualTaxRateList.Count);
        
        foreach (var actualTaxRate in actualTaxRateList)
        {
            var user = taxRates.FirstOrDefault(w => w.Id == actualTaxRate.Id);
            Assert.NotNull(user);

            user.Should().BeEquivalentTo(actualTaxRate);
        }
    }
}
