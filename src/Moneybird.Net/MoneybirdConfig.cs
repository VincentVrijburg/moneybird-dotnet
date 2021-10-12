namespace Moneybird.Net
{
    /// <summary>
    /// Class representing the configuration of the <see href="https://github.com/VincentVrijburg/moneybird-dotnet">Moneybird.Net</see> library.
    /// </summary>
    public class MoneybirdConfig
    {
        private const string ApiUriDefault = "https://moneybird.com/api/";
        private const string AuthUriDefault = "https://moneybird.com/oauth/";
        private const string RedirectUriDefault = "urn:ietf:wg:oauth:2.0:oob";

        /// <summary>
        /// Gets or sets the client id.
        /// </summary>
        public string ClientId { get; set; }
        
        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        public string ClientSecret { get; set; }
        
        /// <summary>
        /// Gets or sets the redirect uri.
        /// </summary>
        public string RedirectUri { get; set; }
        
        /// <summary>
        /// Gets or sets the api uri.
        /// </summary>
        public string ApiUri { get; set; }
        
        /// <summary>
        /// Gets or sets the auth uri.
        /// </summary>
        public string AuthUri { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneybirdConfig"/> class.
        /// </summary>
        public MoneybirdConfig() 
            : this (ApiUriDefault, AuthUriDefault, null, null, RedirectUriDefault)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MoneybirdConfig"/> class.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The client secret.</param>
        public MoneybirdConfig(string clientId, string clientSecret) 
            : this (ApiUriDefault, AuthUriDefault, clientId, clientSecret, RedirectUriDefault)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneybirdConfig"/> class.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="redirectUri">The redirect uri.</param>
        public MoneybirdConfig(string clientId, string clientSecret, string redirectUri)
            : this (ApiUriDefault, AuthUriDefault, clientId, clientSecret, redirectUri)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MoneybirdConfig"/> class.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="redirectUri">The redirect uri.</param>
        /// <param name="apiUri">The api uri.</param>
        /// <param name="authUri">The auth uri.</param>
        public MoneybirdConfig(string clientId, string clientSecret, string redirectUri, string apiUri, string authUri)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
            ApiUri = apiUri;
            AuthUri = authUri;
        }
    }
}