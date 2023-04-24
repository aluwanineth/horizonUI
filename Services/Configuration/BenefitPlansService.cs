using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class BenefitPlansService: IBenefitPlansService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public BenefitPlansService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }

        public async Task<IEnumerable<BenefitPlansVM>> GetBenefitPlans()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BenefitPlansVM>>(BaseURIConfig + "benefitPlans/benefitPlans");
            return result;
        }

        public async Task<string> SaveBenefitPlans(BenefitPlansVM benefitPlans)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitPlans/savebenefitPlans", benefitPlans);
            return result.ToString();
        }


        public async Task<string> UpdateBenefitPlans(BenefitPlansVM benefitPlans)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitPlans/updatebenefitPlans", benefitPlans);
            return result.ToString();
        }


    }
}
