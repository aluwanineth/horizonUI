using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class LoadingService : ILoadingService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public LoadingService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<LoadingVM>> GetLoadings()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<LoadingVM>>(BaseURIConfig + "loading/loadings");
            return result;
        }

        public async Task<string> SaveLoading(LoadingVM loading)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "loading/saveloading", loading);
            return result.ToString();
        }

        public async Task<string> UpdateLoading(LoadingVM loading)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "loading/updateloading", loading);
            return result.ToString();
        }
    }
}
