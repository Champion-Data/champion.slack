using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Champion.Slack.Models
{
    public class SlackMessage
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("blocks")]
        public List<SlackBlock> Blocks { get; set; }
    }

    public class SlackBlock
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("text")]
        public SlackMarkdownText Text { get; set; }

        [JsonPropertyName("accessory")]
        public SlackButton Accessory { get; set; }

        [JsonPropertyName("fields")]
        public List<SlackMarkdownText> Fields { get; set; }
    }

    public class SlackMarkdownText
    {
        [JsonPropertyName("type")]
        public string Type => "mrkdwn";

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class SlackPlainText
    {
        [JsonPropertyName("type")]
        public string Type => "plain_text";

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("emoji")]
        public bool Emoji { get; set; }
    }

    public class SlackButton
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("text")]
        public SlackPlainText Text { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("action_id")]
        public string ActionId { get; set; }
    }
}