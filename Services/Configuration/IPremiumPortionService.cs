using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IPremiumPortionService
    {
        public Task<IEnumerable<PremiumPortionTypeVM>> GetPremiumPortions();
        public Task<string> UpdatePremiumPortion(PremiumPortionTypeVM premiumportion);
        public Task<string> SavePremiumPortion(PremiumPortionTypeVM premiumportion);
    }
}
