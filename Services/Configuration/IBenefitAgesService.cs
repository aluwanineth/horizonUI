using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBenefitAgesService
    {
        public Task<IEnumerable<BenefitAgesVM>> GetBenefitAges();
        public Task<string> UpdateBenefitAges(BenefitAgesVM benefitAges);
        public Task<string> SaveBenefitAges(BenefitAgesVM benefitAges);
    }
}
