using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Champion.Slack.Models;

namespace Champion.Slack
{
    public class SlackMessenger : ISlackMessenger
    {
        public SlackMessenger(string webHookUrl, HttpClient client, ILogger<SlackMessenger> logger)
        {

        }

        public Task<HttpResponseMessage> SendAsync(SlackMessage message)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Send(SlackMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
