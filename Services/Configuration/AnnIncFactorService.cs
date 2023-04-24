using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class AnnIncFactorService : IAnnIncFactorService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public AnnIncFactorService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<AnnIncFactorsVM>> GetAnIncFactors()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<AnnIncFactorsVM>>(BaseURIConfig + "annincfactors/annincfactors");
            return result;
        }

        public async Task<string> SaveAnIncFactors(AnnIncFactorsVM anincfactors)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "annincfactors/saveannincfactors", anincfactors);
            return result.ToString();
        }

        public async Task<string> UpdateAnIncFactors(AnnIncFactorsVM anincfactors)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "annincfactors/updateannincfactors", anincfactors);
            return result.ToString();
        }
    }
}
