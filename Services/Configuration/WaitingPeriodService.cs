using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class WaitingPeriodService : IGeneric<WaitingPeriodsVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public WaitingPeriodService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<WaitingPeriodsVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<WaitingPeriodsVM>>(BaseURIConfig + "WaitingPeriod/WaitingPeriods");
            return result;
        }


        public async Task<string> Update(WaitingPeriodsVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "WaitingPeriod/UpdateWaitingPeriods", model);
            return result.ToString();
        }
    }
}
