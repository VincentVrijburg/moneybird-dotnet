using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.DocumentStyles
{
    public class DocumentStyle : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("identity_id")]
        public string IdentityId { get; set; }
        
        [JsonPropertyName("default")]
        public bool Default { get; set; }
        
        [JsonPropertyName("logo_hash")]
        public string LogoHash { get; set; }
        
        [JsonPropertyName("logo_container_full_width")]
        public bool LogoContainerFullWidth { get; set; }
        
        [JsonPropertyName("logo_display_width")]
        public int LogoDisplayWidth { get; set; }
        
        [JsonPropertyName("logo_position")]
        public string LogoPosition { get; set; }
        
        [JsonPropertyName("background_hash")]
        public string BackgroundHash { get; set; }
        
        [JsonPropertyName("paper_size")]
        public string PaperSize { get; set; }
        
        [JsonPropertyName("address_position")]
        public string AddressPosition { get; set; }
        
        [JsonPropertyName("font_size")]
        public int FontSize { get; set; }
        
        [JsonPropertyName("font_familiy")]
        public string FontFamiliy { get; set; }
        
        [JsonPropertyName("print_on_stationery")]
        public bool PrintOnStationery { get; set; }
        
        [JsonPropertyName("custom_css")]
        public object CustomCss { get; set; }
        
        [JsonPropertyName("invoice_sender_address")]
        public List<DocumentStyleField> InvoiceSenderAddress { get; set; }
        
        [JsonPropertyName("estimate_sender_address")]
        public List<DocumentStyleField> EstimateSenderAddress { get; set; }
        
        [JsonPropertyName("invoice_metadata_left")]
        public List<DocumentStyleField> InvoiceMetadataLeft { get; set; }
        
        [JsonPropertyName("invoice_metadata_right")]
        public List<DocumentStyleField> InvoiceMetadataRight { get; set; }
        
        [JsonPropertyName("estimate_metadata_left")]
        public List<DocumentStyleField> EstimateMetadataLeft { get; set; }
        
        [JsonPropertyName("estimate_metadata_right")]
        public List<DocumentStyleField> EstimateMetadataRight { get; set; }
        
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
