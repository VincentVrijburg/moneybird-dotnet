using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.Products;

namespace Moneybird.Net.Entities.SubscriptionTemplates;

public class SubscriptionTemplate : IMoneybirdEntity
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("administration_id")]
    public string AdministrationId { get; set; }

    [JsonPropertyName("workflow_id")]
    public string WorkflowId { get; set; }

    [JsonPropertyName("document_style_id")]
    public string DocumentStyleId { get; set; }

    [JsonPropertyName("mergeable")]
    public bool Mergeable { get; set; }

    [JsonPropertyName("contact_can_update")]
    public bool ContactCanUpdate { get; set; }

    [JsonPropertyName("products")]
    public List<Product> Products { get; set; }
}
