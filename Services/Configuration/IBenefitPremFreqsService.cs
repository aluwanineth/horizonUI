using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBenefitPremFreqsService
    {
        public Task<IEnumerable<BenefitPremFreqsVM>> GetBenefitPremFreqs();
        public Task<string> UpdateBenefitPremFreqs(BenefitPremFreqsVM benefitPremFreqs);
        public Task<string> SaveBenefitPremFreqs(BenefitPremFreqsVM benefitPremFreqs);
    }
}
