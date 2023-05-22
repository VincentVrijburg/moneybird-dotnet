using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities.CustomFields;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ICustomFieldEndpoint : IReadEndpoint<CustomField>
    {
    }
}
