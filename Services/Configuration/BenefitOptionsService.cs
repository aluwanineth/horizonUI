using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class BenefitOptionsService : IBenefitOptionsService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public BenefitOptionsService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<BenefitOptionsVM>> GetBenefitOptions()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BenefitOptionsVM>>(BaseURIConfig + "benefitoptions/benefitoptions");
            return result;
        }

        public async Task<string> SaveBenefitOptions(BenefitOptionsVM benefitOptions)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitOptions/savebenefitOptions", benefitOptions);
            return result.ToString();
        }

        public async Task<string> UpdateBenefitOptions(BenefitOptionsVM benefitOptions)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitOptions/updatebenefitOptions", benefitOptions);
            return result.ToString();
        }
    }
}
