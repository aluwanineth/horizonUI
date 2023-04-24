using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class EventTypeService : IEventTypeService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public EventTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<EventTypeVM>> GetEventTypes()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<EventTypeVM>>(BaseURIConfig + "eventtype/eventtypes");
            return result;
        }

        public async Task<string> SaveEventType(EventTypeVM eventtype)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "eventtype/saveeeventtype", eventtype);
            return result.ToString();
        }

        public async Task<string> UpdateEventType(EventTypeVM eventtype)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "eventtype/updateeventtype", eventtype);
            return result.ToString();
        }
    }
}
