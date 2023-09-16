using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.Projects;

namespace Moneybird.Net.Endpoints.Projects.Models
{
    public class ProjectFilterOptions : IMoneybirdFilterOptions
    {
        public ProjectState? State { get; set; }
    }
}