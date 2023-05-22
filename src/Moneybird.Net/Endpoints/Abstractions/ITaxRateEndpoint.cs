using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities.TaxRates;
using Moneybird.Net.Entities.Users;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ITaxRateEndpoint : IReadEndpoint<TaxRate>
    {
    }
}
