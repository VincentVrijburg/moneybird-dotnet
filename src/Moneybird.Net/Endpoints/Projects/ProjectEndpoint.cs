using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.Projects.Models;
using Moneybird.Net.Entities.Projects;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.Projects
{
    public class ProjectEndpoint : IProjectEndpoint
    {
        private const string ProjectsUri = "/{0}/projects.json";
        private const string ProjectsIdUri = "/{0}/projects/{1}.json";
        
        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public ProjectEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<IEnumerable<Project>> GetAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(ProjectsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Project>>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<IEnumerable<Project>> GetAsync(string administrationId, string accessToken, ProjectFilterOptions options)
        {
            List<string> paramValues = null;
                        
            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues = new List<string> { $"filter={filterString}" };
            }
            
            var relativeUrl = string.Format(ProjectsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Project>>(responseJson, _config.SerializerOptions);
        }

        public async Task<Project> GetByIdAsync(string administrationId, string id, string accessToken)
        {
            var relativeUrl = string.Format(ProjectsIdUri, administrationId, id);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Project>(responseJson, _config.SerializerOptions);
        }

        public async Task<Project> CreateAsync(string administrationId, ProjectCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(ProjectsUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Project>(responseJson, _config.SerializerOptions);
        }

        public async Task<Project> UpdateByIdAsync(string administrationId, string id, ProjectUpdateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(ProjectsUri, administrationId, id);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Project>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteByIdAsync(string administrationId, string id, string accessToken)
        {
            var relativeUrl = string.Format(ProjectsIdUri, administrationId, id);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }
    }
}