using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Moneybird.Net.Http
{
    public class Requester : RequesterBase, IRequester
    {
        public Requester(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public async Task<string> CreateGetRequestAsync(string host,
            string relativeUrl,
            string accessToken,
            List<string> queryParameters = null)
        {
            var request = ConstructRequest(host, relativeUrl, accessToken, queryParameters, HttpMethod.Get);
            var response = await SendAsync(request).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }

        public async Task<string> CreatePostRequestAsync(string host,
            string relativeUrl,
            string accessToken,
            string body,
            List<string> queryParameters = null)
        {
            var request = ConstructRequest(host, relativeUrl, accessToken, queryParameters, HttpMethod.Post);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");
            
            var response = await SendAsync(request).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }

        public async Task<Stream> CreatePostDownloadRequestAsync(
            string host,
            string relativeUrl,
            string accessToken,
            List<string> queryParameters = null)
        {
            var request = ConstructRequest(host, relativeUrl, accessToken, queryParameters, HttpMethod.Post);
            var response = await SendAsync(request).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Found &&
                response.Headers.Location != null)
            {
                using (response)
                {
                    var downloadUri = response.Headers.Location.IsAbsoluteUri
                        ? response.Headers.Location
                        : new System.Uri(new System.Uri(host), response.Headers.Location);
                    var downloadRequest = new HttpRequestMessage(HttpMethod.Get, downloadUri);
                    var downloadResponse = await SendAsync(downloadRequest).ConfigureAwait(false);
                    return await GetResponseStreamAsync(downloadResponse).ConfigureAwait(false);
                }
            }

            using (response)
            {
                throw new MoneybirdException(
                    "Expected a 302 redirect with a Location header when downloading a file.",
                    response.StatusCode);
            }
        }

        public async Task CreatePostFileRequestAsync(
            string host,
            string relativeUrl,
            string accessToken,
            string fileName,
            Stream body,
            List<string> queryParameters = null)
        {
            var request = ConstructRequest(host, relativeUrl, accessToken, queryParameters, HttpMethod.Post);
            request.Content = new MultipartFormDataContent
            {
                { new StreamContent(body), "file", fileName }
            };

            var response = await SendAsync(request).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        public async Task<string> CreatePatchRequestAsync(string host,
            string relativeUrl,
            string accessToken,
            string body,
            List<string> queryParameters = null)
        {
            var request = ConstructRequest(host, relativeUrl, accessToken, queryParameters, new HttpMethod("PATCH"));
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");
            
            var response = await SendAsync(request).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }

        public async Task<bool> CreateDeleteRequestAsync(string host,
            string relativeUrl,
            string accessToken,
            List<string> queryParameters = null)
        {
            var request = ConstructRequest(host, relativeUrl, accessToken, queryParameters, HttpMethod.Delete);
            var response = await SendAsync(request).ConfigureAwait(false);
            response.Dispose();

            return true;
        }
    }
}
