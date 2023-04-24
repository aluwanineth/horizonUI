using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBenefitPackagesService
    {
        public Task<IEnumerable<BenefitPackagesVM>> GetBenefitPackages();
        public Task<string> UpdateBenefitPackages(BenefitPackagesVM benefitPackages);
        public Task<string> SaveBenefitPackages(BenefitPackagesVM benefitPackages);
    }
}
