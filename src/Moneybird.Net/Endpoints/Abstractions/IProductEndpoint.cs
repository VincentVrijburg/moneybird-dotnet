using System.Threading;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.Products;
using Moneybird.Net.Models.Products;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IProductEndpoint :
        IReadEndpoint<Product>,
        IGetEndpoint<Product>,
        ICreateEndpoint<Product, ProductCreateOptions>,
        IUpdateEndpoint<Product, ProductUpdateOptions>,
        IDeleteEndpoint
    {
        Task<Product> GetByIdentifierAsync(string administrationId, string identifier, string accessToken);
    }
}
