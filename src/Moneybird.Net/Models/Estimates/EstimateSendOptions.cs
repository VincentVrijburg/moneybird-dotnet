using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Estimates
{
    public class EstimateSendOptions
    {
        [JsonPropertyName("estimate_sending")]
        public EstimateSend EstimateSend { get; set; }
        
        [JsonPropertyName("sender")]
        public object Sender { get; set; }
        
        [JsonPropertyName("signature_output")]
        public string SignatureOutput { get; set; }
        
        [JsonPropertyName("audit_trail")]
        public string AuditTrail { get; set; }
        
        [JsonPropertyName("ip_address")]
        public string IpAddress { get; set; }
    }
}
