using Moneybird.Net.Endpoints.Abstractions;

namespace Moneybird.Net.Abstractions
{
    public interface IMoneybirdClient
    {
        /// <summary>
        /// The Account Endpoint.
        /// </summary>
        IAdministrationEndpoint Administration { get; }
    }
}