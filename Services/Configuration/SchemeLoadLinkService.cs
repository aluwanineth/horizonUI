using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class SchemeLoadLinkService : IGeneric<ScheneLoadLinkVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public SchemeLoadLinkService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<ScheneLoadLinkVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ScheneLoadLinkVM>>(BaseURIConfig + "SchemeLoadLink/SchemeLoadLink");
            return result;
        }


        public async Task<string> Update(ScheneLoadLinkVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "SchemeLoadLink/UpdateSchemeLoadLink", model);
            return result.ToString();
        }
    }
}
