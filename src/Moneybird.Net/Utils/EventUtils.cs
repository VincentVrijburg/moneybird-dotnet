using System.Text.Json;
using System.Text.Json.Serialization;
using Moneybird.Net.Models;

namespace Moneybird.Net.Utils
{
    public static class EventUtils
    {
        public static Event ParseEvent(string json)
        {
            ArgumentGuard.NotNullNorEmpty(json, nameof(json));
            
            return JsonSerializer.Deserialize<Event>(json, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
        }
        
        public static Event ConstructEvent(string json, string secretToken)
        {
            ArgumentGuard.NotNullNorEmpty(json, nameof(json));
            ArgumentGuard.NotNullNorEmpty(secretToken, nameof(secretToken));
            
            var payload = ParseEvent(json);
            ValidateToken(payload.WebhookToken, secretToken);

            return payload;
        }
        
        private static void ValidateToken(string token, string secretToken)
        {
            if (!token.Equals(secretToken))
            {
                throw new MoneybirdException("The webhook event token does not match the given secret token.");
            }
        }
    }
}
