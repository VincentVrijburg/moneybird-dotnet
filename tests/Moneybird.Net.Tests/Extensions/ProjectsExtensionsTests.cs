using Moneybird.Net.Endpoints.Projects.Models;
using Moneybird.Net.Entities.Projects;
using Moneybird.Net.Extensions;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class ProjectsExtensionsTests
{
    [Fact]
    public void GetFilterString_FromProjectFilterOptions_StateOnly_Returns_CorrectString()
    {
        const ProjectState state = ProjectState.All;
            
        var options = new ProjectFilterOptions
        {
            State = state
        };

        var expectedString = $"filter=state:{state}";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
}