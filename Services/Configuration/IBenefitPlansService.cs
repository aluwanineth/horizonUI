using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBenefitPlansService
    {
        public Task<IEnumerable<BenefitPlansVM>> GetBenefitPlans();
        public Task<string> UpdateBenefitPlans(BenefitPlansVM benefitPlans);
        public Task<string> SaveBenefitPlans(BenefitPlansVM benefitPlans);
    }
}
