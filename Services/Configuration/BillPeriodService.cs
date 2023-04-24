using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class BillPeriodService : IBillPeriodService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public BillPeriodService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<BillPeriodVM>> GetBillPeriods()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BillPeriodVM>>(BaseURIConfig + "billperiod/billperiods");
            return result;
        }

        public async Task<string> SaveBillPeriod(BillPeriodVM billperiod)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "billperiod/savebillperiod", billperiod);
            return result.ToString();
        }

        public async Task<string> UpdateBillPeriod(BillPeriodVM billperiod)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "billperiod/updatebillperiod", billperiod);
            return result.ToString();
        }
    }
}
