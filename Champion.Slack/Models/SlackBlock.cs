// <copyright file="SlackBlock.cs" company="Champion Data">
// Copyright (c) Champion Data. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Champion.Slack.Models
{
    public class SlackBlock
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "section";

        [JsonPropertyName("text")]
        public SlackMarkdownText Text { get; set; }

        [JsonPropertyName("accessory")]
        public SlackButton Accessory { get; set; }

        [JsonPropertyName("fields")]
        public List<SlackMarkdownText> Fields { get; set; }
    }
}