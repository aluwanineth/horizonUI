using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class ExpiryAgeService : IExpiryAgeService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public ExpiryAgeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<ExpiryAgeVM>> GetExpiryAges()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ExpiryAgeVM>>(BaseURIConfig + "expiryage/expiryages");
            return result;
        }

        public async Task<string> SaveExpiryAge(ExpiryAgeVM expiryage)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "expiryage/saveexpiryage", expiryage);
            return result.ToString();
        }

        public async Task<string> UpdateExpiryAge(ExpiryAgeVM expiryage)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "expiryage/updateexpiryage", expiryage);
            return result.ToString();
        }
    }
}
