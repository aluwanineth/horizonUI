using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IAnnIncFactorService
    {
        public Task<IEnumerable<AnnIncFactorsVM>> GetAnIncFactors();
        public Task<string> UpdateAnIncFactors(AnnIncFactorsVM anincfactors);
        public Task<string> SaveAnIncFactors(AnnIncFactorsVM anincfactors);
    }
}
