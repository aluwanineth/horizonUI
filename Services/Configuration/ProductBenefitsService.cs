using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class ProductBenefitsService : IProductBenefitsService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public ProductBenefitsService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<ProductBenefitsVM>> GetProductBenefits()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ProductBenefitsVM>>(BaseURIConfig + "productBenefits/productBenefits");
            return result;
        }

        public async Task<string> SaveProductBenefits(ProductBenefitsVM premPortion)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "productBenefits/saveProductBenefits", premPortion);
            return result.ToString();
        }

        public async Task<string> UpdateProductBenefits(ProductBenefitsVM premPortion)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "productBenefits/updateProductBenefits", premPortion);
            return result.ToString();
        }
    }
}
