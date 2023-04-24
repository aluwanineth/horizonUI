using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class TransCategoryService: IGeneric<TransactionCategoriesVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public TransCategoryService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<TransactionCategoriesVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<TransactionCategoriesVM>>(BaseURIConfig + "TransCategory/TransactionCategory");
            return result;
        }


        public async Task<string> Update(TransactionCategoriesVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "TransCategory/UpdateTransactionCategory", model);
            return result.ToString();
        }
    }
}
