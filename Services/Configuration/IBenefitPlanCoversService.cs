using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBenefitPlanCoversService
    {
        public Task<IEnumerable<BenefitPlanCoversVM>> GetBenefitPlanCovers();
        public Task<string> UpdateBenefitPlanCovers(BenefitPlanCoversVM benefitPlanCovers);
        public Task<string> SaveBenefitPlanCovers(BenefitPlanCoversVM benefitPlanCovers);
    }
}
