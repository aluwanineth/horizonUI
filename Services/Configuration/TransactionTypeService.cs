using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class TransactionTypeService : ITransTypeService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public TransactionTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<TransTypeVM>> GetTransType()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<TransTypeVM>>(BaseURIConfig + "TransactionType/TransactionType");
            return result;
        }

        public async Task<string> SaveTransType(TransTypeVM transactionType)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "processcontrollogs/saveprocesscontrollogs", transactionType);
            return result.ToString();
        }

        public async Task<string> UpdateTransType(TransTypeVM transactionType)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "TransactionType/UpdateTransactionType", transactionType);
            return result.ToString();
        }
    }
}
