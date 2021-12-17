using System.Collections.Generic;

namespace Champion.Slack.Models;

public class FluentSlackMessage : ITextBlockStage, IBlocksStage
{
    private readonly SlackMessage message;

    private FluentSlackMessage()
    {
        this.message = new SlackMessage();
    }

    public static ITextBlockStage Create()
    {
        return new FluentSlackMessage();
    }

    public IBlocksStage Block()
    {
        this.message.Blocks = new List<SlackBlock>();
        return this;
    }

    public SlackMessage Build()
    {
        return this.message;
    }

    public IBlocksStage Section()
    {
        this.message.Blocks.Add(new SlackBlock());
        return this;
    }

    public ITextBlockStage Text(string text)
    {
        this.message.Text = text;
        return this;
    }
}

public interface IBuildableStage
{
    public SlackMessage Build();
}

public interface ITextBlockStage : IBuildableStage
{
    public IBlocksStage Block();
    public ITextBlockStage Text(string text);
}

public interface IBlocksStage : IBuildableStage
{
    public IBlocksStage Section();
}