using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBenefitPlanIncrsService
    {
        public Task<IEnumerable<BenefitPlanIncrsVM>> GetBenefitPlanIncrs();
        public Task<string> UpdateBenefitPlanIncrs(BenefitPlanIncrsVM benefitPlanIncrs);
        public Task<string> SaveBenefitPlanIncrs(BenefitPlanIncrsVM benefitPlanIncrs);
    }
}
