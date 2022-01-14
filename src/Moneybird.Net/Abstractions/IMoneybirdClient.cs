using Moneybird.Net.Endpoints.Abstractions;

namespace Moneybird.Net.Abstractions
{
    public interface IMoneybirdClient
    {
        /// <summary>
        /// The Administration Endpoint.
        /// </summary>
        IAdministrationEndpoint Administration { get; }
        
        /// <summary>
        /// The Contact Endpoint.
        /// </summary>
        IContactEndpoint Contact { get; }
        
        /// <summary>
        /// The CustomField Endpoint.
        /// </summary>
        ICustomFieldEndpoint CustomField { get; }
    }
}