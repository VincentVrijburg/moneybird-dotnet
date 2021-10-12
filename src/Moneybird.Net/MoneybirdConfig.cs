namespace Moneybird.Net
{
    public class MoneybirdConfig
    {
        private const string ApiUriDefault = "https://moneybird.com/api/";
        private const string AuthUriDefault = "https://moneybird.com/oauth/";
        private const string RedirectUriDefault = "urn:ietf:wg:oauth:2.0:oob";
        
        public string ApiUri { get; }
        
        public string AuthUri { get; }

        public string ClientId { get; }
        
        public string ClientSecret { get; }
        
        public string RedirectUri { get; }
        
        public string CallbackUri { get; }
        
        public MoneybirdConfig() 
            : this (ApiUriDefault, AuthUriDefault, null, null, RedirectUriDefault, null)
        {
        }
        
        public MoneybirdConfig(string clientId, string clientSecret) 
            : this (ApiUriDefault, AuthUriDefault, clientId, clientSecret, RedirectUriDefault, null)
        {
        }
        
        public MoneybirdConfig(string clientId, string clientSecret, string callbackUri) 
            : this (ApiUriDefault, AuthUriDefault, clientId, clientSecret, RedirectUriDefault, callbackUri)
        {
        }
        
        public MoneybirdConfig(string clientId, string clientSecret, string redirectUri, string callbackUri = null)
            : this (ApiUriDefault, AuthUriDefault, clientId, clientSecret, redirectUri, callbackUri)
        {
        }
        
        public MoneybirdConfig(string apiUri, string authUri, string clientId, string clientSecret, string redirectUri, string callbackUri)
        {
            ApiUri = apiUri;
            AuthUri = authUri;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
            CallbackUri = callbackUri;
        }
    }
}