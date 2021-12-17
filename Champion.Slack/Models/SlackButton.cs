using System.Text.Json.Serialization;

namespace Champion.Slack.Models
{
    public class SlackButton
    {
        [JsonPropertyName("action_id")]
        public string ActionId { get; set; }

        [JsonPropertyName("text")]
        public SlackPlainText Text { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}