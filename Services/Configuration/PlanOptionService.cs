using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class PlanOptionService : IPlanOptionService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public PlanOptionService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<PlanOptionVM>> GetPlanOptions()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<PlanOptionVM>>(BaseURIConfig + "planoption/planoptions");
            return result;
        }

        public async Task<string> SavePlanOption(PlanOptionVM planoption)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "planoption/saveplanoption", planoption);
            return result.ToString();
        }

        public async Task<string> UpdatePlanOption(PlanOptionVM planoption)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "planoption/updateplanoption", planoption);
            return result.ToString();
        }
    }
}
