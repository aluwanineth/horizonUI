using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class TitlesService : IGeneric<TitlesVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public TitlesService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<TitlesVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<TitlesVM>>(BaseURIConfig + "Titles/Titles");
            return result;
        }


        public async Task<string> Update(TitlesVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "Titles/UpdateTitles", model);
            return result.ToString();
        }
    }
}
