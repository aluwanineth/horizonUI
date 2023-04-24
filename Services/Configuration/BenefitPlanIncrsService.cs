using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class BenefitPlanIncrsService : IBenefitPlanIncrsService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public BenefitPlanIncrsService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }



        public async Task<IEnumerable<BenefitPlanIncrsVM>> GetBenefitPlanIncrs()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BenefitPlanIncrsVM>>(BaseURIConfig + "benefitPlanIncrs/benefitPlanIncrs");
            return result;
        }

        public async Task<string> SaveBenefitPlanIncrs(BenefitPlanIncrsVM benefitPlanIncrs)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitPlanIncrs/savebenefitPlanIncrs", benefitPlanIncrs);
            return result.ToString();
        }


        public async Task<string> UpdateBenefitPlanIncrs(BenefitPlanIncrsVM benefitPlanIncrs)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitPlanIncrs/updatebenefitPlanIncrs", benefitPlanIncrs);
            return result.ToString();
        }


    }
}
