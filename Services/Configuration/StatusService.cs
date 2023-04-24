using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class StatusService : IGeneric<StatusVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public StatusService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<StatusVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<StatusVM>>(BaseURIConfig + "Status/Status");
            return result;
        }


        public async Task<string> Update(StatusVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "Status/UpdateStatus", model);
            return result.ToString();
        }
    }
}
