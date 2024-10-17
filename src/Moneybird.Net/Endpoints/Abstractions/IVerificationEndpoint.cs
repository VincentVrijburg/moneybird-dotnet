using System.Threading.Tasks;
using Moneybird.Net.Entities.Verifications;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IVerificationEndpoint
    {
        /// <summary>
        /// Get all the verifications within an administration.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>All verified e-mail addresses and bank account numbers, as well as the verified chamber of commerce number and tax number.
        /// </returns>
        Task<Verification> GetAsync(string administrationId, string accessToken);
    }
}