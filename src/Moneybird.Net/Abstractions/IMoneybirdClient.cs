using Moneybird.Net.Endpoints.Abstractions;

namespace Moneybird.Net.Abstractions
{
    public interface IMoneybirdClient
    {
        /// <summary>
        /// The Administration Endpoint.
        /// </summary>
        IAdministrationEndpoint Administration { get; }
    }
}