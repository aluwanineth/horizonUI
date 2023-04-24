using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBenefitTypeService
    {
        public Task<IEnumerable<BenefitTypeVM>> GetBenefitTypes();
        public Task<string> UpdateBenefitType(BenefitTypeVM benefittype);
        public Task<string> SaveBenefitType(BenefitTypeVM benefittype);
    }
}
