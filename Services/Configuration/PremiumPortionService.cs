using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class PremiumPortionService : IPremiumPortionService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public PremiumPortionService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<PremiumPortionTypeVM>> GetPremiumPortions()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<PremiumPortionTypeVM>>(BaseURIConfig + "premportion/premportion");
            return result; throw new NotImplementedException();
        }

        public async Task<string> SavePremiumPortion(PremiumPortionTypeVM premiumportion)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "premportion/SavePremPortion", premiumportion);
            return result.ToString();
        }

        public async Task<string> UpdatePremiumPortion(PremiumPortionTypeVM premiumportion)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "premportion/UpdatePremPortion", premiumportion);
            return result.ToString();
        }
    }
}
