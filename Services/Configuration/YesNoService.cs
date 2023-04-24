using HorizonPollyC.Models;
using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class YesNoService : IYesNoService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public YesNoService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<YesNoVM>> GetYesNos()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<YesNoVM>>(BaseURIConfig + "Configuration/YesNos");
            return result;
        }
    }
}
