using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.SaleInvoices;
using Moneybird.Net.Entities.SaleInvoices;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.SaleInvoices;

public class SaleInvoiceEndpointTest : CommonTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly SaleInvoiceEndpoint _taxRateEndpoint;
    
    private const string ResponsePath = "./Responses/Endpoints/SaleInvoices/postSaleInvoice.json";

    public SaleInvoiceEndpointTest()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _taxRateEndpoint = new SaleInvoiceEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async void GetTaxRatesAsync_ByAccessToken_Returns_TaxRates()
    {
        var options = new SaleInvoiceCreateOptions
        {
            SaleInvoice = new SaleInvoiceCreate
            {
                Reference = "30052",
                ContactId = "370131045504255127",
                Currency = "USD",
                DetailsAttributes = new List<SaleInvoiceCreateDetail>
                {
                    new()
                    {
                        Description = "Rocking Chair",
                        Price = 159.99,
                        TaxRateId = "370131045760107682"
                    }
                }
            }
        };

        var createResponse = await File.ReadAllTextAsync(ResponsePath);

        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<string>>()))
            .ReturnsAsync(createResponse);

        var saleInvoice = JsonSerializer.Deserialize<SaleInvoice>(createResponse, _config.SerializerOptions);
        Assert.NotNull(saleInvoice);

        var actualSaleInvoice = await _taxRateEndpoint.CreateSaleInvoice(AdministrationId, options, AccessToken);
        Assert.NotNull(actualSaleInvoice);

        saleInvoice.Should().BeEquivalentTo(actualSaleInvoice);
    }
}
