using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class BenefitAgesService : IBenefitAgesService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public BenefitAgesService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<BenefitAgesVM>> GetBenefitAges()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BenefitAgesVM>>(BaseURIConfig + "benefitAges/benefitAges");
            return result;
        }

        public async Task<string> SaveBenefitAges(BenefitAgesVM benefitAges)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitAges/saveBenefitAges", benefitAges);
            return result.ToString();
        }

        public async Task<string> UpdateBenefitAges(BenefitAgesVM benefitAges)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitAges/updateBenefitAges", benefitAges);
            return result.ToString();
        }
    }
}
