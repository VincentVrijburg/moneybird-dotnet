using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities.Workflows;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IWorkflowEndpoint
    {
        /// <summary>
        /// Get list of all the available workflows by access token.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A list of available workflow objects.</returns>
        Task<List<Workflow>> GetWorkflowsAsync(string administrationId, string accessToken);
    }
}