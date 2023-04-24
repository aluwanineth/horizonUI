using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class LevelService : ILevelService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public LevelService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<LevelVM>> GetLevels()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<LevelVM>>(BaseURIConfig + "level/levels");
            return result;
        }

        public async Task<string> SaveLevel(LevelVM level)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "level/savelevel", level);
            return result.ToString();
        }

        public async Task<string> UpdateLevel(LevelVM level)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "level/updatelevel", level);
            return result.ToString();
        }
    }
}
