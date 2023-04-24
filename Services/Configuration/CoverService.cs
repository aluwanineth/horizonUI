using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class CoverService : ICoverService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public CoverService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<CoverVM>> GetCovers()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<CoverVM>>(BaseURIConfig + "cover/cover");
            return result;
        }

        public async Task<string> SaveCover(CoverVM cover)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "cover/savecover", cover);
            return result.ToString();
        }

        public async Task<string> UpdateCover(CoverVM cover)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "cover/updatecover", cover);
            return result.ToString();
        }
    }
}
