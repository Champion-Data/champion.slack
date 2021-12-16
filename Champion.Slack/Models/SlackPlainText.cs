// <copyright file="SlackPlainText.cs" company="Champion Data">
// Copyright (c) Champion Data. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Champion.Slack.Models
{
    public class SlackPlainText
    {
        [JsonPropertyName("type")]
        public string Type => "plain_text";

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("emoji")]
        public bool Emoji { get; set; }
    }
}