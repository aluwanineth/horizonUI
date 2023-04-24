using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class BenefitPackageService : IBenefitPackageServices
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public BenefitPackageService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<BenefitPackageVM>> GetBenefitPackages()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BenefitPackageVM>>(BaseURIConfig + "benefitpackage/benefitpackage");
            return result;
        }

        public async Task<string> SaveBenefitPackage(BenefitPackageVM benefitpackage)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitpackage/savebenefitpackage", benefitpackage);
            return result.ToString();
        }

        public async Task<string> UpdateBenefitPackage(BenefitPackageVM benefitpackage)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitpackage/updatebenefitpackage", benefitpackage);
            return result.ToString();
        }
    }
}
