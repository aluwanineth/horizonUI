using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface ISchemePlanFactorsService
    {
        public Task<IEnumerable<SchemePlanFactorsVM>> GetSchemePlanFactors();
        public Task<string> UpdateSchemePlanFactors(SchemePlanFactorsVM schemePlanFactors);
        public Task<string> SaveSchemePlanFactors(SchemePlanFactorsVM schemePlanFactors);
    }
}
