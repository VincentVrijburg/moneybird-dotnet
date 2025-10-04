using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.Identities;
using Moneybird.Net.Models.Identities;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IIdentityEndpoint :
        IReadEndpoint<Identity>,
        IGetEndpoint<Identity>,
        ICreateEndpoint<Identity, IdentityCreateOptions>,
        IUpdateEndpoint<Identity, IdentityUpdateOptions>,
        IDeleteEndpoint
    {
        Task<Identity> GetDefaultAsync(string administrationId, string accessToken);
        Task<Identity> UpdateDefaultAsync(string administrationId, IdentityUpdateOptions options, string accessToken);
    }
}
