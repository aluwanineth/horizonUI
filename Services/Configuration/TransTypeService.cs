using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class TransTypeService: ITransTypeService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public TransTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<TransTypeVM>> GetTransType()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<TransTypeVM>>(BaseURIConfig + "transtype/transtype");
            return result;
        }

        public async Task<string> SaveTransType(TransTypeVM transType)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "transType/saveTransType", transType);
            return result.ToString();
        }

        public async Task<string> UpdateTransType(TransTypeVM transType)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "transType/updateTransType", transType);
            return result.ToString();
        }

      
    }
}
