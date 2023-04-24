using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class ProductLineServices : IGeneric<ProductLineVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public ProductLineServices(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<ProductLineVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ProductLineVM>>(BaseURIConfig + "ProductLine/ProductLine");
            return result;
        }


        public async Task<string> Update(ProductLineVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "ProductLine/UpdateProductLine", model);
            return result.ToString();
        }
    }
}
