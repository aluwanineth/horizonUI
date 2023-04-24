using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class PremiumPortionTypeService : IGeneric<PremiumPortionTypeVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public PremiumPortionTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<PremiumPortionTypeVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<PremiumPortionTypeVM>>(BaseURIConfig + "PremiumPortionType/PremiumPortionType");
            return result;
        }


        public async Task<string> Update(PremiumPortionTypeVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "PremiumPortionType/UpdatePremiumPortionType", model);
            return result.ToString();
        }
    }
}
