using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class PremPortionService : IPremPortionService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public PremPortionService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<PremPortionVM>> GetPremPortion()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<PremPortionVM>>(BaseURIConfig + "premportion/premportion");
            return result; 
        }

        public async Task<string> SavePremPortion(PremPortionVM premiumportion)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "premportion/savepremportion", premiumportion);
            return result.ToString();
        }

        public async Task<string> UpdatePremPortion(PremPortionVM premiumportion)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "premportion/updatepremportion", premiumportion);
            return result.ToString();
        }

    }
}
