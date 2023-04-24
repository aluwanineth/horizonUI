using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class SchemeService : IGeneric<SchemeVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public SchemeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<SchemeVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<SchemeVM>>(BaseURIConfig + "Scheme/Scheme");
            return result;
        }


        public async Task<string> Update(SchemeVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "Scheme/UpdateScheme", model);
            return result.ToString();
        }
    }
}
