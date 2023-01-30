using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities.Users;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IUserEndpoint
    {
        /// <summary>
        /// Get list of all the users by access token.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A list of user objects.</returns>
        Task<List<User>> GetUsersAsync(string administrationId, string accessToken);
    }
}