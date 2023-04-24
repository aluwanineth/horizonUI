using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class EventSubscriptionService : IEventSubscriptionService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public EventSubscriptionService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<EventSubscriptionVM>> GetEventSubscriptions()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<EventSubscriptionVM>>(BaseURIConfig + "EventSubscription/EventSubscriptions");
            return result;
        }

        public async Task<string> SaveEventSubscription(EventSubscriptionVM eventsubscription)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "eventsubscription/saveeeventsubscription", eventsubscription);
            return result.ToString();
        }

        public async Task<string> UpdateEventSubscription(EventSubscriptionVM eventsubscription)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "eventsubscription/updateeventsubscription", eventsubscription);
            return result.ToString();
        }
    }
}
