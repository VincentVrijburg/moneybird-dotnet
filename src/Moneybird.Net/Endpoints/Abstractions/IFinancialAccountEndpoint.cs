using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.FinancialAccounts;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IFinancialAccountEndpoint :
        IReadEndpoint<FinancialAccount>
    {
    }
}