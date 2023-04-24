using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{

    public class BenefitOptionService : IBenefitOptionService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public BenefitOptionService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<BenefitOptionVM>> GetBenefitOptions()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BenefitOptionVM>>(BaseURIConfig + "benefitoption/benefitoptions");
            return result;
        }

        public async Task<string> SaveBenefitOption(BenefitOptionVM benefitoption)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitoption/savebenefitoption", benefitoption);
            return result.ToString();
        }

        public async Task<string> UpdateBenefitOption(BenefitOptionVM benefitoption)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitoption/updatebenefitoption", benefitoption);
            return result.ToString();
        }
    }
}
