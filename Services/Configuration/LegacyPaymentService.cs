using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class LegacyPaymentService : ILegacyPaymentService
    {

        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public LegacyPaymentService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<LegacyPaymentVM>> GetLegacyPayments()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<LegacyPaymentVM>>(BaseURIConfig + "legacypayment/legacypayments");
            return result;
        }

        public async Task<string> SaveLegacyPayment(LegacyPaymentVM legacypayment)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "legacypayment/savelegacypayment", legacypayment);
            return result.ToString();
        }

        public async Task<string> UpdateLegacyPayment(LegacyPaymentVM legacypayment)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "legacypayment/updatelegacypayment", legacypayment);
            return result.ToString();
        }
    }
}
