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

public class SalesInvoiceEndpointTest : CommonTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly SalesInvoiceEndpoint _salesInvoiceEndpoint;
    
    private const string ResponsePath = "./Responses/Endpoints/SalesInvoices/postSalesInvoice.json";

    public SalesInvoiceEndpointTest()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _salesInvoiceEndpoint = new SalesInvoiceEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async void CreateSalesInvoiceAsync_ByAccessToken_Returns_SalesInvoice()
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

        var actualSaleInvoice = await _salesInvoiceEndpoint.CreateAsync(AdministrationId, options, AccessToken);
        Assert.NotNull(actualSaleInvoice);

        saleInvoice.Should().BeEquivalentTo(actualSaleInvoice);
    }
}
