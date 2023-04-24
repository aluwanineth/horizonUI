using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class PortionOptionService : IPortionOptionService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public PortionOptionService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<PortionOptionVM>> GetPortionOptions()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<PortionOptionVM>>(BaseURIConfig + "portionoption/portionoption");
            return result;
        }

        public async Task<string> SavePortionOption(PortionOptionVM portionoption)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "portionoption/saveportionoption", portionoption);
            return result.ToString();
        }

        public async Task<string> UpdatePortionOption(PortionOptionVM portionoption)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "portionoption/updateportionoption", portionoption);
            return result.ToString();
        }
    }
}
