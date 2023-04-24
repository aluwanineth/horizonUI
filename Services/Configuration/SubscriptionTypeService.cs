using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class SubscriptionTypeService : IGeneric<SubscriptionTypeVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public SubscriptionTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<SubscriptionTypeVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<SubscriptionTypeVM>>(BaseURIConfig + "SubscriptionType/SubscriptionType");
            return result;
        }


        public async Task<string> Update(SubscriptionTypeVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "SubscriptionType/UpdateSubscriptionType", model);
            return result.ToString();
        }
    }
}
