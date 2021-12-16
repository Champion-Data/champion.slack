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
}