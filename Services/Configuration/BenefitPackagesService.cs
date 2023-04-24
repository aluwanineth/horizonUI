using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class BenefitPackagesService : IBenefitPackagesService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public BenefitPackagesService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<BenefitPackagesVM>> GetBenefitPackages()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BenefitPackagesVM>>(BaseURIConfig + "benefitpackages/benefitpackages");
            return result;
        }

        public async Task<string> SaveBenefitPackages(BenefitPackagesVM benefitPackages)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitpackages/SaveBenefitPackages", benefitPackages);
            return result.ToString();
        }

        public async Task<string> UpdateBenefitPackages(BenefitPackagesVM benefitPackages)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "benefitpackages/UpdateBenefitPackage", benefitPackages);
            return result.ToString();
        }
    }
}
