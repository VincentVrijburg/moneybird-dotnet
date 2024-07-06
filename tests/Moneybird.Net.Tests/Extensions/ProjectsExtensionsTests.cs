using Moneybird.Net.Entities.Projects;
using Moneybird.Net.Extensions;
using Moneybird.Net.Models.Projects;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class ProjectsExtensionsTests
{
    [Fact]
    public void GetFilterString_FromProjectFilterOptions_StateOnly_Returns_CorrectString()
    {
        const ProjectState state = ProjectState.Active;
            
        var options = new ProjectFilterOptions
        {
            State = state
        };

        const string expectedString = "filter=state:active";
        var actualString = options.GetFilterString();
            
        Assert.Equal(expectedString, actualString);
    }
}