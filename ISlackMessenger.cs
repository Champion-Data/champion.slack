using System;
using System.Net.Http;
using System.Threading.Tasks;
using Champion.Slack.Models;

namespace Champion.Slack
{
    public interface ISlackMessenger
    {
        Task<HttpResponseMessage> SendAsync(SlackMessage message);
        HttpResponseMessage Send(SlackMessage message);
    }
}

