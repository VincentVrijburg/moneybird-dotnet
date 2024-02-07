using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.Projects;
using Moneybird.Net.Models.Projects;

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