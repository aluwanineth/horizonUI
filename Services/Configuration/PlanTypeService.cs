using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class PlanTypeService : IPlanTypeService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public PlanTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<PlanTypeVM>> GetPlanTypes()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<PlanTypeVM>>(BaseURIConfig + "plantype/plantypes");
            return result;
        }

        public async Task<string> SavePlanType(PlanTypeVM plantype)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "plantype/saveplantype", plantype);
            return result.ToString();
        }

        public async Task<string> UpdatePlanType(PlanTypeVM plantype)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "plantype/updateplantype", plantype);
            return result.ToString();
        }
    }
}
