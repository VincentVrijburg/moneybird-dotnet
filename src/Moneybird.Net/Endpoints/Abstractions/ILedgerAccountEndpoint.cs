using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities.LedgerAccounts;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ILedgerAccountEndpoint : IReadEndpoint<LedgerAccount>
    {
    }
}
