using System.Text.Json.Serialization;
using Moneybird.Net.Misc;

namespace Moneybird.Net.Models.Estimates
{
    public class EstimateSend
    {
        [JsonPropertyName("delivery_method")]
        public DeliveryMethod DeliveryMethod { get; set; }

        [JsonPropertyName("sending_scheduled")]
        public bool SendingScheduled { get; set; }
        
        [JsonPropertyName("deliver_ubl")]
        public bool DeliverUbl { get; set; }

        [JsonPropertyName("mergable")]
        public bool Mergeable { get; set; }

        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("email_message")]
        public string EmailMessage { get; set; }
    }
}
