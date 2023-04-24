using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IPaymentFrequencyService
    {
        public Task<IEnumerable<PaymentFreqVM>> GetPaymentFreqs();
        public Task<string> UpdatePaymentFreq(PaymentFreqVM paymentfreq);
        public Task<string> SavePaymentFreq(PaymentFreqVM paymentfreq);
    }
}
