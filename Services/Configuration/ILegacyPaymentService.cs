using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface ILegacyPaymentService
    {
        public Task<IEnumerable<LegacyPaymentVM>> GetLegacyPayments();
        public Task<string> UpdateLegacyPayment(LegacyPaymentVM legacypayment);
        public Task<string> SaveLegacyPayment(LegacyPaymentVM legacypayment);
    }
}
