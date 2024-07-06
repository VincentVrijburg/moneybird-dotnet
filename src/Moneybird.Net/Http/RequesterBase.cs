using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Extensions;

namespace Moneybird.Net.Http
{
    [ExcludeFromCodeCoverage]
    public abstract class RequesterBase : IDisposable
    {
        private readonly HttpClient _httpClient;

        private static List<HttpStatusCode> _httpStatusCodeResponses = new(){
            HttpStatusCode.BadRequest, HttpStatusCode.Unauthorized,
            HttpStatusCode.PaymentRequired, HttpStatusCode.Forbidden,
            HttpStatusCode.NotFound, HttpStatusCode.MethodNotAllowed,
            HttpStatusCode.NotAcceptable, (HttpStatusCode) 422,
            (HttpStatusCode) 429, HttpStatusCode.InternalServerError
        };

        protected RequesterBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                HandleRequestFailure(response);
            }
            
            return response;
        }
        
        protected HttpRequestMessage ConstructRequest(string host, string relativeUrl, string accessToken, List<string> queryParameters, HttpMethod httpMethod)
        {
            var uri = queryParameters == null ?
                $"{host}{relativeUrl}" :
                $"{host}{relativeUrl}?{GetQueryString(queryParameters)}";

            var requestMessage = new HttpRequestMessage(httpMethod, uri);
            if (!string.IsNullOrEmpty(accessToken))
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            
            return requestMessage;
        }

        private string GetQueryString(List<string> queryParameters)
        {
            return queryParameters
                .Where(param => !string.IsNullOrWhiteSpace(param))
                .Aggregate(string.Empty, (current, param) => current + "&" + param);
        }

        private void HandleRequestFailure(HttpResponseMessage response)
        {
            try
            {
                if (_httpStatusCodeResponses.Contains(response.StatusCode))
                {
                    string message;
                    
                    try
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        var jsonDocument = JsonDocument.Parse(json);
                        message = jsonDocument.RootElement.GetErrorMessage();
                    }
                    catch {
                        message = response.StatusCode.ToString();
                    }
                    
                    throw new MoneybirdException(message, response.StatusCode);
                }
                else
                {
                    throw new MoneybirdException("Unexpeced failure", response.StatusCode);
                }
            }
            finally
            {
                response.Dispose();
            }
        }
        
        protected async Task<string> GetResponseContentAsync(HttpResponseMessage response)
        {
            using (response)
            using (var content = response.Content)
            {
                return await content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
