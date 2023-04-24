using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class BordereauxSourceService : IBordereauxSourceService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public BordereauxSourceService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<BordereauxSourceVM>> GetBordereauxSources()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BordereauxSourceVM>>(BaseURIConfig + "bordereauxsource/bordereauxsources");
            return result;
        }

        public async Task<string> SavetBordereauxSource(BordereauxSourceVM bordereauxsource)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "bordereauxsource/savebordereauxsource", bordereauxsource);
            return result.ToString();
        }

        public async Task<string> UpdatetBordereauxSource(BordereauxSourceVM bordereauxsource)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "bordereauxsource/updatebordereauxsource", bordereauxsource);
            return result.ToString();
        }
    }
}
