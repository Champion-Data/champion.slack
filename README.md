# Champion.Slack
A lightweight library for sending messages to Slack via System.Net.Http.HttpClient using System.Text.Json

This is an ongoing side project that only gets a few hours a week. The goal is to release a NuGet package with documentation.

The README will be updated as progress is made.

## TODO / ROADMAP

* Get basic version going
* Ensure XML documentation
* Add example usage to README.md
* Build a fluent interface
* Update documentation
* Get a Github Actions pipeline going to build and publish as a NuGet package

## End Goal

The end goal of the project will ideally include a fluent interface for creating a Slack message using [block kit](https://api.slack.com/reference/block-kit) syntax.

Rough idea would be something like the following:
```c#
var message = FluentSlackMessage.Create().Text(messageText)
    .Blocks()
    .Section(messageText)
        .Button(":grin: Smile", "smile-now", "https://github.com/Champion-Data/champion.slack", "grin", ButtonStyle.Danger)
        .Fields("*Smile*: grin")
    .Divider()
    .Section().Fields("Field A: :A:", "Field B: :B:")
    .Build();
```
