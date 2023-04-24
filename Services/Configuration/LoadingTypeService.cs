using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class LoadingTypeService : ILoadingTypeService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public LoadingTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<LoadingTypeVM>> GetLoadingTypes()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<LoadingTypeVM>>(BaseURIConfig + "loadingtype/loadingtypes");
            return result;
        }

        public async Task<string> SaveLoadingType(LoadingTypeVM loadingtype)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "loadingtype/saveloadingtype", loadingtype);
            return result.ToString();
        }

        public async Task<string> UpdateLoadingType(LoadingTypeVM loadingtype)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "loadingtype/updateloadingtype", loadingtype);
            return result.ToString();
        }
    }
}
