using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class TierSerice : IGeneric<TierVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public TierSerice(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<TierVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<TierVM>>(BaseURIConfig + "Tier/Tier");
            return result;
        }


        public async Task<string> Update(TierVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "Tier/UpdateTier", model);
            return result.ToString();
        }
    }
}
