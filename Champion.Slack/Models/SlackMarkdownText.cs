using System.Text.Json.Serialization;

namespace Champion.Slack.Models
{
    public class SlackMarkdownText
    {
        [JsonPropertyName("type")]
        public string Type => "mrkdwn";

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}