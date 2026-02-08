using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Workflows
{
    public class WorkflowSteps
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }
        
        [JsonPropertyName("step_order")]
        public int StepOrder { get; set; }
        
        [JsonPropertyName("due_interval")]
        public int DueInterval { get; set; }
        
        [JsonPropertyName("reminder_delay")]
        public int ReminderDelay { get; set; }
        
        [JsonPropertyName("reminder_text")]
        public string ReminderText { get; set; }
        
        [JsonPropertyName("reminder_auto_send")]
        public bool ReminderAutoSend { get; set; }
        
        [JsonPropertyName("payment_methods")]
        public string[] PaymentMethods { get; set; }
        
        [JsonPropertyName("collection_method")]
        public string CollectionMethod { get; set; }
        
        [JsonPropertyName("show_qr_code")]
        public bool ShowQrCode { get; set; }
        
        [JsonPropertyName("action")]
        public WorkflowStepAction? Action { get; set; }
        
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}