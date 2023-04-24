using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public DiscountService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<DiscountVM>> GetDiscounts()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<DiscountVM>>(BaseURIConfig + "discount/discounts");
            return result;
        }

        public async Task<string> SaveDiscount(DiscountVM discount)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "discount/savediscount", discount);
            return result.ToString();
        }

        public async Task<string> UpdateDiscount(DiscountVM discount)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "discount/updatediscount", discount);
            return result.ToString();
        }
    }
}
