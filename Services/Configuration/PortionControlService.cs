using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Drawing.Drawing2D;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class PortionControlService : IPortionControlService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public PortionControlService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<PortionControlVM>> GetPortionControls()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<PortionControlVM>>(BaseURIConfig + "portioncontrol/portioncontrol");
            return result;
        }

        public async Task<string> SavePortionControl(PortionControlVM portioncontrol)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "portioncontrol/saveportioncontrol", portioncontrol);
            return result.ToString();
        }

        public async Task<string> UpdatePortionControl(PortionControlVM portioncontrol)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "portioncontrol/updateportioncontrol", portioncontrol);
            return result.ToString();
        }
    }
}
