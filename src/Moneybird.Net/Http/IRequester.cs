using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moneybird.Net.Http
{
    public interface IRequester : IDisposable
    {
        /// <summary>
        /// Create a get request and send it asynchronously to the Moneybird api.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="relativeUrl">The relative url.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="queryParameters">The query parameters.</param>
        /// <returns>The content of the response.</returns>
        /// <exception cref="MoneybirdException">
        /// Thrown if an Http error occurs. 
        /// Contains the Http error code and error message.
        /// </exception>
        Task<string> CreateGetRequestAsync(string host, string relativeUrl, string accessToken, List<string> queryParameters = null);
        
        /// <summary>
        /// Create a post request and send it asynchronously to the Moneybird api.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="relativeUrl">The relative url.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="body">The request body.</param>
        /// <param name="queryParameters">The query parameters.</param>
        /// <returns>The content of the response.</returns>
        /// <exception cref="MoneybirdException">
        /// Thrown if an Http error occurs. 
        /// Contains the Http error code and error message.
        /// </exception>
        Task<string> CreatePostRequestAsync(string host, string relativeUrl, string accessToken, string body, List<string> queryParameters = null);
        
        /// <summary>
        /// Create a patch request and send it asynchronously to the Moneybird api.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="relativeUrl">The relative url.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="body">The request body.</param>
        /// <param name="queryParameters">The query parameters.</param>
        /// <returns>The content of the response.</returns>
        /// <exception cref="MoneybirdException">
        /// Thrown if an Http error occurs. 
        /// Contains the Http error code and error message.
        /// </exception>
        Task<string> CreatePatchRequestAsync(string host, string relativeUrl, string accessToken, string body, List<string> queryParameters = null);
        
        /// <summary>
        /// Create a delete request and send it asynchronously to the Moneybird api.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="relativeUrl">The relative url.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="queryParameters">The query parameters.</param>
        /// <returns>A boolean value.</returns>
        /// <exception cref="MoneybirdException">
        /// Thrown if an Http error occurs. 
        /// Contains the Http error code and error message.
        /// </exception>
        Task<bool> CreateDeleteRequestAsync(string host, string relativeUrl, string accessToken, List<string> queryParameters = null);
    }
}
