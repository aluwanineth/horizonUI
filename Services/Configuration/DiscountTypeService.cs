using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class DiscountTypeService : IDiscountTypeService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public DiscountTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<DiscountTypeVM>> GetDiscountTypes()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<DiscountTypeVM>>(BaseURIConfig + "discounttype/discounttypes");
            return result;
        }

        public async Task<string> SaveDiscountType(DiscountTypeVM discounttype)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "discountype/savediscounttype", discounttype);
            return result.ToString();
        }

        public async Task<string> UpdateDiscountType(DiscountTypeVM discounttype)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "discounttype/updatediscounttype", discounttype);
            return result.ToString();
        }
    }
}
