using Moneybird.Net.Endpoints.TaxRates.Models;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.TaxRates;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ITaxRateEndpoint :
        IReadEndpoint<TaxRate>,
        IReadFilterEndpoint<TaxRate, TaxRateFilterOptions>
    {
    }
}
