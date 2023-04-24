using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class SchemePlanFactorsService : ISchemePlanFactorsService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public SchemePlanFactorsService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<SchemePlanFactorsVM>> GetSchemePlanFactors()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<SchemePlanFactorsVM>>(BaseURIConfig + "schemePlanFactors/schemePlanFactors");
            return result;
        }

        public async Task<string> SaveSchemePlanFactors(SchemePlanFactorsVM schemePlanFactors)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "schemePlanFactors/saveSchemePlanFactors", schemePlanFactors);
            return result.ToString();
        }

        public async Task<string> UpdateSchemePlanFactors(SchemePlanFactorsVM schemePlanFactors)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "schemePlanFactors/updateschemePlanFactors", schemePlanFactors);
            return result.ToString();
        }
    }
}
