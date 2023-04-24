using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class LanguageService : ILanguageService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public LanguageService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<LanguageVM>> GetLanguages()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<LanguageVM>>(BaseURIConfig + "language/languages");
            return result; 
        }

        public async Task<string> SaveLanguage(LanguageVM language)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "language/savelanguage", language);
            return result.ToString();
        }

        public async Task<string> UpdateLanguage(LanguageVM language)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "language/updatelanguage", language);
            return result.ToString();
        }
    }
}
