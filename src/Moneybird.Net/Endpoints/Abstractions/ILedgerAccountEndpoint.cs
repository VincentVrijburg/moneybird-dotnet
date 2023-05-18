using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities.LedgerAccounts;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ILedgerAccountEndpoint
    {
        /// <summary>
        /// Get list of all the ledger accounts by access token.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A list of ledger account objects.</returns>
        Task<List<LedgerAccount>> GetLedgerAccountsAsync(string administrationId, string accessToken);
    }
}
