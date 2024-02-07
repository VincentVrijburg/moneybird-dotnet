using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.LedgerAccounts;
using Moneybird.Net.Models.LedgerAccounts;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ILedgerAccountEndpoint :
        IReadEndpoint<LedgerAccount>,
        IGetEndpoint<LedgerAccount>,
        ICreateEndpoint<LedgerAccount, LedgerAccountCreateOptions>,
        IUpdateEndpoint<LedgerAccount, LedgerAccountUpdateOptions>,
        IDeleteEndpoint
    {
    }
}