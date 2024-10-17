using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Workflows;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints
{
    public class WorkflowEndpoint : IWorkflowEndpoint
    {
        private const string WorkflowsUri = "/{0}/workflows.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public WorkflowEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<IEnumerable<Workflow>> GetAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(WorkflowsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Workflow>>(responseJson, _config.SerializerOptions);
        }
    }
}
