using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Champion.Slack.Models;

public class FluentSlackMessage : ITextBlockStage, ISectionStage
{
    private readonly SlackMessage message;

    private SlackBlock CurrentBlock => this.message.Blocks.Last();

    private FluentSlackMessage()
    {
        this.message = new SlackMessage();
    }

    public static ITextBlockStage Create()
    {
        return new FluentSlackMessage();
    }

    public IBlocksStage Blocks()
    {
        this.message.Blocks = new List<SlackBlock>();
        return this;
    }

    public SlackMessage Build()
    {
        return this.message;
    }

    public ITextBlockStage Text(string text)
    {
        this.message.Text = text;
        return this;
    }

    public ISectionStage Button(string text, string actionId, string url, string value, ButtonStyle style = ButtonStyle.Primary)
    {
        this.CurrentBlock.Accessory = new SlackButton
        {
            Type = "button",
            Text = new SlackPlainText { Text = text, Emoji = true },
            ActionId = actionId,
            Url = url,
            Value = value,
            Style = style
        };
        return this;
    }

    public ISectionStage Section()
    {
        this.message.Blocks.Add(new SlackBlock());
        return this;
    }

    public ISectionStage Section(string markdownText)
    {
        this.message.Blocks.Add(new SlackBlock(markdownText));
        return this;
    }

    public IBlocksStage Divider()
    {
        this.message.Blocks.Add(new SlackBlock {Type = "divider"});
        return this;
    }

    public ISectionStage Fields(string[] markdownStrings)
    {
        this.CurrentBlock.Fields = new List<SlackMarkdownText>();
        foreach (var markdownString in markdownStrings)
        {
            this.CurrentBlock.Fields.Add(new SlackMarkdownText{Text = markdownString});
        }

        return this;
    }

    ISectionStage ISectionStage.Text(string markdownText)
    {
        this.CurrentBlock.Text = new SlackMarkdownText { Text = markdownText };
        return this;
    }
}

public interface IBuildableStage
{
    public SlackMessage Build();
}

public interface ITextBlockStage : IBuildableStage
{
    public IBlocksStage Blocks();
    public ITextBlockStage Text(string text);
}

public interface IBlocksStage : IBuildableStage
{
    public ISectionStage Section();

    public ISectionStage Section(string markdownText);

    public IBlocksStage Divider();
}

public interface ISectionStage : IBlocksStage
{
    public ISectionStage Fields(params string[] markdownStrings);

    public ISectionStage Text(string markdownText);

    public ISectionStage Button(string text, string actionId, string url, string value, ButtonStyle style = ButtonStyle.Default);
}

public enum ButtonStyle
{
    [JsonIgnore]
    Default,
    Primary,
    Danger
}