using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Champion.Slack.Models;

namespace Champion.Slack
{
    public class SlackMessenger : ISlackMessenger
    {
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public string WebHookUrl { get; set; }

        public HttpClient Client { get; set; }

        public ILogger<SlackMessenger> Logger { get; }

        public SlackMessenger(string webHookUrl, HttpClient client, ILogger<SlackMessenger> logger)
        {
            this.WebHookUrl = webHookUrl;
            this.Client = client;
            this.Logger = logger;
            this.jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
        public async Task<HttpResponseMessage> SendAsync(SlackMessage message)
        {
            var json = JsonSerializer.Serialize(message, this.jsonSerializerOptions);
            this.Logger.LogInformation("Sending Slack message to WebHook at {url} with a payload of {json}", this.WebHookUrl, json);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return await this.Client.PostAsync(this.WebHookUrl, data);
        }
    }
}
