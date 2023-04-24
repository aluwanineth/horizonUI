using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBenefitOptionService
    {
        public Task<IEnumerable<BenefitOptionVM>> GetBenefitOptions();
        public Task<string> UpdateBenefitOption(BenefitOptionVM benefitoption);
        public Task<string> SaveBenefitOption(BenefitOptionVM benefitoption);
    }
}
