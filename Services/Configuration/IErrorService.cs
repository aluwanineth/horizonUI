using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IErrorService
    {
        public Task<IEnumerable<ErrorVM>> GetErrors();
        public Task<string> UpdateError(ErrorVM error);
        public Task<string> SaveError(ErrorVM error);
    }
}
