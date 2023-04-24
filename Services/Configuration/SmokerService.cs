using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class SmokerService : IGeneric<SmokerVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public SmokerService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<SmokerVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<SmokerVM>>(BaseURIConfig + "Smoker/Smoker");
            return result;
        }


        public async Task<string> Update(SmokerVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "Smoker/UpdateSmoker", model);
            return result.ToString();
        }
    }
}
