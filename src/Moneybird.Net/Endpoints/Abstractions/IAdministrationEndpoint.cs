using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Administrations.Models;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IAdministrationEndpoint
    {
        /// <summary>
        /// Get list of all the administrations.
        /// </summary>
        /// <returns>An administration list.</returns>
        Task<AdministrationList> GetAdministrationsAsync(string accessToken);
    }
}