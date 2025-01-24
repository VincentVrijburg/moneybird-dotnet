using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.Projects;
using Moneybird.Net.Http;
using Moneybird.Net.Models.Projects;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class ProjectEndpointTests : ProjectTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly ProjectEndpoint _projectEndpoint;
    
    private const string GetProjectsResponsePath = "./Responses/Endpoints/Projects/getProjects.json";
    private const string GetProjectResponsePath = "./Responses/Endpoints/Projects/getProject.json";
    private const string PostProjectResponsePath = "./Responses/Endpoints/Projects/postProject.json";
    private const string PatchProjectResponsePath = "./Responses/Endpoints/Projects/patchProject.json";

    public ProjectEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _projectEndpoint = new ProjectEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async Task GetProjectsAsync_ByAccessToken_Returns_Projects()
    {
        var projectListJson = await File.ReadAllTextAsync(GetProjectsResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(projectListJson);

        var projects = JsonSerializer.Deserialize<List<Project>>(projectListJson, _config.SerializerOptions);
        Assert.NotNull(projects);

        var actualProjects = await _projectEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualProjects);
        
        var actualProjectList = actualProjects.ToList();
        Assert.Equal(projects.Count, actualProjectList.Count);
        foreach (var actualProject in actualProjectList)
        {
            var expectedProject = projects.FirstOrDefault(w => w.Id == actualProject.Id);
            Assert.NotNull(expectedProject);

            actualProject.Should().BeEquivalentTo(expectedProject);
        }
    }
    
    [Fact]
    public async Task GetProjectsAsync_UsingFilterOptions_ByAccessToken_Returns_Projects()
    {
        var projectListJson = await File.ReadAllTextAsync(GetProjectsResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(projectListJson);

        var projects = JsonSerializer.Deserialize<List<Project>>(projectListJson, _config.SerializerOptions);
        Assert.NotNull(projects);
        
        var filterOptions = new ProjectFilterOptions
        {
            State = ProjectState.All
        };

        var actualProjects = await _projectEndpoint.GetAsync(AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualProjects);
        
        var actualProjectList = actualProjects.ToList();
        Assert.Equal(projects.Count, actualProjectList.Count);
        
        foreach (var actualProject in actualProjectList)
        {
            var project = projects.FirstOrDefault(w => w.Id == actualProject.Id);
            Assert.NotNull(project);

            project.Should().BeEquivalentTo(actualProject);
        }
    }
    
    [Fact]
    public async Task GetProjectAsync_ByAccessToken_Returns_Single_Project()
    {
        var projectJson = await File.ReadAllTextAsync(GetProjectResponsePath);
            
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(projectJson);
            
        var expectedProject = JsonSerializer.Deserialize<Project>(projectJson, _config.SerializerOptions);
        Assert.NotNull(expectedProject);

        var actualProject = await _projectEndpoint.GetByIdAsync(AdministrationId, ProjectId, AccessToken);
        Assert.NotNull(actualProject);

        actualProject.Should().BeEquivalentTo(expectedProject);
    }
    
    [Fact]
    public async Task CreateProjectAsync_ByAccessToken_Returns_NewProject()
    {
        var projectJson = await File.ReadAllTextAsync(PostProjectResponsePath);
        var projectCreateOptions = new ProjectCreateOptions
        {
            Project = new ProjectCreate
            {
                Name = "Falcon",
                Budget = "500"
            }
        };
        
        var serializedProjectCreateOptions = JsonSerializer.Serialize(projectCreateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedProjectCreateOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(projectJson);
    
        var expectedProject = JsonSerializer.Deserialize<Project>(projectJson, _config.SerializerOptions);
        Assert.NotNull(expectedProject);

        var actualProject = await _projectEndpoint.CreateAsync(AdministrationId, projectCreateOptions, AccessToken);
        Assert.NotNull(actualProject);

        actualProject.Should().BeEquivalentTo(expectedProject);
    }
    
    [Fact]
    public async Task UpdateProjectAsync_ByAccessToken_Returns_UpdatedProject()
    {
        var projectJson = await File.ReadAllTextAsync(PatchProjectResponsePath);
        var projectUpdateOptions = new ProjectUpdateOptions
        {
            Project = new ProjectUpdate
            {
                Name = "Eagle",
                Budget = "1000"
            }
        };
        
        var serializedProjectOptions = JsonSerializer.Serialize(projectUpdateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedProjectOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(projectJson);
    
        var expectedProject = JsonSerializer.Deserialize<Project>(projectJson, _config.SerializerOptions);
        Assert.NotNull(expectedProject);

        var actualProject = await _projectEndpoint.UpdateByIdAsync(AdministrationId, ProjectId, projectUpdateOptions, AccessToken);
        Assert.NotNull(actualProject);

        actualProject.Should().BeEquivalentTo(expectedProject);
    }
    
    [Fact]
    public async Task DeleteProjectByIdAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var response = await _projectEndpoint.DeleteByIdAsync(AdministrationId, ProjectId, AccessToken);
        Assert.True(response);
    }
}