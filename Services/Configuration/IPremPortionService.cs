using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IPremPortionService
    {
        public Task<IEnumerable<PremPortionVM>> GetPremPortion();
        public Task<string> UpdatePremPortion(PremPortionVM premPortion);
        public Task<string> SavePremPortion(PremPortionVM premPortion);
    }
}
