using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBenefitPlanAncillsService
    {
        public Task<IEnumerable<BenefitPlanAncillsVM>> GetBenefitPlanAncills();
        public Task<string> UpdateBenefitPlanAncills(BenefitPlanAncillsVM benefitPlanAncills);
        public Task<string> SaveBenefitPlanAncills(BenefitPlanAncillsVM benefitPlanAncills);
    }
}
