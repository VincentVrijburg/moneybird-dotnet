using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.Projects;

namespace Moneybird.Net.Models.Projects
{
    public class ProjectFilterOptions : IMoneybirdFilterOptions
    {
        public ProjectState? State { get; set; }
    }
}