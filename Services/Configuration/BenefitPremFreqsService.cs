using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class BenefitPremFreqsService:IBenefitPremFreqsService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public BenefitPremFreqsService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }


        public async Task<IEnumerable<BenefitPremFreqsVM>> GetBenefitPremFreqs()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BenefitPremFreqsVM>>(BaseURIConfig + "benefitPremFreqs/benefitPremFreqs");
            return result;
        }

        public async Task<string> SaveBenefitPremFreqs(BenefitPremFreqsVM benefitPremFreqs)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitPremFreqs/savebenefitPremFreqs", benefitPremFreqs);
            return result.ToString();
        }



        public async Task<string> UpdateBenefitPremFreqs(BenefitPremFreqsVM benefitPremFreqs)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitPremFreqs/updatebenefitPremFreqs", benefitPremFreqs);
            return result.ToString();
        }

    }
}
