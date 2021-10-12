using System.Text.Json.Serialization;

namespace Moneybird.Net.Authentication.Models
{
    /// <summary>
    /// Class representing an access token.
    /// </summary>
    public class AccessToken
        {
            /// <summary>
            /// Gets or sets the token value.
            /// </summary>
            [JsonPropertyName("access_token")]
            public string Value { get; set; }
    
            /// <summary>
            /// Gets or sets the token type.
            /// </summary>
            [JsonPropertyName("token_type")]
            public string TokenType { get; set; }
    
            /// <summary>
            /// Gets or sets refresh token value.
            /// </summary>
            [JsonPropertyName("refresh_token")]
            public string RefreshToken { get; set; }
    
            /// <summary>
            /// Gets or sets the token scope string.
            /// </summary>
            [JsonPropertyName("scope")]
            public string Scope { get; set; }
            
            /// <summary>
            /// Gets or sets the expires in (seconds).
            /// As of now, the token does not expire (as described in the official <a href="https://developer.moneybird.com/authentication">documentation</a>).
            /// </summary>
            [JsonIgnore]
            public long ExpiresIn { get; set; }
    
            /// <summary>
            /// Gets or sets the Moneybird created at (unix timestamp).
            /// </summary>
            [JsonPropertyName("created_at")]
            public long CreatedAt { get; set; }
    
            /// <summary>
            /// Gets truth check if the token has been expired.
            /// As of now, the token does not expire (as described in the official <a href="https://developer.moneybird.com/authentication">documentation</a>).
            /// </summary>
            [JsonIgnore]
            public bool IsExpired { get; }
        }
}