using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class PremiumTypeService : IGeneric<PremiumTypeVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public PremiumTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<PremiumTypeVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<PremiumTypeVM>>(BaseURIConfig + "PremiumType/PremiumType");
            return result;
        }


        public async Task<string> Update(PremiumTypeVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "PremiumType/UpdatePremiumType", model);
            return result.ToString();
        }
    }
}
