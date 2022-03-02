using System.Text.Json.Serialization;

namespace WizardApi.Models
{
    public sealed class FeedbackInfo
    {
        [JsonPropertyName("feedback")]
        public string Feedback { get; set; }

        [JsonPropertyName("feedbackType")]
        public string Type { get; set; }
    }
}
