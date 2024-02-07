using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.TaxRates;
using Moneybird.Net.Models.TaxRates;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ITaxRateEndpoint :
        IReadEndpoint<TaxRate>,
        IReadFilterEndpoint<TaxRate, TaxRateFilterOptions>
    {
    }
}
