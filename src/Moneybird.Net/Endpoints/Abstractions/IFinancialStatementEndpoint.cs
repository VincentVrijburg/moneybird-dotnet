using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Endpoints.FinancialStatements.Models;
using Moneybird.Net.Entities.FinancialStatements;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IFinancialStatementEndpoint :
        ICreateEndpoint<FinancialStatement, FinancialStatementCreateOptions>,
        IUpdateEndpoint<FinancialStatement, FinancialStatementUpdateOptions>,
        IDeleteEndpoint
    {
    }
}