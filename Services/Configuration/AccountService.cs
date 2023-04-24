using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class AccountService : IAccountService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public AccountService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<AccountVM>> GetAccounts()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<AccountVM>>(BaseURIConfig + "account/accounts");
            return result;
        }

        public async Task<string> SaveAccount(AccountVM account)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "account/saveaccount", account);
            return result.ToString();
        }

        public async Task<string> UpdateAccount(AccountVM account)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "account/updateaccount", account);
            return result.ToString();
        }
    }
}
