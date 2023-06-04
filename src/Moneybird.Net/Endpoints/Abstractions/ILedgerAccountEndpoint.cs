using System.Threading.Tasks;
using Moneybird.Net.Endpoints.LegderAccounts.Models;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.LedgerAccounts;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ILedgerAccountEndpoint :
        IReadEndpoint<LedgerAccount>,
        IGetEndpoint<LedgerAccount>,
        IDeleteEndpoint
    {
        /// <summary>
        /// Create a ledger account by access token.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="options">The options to create with.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A ledger account object.</returns>
        Task<LedgerAccount> CreateLedgerAccountAsync(string administrationId, LedgerAccountCreateOptions options, string accessToken);
        
        /// <summary>
        /// Update a ledger account by id and access token.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="ledgerAccountId">The ledger account id.</param>
        /// <param name="options">The options to update with.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A ledger account object.</returns>
        Task<LedgerAccount> UpdateLedgerAccountByIdAsync(string administrationId, string ledgerAccountId, LedgerAccountUpdateOptions options, string accessToken);
    }
}