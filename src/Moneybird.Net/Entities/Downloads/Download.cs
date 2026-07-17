using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Downloads
{
    public class Download : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("download_type")]
        public DownloadType DownloadType { get; set; }

        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        [JsonPropertyName("content_type")]
        public string ContentType { get; set; }

        [JsonPropertyName("failed")]
        public bool Failed { get; set; }

        [JsonPropertyName("downloaded")]
        public bool Downloaded { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
