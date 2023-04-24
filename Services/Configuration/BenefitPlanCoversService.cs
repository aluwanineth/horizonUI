using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class BenefitPlanCoversService : IBenefitPlanCoversService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public BenefitPlanCoversService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<BenefitPlanCoversVM>> GetBenefitPlanCovers()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BenefitPlanCoversVM>>(BaseURIConfig + "benefitplancovers/benefitplancovers");
            return result;
        }

        public async Task<string> SaveBenefitPlanCovers(BenefitPlanCoversVM benefitPlanCovers)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitPlanCovers/savebenefitplancovers", benefitPlanCovers);
            return result.ToString();
        }


        public async Task<string> UpdateBenefitPlanCovers(BenefitPlanCoversVM benefitPlanCovers)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitPlanCovers/updatebenefitPlanCovers", benefitPlanCovers);
            return result.ToString();
        }

    }
}
