using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class TakeonOptionService : IGeneric<TakeOnOptionVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public TakeonOptionService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<TakeOnOptionVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<TakeOnOptionVM>>(BaseURIConfig + "TakeonOption/TakeonOption");
            return result;
        }


        public async Task<string> Update(TakeOnOptionVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "TakeonOption/UpdateTakeonOption", model);
            return result.ToString();
        }
    }
}
