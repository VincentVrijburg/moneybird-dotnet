using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.Users;
using Moneybird.Net.Entities.Users;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.Users;

public class UserEndpointTest : CommonTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly UserEndpoint _userEndpoint;
    
    private const string ResponsePath = "./Responses/Endpoints/Users/getUsers.json";

    public UserEndpointTest()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _userEndpoint = new UserEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async void GetUsersAsync_ByAccessToken_Returns_UserList()
    {
        var userListJson = await File.ReadAllTextAsync(ResponsePath);
            
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(userListJson);
            
        var userList = JsonSerializer.Deserialize<List<User>>(userListJson, _config.SerializerOptions);
        Assert.NotNull(userList);

        var actualUserList = await _userEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualUserList);

        var actualUsers = actualUserList.ToList();
        Assert.Equal(userList.Count, actualUsers.Count);
        foreach (var actualUser in actualUsers)
        {
            var user = userList.FirstOrDefault(w => w.Id == actualUser.Id);
            Assert.NotNull(user);

            user.Should().BeEquivalentTo(actualUser);
        }
    }
}
