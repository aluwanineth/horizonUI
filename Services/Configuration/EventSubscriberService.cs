using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class EventSubscriberService : IEventSubscriberService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public EventSubscriberService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<EventSubscriberVM>> GetEventSubscribers()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<EventSubscriberVM>>(BaseURIConfig + "eventsubscriber/eventsubscribers");
            return result;
        }

        public async Task<string> SaveEventSubscriber(EventSubscriberVM eventsubscriber)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "eventsubscriber/saveeeventsubscriber", eventsubscriber);
            return result.ToString();
        }

        public async Task<string> UpdateEventSubscriber(EventSubscriberVM eventsubscriber)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "eventsubscriber/updateeventsubscriber", eventsubscriber);
            return result.ToString();
        }
    }
}
