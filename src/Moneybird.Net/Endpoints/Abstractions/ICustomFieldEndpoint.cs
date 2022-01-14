using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities.CustomFields;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ICustomFieldEndpoint
    {
        /// <summary>
        /// Get list of all the custom fields by access token.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A list of custom field objects.</returns>
        Task<List<CustomField>> GetCustomFieldsAsync(string administrationId, string accessToken);
    }
}