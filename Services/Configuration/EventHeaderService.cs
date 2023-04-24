using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class EventHeaderService : IEventHeaderService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public EventHeaderService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<EventHeaderVM>> GetEventHeaders()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<EventHeaderVM>>(BaseURIConfig + "eventheader/eventheaders");
            return result;
        }

        public async Task<string> SaveEventHeader(EventHeaderVM eventheader)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "eventheader/saveeeventheader", eventheader);
            return result.ToString();
        }

        public async Task<string> UpdateEventHeader(EventHeaderVM eventheader)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "eventheader/updateeventheader", eventheader);
            return result.ToString();
        }
    }
}
