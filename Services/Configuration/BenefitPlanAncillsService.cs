using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class BenefitPlanAncillsService : IBenefitPlanAncillsService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public BenefitPlanAncillsService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<BenefitPlanAncillsVM>> GetBenefitPlanAncills()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BenefitPlanAncillsVM>>(BaseURIConfig + "BenefitPlanAncills/benefitplanancills");
            return result;
        }

        public async Task<string> SaveBenefitPlanAncills(BenefitPlanAncillsVM benefitPlanAncills)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitPlanAncills/savebenefitPlanAncills", benefitPlanAncills);
            return result.ToString();
        }

        public async Task<string> UpdateBenefitPlanAncills(BenefitPlanAncillsVM benefitPlanAncills)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitPlanAncills/updatebenefitPlanAncills", benefitPlanAncills);
            return result.ToString();
        }
    }
}
