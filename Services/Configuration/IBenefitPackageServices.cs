using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBenefitPackageServices
    {
        public Task<IEnumerable<BenefitPackageVM>> GetBenefitPackages();
        public Task<string> UpdateBenefitPackage(BenefitPackageVM benefitPackage);
        public Task<string> SaveBenefitPackage(BenefitPackageVM benefitPackage);
    }
}
