
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Barney.Domain.Clients;
using Barney.Domain.Events;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Barney.Data.Clients
{
    public class MessageApiClient : IMessageApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MessageApiClient> _logger;
        public MessageApiClient(HttpClient client, ILogger<MessageApiClient> logger)
        {
            _httpClient = client;
            _logger = logger;
        }
        
        
        public async Task Publish(IncomeReceived incomeReceived)
        {
            var incomeReceivedEvent = new
            {
                EventType = "IncomeReceived",
                Body = JsonConvert.SerializeObject(incomeReceived),
                Sent = DateTime.Now
            };

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/events")
            {
                
            };

            var content = new StringContent(JsonConvert.SerializeObject(incomeReceivedEvent));
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            requestMessage.Content = content;
            
            requestMessage.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                _logger.LogError($"Unable to publish event StatusCode {response.StatusCode} with message: {responseContent}");
            }

        }


        
    }
}
