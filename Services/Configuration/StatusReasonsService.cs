using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class StatusReasonsService : IStatusReasonsService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public StatusReasonsService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<StatusReasonsVM>> GetStatusReasons()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<StatusReasonsVM>>(BaseURIConfig + "statusReasons/statusReasons");
            return result;
        }

        public async Task<string> SaveStatusReasons(StatusReasonsVM statusReasons)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "statusReasons/saveStatusReasons", statusReasons);
            return result.ToString();
        }

        public async Task<string> UpdateStatusReasons(StatusReasonsVM statusReasons)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "statusReasons/updateStatusReasons", statusReasons);
            return result.ToString();
        }
    }
}
