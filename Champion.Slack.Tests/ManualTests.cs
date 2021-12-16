using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Champion.Slack.Models;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;
using Xunit.Abstractions;

namespace Champion.Slack.Tests;

public class ManualTests
{
    private readonly ITestOutputHelper output;

    IConfiguration Configuration { get; }

    public ManualTests(ITestOutputHelper output)
    {
        this.output = output;
        var builder = new ConfigurationBuilder().AddUserSecrets<ManualTests>();

        this.Configuration = builder.Build();
    }

    [Fact]
    [Trait("Category","Manual")]
    public async Task BasicMessageTest()
    {
        var webHookUrl = this.Configuration["WebHookUrl"];

        webHookUrl.Should().NotBeNullOrWhiteSpace();

        var messageText = "Basic *message* _test_ ~struck~";

        var slackMessage = new SlackMessage
        {
            Text = messageText,
            Blocks = new List<SlackBlock>
            {
                new()
                {
                    Text = new SlackMarkdownText
                    {
                        Text = messageText
                    },
                    Accessory = new SlackButton
                    {
                        Type = "button",
                        Text = new SlackPlainText
                        {
                            Text = ":grin: Smile",
                            Emoji = true
                        },
                        Value = "grin",
                        Url = "https://github.com/Champion-Data/champion.slack",
                        ActionId = "smile-now"
                    },
                    Fields = new List<SlackMarkdownText>
                    {
                        new() { Text = "*Smile*: grin" }
                    }
                },
                new()
                {
                    Type = "divider"
                },
                new()
                {
                    Fields = new List<SlackMarkdownText>
                    {
                        new() { Text = "Field A: :A:" },
                        new() { Text = "Field B: :B:" }
                    }
                }
            }
        };


        var client = new HttpClient();
        var logger = this.output.BuildLoggerFor<SlackMessenger>();
        var messenger = new SlackMessenger(webHookUrl, client, logger);
        var response = await messenger.SendAsync(slackMessage);

        response.IsSuccessStatusCode.Should().BeTrue();
    }
}