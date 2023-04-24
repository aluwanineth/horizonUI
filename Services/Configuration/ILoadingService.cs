using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface ILoadingService
    {
        public Task<IEnumerable<LoadingVM>> GetLoadings();
        public Task<string> UpdateLoading(LoadingVM loading);
        public Task<string> SaveLoading(LoadingVM loading);
    }
}
