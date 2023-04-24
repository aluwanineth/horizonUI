using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IAccountService
    {
        public Task<IEnumerable<AccountVM>> GetAccounts();
        public Task<string> UpdateAccount(AccountVM account);
        public Task<string> SaveAccount(AccountVM account);
    }
}
