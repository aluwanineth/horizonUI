using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class PaymentFrequencyService : IPaymentFrequencyService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public PaymentFrequencyService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<PaymentFreqVM>> GetPaymentFreqs()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<PaymentFreqVM>>(BaseURIConfig + "paymentfreq/paymentfreqs");
            return result;
        }

        public async Task<string> SavePaymentFreq(PaymentFreqVM paymentfreq)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "paymentfreq/savepaymentfreq", paymentfreq);
            return result.ToString();
        }

        public async Task<string> UpdatePaymentFreq(PaymentFreqVM paymentfreq)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "paymentfreq/updatepaymentfreq", paymentfreq);
            return result.ToString();
        }
    }
}
