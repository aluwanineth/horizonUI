using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IAncilTypeService
    {
        public Task<IEnumerable<AncilTypeVM>> GetAncilTypes();
        public Task<string> UpdateAnciltype(AncilTypeVM anciltypes);
        public Task<string> SaveAnciltype(AncilTypeVM anciltypes);
    }
}
