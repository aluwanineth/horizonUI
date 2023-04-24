using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class BenefitTypeService : IBenefitTypeService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public BenefitTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }

        public async Task<IEnumerable<BenefitTypeVM>> GetBenefitTypes()
        {

            var result = await httpClient.GetFromJsonAsync<IEnumerable<BenefitTypeVM>>(BaseURIConfig + "benefittype/benefittypes");
            return result;
        }

        public async Task<string> SaveBenefitType(BenefitTypeVM benefittype)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefittype/savebenefittype", benefittype);
            return result.ToString();
        }

        public async Task<string> UpdateBenefitType(BenefitTypeVM benefittype)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefittype/updatebenefittype", benefittype);
            return result.ToString();
        }
    }
}
