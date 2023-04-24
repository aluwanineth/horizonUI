using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class EntryAgeService : IEntryAgeService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public EntryAgeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<EntryAgeVM>> GetEntryAges()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<EntryAgeVM>> (BaseURIConfig + "entryage/entryages");
            return result;
        }

        public async Task<string> SaveEntryAge(EntryAgeVM entryage)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "entryage/saveentryage", entryage);
            return result.ToString();
        }

        public async Task<string> UpdateEntryAge(EntryAgeVM entryage)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "entryage/updateentryage", entryage);
            return result.ToString();
        }
    }
}
