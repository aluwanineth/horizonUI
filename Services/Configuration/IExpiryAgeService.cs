using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IExpiryAgeService
    {
        public Task<IEnumerable<ExpiryAgeVM>> GetExpiryAges();
        public Task<string> UpdateExpiryAge(ExpiryAgeVM expiryage);
        public Task<string> SaveExpiryAge(ExpiryAgeVM expiryage);
    }
}
