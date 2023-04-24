using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBenefitOptionsService
    {
        public Task<IEnumerable<BenefitOptionsVM>> GetBenefitOptions();
        public Task<string> UpdateBenefitOptions(BenefitOptionsVM benefitOptions);
        public Task<string> SaveBenefitOptions(BenefitOptionsVM benefitOptions);
    }
}
