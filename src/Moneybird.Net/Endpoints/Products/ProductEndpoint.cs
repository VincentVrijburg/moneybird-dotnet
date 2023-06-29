using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.Products.Models;
using Moneybird.Net.Entities.Products;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.Products
{
    public class ProductEndpoint : IProductEndpoint
    {
        private const string ProductsUri = "/{0}/products.json";
        private const string ProductsIdUri = "/{0}/products/{1}.json";
        private const string ProductsIdentifierUri = "/{0}/products/identifier/{1}.json";
        
        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public ProductEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<IEnumerable<Product>> GetAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(ProductsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Product>>(responseJson, _config.SerializerOptions);
        }

        public async Task<Product> GetByIdAsync(string administrationId, string id, string accessToken)
        {
            var relativeUrl = string.Format(ProductsIdUri, administrationId, id);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Product>(responseJson, _config.SerializerOptions);
        }

        public async Task<Product> CreateAsync(string administrationId, ProductCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(ProductsUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Product>(responseJson, _config.SerializerOptions);
        }

        public async Task<Product> UpdateByIdAsync(string administrationId, string id, ProductUpdateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(ProductsUri, administrationId, id);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Product>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteByIdAsync(string administrationId, string id, string accessToken)
        {
            var relativeUrl = string.Format(ProductsIdUri, administrationId, id);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<Product> GetByIdentifierAsync(string administrationId, string identifier, string accessToken)
        {
            var relativeUrl = string.Format(ProductsIdentifierUri, administrationId, identifier);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Product>(responseJson, _config.SerializerOptions);
        }
    }
}
