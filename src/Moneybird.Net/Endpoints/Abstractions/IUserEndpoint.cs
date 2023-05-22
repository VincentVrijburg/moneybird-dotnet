using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities.Users;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IUserEndpoint : IReadEndpoint<User>
    {
    }
}
