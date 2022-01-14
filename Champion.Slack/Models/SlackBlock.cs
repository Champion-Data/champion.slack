using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Champion.Slack.Models
{
    public class SlackBlock
    {
        public SlackBlock(string markdownText)
        {
            this.Text = new SlackMarkdownText { Text = markdownText };
        }

        public SlackBlock()
        {
        }

        [JsonPropertyName("accessory")]
        public SlackButton Accessory { get; set; }

        [JsonPropertyName("fields")]
        public List<SlackMarkdownText> Fields { get; set; }

        [JsonPropertyName("text")]
        public SlackMarkdownText Text { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = "section";
    }
}