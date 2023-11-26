using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.Products;
using Moneybird.Net.Http;
using Moneybird.Net.Misc;
using Moneybird.Net.Models.Products;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.Products;

public class ProductEndpointTests : ProductTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly ProductEndpoint _productEndpoint;
    
    private const string GetProductsResponsePath = "./Responses/Endpoints/Products/getProducts.json";
    private const string GetProductResponsePath = "./Responses/Endpoints/Products/getProduct.json";
    private const string PostProductResponsePath = "./Responses/Endpoints/Products/postProduct.json";
    private const string PatchProductResponsePath = "./Responses/Endpoints/Products/patchProduct.json";

    public ProductEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _productEndpoint = new ProductEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async void GetProductsAsync_ByAccessToken_Returns_Products()
    {
        var productListJson = await File.ReadAllTextAsync(GetProductsResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(productListJson);

        var expectedProductList = JsonSerializer.Deserialize<List<Product>>(productListJson, _config.SerializerOptions);
        Assert.NotNull(expectedProductList);

        var actualProducts = await _productEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualProducts);
        
        var actualProductList = actualProducts.ToList();
        Assert.Equal(expectedProductList.Count, actualProductList.Count);
        foreach (var actualProduct in actualProductList)
        {
            var expectedProduct = expectedProductList.FirstOrDefault(w => w.Id == actualProduct.Id);
            Assert.NotNull(expectedProduct);

            actualProduct.Should().BeEquivalentTo(expectedProduct);
        }
    }
    
    [Fact]
    public async void GetProductAsync_ByAccessToken_Returns_Single_Product()
    {
        var productJson = await File.ReadAllTextAsync(GetProductResponsePath);
            
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(productJson);
            
        var expectedProduct = JsonSerializer.Deserialize<Product>(productJson, _config.SerializerOptions);
        Assert.NotNull(expectedProduct);

        var actualProduct = await _productEndpoint.GetByIdAsync(AdministrationId, ProductId, AccessToken);
        Assert.NotNull(actualProduct);

        actualProduct.Should().BeEquivalentTo(expectedProduct);
    }
    
    [Fact]
    public async void GetProductByIdentifierAsync_ByAccessToken_Returns_Single_Product()
    {
        var productJson = await File.ReadAllTextAsync(GetProductResponsePath);
            
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(productJson);
            
        var expectedProduct = JsonSerializer.Deserialize<Product>(productJson, _config.SerializerOptions);
        Assert.NotNull(expectedProduct);

        var actualProduct = await _productEndpoint.GetByIdentifierAsync(AdministrationId, ProductIdentifier, AccessToken);
        Assert.NotNull(actualProduct);

        actualProduct.Should().BeEquivalentTo(expectedProduct);
    }
    
    [Fact]
    public async void CreateProductAsync_ByAccessToken_Returns_NewProduct()
    {
        var productJson = await File.ReadAllTextAsync(PostProductResponsePath);
        var productCreateOptions = new ProductCreateOptions
        {
            Product = new ProductCreate
            {
                Title = "Test product",
                Description = "Test product description",
                Price = 14.95,
                DocumentStyleId = "369764439814046847",
                LedgerAccountId = "369764439364207706",
                TaxRateId = "369764439469065326",
                WorkflowId = "369764439776298107",
                Currency = "EUR",
                CheckoutType = CheckoutType.Product,
                FrequencyType = FrequencyType.Year,
                Frequency = 1,
                ProductType = ProductType.DigitalService,
                VatRateType = VatRateType.Standard,
                MaxAmountPerOrder = 1,
                Identifier = "SKU1234",
                FrequencyPreset = "year"
            }
        };
        
        var serializedProductCreateOptions = JsonSerializer.Serialize(productCreateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedProductCreateOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(productJson);
    
        var expectedProduct = JsonSerializer.Deserialize<Product>(productJson, _config.SerializerOptions);
        Assert.NotNull(expectedProduct);

        var actualProduct = await _productEndpoint.CreateAsync(AdministrationId, productCreateOptions, AccessToken);
        Assert.NotNull(actualProduct);

        actualProduct.Should().BeEquivalentTo(expectedProduct);
    }
    
    [Fact]
    public async void UpdateProductAsync_ByAccessToken_Returns_UpdatedProduct()
    {
        var productJson = await File.ReadAllTextAsync(PatchProductResponsePath);
        var productUpdateOptions = new ProductUpdateOptions
        {
            Product = new ProductUpdate
            {
                Title = "Test product",
                Description = "Test product description",
                Price = 14.95,
                DocumentStyleId = "369764439814046847",
                LedgerAccountId = "369764439364207706",
                TaxRateId = "369764439469065326",
                WorkflowId = "369764439776298107",
                Currency = "EUR",
                CheckoutType = CheckoutType.Product,
                FrequencyType = FrequencyType.Year,
                Frequency = 1,
                ProductType = ProductType.DigitalService,
                VatRateType = VatRateType.Standard,
                MaxAmountPerOrder = 1,
                Identifier = "SKU1234",
                FrequencyPreset = "year"
            }
        };
        
        var serializedProductOptions = JsonSerializer.Serialize(productUpdateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedProductOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(productJson);
    
        var expectedProduct = JsonSerializer.Deserialize<Product>(productJson, _config.SerializerOptions);
        Assert.NotNull(expectedProduct);

        var actualProduct = await _productEndpoint.UpdateByIdAsync(AdministrationId, ProductId, productUpdateOptions, AccessToken);
        Assert.NotNull(actualProduct);

        actualProduct.Should().BeEquivalentTo(expectedProduct);
    }
    
    [Fact]
    public async void DeleteProductByIdAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var response = await _productEndpoint.DeleteByIdAsync(AdministrationId, ProductId, AccessToken);
        Assert.True(response);
    }
}
