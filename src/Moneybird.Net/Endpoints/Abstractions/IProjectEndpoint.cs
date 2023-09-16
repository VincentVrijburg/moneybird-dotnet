using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Endpoints.Projects.Models;
using Moneybird.Net.Entities.Projects;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IProjectEndpoint :
        IReadEndpoint<Project>,
        IReadFilterEndpoint<Project, ProjectFilterOptions>,
        IGetEndpoint<Project>,
        ICreateEndpoint<Project, ProjectCreateOptions>,
        IUpdateEndpoint<Project, ProjectUpdateOptions>,
        IDeleteEndpoint
    {
    }
}