using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface ILoadingTypeService
    {
        public Task<IEnumerable<LoadingTypeVM>> GetLoadingTypes();
        public Task<string> UpdateLoadingType(LoadingTypeVM loadingtype);
        public Task<string> SaveLoadingType(LoadingTypeVM loadingtype);
    }
}
