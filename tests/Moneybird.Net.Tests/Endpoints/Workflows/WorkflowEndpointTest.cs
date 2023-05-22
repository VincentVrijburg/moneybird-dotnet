using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.Workflows;
using Moneybird.Net.Entities.Workflows;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.Workflows
{
    public class WorkflowEndpointTest : CommonTestBase
    {
        private static Mock<IRequester> _requester;
        private readonly MoneybirdConfig _config;
        private readonly WorkflowEndpoint _workflowEndpoint;
        
        private const string ResponsePath = "./Responses/Endpoints/Workflows/getWorkflows.json";
        
        public WorkflowEndpointTest()
        {  
            _requester = new Mock<IRequester>();
            _config = new MoneybirdConfig();
            _workflowEndpoint = new WorkflowEndpoint(_config, _requester.Object);
        }
        
        [Fact]
        public async void GetWorkflowsAsync_ByAccessToken_Returns_WorkflowList()
        {
            var workflowListJson = await File.ReadAllTextAsync(ResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(workflowListJson);
            
            var workflowList = JsonSerializer.Deserialize<List<Workflow>>(workflowListJson, _config.SerializerOptions);
            Assert.NotNull(workflowList);

            var actualWorkflowList = await _workflowEndpoint.GetAsync(AdministrationId, AccessToken);
            Assert.NotNull(actualWorkflowList);

            var actualWorkflows = actualWorkflowList.ToList();
            Assert.Equal(workflowList.Count, actualWorkflows.Count);
            foreach (var actualWorkflow in actualWorkflows)
            {
                var workflow = workflowList.FirstOrDefault(w => w.Id == actualWorkflow.Id);
                Assert.NotNull(workflow);

                workflow.Should().BeEquivalentTo(actualWorkflow);
            }
        }
    }
}
