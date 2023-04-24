using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class TranslateService : IGeneric<TranslateVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public TranslateService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<TranslateVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<TranslateVM>>(BaseURIConfig + "Translate/Translate");
            return result;
        }


        public async Task<string> Update(TranslateVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "Translate/UpdateTranslate", model);
            return result.ToString();
        }
    }
}
