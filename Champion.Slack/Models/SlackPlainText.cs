using System.Text.Json.Serialization;

namespace Champion.Slack.Models
{
    public class SlackPlainText
    {
        [JsonPropertyName("emoji")]
        public bool Emoji { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("type")]
        public string Type => "plain_text";
    }
}