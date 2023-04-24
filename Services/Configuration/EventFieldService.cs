using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class EventFieldService : IEventFieldService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public EventFieldService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<EventFieldVM>> GetEventFields()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<EventFieldVM>>(BaseURIConfig + "eventfield/eventfields");
            return result;
        }

        public async Task<string> SaveEventField(EventFieldVM eventfield)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "eventfield/saveeventfield", eventfield);
            return result.ToString();
        }

        public async Task<string> UpdateEventField(EventFieldVM eventfield)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "eventfield/updateeventfield", eventfield);
            return result.ToString();
        }
    }
}
