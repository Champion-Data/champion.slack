// <copyright file="SlackButton.cs" company="Champion Data">
// Copyright (c) Champion Data. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Champion.Slack.Models
{
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