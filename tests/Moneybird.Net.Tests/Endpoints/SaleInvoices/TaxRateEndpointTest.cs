using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.SalesInvoices;
using Moneybird.Net.Endpoints.SalesInvoices.Models;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.SaleInvoices;

public class SaleInvoiceEndpointTest : CommonTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly SalesInvoiceEndpoint _taxRateEndpoint;
    
    private const string ResponsePath = "./Responses/Endpoints/SaleInvoices/postSaleInvoice.json";

    public SaleInvoiceEndpointTest()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _taxRateEndpoint = new SalesInvoiceEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async void GetTaxRatesAsync_ByAccessToken_Returns_TaxRates()
    {
        var options = new SalesInvoiceCreateOptions
        {
            SalesInvoice = new SalesInvoiceCreate
            {
                Reference = "30052",
                ContactId = "370131045504255127",
                Currency = "USD",
                DetailsAttributes = new List<SalesInvoiceCreateDetail>
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

        var saleInvoice = JsonSerializer.Deserialize<SalesInvoice>(createResponse, _config.SerializerOptions);
        Assert.NotNull(saleInvoice);

        var actualSaleInvoice = await _taxRateEndpoint.CreateSaleInvoiceAsync(AdministrationId, options, AccessToken);
        Assert.NotNull(actualSaleInvoice);

        saleInvoice.Should().BeEquivalentTo(actualSaleInvoice);
    }
}
